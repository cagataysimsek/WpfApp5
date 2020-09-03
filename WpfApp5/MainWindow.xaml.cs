using Models.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ParaBirimiTanimlama_Click(object sender, RoutedEventArgs e)
        {
            CurrencyDefination currency = new CurrencyDefination();
            currency.ShowDialog();
        }
        private void OlcuBirimiTanımla_Click(object sender, RoutedEventArgs e)
        {
            MeasurementUnitDefination measurementUnitDefination = new MeasurementUnitDefination();
            measurementUnitDefination.ShowDialog();
        }
        private void BussinessTypeTanimlama_Click(object sender, RoutedEventArgs e)
        {
            BussinessTypeDefination bussiness = new BussinessTypeDefination();
            bussiness.ShowDialog();
        }
        private void DagiticiTanimlama_Click(object sender, RoutedEventArgs e)
        {
            DealerDefination dealer = new DealerDefination();
            dealer.ShowDialog();
        }
        private void IstasyonTanimlama_Click(object sender, RoutedEventArgs e)
        {
            StationDefination station = new StationDefination();
            station.ShowDialog();
        }
        private void TedarikciTanimle_Clk(object sender, RoutedEventArgs e)
        {
            SupplierDefination supplier = new SupplierDefination();
            supplier.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MaterialInputOutput material = new MaterialInputOutput();
            material.ShowDialog();
        }
        private void MateryalTanimla_Click(object sender, RoutedEventArgs e)
        {
            MaterialDefination mt = new MaterialDefination();
            mt.ShowDialog();
           
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Recipt recipt = new Recipt();
            recipt.ShowDialog();
        }
    }
}
