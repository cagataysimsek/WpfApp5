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
            if (!string.IsNullOrEmpty(comboNewBussinessTypeName.Text))
            {
                var item = (from x in context.Definations where x.DefValue == comboNewBussinessTypeName.Text && x.DefType == (int)Definition.BussinessType select x).FirstOrDefault();
                if (item == null)
                {
                    var item2 = (from x in context.Definations where x.DefValue == lblName.Content.ToString() && x.DefType == (int)Definition.BussinessType select x).FirstOrDefault();
                    item2.DefValue = comboNewBussinessTypeName.Text;
                    context.SaveChanges();
                    MessageBox.Show(lblName.Content + " Para Biriminin Adı " + comboNewBussinessTypeName.Text + " Olarak Değiştirildi.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(comboNewBussinessTypeName.Text + " Bussiness Type'ı Daha Once Tanımlanmış! Lütfen Başka Sistemde Olmayan Bir isim Giriniz!");
                    comboNewBussinessTypeName.SelectedValue = null;
                }

            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!");
            }
        }
    }
}
