using Microsoft.EntityFrameworkCore.Diagnostics;
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
using System.Xml.Linq;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for SupplierDefination.xaml
    /// </summary>
    public partial class SupplierDefination : Window
    {
        StockAutomationDBContext context = new StockAutomationDBContext();
        public SupplierDefination()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboShow();
        }

        private void comboShow()
        {
            comboSupplierName.ItemsSource = (from x in context.Suppliers select x).ToList();
            comboSupplierName.DisplayMemberPath = "SupplierName";
            comboSupplierName.SelectedValuePath = "Id";
        }

        private void buttonEkle_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(comboSupplierName.Text))
            {
                var item = (from x in context.Suppliers where x.SupplierName == comboSupplierName.Text select x).FirstOrDefault();
                if (item==null)
                {
                    var NewItem = new Supplier();
                    NewItem.SupplierName = comboSupplierName.Text;
                    context.Suppliers.Add(NewItem);
                    context.SaveChanges();
                    string name = comboSupplierName.Text;
                    comboSupplierName.Text = "";
                    MessageBox.Show(name+ " Tedarikçisi Başarıyla Eklendi");
                    comboShow();
                }
                else
                {
                    MessageBox.Show(comboSupplierName.Text+" Tedarikçisi Zaten Var");
                    comboSupplierName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Teradikçi Adı Boş Bırakılamaz");
            }
        }
        private void buttonSil_Click(object sender, RoutedEventArgs e)
        {
            var item = (from x in context.Suppliers where x.SupplierName==comboSupplierName.Text select x).FirstOrDefault();
            if (item!=null)
            {
                context.Suppliers.Remove(item);
                context.SaveChanges();
                string name = comboSupplierName.Text;
                comboSupplierName.Text = "";
                MessageBox.Show(name + " Tedarikçisi Başarıyla Silindi");
                comboShow();
            }
            else
            {
                MessageBox.Show(comboSupplierName.Text + " Adında Bir Tedarikçi Bulunmamakta!");
            }
        }

        private void buttonGuncelle_Click(object sender, RoutedEventArgs e)
        {
            var item = context.Suppliers.Where(x => x.SupplierName == comboSupplierName.Text).FirstOrDefault();
            if (item!=null)
            {
                SupplierUpdate sup = new SupplierUpdate();
                sup.comboSupplierName1.ItemsSource = comboSupplierName.ItemsSource;
                sup.comboSupplierName1.DisplayMemberPath = comboSupplierName.DisplayMemberPath;
                sup.comboSupplierName1.SelectedValuePath = comboSupplierName.SelectedValuePath;
                sup.lblSupplierName.Content = comboSupplierName.Text;
                this.Close();
                sup.ShowDialog();
            }
            else
            {
                MessageBox.Show(comboSupplierName.Text+" Adında Bir Tadarikçi Bulunmamaktadır!!!");
            }
        }
    }
}
