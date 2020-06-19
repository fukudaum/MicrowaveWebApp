using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MicrowaveWebApp.Models
{
    public class ProgramType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Instructions { get; set; }
        public int Duration { get; set; }
        public int Potency { get; set; }
        public string HeatChar { get; set; }

    }
}