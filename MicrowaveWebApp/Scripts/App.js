var ViewModel = function () {
    var self = this;
    self.programTypes = ko.observableArray();
    self.error = ko.observable();

    var programTypesUri = '/api/programTypes/';

    function ajaxHelper(uri, method, data) {
        self.error(''); 
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllProgramTypes() {
        ajaxHelper(programTypesUri, 'GET').done(function (data) {
            self.programTypes(data);
        });
    }

    self.detail = ko.observable();

    self.getProgramTypeDetail = function (item) {
        ajaxHelper(programTypesUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }
    
    self.newProgramType = {
        Name: ko.observable(),
        Instructions: ko.observable(),
        Duration: ko.observable(),
        Potency: ko.observable(),
        HeatChar: ko.observable()
    }

    self.addProgramType = function (formElement) {
        var programType = {
            Name: self.newProgramType.Name(),
            Instructions: self.newProgramType.Instructions(),
            Duration: self.newProgramType.Duration(),
            Potency: self.newProgramType.Potency(),
            HeatChar: self.newProgramType.HeatChar()
        };

        ajaxHelper(programTypesUri, 'POST', programType).done(function (item) {
            self.programTypes.push(item);
        });
    }

    function verifyProgram(info) {
        var array = self.programTypes();
        var index = array.map(function (e) {
            return e.Name.toLowerCase();
        }).indexOf(info.duration);

        if (index < 0) {
            throw "Alimento incompatível com o programa!";
        }
        info.potency = array[index].Potency;
        info.duration = array[index].Duration;
        info.heatChar = array[index].HeatChar;

    }

    function isNumber(val) {
        return typeof val === "number"
    }

    function verifyDuration(info) {
        if (!info.duration) {
            throw "A duração deve ser informada!";           
        }

        if (!isNumber(info.duration)) {            
            verifyProgram(info);
        }
        
        if (info.duration <= 0 || info.duration > 120) {
            throw "Os valores de duração deve estar entre 1 a 120 segundos!";
        } else  {            
            info.duration *= 1000;
            return;
        } 

        
    }

    function verifyPotency(info) {
        if (!info.potency) {
            info.potency = 10;
        }
        if (info.potency < 0 || info.potency > 10) {
            throw "Os valores de potencia deve estar entre 1 a 10";
        }
    }

    function heatCharByPotency(info) {
        var charHeat = info.heatChar;
        for (var i = 1; i < info.potency; i++) {
            info.heatChar += charHeat;
        }
    }

    function heating(info) {

        document.getElementById("inputCommand").value = "Aquecendo: ";
        heatCharByPotency(info);
        var inputCaracter = setInterval(() => {
            document.getElementById("inputCommand").value += info.heatChar;            
        }, 1000);

        setTimeout(() => {
            clearInterval(inputCaracter);
            document.getElementById("inputCommand").value = "Aquecida";
        }, info.duration);

        
    }
    
    self.executeCommand = function () {
        var info = { duration: "", potency: "10", heatChar: "." };
        var command = document.getElementById("inputCommand").value;
        var commandInput = command.split(";", 2);
        
        info.duration = commandInput[0];
        info.potency = commandInput[1]
        
        verifyDuration(info);           
        verifyPotency(info);
        heating(info);
    }

    self.fastHeating = function () {
        var info = { duration: 30000, potency: 8, heatChar: "." };

        heating(info);
    }

    getAllProgramTypes();
};

ko.applyBindings(new ViewModel());