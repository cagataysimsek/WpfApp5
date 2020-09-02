using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using Models;

namespace WpfApp5
{
    
    /// <summary>
    /// Interaction logic for SupplierUpdate.xaml
    /// </summary>
    public partial class SupplierUpdate : Window
    {
        StockAutomationDBContext context = new StockAutomationDBContext();
        public SupplierUpdate()
        {
            InitializeComponent();
        }

        private void buttonGüncellemeİsleminiTamamla_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(comboSupplierName1.Text))
            {
                var item = (from x in context.Suppliers where x.SupplierName == comboSupplierName1.Text select x).FirstOrDefault();
                if (item==null)
                {
                    var item2 = context.Suppliers.Where(x => x.SupplierName == lblSupplierName.Content.ToString()).FirstOrDefault();
                    item2.SupplierName = comboSupplierName1.Text;
                    context.SaveChanges();
                    MessageBox.Show(lblSupplierName.Content.ToString() + " Terarikçisinin Adı " + comboSupplierName1.Text + " Olarak Değiştirildi.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(comboSupplierName1.Text + " Adında Bir Tedarikçi Zaten Var!!!");
                    comboSupplierName1.Text = "";
                } 
            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz.");
            }
        }

    }
}
