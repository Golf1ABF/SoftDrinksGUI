using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoftDrinksGUI
{

    public partial class MainWindow : Window
    {
        List<Drinks> lista = new List<Drinks>();
        public MainWindow()
        {
            InitializeComponent();
            var rnd = new Random();
            var sr = new StreamReader("../../../source/softDrinks.txt", System.Text.Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream) 
            { 
                lista.Add(new Drinks(sr.ReadLine()));
            }
            sr.Close();
            //4. Feladat
            maiAjanlat.Content = $"Ajánlatunk:{lista[rnd.Next(lista.Count)].Nev}";

            //5. Feladat
            var legolcsobbUdito = lista.MinBy(x => x.Ar);
            legolcsobb.Content = $"{legolcsobbUdito.Nev} - {legolcsobbUdito.Ar} Ft";

            //6. Feladat
            hanyGyarto.Content = $"{lista.GroupBy(x => x.Nev.Split(" ")[0]).Count()} féle gyártó termékei közül választhatnak!";

            //7. Feladat
            var sw = new StreamWriter("../../../source/all.txt", false);
            var uditoNevek = lista.GroupBy(x => x.Nev);
            foreach (var item in uditoNevek)
            {
                sw.WriteLine($"{item.Key} {Math.Round(item.Average(x => x.GyumolcsTartalom), 2)}");
            }
            sw.Close();

            //8. Feladat
            sw = new StreamWriter("../../../source/sweetening.txt", false);
            var edesitoSzerint = lista.GroupBy(x => x.EdesitoAnyag);
            foreach (var item in edesitoSzerint)
            {
                sw.WriteLine($"{item.Key}-{item.Count()} db");
            }
            sw.Close();

            
        }

        private void arajanlatBtn_Click(object sender, RoutedEventArgs e)
        {
            var sw = new StreamWriter("../../../source/offer.txt", false);
            var felhasznaloAltalValasztott = lista.Where(x => x.Nev.Split(" ")[0] == gyartoKereses.Text);
            foreach (var item in felhasznaloAltalValasztott)
            {
                sw.WriteLine(item.Nev);
            }
            sw.Close();

            if (felhasznaloAltalValasztott != null)
            {
                MessageBox.Show($"{felhasznaloAltalValasztott.Count()} db üdítő van ettől a gyártótól, átlagáruk: {felhasznaloAltalValasztott.Average(x => x.Ar)}");
            } else 
            {
                MessageBox.Show("Nincs ilyen üdítőnk. Kérjük válasszon mást!");
            }
        }
    }
}