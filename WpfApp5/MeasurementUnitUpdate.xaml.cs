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
    /// Interaction logic for MeasurementUnitUpdate.xaml
    /// </summary>
    public partial class MeasurementUnitUpdate : Window
    {
        StockAutomationDBContext context = new StockAutomationDBContext();
        public MeasurementUnitUpdate()
        {
            InitializeComponent();
        }

        private void buttonGüncellemeİsleminiTamamla_Click(object sender, RoutedEventArgs e)
        {
            var item = (from x in context.Definations where x.DefValue == comboNewMeasurementName.Text && x.DefType == (int)Definition.Unit select x).FirstOrDefault();
            if (item == null)
            {
                if (!string.IsNullOrEmpty(comboNewMeasurementName.Text))
                {
                    var item2 = (from x in context.Definations where x.DefValue == lblName.Content.ToString() && x.DefType == (int)Definition.Unit select x).FirstOrDefault();
                    item2.DefValue = comboNewMeasurementName.Text;
                    context.SaveChanges();
                    MessageBox.Show(lblName.Content + " Ölçü Biriminin Adı " + comboNewMeasurementName.Text + " Olarak Değiştirildi.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!");
                }
            }
            else
            {
                MessageBox.Show(comboNewMeasurementName.Text + "Ölçü Birimi Daha Once Tanımlanmış! Lütfen Başka Sistemde Olmayan Bir Ölçü Birimi Giriniz!");
                comboNewMeasurementName.Text = null;
            }
        }
    }
}
