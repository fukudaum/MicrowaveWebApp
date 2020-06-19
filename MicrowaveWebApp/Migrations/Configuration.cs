namespace MicrowaveWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MicrowaveWebApp.Data;
    using MicrowaveWebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MicrowaveWebApp.Data.MicrowaveWebAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MicrowaveWebApp.Data.MicrowaveWebAppContext context)
        {


            context.ProgramTypes.AddOrUpdate(x => x.Id,
                new ProgramType() { 
                    Id = 1, 
                    Name = "Frango", 
                    Instructions = "Para descongelar o frango", 
                    Duration = 100,
                    Potency = 8, 
                    HeatChar = "F"
                },
                new ProgramType() { 
                    Id = 2, 
                    Name = "Boi",
                    Instructions = "Para descongelar a carne bovina", 
                    Duration = 120, 
                    Potency = 10, 
                    HeatChar = "B"
                },
                new ProgramType() { 
                    Id = 3, 
                    Name = "Peixe",
                    Instructions = "Para descongelar o peixe",
                    Duration = 90,
                    Potency = 6, 
                    HeatChar = "P"
                },
                new ProgramType() { 
                    Id = 4, 
                    Name = "Suino", 
                    Instructions = "Para descongelar a carne suína",
                    Duration = 110,
                    Potency = 7, 
                    HeatChar = "S"
                },
                new ProgramType() {
                    Id = 5, 
                    Name = "Carneiro",
                    Instructions = "Para descongelar o carneiro",
                    Duration = 115, 
                    Potency = 9,
                    HeatChar = "C"
                }
            );

        }
    }
}
