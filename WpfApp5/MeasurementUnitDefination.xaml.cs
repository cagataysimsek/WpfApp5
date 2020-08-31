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
            var item = context.Definations.Where(x => x.DefValue == comboMeasurementUnit.Text).FirstOrDefault();
            if (item==null)
            {
                if (!string.IsNullOrEmpty(comboMeasurementUnit.Text))
                {
                    var newItem = new Defination();
                    newItem.DefType = 2;
                    newItem.DefValue = comboMeasurementUnit.Text;
                    context.Definations.Add(newItem);
                    context.SaveChanges();
                    MessageBox.Show(comboMeasurementUnit.Text + "Birimi Başarıyla Eklendi");
                    comboShow();
                }
                else
                {
                    MessageBox.Show( "Boş Kayıt Eklenemez!");
                }
            }
            else
            {
                MessageBox.Show(comboMeasurementUnit.Text + " Kayıdı Zaten Var!");
            }

            //context.Definations.Add(item);
        }

        private void buttonSil_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty( comboMeasurementUnit.Text))
            {
                var item = context.Definations.Where(x => x.Id == Convert.ToInt32(comboMeasurementUnit.SelectedValue)).FirstOrDefault();
                context.Definations.Remove(item);
                context.SaveChanges();
                string name = comboMeasurementUnit.Text;
                comboShow();
                MessageBox.Show(name +" Ölçü Birimini Silme İşlemi Başarılı.");
            }
        }

        private void buttonGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (comboMeasurementUnit.SelectedValue!=null)
            {
                MeasurementUnitUpdate mu = new MeasurementUnitUpdate();
                mu.comboMeasurementName1.ItemsSource = comboMeasurementUnit.ItemsSource;
                mu.comboMeasurementName1.DisplayMemberPath = comboMeasurementUnit.DisplayMemberPath;
                mu.comboMeasurementName1.SelectedValuePath = comboMeasurementUnit.SelectedValuePath;
                mu.comboMeasurementName1.SelectedValue = comboMeasurementUnit.SelectedValue;
                this.Close();
                mu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Güncelleme Yapmadan Önce Güncellemek İstediğiniz Dağıtıcıyı Seçmelisiniz.");
            }
        }
    }
}
