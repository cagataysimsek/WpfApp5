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
    /// Interaction logic for StationUpdate.xaml
    /// </summary>
    public partial class StationUpdate : Window
    {
        public int selectedId;
        public int selectedDealerId;
        public string selectedStationName;
        public int selectedBussnessType;
        StockAutomationDBContext context = new StockAutomationDBContext();
        public StationUpdate()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboBussinessType.ItemsSource = context.Definations.Where(x => x.DefType == (int)Definition.BussinessType).ToList();
            comboBussinessType.DisplayMemberPath = "DefValue";
            comboBussinessType.SelectedValuePath = "Id";
            comboDealerName.ItemsSource = context.Dealers.ToList();
            comboDealerName.DisplayMemberPath = "DealerName";
            comboDealerName.SelectedValuePath = "Id";
        }

        private void buttonGüncellemeİsleminiTamamla_Click(object sender, RoutedEventArgs e)
        {
      

            if (comboBussinessType.SelectedValue != null && comboDealerName.SelectedValue != null && !string.IsNullOrEmpty(comboStationName.Text))
            {
                if (comboDealerName.Text == lblDealer.Content.ToString() && comboStationName.Text == lblStationName.Content.ToString())
                {
                    var item = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
                    item.BussinessTypeId = (int)comboBussinessType.SelectedValue;
                    MessageBox.Show("Güncelleme Öncesi: \nBussnessType:" + lblBussinessType.Content + ",Dağıtıcı:" + lblDealer.Content + ",İstasyon Adı:" + lblStationName.Content+"\nGüncelleme Sonrası:\nBussnessType:"+comboBussinessType.Text+ ",Dağıtıcı:"+comboDealerName.Text+ ",İstasyon Adı:"+comboStationName.Text);
                }
                else if ((comboDealerName.Text == lblDealer.Content.ToString() && comboStationName.Text != lblStationName.Content.ToString()) || (comboDealerName.Text != lblDealer.Content.ToString()))
                {
                    var item = context.Stations.Where(x => x.DealerId == (int)comboDealerName.SelectedValue && x.StationName == comboStationName.Text).FirstOrDefault();
                    if (item==null)
                    {
                        var item2 = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
                        item2.DealerId =(int) comboDealerName.SelectedValue;
                        item2.StationName = comboStationName.Text;
                        item2.BussinessTypeId =(int) comboBussinessType.SelectedValue;
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show(comboDealerName.Text + " Dağıtıcına Bağlı " + comboStationName.Text + " Adında Bir İstasyon Zaten Bulunuyor!!!");
                        comboBussinessType.SelectedValue = null;
                        comboDealerName.SelectedValue = null;
                        comboStationName.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!");
            }
        }

        private void comboDealerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboDealerName.SelectedValue!=null && comboBussinessType.SelectedValue!=null)
            {
                comboStationName.ItemsSource = context.Stations.Where(x => x.DealerId == (int)comboDealerName.SelectedValue && x.BussinessTypeId==(int)comboBussinessType.SelectedValue).ToList();
                comboStationName.DisplayMemberPath = "StationName";
            }
            else
            {
                comboStationName.ItemsSource = null;
            }
            
        }


        private void checkBussnessType_Click(object sender, RoutedEventArgs e)
        {
            if (comboBussinessType.IsEnabled == true)
            {
                comboBussinessType.IsEnabled = false;
                comboBussinessType.Text = "";
            }
            else
            {
                comboBussinessType.IsEnabled = true;
                comboBussinessType.Text = "";
            }
        }

        private void checkDealer_Click(object sender, RoutedEventArgs e)
        {

            if (comboDealerName.IsEnabled == true)
            {
                comboDealerName.IsEnabled = false;
                comboDealerName.Text = "";
                comboStationName.ItemsSource = null;

            }
            else
            {
                comboDealerName.IsEnabled = true;
                comboDealerName.Text = "";
            }
        }

        private void checkStation_Click(object sender, RoutedEventArgs e)
        {

            if (comboStationName.IsEnabled == true)
            {
                comboStationName.IsEnabled = false;
                comboStationName.Text = "";
            }
            else
            {
                comboStationName.IsEnabled = true;
                comboStationName.Text = "";
            }
        }

        private void comboBussinessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboDealerName.SelectedValue != null && comboBussinessType.SelectedValue != null)
            {
                comboStationName.ItemsSource = context.Stations.Where(x => x.DealerId == (int)comboDealerName.SelectedValue && x.BussinessTypeId == (int)comboBussinessType.SelectedValue).ToList();
                comboStationName.DisplayMemberPath = "StationName";
            }
            else
            {
                comboStationName.ItemsSource = null;
            }
        }
    }
}
