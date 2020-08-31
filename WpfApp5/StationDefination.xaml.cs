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
    /// Interaction logic for StationDefination.xaml
    /// </summary>
    public partial class StationDefination : Window
    {
        StockAutomationDBContext context = new StockAutomationDBContext();
        public StationDefination()
        {
            InitializeComponent();
        }

        private void buttonEkle_Click(object sender, RoutedEventArgs e)
        {
            if (comboBussinessType.SelectedValue != null && comboDealerName.SelectedValue != null && !string.IsNullOrEmpty(comboStationName.Text))
            {
                var item = context.Stations.Where(x => x.StationName == comboStationName.Text).Where(x => x.DealerId==Convert.ToInt32(comboDealerName.SelectedValue)).FirstOrDefault();
                if (item == null)
                {
                    var newItem = new Station();
                    newItem.BussinessTypeId = Convert.ToInt32(comboBussinessType.SelectedValue);
                    newItem.DealerId = Convert.ToInt32(comboDealerName.SelectedValue);
                    newItem.StationName = comboStationName.Text;
                    context.Stations.Add(newItem);
                    context.SaveChanges();
                    MessageBox.Show("İstasyonu Başarıyla Eklendi.");
                    ComboShow();
                }
                else
                {
                    MessageBox.Show(comboDealerName.Text+" Dağıtıcısına Tanımlı Bir "+comboStationName.Text+"  İstasyonu Zaten Bulunuyor!");
                }
            }
            else
            {
                MessageBox.Show("Herhangi Bir Bilgi Boş Bırakılamaz!");
            }
        }

        private void buttonSil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ComboShow();
            var a = (from s in context.Stations
                     join sl in context.Dealers on s.DealerId equals sl.Id
                     join def in context.Definations on s.BussinessTypeId equals def.Id
                     select  new {
                     s.Id,
                     s.StationName,
                     sl.DealerName,
                     def.DefValue,
                     
                     s.BussinessTypeId,
                     s.DealerId}).ToList();
            dataGridView1.ItemsSource = a;
        }

        private void ComboShow()
        {
            //comboBussinessType.ItemsSource = context.Definations.Where(x => x.DefType == 3).ToList();
            comboBussinessType.ItemsSource = (from x in context.Definations
                                             where x.DefType==3
                                             select x).ToList();
            comboBussinessType.DisplayMemberPath = "DefValue";
            comboBussinessType.SelectedValuePath = "Id";
            comboDealerName.ItemsSource = context.Dealers.ToList();
            comboDealerName.DisplayMemberPath = "DealerName";
            comboDealerName.SelectedValuePath = "Id";
            comboStationName.Text = "";
            comboDealerName.Text = "";
            comboBussinessType.Text = "";
        }

        private void comboDealerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboStationName.ItemsSource = context.Stations.Where(x=> x.DealerId==Convert.ToInt32(comboDealerName.SelectedValue)).ToList();
            comboStationName.DisplayMemberPath = "StationName";
            comboStationName.SelectedValuePath = "Id";
        }
    }
}
