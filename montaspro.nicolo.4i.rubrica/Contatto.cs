using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace montaspro.nicolo._4i.rubrica
{
    public enum TipoContatto { nessuno, Email, Telefono, Web, Instagram, Facebook, Cellulare }
   public class Contatto
    {
        public int IdPersona { get; set; }
        public TipoContatto Tipo { get; set; }
        public string Val { get; set; }

        public Contatto()
        {
            Tipo = TipoContatto.nessuno;
        }
        public Contatto(string riga)
        {
            string[] campi = riga.Split(';');
           

        

            int Id = 0;
            int.TryParse(campi[0], out Id);
            IdPersona = Id;

            TipoContatto c;
            Enum.TryParse(campi[1], out c);
            this.Tipo = c;

            this.Val = campi[2];
        }

        public static Contatto MakeContatto(string riga)
        {
            string[] campi = riga.Split(';');


            TipoContatto c;
            Enum.TryParse(campi[1], out c);
            
            switch(c)
            {
                case TipoContatto.Email:
                    return new ContattoEmail(riga);
                    break;
            }
            return new Contatto(riga);
        }
    }

    public class ContattoEmail: Contatto
    {
        public ContattoEmail() { }

        public ContattoEmail(string riga)
            : base(riga)
        {

        }
    }

    public class ContattoTelefono : Contatto {
        
        public ContattoTelefono() { }

        public ContattoTelefono (string riga)
            : base(riga)
        {

        }
    
    }

    public class ContattoWeb : Contatto
    {
        public ContattoWeb() { }

        public ContattoWeb (string riga)
            : base(riga)
        { 
            
        }
    }

    public class ContattoInstagram : Contatto
    {
        public ContattoInstagram() { }

        public ContattoInstagram(string riga)
            : base(riga)
        {

        }
    }

    public class ContattoFacebook : Contatto { 
            
        public ContattoFacebook() { }

        public ContattoFacebook(string riga)
            : base(riga)
        {

        }
    
    }

    public class ContattoCellulare : Contatto
    {
        public ContattoCellulare() { }

        public ContattoCellulare(string riga)
            : base(riga)
        {

        }
    }



    public class Contatti : List<Contatto>
    {
        public Contatti() { }

        public Contatti(string nomeFile)
        {

            StreamReader fine = new StreamReader(nomeFile);
            fine.ReadLine();
            while (!fine.EndOfStream)

               Add( Contatto.MakeContatto(fine.ReadLine()));

            fine.Close();


        }
    }
}
