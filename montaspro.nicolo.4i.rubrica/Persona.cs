using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace montaspro.nicolo._4i.rubrica
{
    class Persona
    {
        public int IdPersona { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }

        public Persona(){}

        public Persona(string riga) 
        {
            string[] campi = riga.Split(';');

            int Id = 0;
            int.TryParse(campi[0], out Id);
            IdPersona = Id;

            this.nome = campi[1];
            this.cognome = campi[2];
        }
    }
}
