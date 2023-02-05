using System;
using System.Collections.Generic;
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

namespace SzinkeveroV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SzinKeveres()
        {
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliPiros.Value), Convert.ToByte(sliZold.Value), Convert.ToByte(sliKek.Value)));
            labRed.Content = Convert.ToByte(sliPiros.Value);
            labGreen.Content = Convert.ToByte(sliZold.Value);
            labBlue.Content = Convert.ToByte(sliKek.Value);
        }

        private void sliPiros_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinKeveres();
        }

        private void sliZold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinKeveres();
        }

        private void sliKek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinKeveres();
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.Items.Contains($"{Convert.ToByte(sliPiros.Value)}; {Convert.ToByte(sliZold.Value)}; {Convert.ToByte(sliKek.Value)}"))
            {
                MessageBox.Show("Ilyen elem már létezik!");
            }
            else
            {
                lbSzinek.Items.Add($"{Convert.ToByte(sliPiros.Value)}; {Convert.ToByte(sliZold.Value)}; {Convert.ToByte(sliKek.Value)}");
            }
        }

        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.SelectedIndex < 0)
            {
                MessageBox.Show("Válassz ki egy törlendő elemet!");
            }
            else
            {
                lbSzinek.Items.RemoveAt(lbSzinek.SelectedIndex);
            }
        }

        private void btnUrit_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.Items.Count == 0)
            {
                MessageBox.Show("Nincsenek elemek!");
            }
            lbSzinek.Items.Clear();
        }

        private void lbSzinek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] szinek = lbSzinek.SelectedItem.ToString().Split(";");
            sliPiros.Value = Convert.ToDouble(szinek[0]);
            sliZold.Value = Convert.ToDouble(szinek[1]);
            sliKek.Value = Convert.ToDouble(szinek[2]);
        }
    }
}
