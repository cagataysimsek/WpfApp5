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
    /// Interaction logic for MeasurementUnitDefination.xaml
    /// </summary>
    public partial class MeasurementUnitDefination : Window
    {
        StockAutomationDBContext context = new StockAutomationDBContext();
        public MeasurementUnitDefination()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboShow();
        }

        private void comboShow()
        {
            comboMeasurementUnit.Text = "";
            comboMeasurementUnit.ItemsSource = context.Definations.Where(x => x.DefType == 2).ToList();
            comboMeasurementUnit.DisplayMemberPath = "DefValue";
            comboMeasurementUnit.SelectedValuePath = "Id";
        }

        private void buttonEkle_Click(object sender, RoutedEventArgs e)
        {
            var item = context.Definations.Where(x => x.DefValue == comboMeasurementUnit.Text && x.DefType==(int)Definition.Unit).SingleOrDefault();
            if (item == null)
            {
                if (string.IsNullOrEmpty(comboMeasurementUnit.Text))
                {
                    MessageBox.Show("Ölçü Birimi Boş Bırakılamaz!");
                }
                else
                {
                    Defination newItem = new Defination();
                    newItem.DefType = (int)Definition.Unit;
                    newItem.DefValue = comboMeasurementUnit.Text;
                    context.Definations.Add(newItem);
                    context.SaveChanges();
                    MessageBox.Show("Ekleme İşlemi Başarılı");
                    comboShow();
                }
            }
            else
            {
                MessageBox.Show(comboMeasurementUnit.Text + " Kayıdı Zaten Var!");
            }
        }

        private void buttonSil_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(comboMeasurementUnit.Text))
            {
                var item = context.Definations.Where(x => x.DefValue == comboMeasurementUnit.Text && x.DefType == (int)Definition.Unit).FirstOrDefault();
                if (item != null)
                {
                    context.Definations.Remove(item);
                    context.SaveChanges();
                    string name = comboMeasurementUnit.Text;
                    comboShow();
                    MessageBox.Show(name + " Ölçü Birimini Silme İşlemi Başarılı.");
                }
                else
                {
                    MessageBox.Show(comboMeasurementUnit.Text + " Adında Bir Ölçü Birimi Bulunmamakta!");
                }
            }
        }

        private void buttonGuncelle_Click(object sender, RoutedEventArgs e)
        {
            var item = context.Definations.Where(x => x.DefValue == comboMeasurementUnit.Text && x.DefType == (int)Definition.Unit).FirstOrDefault();
            if (!string.IsNullOrEmpty(comboMeasurementUnit.Text))
            {
                if (item != null)
                {
                    MeasurementUnitUpdate measurement = new MeasurementUnitUpdate();
                    measurement.lblName.Content = item.DefValue;
                    this.Close();
                    measurement.ShowDialog();
                }
                else
                {
                    MessageBox.Show(comboMeasurementUnit.Text + " Adında Bir Ölçü Birimi Bulunmamakta!");
                }
            }
        }
    }
}
