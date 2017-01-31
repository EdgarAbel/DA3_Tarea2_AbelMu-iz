using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaJson.Models
{
    public class Especificaciones
    {
        public int id { get; set; }
        public string modelo { get; set; }
        public string costo { get; set; }
        public string ram{get;set;}
        public string procesador { get; set; }
        public string HDD { get; set; }
        public string dimensiones { get; set; }
    }
}