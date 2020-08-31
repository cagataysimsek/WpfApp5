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
            if (comboMeasurementName1.SelectedValue!=null && !string.IsNullOrEmpty(txtNewMeasurementName.Text))
            {
                var item = (from x in context.Definations where x.Id == Convert.ToInt32(comboMeasurementName1.SelectedValue) select x).FirstOrDefault();
                item.DefValue = txtNewMeasurementName.Text;
                context.SaveChanges();
                MessageBox.Show(comboMeasurementName1.Text + " Ölçü Biriminin Adı " + txtNewMeasurementName.Text + " Olarak Değiştirildi.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz.");
            }
        }
    }
}
