using Models;
using Models.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for DealerDefination.xaml
    /// </summary>
    public partial class DealerDefination : Window
    {
        StockAutomationDBContext context = new StockAutomationDBContext();
        public DealerDefination()
        {
            InitializeComponent();
        }
        private void buttonEkle_Click(object sender, RoutedEventArgs e)
        {
            var item = context.Dealers.Where(x => x.DealerName == comboDealerName.Text).SingleOrDefault();
            if (item == null)
            {
                if (string.IsNullOrEmpty(comboDealerName.Text))
                {
                    MessageBox.Show("Para Birimi Boş Bırakılamaz!");
                }
                else
                {
                    Dealer newItem = new Dealer();
                    newItem.DealerName = comboDealerName.Text;
                    context.Dealers.Add(newItem);
                    context.SaveChanges();
                    MessageBox.Show("Ekleme İşlemi Başarılı");
                    comboShow();
                }
            }
            else
            {
                MessageBox.Show(comboDealerName.Text + " Kayıdı Zaten Var!");
                comboDealerName.Text = "";
            }
        }

        private void comboShow()
        {
            comboDealerName.Text = "";
            comboDealerName.ItemsSource = context.Dealers.ToList();
            comboDealerName.DisplayMemberPath = "DealerName";
            comboDealerName.SelectedValuePath = "Id";
        }

        private void buttonSil_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(comboDealerName.Text))
            {
                var item = context.Dealers.Where(x => x.DealerName == comboDealerName.Text).FirstOrDefault();
                if (item != null)
                {
                    context.Dealers.Remove(item);
                    context.SaveChanges();
                    string name = comboDealerName.Text;
                    comboShow();
                    MessageBox.Show(name + " Dağıtısı Başarıyla Silinidi.");
                }
                {
                    MessageBox.Show(comboDealerName.Text + " Adında Bir Dağıtıcı Bulunmamakta!");
                    comboDealerName.Text = "";
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboShow();
        }

        private void buttonGüncelle_Click(object sender, RoutedEventArgs e)
        {
            var item = context.Dealers.Where(x => x.DealerName == comboDealerName.Text).FirstOrDefault();
            if (!string.IsNullOrEmpty(comboDealerName.Text))
            {
                if (item != null)
                {
                    DealerUpdate dealer = new DealerUpdate();
                    dealer.lblDealer.Content = item.DealerName;
                    this.Close();
                    dealer.ShowDialog();
                }
                else
                {
                    MessageBox.Show(comboDealerName.Text + " Adında Bir Dağıtıcı Bulunmamakta!");
                    comboDealerName.Text = "";
                }
            }
        }
    } 
}
