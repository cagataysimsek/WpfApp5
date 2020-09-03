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
    /// Interaction logic for MaterialInputOutput.xaml
    /// </summary>
    public partial class MaterialInputOutput : Window
    {
        int OperationTypeNum = 99;
        StockAutomationDBContext context = new StockAutomationDBContext();
        public MaterialInputOutput()
        {
            InitializeComponent();
            
        }

        private void buttonInput_Click(object sender, RoutedEventArgs e)
        {
            one.Visibility = Visibility.Visible;
            two.Visibility = Visibility.Visible;
            three.Visibility = Visibility.Visible;
            four.Visibility = Visibility.Visible;
            five.Visibility = Visibility.Visible;
            six.Visibility = Visibility.Visible;
            seven.Visibility = Visibility.Visible;
            eight.Visibility = Visibility.Visible;
            nine.Visibility = Visibility.Visible;
            comboMaterial.Visibility = Visibility.Visible;
            comboSupplier.Visibility = Visibility.Visible;
            doubleUpDownQuantity.Visibility = Visibility.Visible;
            comboCurrency.Visibility = Visibility.Visible;
            doubleUpDownFee.Visibility = Visibility.Visible;
            txtOfficalName.Visibility = Visibility.Visible;
            comboBussinessType.Visibility = Visibility.Visible;
            comboDelaer.Visibility = Visibility.Visible;
            comboStation.Visibility = Visibility.Visible;
            radioGift.Visibility = Visibility.Hidden;
            radioLoss.Visibility = Visibility.Hidden;
            radioSales.Visibility = Visibility.Hidden;
            buttonAdd.Visibility = Visibility.Visible;
            buttonUpdate.Visibility = Visibility.Visible;
            buttonDelete.Visibility = Visibility.Visible;

            /////////////////////////////////////////////////////////////////////////

            OperationTypeNum = 1;
            allCoontrolsAreEmpty();
            lblOperationType.Content = "Materyal Girişi";




            /////////////////////////////////////////////////////////////////////////
            comboMaterial.IsEnabled = true;
            comboSupplier.IsEnabled = true;
            doubleUpDownQuantity.IsEnabled = true;
            comboCurrency.IsEnabled = true;
            doubleUpDownFee.IsEnabled = true;
            txtOfficalName.IsEnabled = false;
            comboBussinessType.IsEnabled = false;
            comboDelaer.IsEnabled = false;
            comboStation.IsEnabled = false;

        }

        private void buttonOutput_Click(object sender, RoutedEventArgs e)
        {
            one.Visibility = Visibility.Visible;
            two.Visibility = Visibility.Visible;
            three.Visibility = Visibility.Visible;
            four.Visibility = Visibility.Visible;
            five.Visibility = Visibility.Visible;
            six.Visibility = Visibility.Visible;
            seven.Visibility = Visibility.Visible;
            eight.Visibility = Visibility.Visible;
            nine.Visibility = Visibility.Visible;
            comboMaterial.Visibility = Visibility.Visible;
            comboSupplier.Visibility = Visibility.Visible;
            doubleUpDownQuantity.Visibility = Visibility.Visible;
            comboCurrency.Visibility = Visibility.Visible;
            doubleUpDownFee.Visibility = Visibility.Visible;
            txtOfficalName.Visibility = Visibility.Visible;
            comboBussinessType.Visibility = Visibility.Visible;
            comboDelaer.Visibility = Visibility.Visible;
            comboStation.Visibility = Visibility.Visible;
            radioGift.Visibility = Visibility.Visible;
            radioLoss.Visibility = Visibility.Visible;
            radioSales.Visibility = Visibility.Visible;
            buttonAdd.Visibility = Visibility.Visible;
            buttonUpdate.Visibility = Visibility.Visible;
            buttonDelete.Visibility = Visibility.Visible;
            /////////////////////////////////////////////////////////////////////////
            OperationTypeNum = 0;
            allCoontrolsAreEmpty();
            lblOperationType.Content = "Materyal Çıkışı";




            /////////////////////////////////////////////////////////////////////////
            comboMaterial.IsEnabled = false;
            comboSupplier.IsEnabled = false;
            doubleUpDownQuantity.IsEnabled = false;
            comboCurrency.IsEnabled = false;
            doubleUpDownFee.IsEnabled = false;
            txtOfficalName.IsEnabled = false;
            comboBussinessType.IsEnabled = false;
            comboDelaer.IsEnabled = false;
            comboStation.IsEnabled = false;

            radioGift.IsChecked = false;
            radioLoss.IsChecked = false;
            radioSales.IsChecked = false;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            lblUnit.Content = "";
            lblOperationType.Content = "";
            radioGift.Visibility = Visibility.Hidden;
            radioLoss.Visibility = Visibility.Hidden;
            radioSales.Visibility = Visibility.Hidden;
            comboMaterial.Visibility = Visibility.Hidden;
            comboSupplier.Visibility = Visibility.Hidden;
            doubleUpDownQuantity.Visibility = Visibility.Hidden;
            comboCurrency.Visibility = Visibility.Hidden;
            doubleUpDownFee.Visibility = Visibility.Hidden;
            txtOfficalName.Visibility = Visibility.Hidden;
            comboBussinessType.Visibility = Visibility.Hidden;
            comboDelaer.Visibility = Visibility.Hidden;
            comboStation.Visibility = Visibility.Hidden;
            one.Visibility= Visibility.Hidden;
            two.Visibility = Visibility.Hidden;
            three.Visibility = Visibility.Hidden;
            four.Visibility = Visibility.Hidden;
            five.Visibility = Visibility.Hidden;
            six.Visibility = Visibility.Hidden;
            seven.Visibility = Visibility.Hidden;
            eight.Visibility = Visibility.Hidden;
            nine.Visibility = Visibility.Hidden;
            buttonAdd.Visibility = Visibility.Hidden;
            buttonUpdate.Visibility = Visibility.Hidden;
            buttonDelete.Visibility = Visibility.Hidden;
            //////////////////////////////////////////////////////////////////


            comboMaterial.ItemsSource = context.Materials.ToList();
            comboMaterial.DisplayMemberPath = "MaterialName";
            comboMaterial.SelectedValuePath = "Id";

            comboSupplier.ItemsSource = context.Suppliers.ToList();
            comboSupplier.DisplayMemberPath = "SupplierName";
            comboSupplier.SelectedValuePath = "Id";

            comboCurrency.ItemsSource = context.Definations.Where(x => x.DefType == (int)Definition.Currency).ToList();
            comboCurrency.DisplayMemberPath = "DefValue";
            comboCurrency.SelectedValuePath = "Id";

            comboBussinessType.ItemsSource = context.Definations.Where(x => x.DefType == (int)Definition.BussinessType).ToList();
            comboBussinessType.DisplayMemberPath = "DefValue";
            comboBussinessType.SelectedValuePath = "Id";


        }

        private void radioSales_Checked(object sender, RoutedEventArgs e)
        {
            comboMaterial.IsEnabled = true;
            comboSupplier.IsEnabled = false;
            doubleUpDownQuantity.IsEnabled = true;
            comboCurrency.IsEnabled = true;
            doubleUpDownFee.IsEnabled = true;
            comboBussinessType.IsEnabled = true;
            comboDelaer.IsEnabled = true;
            comboStation.IsEnabled = true;
            allCoontrolsAreEmpty();
        }

        private void radioLoss_Checked(object sender, RoutedEventArgs e)
        {
            comboMaterial.IsEnabled = true;
            comboSupplier.IsEnabled = false;
            doubleUpDownQuantity.IsEnabled = true;
            comboCurrency.IsEnabled = false;
            doubleUpDownFee.IsEnabled = false;
            comboBussinessType.IsEnabled = false;
            comboDelaer.IsEnabled = false;
            comboStation.IsEnabled = false;
            allCoontrolsAreEmpty();

        }

        private void allCoontrolsAreEmpty()
        {
            comboMaterial.SelectedValue = null;
            comboSupplier.SelectedValue = null;
            doubleUpDownQuantity.Value = 0;
            comboCurrency.SelectedValue = null;
            doubleUpDownFee.Value = 0;
            comboBussinessType.SelectedValue = null;
            comboDelaer.SelectedValue = null;
            comboStation.SelectedValue = null;
        }

        private void radioGift_Checked(object sender, RoutedEventArgs e)
        {
            comboMaterial.IsEnabled = true;
            comboSupplier.IsEnabled = false;
            doubleUpDownQuantity.IsEnabled = true;
            comboCurrency.IsEnabled = false;
            doubleUpDownFee.IsEnabled = false;
            comboBussinessType.IsEnabled = true;
            comboDelaer.IsEnabled = true;
            comboStation.IsEnabled = true;
            allCoontrolsAreEmpty();
        }

        private void comboBussinessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBussinessType.SelectedValue!=null)
            {
                comboDelaer.SelectedValue = null;
                comboDelaer.ItemsSource = (from x in context.Stations join y in context.Dealers on x.DealerId equals y.Id where x.BussinessTypeId == (int)comboBussinessType.SelectedValue select y).Distinct().ToList();
                comboDelaer.DisplayMemberPath = "DealerName";
                comboDelaer.SelectedValuePath = "Id";
            }
            else
            {
                comboDelaer.ItemsSource = null;
            }
            
        }

        private void comboDelaer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboDelaer.SelectedValue!=null)
            {
                comboStation.ItemsSource = context.Stations.Where(x => x.DealerId == (int)comboDelaer.SelectedValue && x.BussinessTypeId == (int)comboBussinessType.SelectedValue).ToList();
                comboStation.DisplayMemberPath = "StationName";
                comboStation.SelectedValuePath = "Id";
            }
            else
            {
                comboStation.ItemsSource = null;
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (OperationTypeNum == 1 && comboMaterial.SelectedValue!=null && comboSupplier.SelectedValue!=null && comboCurrency.SelectedValue!=null && !string.IsNullOrEmpty(doubleUpDownFee.Text) && !string.IsNullOrEmpty(doubleUpDownQuantity.Text) && !string.IsNullOrWhiteSpace(doubleUpDownFee.Text) && !string.IsNullOrWhiteSpace(doubleUpDownQuantity.Text))
            {
                if (doubleUpDownFee.Value!=0 && doubleUpDownQuantity.Value!=0)
                {
                    
                }
                else
                {
                    MessageBox.Show("Ücret ve Miktar 0'dan Farklı Olmalıdır! Bilgilerinizi Kontrol Ediniz!!!");
                }
            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!!!");
            }
        }

        //private void DoubleUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        //{
        //    string text = doubleUD.Text.Replace('.', ',');
        //    double sayi =double.Parse(text);

        //}
    }
}
