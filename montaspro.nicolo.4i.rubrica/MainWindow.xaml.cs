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
        Persone Persone;
        Contatti contatti;
        public MainWindow()
        {
            InitializeComponent();
        } 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
               
                Persone = new ("persone.csv");
                dgPersone.ItemsSource = Persone;

                statusbar.Text = $"Ho letto dal file {Persone.Count} persone";


                contatti = new("contatti.csv");
                statusbar.Text = $"Ho letto dal file" +
                     $"{Persone.Count} persone e " +
                     $"{contatti.Count} contatti";

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

                Contatti contattiFiltrati = new();
                foreach (var item in contatti)
                    if (item.IdPersona == p.IdPersona)
                        contattiFiltrati.Add(item);

                dgContatti.ItemsSource = contattiFiltrati;
            }

        }

        private void AdOgniRiga(object sender , DataGridRowEventArgs e) { 

            Persona p = e.Row.Item as Persona;
            if(p != null)
            {
                if(p.IdPersona == 1)
                {
                    e.Row.Background = Brushes.Red;
                    e.Row.Foreground = Brushes.White;
                }
                
            }
        
        }

        private void dgContatti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
