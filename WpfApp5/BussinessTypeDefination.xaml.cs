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
            var item = context.Definations.Where(x => x.DefValue == comboBusinessType.Text && x.DefType == (int)Definition.BussinessType).SingleOrDefault();
            if (item == null)
            {
                if (string.IsNullOrEmpty(comboBusinessType.Text))
                {
                    MessageBox.Show("Para Birimi Boş Bırakılamaz!");
                }
                else
                {
                    Defination newItem = new Defination();
                    newItem.DefType = (int)Definition.BussinessType;
                    newItem.DefValue = comboBusinessType.Text;
                    context.Definations.Add(newItem);
                    context.SaveChanges();
                    MessageBox.Show("Ekleme İşlemi Başarılı");
                    comboShow();
                }
            }
            else
            {
                MessageBox.Show(comboBusinessType.Text + " Kayıdı Zaten Var!");
                comboBusinessType.Text = "";
            }
        }

        private void buttonSil_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBusinessType.Text))
            {
                var item = context.Definations.Where(x => x.DefValue == comboBusinessType.Text && x.DefType == (int)Definition.BussinessType).FirstOrDefault();
                if (item != null)
                {
                    context.Definations.Remove(item);
                    context.SaveChanges();
                    string name = comboBusinessType.Text;
                    comboShow();
                    MessageBox.Show(name + " Bussiness Type'ı Başarıyla Silindi.");
                }
                else
                {
                    MessageBox.Show(comboBusinessType.Text + " Adında Bir Bussiness Type Bulunmamakta!");
                    comboBusinessType.Text = "";
                }

            }
        }

        private void buttonGuncelle_Click(object sender, RoutedEventArgs e)
        {
            var item = context.Definations.Where(x => x.DefValue == comboBusinessType.Text && x.DefType == (int)Definition.BussinessType).FirstOrDefault();
            if (!string.IsNullOrEmpty(comboBusinessType.Text))
            {
                if (item != null)
                {
                    BussinessTypeUpdate bussiness = new BussinessTypeUpdate();
                    bussiness.comboNewBussinessTypeName.ItemsSource = comboBusinessType.ItemsSource;
                    bussiness.comboNewBussinessTypeName.DisplayMemberPath = "DefValue";
                    bussiness.lblName.Content = item.DefValue;
                    this.Close();
                    bussiness.ShowDialog();
                }
                else
                {
                    MessageBox.Show(comboBusinessType.Text + " Adında Bir Bussiness Type Bulunmamakta!");
                    comboBusinessType.Text = "";
                }
            }
            
        }
    }
}
