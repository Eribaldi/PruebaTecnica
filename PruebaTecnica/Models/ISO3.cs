using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PruebaTecnica.Models
{
    public class ISO3
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public static List<ISO3>RetornarListaPaises(string raiz)
        {
            string json = File.ReadAllText($"{raiz}\\Json\\JsonISO3.json");
            List<ISO3> listaPaises = JsonConvert.DeserializeObject<List<ISO3>>(json);
            return listaPaises;
        }
    }
}
