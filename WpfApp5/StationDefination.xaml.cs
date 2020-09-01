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
                var item = (from x in context.Stations where x.DealerId == (int)comboDealerName.SelectedValue && x.StationName == comboStationName.Text select x).FirstOrDefault();
                if (item == null)
                {
                    var item2 = new Station();
                    item2.BussinessTypeId = (int)comboBussinessType.SelectedValue;
                    item2.DealerId = (int)comboDealerName.SelectedValue;
                    item2.StationName = comboStationName.Text;
                    context.Stations.Add(item2);
                    context.SaveChanges();
                    MessageBox.Show(comboStationName.Text + " İstasyonu " + comboDealerName.Text + " Dağıtıcısına Bağlı ve Bussiness Type'ı " + comboBussinessType.Text + " Olarak Sisteme Kaydedildi!");
                    comboDealerName.SelectedValue = null;
                    comboBussinessType.SelectedValue = null;
                    comboStationName.Text = "";
                }
                else
                {
                    MessageBox.Show(comboDealerName.Text + " Dağıtıcısına Bağlı " + comboStationName.Text + " Adında Bir İstasyon Zaten Bulunmakta!");
                    comboDealerName.SelectedValue = null;
                    comboBussinessType.SelectedValue = null;
                    comboStationName.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!");
            }
        }

        private void buttonSil_Click(object sender, RoutedEventArgs e)
        {
            if (comboDealerName.SelectedValue != null && comboBussinessType.SelectedValue != null && !string.IsNullOrEmpty(comboStationName.Text))
            {
                var item = context.Stations.Where(x => x.DealerId == (int)comboDealerName.SelectedValue && x.BussinessTypeId==(int)comboBussinessType.SelectedValue && x.StationName == comboStationName.Text).FirstOrDefault();
                if (item!=null)
                {
                    context.Stations.Remove(item);
                    context.SaveChanges();
                    MessageBox.Show( comboDealerName.Text + " Dağıtıcısına Bağlı ve Bussiness Type'ı " + comboBussinessType.Text + " Olan " + comboStationName.Text + " İstasyonu Başarıyla Silindi");
                    comboDealerName.SelectedValue = null;
                    comboBussinessType.SelectedValue = null;
                    comboStationName.Text = "";

                }
                else
                {
                    MessageBox.Show(comboDealerName.Text + " Dağıtıcısına Bağlı ve Bussiness Type'ı " + comboBussinessType.Text +" Olan "+ comboStationName.Text + " İstasyonu Bulunmamakta. Lütfen Bilgileri Gözden Geçiriniz!");
                    comboDealerName.SelectedValue = null;
                    comboBussinessType.SelectedValue = null;
                    comboStationName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!");
            }
           
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboBussinessType.ItemsSource = context.Definations.Where(x => x.DefType == (int)Definition.BussinessType).ToList();
            comboBussinessType.DisplayMemberPath = "DefValue";
            comboBussinessType.SelectedValuePath = "Id";
        }

        private void ComboShow()
        {

        }

        private void comboDealerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (comboDealerName.SelectedValue != null)
            {
                comboStationName.ItemsSource = context.Stations.Where(x => x.DealerId == (int)comboDealerName.SelectedValue && x.BussinessTypeId==(int)comboBussinessType.SelectedValue).ToList();
                comboStationName.DisplayMemberPath = "StationName";
            }
            else
            {
                comboStationName.ItemsSource = null;
            }

        }

        private void buttonGüncelleClick(object sender, RoutedEventArgs e)
        {
            if (comboBussinessType.SelectedValue!=null && comboDealerName.SelectedValue!=null && !string.IsNullOrEmpty(comboStationName.Text))
            {
                var item = context.Stations.Where(x => x.DealerId == (int)comboDealerName.SelectedValue && x.BussinessTypeId == (int)comboBussinessType.SelectedValue && x.StationName == comboStationName.Text).FirstOrDefault();
                if (item!=null)
                {
                    StationUpdate update = new StationUpdate();
                    update.lblBussinessType.Content = comboBussinessType.Text;
                    update.lblDealer.Content = comboDealerName.Text;
                    update.lblStationName.Content = comboStationName.Text;
                    update.selectedId = item.Id;
                    update.selectedDealerId =item.DealerId;
                    update.selectedStationName = item.StationName;
                    update.selectedBussnessType = item.BussinessTypeId;
                    update.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(comboDealerName.Text + " Dağıtıcısına Bağlı ve Bussiness Type'ı " + comboBussinessType.Text + " Olan " + comboStationName.Text + " İstasyonu Bulunmamakta. Lütfen Bilgileri Gözden Geçiriniz!");
                    comboBussinessType.SelectedValue = null;
                }
            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!");
                comboBussinessType.SelectedValue = null;
            }
        }

        private void comboBussinessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBussinessType.SelectedValue!=null)
            {
                comboDealerName.ItemsSource = (from x in context.Stations
                                               join y in context.Dealers on x.DealerId equals y.Id
                                               where x.BussinessTypeId == (int)comboBussinessType.SelectedValue
                                               select y).Distinct().ToList();

                comboDealerName.DisplayMemberPath = "DealerName";
                comboDealerName.SelectedValuePath = "Id";
            }
            else
            {
                comboDealerName.ItemsSource = null;
            }
        }
    }
}
