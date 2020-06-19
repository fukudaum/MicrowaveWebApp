using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MicrowaveWebApp.Data
{
    public class MicrowaveWebAppContext : DbContext
    {

        public MicrowaveWebAppContext() : base("name=MicrowaveWebAppContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }


        public System.Data.Entity.DbSet<MicrowaveWebApp.Models.ProgramType> ProgramTypes { get; set; }
    }
}
