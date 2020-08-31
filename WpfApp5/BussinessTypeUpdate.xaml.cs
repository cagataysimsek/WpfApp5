using Models;
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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for BussinessTypeUpdate.xaml
    /// </summary>
    public partial class BussinessTypeUpdate : Window
    {
        StockAutomationDBContext context = new StockAutomationDBContext();
        public BussinessTypeUpdate()
        {
            InitializeComponent();
        }

        private void buttonGüncellemeİsleminiTamamla_Click(object sender, RoutedEventArgs e)
        {
            //if (comboBussinessType1.SelectedValue!=null && !string.IsNullOrEmpty(txtNewBussinessTypeName.Text))
            //{
            //    var item = (from x in context.Definations where x.Id == Convert.ToInt32(comboBussinessType1.SelectedValue) select x).FirstOrDefault();
            //    item.DefValue = txtNewBussinessTypeName.Text;
            //    context.SaveChanges();
            //    MessageBox.Show(comboBussinessType1.Text + " BussinessType " + txtNewBussinessTypeName.Text + " Olarak Değiştirildi");
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!");
            //}
        }
    }
}
