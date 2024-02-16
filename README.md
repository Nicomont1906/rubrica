# rubrica

Realizzare un programma che visualizza due griglie; una con un elenco di persone, la'ltra con un elenco di contatti

- prevedere due classi: "Persona" e "Contatto"
- prevedere due file: "persone.csv" e "contatti.csv
- prevedere due griglie che visualizzano il contenuto dei due file
- prevedere la funzionalità che, selezionando una Persona nel datagrid "Persone", il sistema visualizza tutti i suoi contatti.
- abbia una classe Persone che deriva da List<Persona>
- abbia una classe Contatti che deriva da List<Contatto>
- utilizzi la classe Contatto come base
- abbia una serie di classi derivate ContattoEmail, ContattoWeb etc etc
- utilizzi i costruttori di Persone e Contatti per leggere i rispettivi file



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
Anche la classe Contatto è caraterrizata da tre attributi (IdPersona,Tipo,Val). Dentro questa classe abbiamo due costruttori: Il primo viene richiamato quando viene creato un nuovo oggetto 'Contatto' che viene impostato su "nessuno" come valore predefinito.

```
 public Contatto()
        {
            Tipo = TipoContatto.nessuno;
        }
```
il secondo costruttore riceve come parametro una stringa "riga" come parametro e inizializza gli attributi dell'oggetto Contatto basandosi sui dati contenuti nella stringa.

```
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
```

All'interno dello xaml.cs abbiamo creato due liste di oggetti "Persone" e "Contatti" che memorizzano  informazioni sulle persone e sui loro contatti.

IL metodo Windo_Loaded che viene chiamato quando la finestra è stata caricata e si occupa di leggere i dati dai file CSV corrispondenti ("persone.csv" e "contatti.csv"), creando oggetti Persona e Contatto e popolando gli elenchi Persone e Contatti.

```
  private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader fin = new StreamReader("persone.csv");
                fin.ReadLine();
                while (!fin.EndOfStream)
                {
                    string rigaP = fin.ReadLine();
                    Persona persona = new Persona(rigaP);
                    Persone.Add(persona);
                }
                dgPersone.ItemsSource = Persone;

                statusbar.Text = $"Ho letto dal file {Persone.Count} righe";

                StreamReader fine = new StreamReader("contatti.csv");
                fine.ReadLine();
                while (!fine.EndOfStream)
                {
                    string rigaC = fine.ReadLine();
                    Contatto contatto = new Contatto(rigaC);
                    Contatti.Add(contatto);
                }
                dgContatti.ItemsSource = Contatti;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }
```
E infine Il metodo dgDati_SelectionChanged viene chiamato quando la selezione nell'elemento della finestra dgDati cambia. In particolare, si occupa di filtrare i contatti associati alla persona selezionata e di visualizzarli nell'elemento della finestra dgContatti.

```
 private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persona p = e.AddedItems[0] as Persona;
            statusbar.Text = $"{p.cognome}";

            List<Contatto> contattiFiltrati = new List<Contatto>();
            foreach (var item in Contatti)
                if (item.IdPersona == p.IdPersona)
                    contattiFiltrati.Add(item);

            dgContatti.ItemsSource = contattiFiltrati;

        }
```
Dopo aver studiato L'ereditarietà e il Polimorfismo siamo riusciti a creare due classi Persone e Contatti che derivano da List<Persona> e da List<Contatto>
```
 public class Persone : List<Persona>
    {
        public Persone() { }

        public Persone (string nomeFile)
        {
            StreamReader fin = new StreamReader(nomeFile);
            fin.ReadLine();
            while (!fin.EndOfStream)
            
                Add(new Persona(fin.ReadLine()));

            fin.Close();
        }
    }
```
In tutte e due le classi andiamo a creare un construttore vuoto e un costruttore che riceveva come paramentro il nomeFile e grazie allo StramReader legge cosa c'è all'interno del file e una volta arrivato alla fine lo chiude.

Infine siamo andati ad aggiungere altre classi derivate come ContattoWeb, Contatto Telefono....

```
 public class ContattoEmail: Contatto
    {
        public ContattoEmail() { }

        public ContattoEmail(string riga)
            : base(riga)
        {

        }
    }
```
Ogni classe derivata avrà un costruttore vuoto e un costruttore che accetta come parametro una riga.

