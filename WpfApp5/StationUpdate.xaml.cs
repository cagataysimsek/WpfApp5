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
            //if (checkBussnessType.IsChecked == true && checkDealer.IsChecked==false && checkStation.IsChecked==false && !string.IsNullOrEmpty(comboBussinessType.Text))
            //{
            //    var item = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
            //    item.BussinessTypeId = (int)comboBussinessType.SelectedValue;
            //}
            //else
            //{
            //    MessageBox.Show("Güncellenmek İstenen Alanlar Boş Bırakılamaz!");
            //}


            //if (checkBussnessType.IsChecked == false && checkDealer.IsChecked == true && checkStation.IsChecked == false && !string.IsNullOrEmpty(comboDealerName.Text))
            //{
            //    var item = context.Stations.Where(x => x.DealerId == selectedDealerId && x.StationName==lblStationName.Content.ToString()).FirstOrDefault();
            //    if (item!=null)
            //    {
            //        MessageBox.Show("Bu İşlem Yapılamaz Çünkü " + comboDealerName.Text + " Dağıtıcısında " + lblStationName.Content + " Adında Bir İstasyon Zaten Var! ");
            //    }
            //    else
            //    {
            //        var item2 = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
            //        item2.DealerId =(int) comboDealerName.SelectedValue;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Güncellenmek İstenen Alanlar Boş Bırakılamaz!");
            //}



            //if (checkBussnessType.IsChecked == false && checkDealer.IsChecked == false && checkStation.IsChecked == true && !string.IsNullOrEmpty(comboStationName.Text))
            //{
            //    var item = context.Stations.Where(x => x.DealerId == selectedDealerId && x.StationName == comboStationName.Text);
            //    if (item!=null)
            //    {
            //        MessageBox.Show("Bu İşlem Yapılamaz Çünkü " + lblBussinessType.Content + " Dağıtıcısında " + comboDealerName.Text + " Adında Bir İstasyon Zaten Var! ");
            //    }
            //    else
            //    {
            //        var item2 = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
            //        item2.StationName = comboStationName.Text;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Güncellenmek İstenen Alanlar Boş Bırakılamaz!");
            //}


            //if (checkBussnessType.IsChecked == true && checkDealer.IsChecked == true && checkStation.IsChecked == false && !string.IsNullOrEmpty(comboBussinessType.Text) && !string.IsNullOrEmpty(comboDealerName.Text))
            //{
            //    var item = context.Stations.Where(x => x.DealerId == (int)comboDealerName.SelectedValue && x.StationName == lblStationName.Content.ToString()).FirstOrDefault();
            //    if (item!=null)
            //    {
            //        MessageBox.Show("Bu İşlem Yapılamaz Çünkü " + comboDealerName.Text + " Dağıtıcısında " + lblStationName.Content + " Adında Bir İstasyon Zaten Var! ");
            //    }
            //    else
            //    {
            //        var item2 = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
            //        item2.DealerId = (int)comboDealerName.SelectedValue;
            //        item2.BussinessTypeId =(int) comboBussinessType.SelectedValue;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Güncellenmek İstenen Alanlar Boş Bırakılamaz!");
            //}


            //if (checkBussnessType.IsChecked == true && checkDealer.IsChecked == false && checkStation.IsChecked == true && !string.IsNullOrEmpty(comboBussinessType.Text) && !string.IsNullOrEmpty(comboStationName.Text))
            //{
            //    var item = context.Stations.Where(x => x.DealerId == selectedDealerId && x.StationName == comboStationName.Text).FirstOrDefault();
            //    if (item != null)
            //    {
            //        MessageBox.Show("Bu İşlem Yapılamaz Çünkü " + comboDealerName.Text + " Dağıtıcısında " + lblStationName.Content + " Adında Bir İstasyon Zaten Var! ");
            //    }
            //    else
            //    {
            //        var item2 = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
            //        item2.BussinessTypeId =(int) comboBussinessType.SelectedValue;
            //        item2.StationName = comboStationName.Text;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Güncellenmek İstenen Alanlar Boş Bırakılamaz!");
            //}

















            if (checkBussnessType.IsChecked == true && checkDealer.IsChecked == false && checkStation.IsChecked == false && !string.IsNullOrEmpty(comboBussinessType.Text))
            {
                var item = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
                item.BussinessTypeId = (int)comboBussinessType.SelectedValue;
                context.SaveChanges();
            }



            else if (checkBussnessType.IsChecked == false && checkDealer.IsChecked == true && checkStation.IsChecked == false && !string.IsNullOrEmpty(comboDealerName.Text))
            {
                var item = context.Stations.Where(x => x.DealerId == (int)comboDealerName.SelectedValue && x.StationName == lblStationName.Content.ToString()).FirstOrDefault();
                if (item != null)
                {
                    MessageBox.Show("Bu İşlem Yapılamaz Çünkü " + comboDealerName.Text + " Dağıtıcısında " + lblStationName.Content + " Adında Bir İstasyon Zaten Var! ");
                }
                else
                {
                    var item2 = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
                    item2.DealerId = (int)comboDealerName.SelectedValue;
                    context.SaveChanges();
                }
            }




            else if (checkBussnessType.IsChecked == false && checkDealer.IsChecked == false && checkStation.IsChecked == true && !string.IsNullOrEmpty(comboStationName.Text))
            {
                var item = context.Stations.Where(x => x.DealerId == selectedDealerId && x.StationName == comboStationName.Text).FirstOrDefault();
                if (item != null)
                {
                    MessageBox.Show("Bu İşlem Yapılamaz Çünkü " + lblDealer.Content + " Dağıtıcısında " + comboStationName.Text + " Adında Bir İstasyon Zaten Var! ");
                }
                else
                {
                    var item2 = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
                    item2.StationName = comboStationName.Text;
                    context.SaveChanges();
                }
            }



            else if (checkBussnessType.IsChecked == true && checkDealer.IsChecked == true && checkStation.IsChecked == false && !string.IsNullOrEmpty(comboBussinessType.Text) && !string.IsNullOrEmpty(comboDealerName.Text))
            {
                var item = context.Stations.Where(x => x.DealerId == (int)comboDealerName.SelectedValue && x.StationName == lblStationName.Content.ToString()).FirstOrDefault();
                if (item != null)
                {
                    MessageBox.Show("Bu İşlem Yapılamaz Çünkü " + comboDealerName.Text + " Dağıtıcısında " + lblStationName.Content + " Adında Bir İstasyon Zaten Var! ");
                }
                else
                {
                    var item2 = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
                    item2.DealerId = (int)comboDealerName.SelectedValue;
                    item2.BussinessTypeId = (int)comboBussinessType.SelectedValue;
                    context.SaveChanges();
                }
            }



            else if (checkBussnessType.IsChecked == true && checkDealer.IsChecked == false && checkStation.IsChecked == true && !string.IsNullOrEmpty(comboBussinessType.Text) && !string.IsNullOrEmpty(comboStationName.Text))
            {
                var item = context.Stations.Where(x => x.DealerId == selectedDealerId && x.StationName == comboStationName.Text).FirstOrDefault();
                if (item != null)
                {
                    MessageBox.Show("Bu İşlem Yapılamaz Çünkü " + comboDealerName.Text + " Dağıtıcısında " + lblStationName.Content + " Adında Bir İstasyon Zaten Var! ");
                }
                else
                {
                    var item2 = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
                    item2.BussinessTypeId = (int)comboBussinessType.SelectedValue;
                    item2.StationName = comboStationName.Text;
                    context.SaveChanges();
                }
            }

            else if (checkBussnessType.IsChecked == false && checkDealer.IsChecked == true && checkStation.IsChecked == true && !string.IsNullOrEmpty(comboDealerName.Text) && !string.IsNullOrEmpty(comboStationName.Text))
            {
                var item = context.Stations.Where(x => x.DealerId == (int)comboDealerName.SelectedValue && x.StationName == comboStationName.Text).FirstOrDefault();
                if (item != null)
                {
                    MessageBox.Show("Bu İşlem Yapılamaz Çünkü " + comboDealerName.Text + " Dağıtıcısında " + comboStationName.Text + " Adında Bir İstasyon Zaten Var! ");
                }
                else
                {
                    var item2 = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
                    item2.DealerId = (int)comboDealerName.SelectedValue;
                    item2.StationName = comboStationName.Text;
                    context.SaveChanges();
                }
            }

            else if (checkBussnessType.IsChecked == true && checkDealer.IsChecked == true && checkStation.IsChecked == true && !string.IsNullOrEmpty(comboBussinessType.Text) && !string.IsNullOrEmpty(comboDealerName.Text) && !string.IsNullOrEmpty(comboStationName.Text))
            {
                var item = context.Stations.Where(x => x.DealerId == (int)comboDealerName.SelectedValue && x.StationName == comboStationName.Text).FirstOrDefault();
                if (item != null)
                {
                    MessageBox.Show("Bu İşlem Yapılamaz Çünkü " + comboDealerName.Text + " Dağıtıcısında " + comboStationName.Text + " Adında Bir İstasyon Zaten Var! ");
                }
                else
                {
                    var item2 = context.Stations.Where(x => x.Id == selectedId).FirstOrDefault();
                    item2.DealerId = (int)comboDealerName.SelectedValue;
                    item2.StationName = comboStationName.Text;
                    item2.BussinessTypeId = (int)comboBussinessType.SelectedValue;
                    context.SaveChanges();
                }
            }
            else if (checkBussnessType.IsChecked == false && checkDealer.IsChecked == false && checkStation.IsChecked == false)
            {
                MessageBox.Show("Güncellemek Yapmak İçin Güncellemek İstediğiniz Alanları İşaretlemelisiniz!");
            }
            else
            {
                MessageBox.Show("Güncellenmek İstenen Alanlar Boş Bırakılamaz!");
            }





        }

        private void comboDealerName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboDealerName.SelectedValue!=null)
            {
                comboStationName.ItemsSource = context.Stations.Where(x => x.DealerId == (int)comboDealerName.SelectedValue).ToList();
                comboStationName.DisplayMemberPath = "StationName";
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
    }
}
