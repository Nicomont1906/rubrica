# rubrica

Realizzare un programma che visualizza due griglie; una con un elenco di persone, la'ltra con un elenco di contatti

- prevedere due classi: "Persona" e "Contatto"
- prevedere due file: "persone.csv" e "contatti.csv
- prevedere due griglie che visualizzano il contenuto dei due file


La classe persona è costituita da tre attributi (IdPersona,nome,cognomre) e un costruttore che viene utilizzato per creare un un'istanza della classe fornendo una stringa contenente i dati della persona separati da un punto e virgola, presumibilmente nell'ordine ID, nome e cognome
```
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
```
