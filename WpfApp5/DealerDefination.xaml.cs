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
            context.SaveChanges();
            var item = context.Dealers.Where(x => x.DealerName == comboDealerName.Text).FirstOrDefault();
            if (item == null)
            {
                if (!string.IsNullOrEmpty(comboDealerName.Text))
                {
                    var newItem = new Dealer();
                    newItem.DealerName = comboDealerName.Text;
                    context.Dealers.Add(newItem);
                    context.SaveChanges();
                    MessageBox.Show(comboDealerName.Text + " İstasyonu Baraşarıyla Eklendi.");
                    comboShow();
                }
                else
                {
                    MessageBox.Show("İstasyon İsmi Boş Bırakılamaz!");
                }
            }
            else
            {
                MessageBox.Show(comboDealerName.Text + " İstasyonu Zaten Kayıtlı!");
                comboShow();
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
                var item = context.Dealers.Where(x => x.Id == Convert.ToInt32(comboDealerName.SelectedValue)).FirstOrDefault();
                context.Dealers.Remove(item);
                context.SaveChanges();
                string name = comboDealerName.Text;
                comboShow();
                MessageBox.Show(name + " Dağıtıcısını Silme İşlemi Başarılı.");
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboShow();
        }

        private void buttonGüncelle_Click(object sender, RoutedEventArgs e)
        {
            if (comboDealerName.SelectedValue!= null)
            {
                DealerUpdate dealerUpdate = new DealerUpdate();
                dealerUpdate.comboDealerName1.ItemsSource = comboDealerName.ItemsSource;
                dealerUpdate.comboDealerName1.DisplayMemberPath = comboDealerName.DisplayMemberPath;
                dealerUpdate.comboDealerName1.SelectedValuePath = comboDealerName.SelectedValuePath;
                dealerUpdate.comboDealerName1.SelectedValue = comboDealerName.SelectedValue;
                this.Close();
                dealerUpdate.ShowDialog();
            }
            else
            {
                MessageBox.Show("Güncelleme Yapmadan Önce Güncellemek İstediğiniz Dağıtıcıyı Seçmelisiniz.");
            }
        }
    }
}
