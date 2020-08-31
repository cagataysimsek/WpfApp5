using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for CurrencyUpdate.xaml
    /// </summary>
    public partial class CurrencyUpdate : Window
    {
        StockAutomationDBContext context = new StockAutomationDBContext();
        public CurrencyUpdate()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void buttonGüncellemeİsleminiTamamla_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewCurrencyName.Text))
            {
                var item = (from x in context.Definations where x.DefValue == lblName.Content.ToString() && x.DefType==(int)Definition.Currency  select x).FirstOrDefault();
                item.DefValue = txtNewCurrencyName.Text;
                context.SaveChanges();
                MessageBox.Show(lblName.Content + " Para Biriminin Adı " + txtNewCurrencyName.Text + " Olarak Değiştirildi.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!");
            }
        }
    }
}
