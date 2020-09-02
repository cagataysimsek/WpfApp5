using Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for CurrencyDefination.xaml
    /// </summary>
    public partial class CurrencyDefination : Window
    {
        StockAutomationDBContext context = new StockAutomationDBContext();
        public CurrencyDefination()
        {
            InitializeComponent();
        }

        private void buttonEkle_Click(object sender, RoutedEventArgs e)
        {
            var item = context.Definations.Where(x => x.DefValue == comboCurrency.Text && x.DefType == (int)Definition.Currency).SingleOrDefault();
            if (item == null)
            {
                if (string.IsNullOrEmpty(comboCurrency.Text))
                {
                    MessageBox.Show("Para Birimi Boş Bırakılamaz!");
                }
                else
                {
                    Defination newItem = new Defination();
                    newItem.DefType = (int)Definition.Currency;
                    newItem.DefValue = comboCurrency.Text;
                    context.Definations.Add(newItem);
                    context.SaveChanges();
                    MessageBox.Show("Ekleme İşlemi Başarılı");
                    comboShow();
                }
            }
            else
            {
                MessageBox.Show(comboCurrency.Text + " Kayıdı Zaten Var!");
                comboCurrency.Text = "";
            }

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboShow();

        }

        private void comboShow()
        {
            
            comboCurrency.Text = "";
            comboCurrency.ItemsSource = context.Definations.Where(x => x.DefType == 1).ToList();
            comboCurrency.DisplayMemberPath = "DefValue";
            comboCurrency.SelectedValuePath = "Id";
        }

        private void buttonSil_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(comboCurrency.Text))
            {
                var item = context.Definations.Where(x => x.DefValue == comboCurrency.Text && x.DefType == (int)Definition.Currency).FirstOrDefault();
                if (item != null)
                {
                    context.Definations.Remove(item);
                    context.SaveChanges();
                    string name = comboCurrency.Text;
                    comboShow();
                    MessageBox.Show(name + " Para Birimini Silme İşlemi Başarılı.");
                }
                else
                {
                    MessageBox.Show(comboCurrency.Text + " Adında Para Birimi Bulunmamakta!");
                    comboCurrency.Text = "";
                }
            }
        }

        private void buttonGuncelle_Click(object sender, RoutedEventArgs e)
        {
            var item = context.Definations.Where(x => x.DefValue == comboCurrency.Text && x.DefType == (int)Definition.Currency).FirstOrDefault();
            if (!string.IsNullOrEmpty(comboCurrency.Text))
            {
                if (item != null)
                {
                    CurrencyUpdate currency = new CurrencyUpdate();
                    currency.comboNewCurrencyName.ItemsSource = comboCurrency.ItemsSource;
                    currency.comboNewCurrencyName.DisplayMemberPath = comboCurrency.DisplayMemberPath;
                    currency.lblName.Content = item.DefValue;
                    this.Close();
                    currency.ShowDialog();
                }
                else
                {
                    MessageBox.Show(comboCurrency.Text + " Adında Para Birimi Bulunmamakta!");
                    comboCurrency.Text = "";
                }
            }
        }
    }
}
