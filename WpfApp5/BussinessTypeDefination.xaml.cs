using Microsoft.IdentityModel.Tokens;
using Models;
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
    /// Interaction logic for BussinessTypeDefination.xaml
    /// </summary>
    public partial class BussinessTypeDefination : Window
    {
        StockAutomationDBContext context = new StockAutomationDBContext();
        public BussinessTypeDefination()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboShow();
        }

        private void comboShow()
        {
            comboBusinessType.Text = "";
            comboBusinessType.ItemsSource = context.Definations.Where(x => x.DefType == 3).ToList();
            comboBusinessType.DisplayMemberPath = "DefValue";
            comboBusinessType.SelectedValuePath = "Id";
        }

        private void buttonEkle_Click(object sender, RoutedEventArgs e)
        {
            var item = context.Definations.Where(x => x.DefValue == comboBusinessType.Text).FirstOrDefault();
            if (item == null)
            {
                if (!string.IsNullOrEmpty(comboBusinessType.Text))
                {
                    var newItem = new Defination();
                    newItem.DefType = 3;
                    newItem.DefValue = comboBusinessType.Text;
                    context.Definations.Add(newItem);
                    context.SaveChanges();
                    MessageBox.Show(comboBusinessType.Text + "Bussiness Type Başarıyla Eklendi.");
                    comboShow();
                }
                else
                {
                    MessageBox.Show("Boş Kayıt Eklenemez!");
                }
            }
            else
            {
                MessageBox.Show(comboBusinessType.Text + " Kayıdı Zaten Var");
            }
        }

        private void buttonSil_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBusinessType.Text))
            {
                var item = context.Definations.Where(x => x.Id == Convert.ToInt32(comboBusinessType.SelectedValue)).FirstOrDefault();
                context.Definations.Remove(item);
                context.SaveChanges();
                string name = comboBusinessType.Text;
                comboShow();
                MessageBox.Show(name + "Business Type Silme işlemi Başarılı.");
            }
        }

        private void buttonGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (comboBusinessType.SelectedValue!=null)
            {
                BussinessTypeUpdate btu = new BussinessTypeUpdate();
                this.Close();
                btu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Güncelleme Yapmadan Önce Güncellemek İstediğiniz Para Birimini Seçmelisiniz.");
            }
        }
    }
}
