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
            if (comboSupplierName1.SelectedValue!=null && !string.IsNullOrEmpty(txtNewSupplierName.Text))
            {
                var item = (from x in context.Suppliers where x.Id == Convert.ToInt32(comboSupplierName1.SelectedValue) select x).FirstOrDefault();
                item.SupplierName = txtNewSupplierName.Text;
                context.SaveChanges();
                MessageBox.Show(comboSupplierName1.Text + " Terarikçisinin Adı " + txtNewSupplierName.Text + " Olarak Değiştirildi.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz.");
            }
        }

    }
}
