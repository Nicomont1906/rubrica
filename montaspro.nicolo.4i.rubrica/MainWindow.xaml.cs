using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace montaspro.nicolo._4i.rubrica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    { 
        List<Persona> Persone = new List<Persona>();
        List<Contatto> Contatti = new List<Contatto>();
        public MainWindow()
        {
            InitializeComponent();
        } 
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

                statusbar.Text = $"Ho letto dal file {Persone.Count} persone";
                fin.Close();

                StreamReader fine = new StreamReader("contatti.csv");
                fine.ReadLine();
                while (!fine.EndOfStream)
                {
                    string rigaC = fine.ReadLine();
                    Contatto contatto = new Contatto(rigaC);
                    Contatti.Add(contatto);
                }
               // dgContatti.ItemsSource = Contatti;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }
        private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persona p = e.AddedItems[0] as Persona;
            if (p != null)
            {
                statusbar.Text = $" Hai selezionato {p.nome} {p.cognome}";

                List<Contatto> contattiFiltrati = new List<Contatto>();
                foreach (var item in Contatti)
                    if (item.IdPersona == p.IdPersona)
                        contattiFiltrati.Add(item);

                dgContatti.ItemsSource = contattiFiltrati;
            }

        }

        private void dgContatti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
