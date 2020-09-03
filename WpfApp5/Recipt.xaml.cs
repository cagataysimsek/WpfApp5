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
using  System.Drawing;
using Xceed.Wpf.Toolkit;
using Point = System.Windows.Point;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for Recipt.xaml
    /// </summary>
    public partial class Recipt : Window
    {
        public Recipt()
        {
            InitializeComponent();
        }
        int x = 0;
        int y = 0;
        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;
        int e = 0;
        int f = 0;
        int i = 0;
        private void btnMaterialCreate_Click(object sender, RoutedEventArgs e)
        {
            TextBox tb = new TextBox();
            tb.Text = "Hammadde Adı : ";
            tb.Name = "btn"+i;
            tb.Margin = new Thickness(0, y, 0, 0);
            this.canContainer.Children.Add(tb);
            y += 40;

            ComboBox cb = new ComboBox();
            cb.Width = 100;
            cb.Name = "combo" + i;
            cb.Margin = new Thickness(120,b,0,0);
            this.canContainer.Children.Add(cb);
            b += 40;

            TextBox tb1 = new TextBox();
            tb1.Text = "Ölçü birimi : ";
            tb1.Name = "btn" + i;
            tb1.Margin = new Thickness(260, a, 0, 0);
            this.canContainer.Children.Add(tb1);
            a += 40;

            ComboBox cb1 = new ComboBox();
            cb1.Width = 100;
            cb1.Name = "comboOlcu" + i;
            cb1.Margin = new Thickness(345, d, 0, 0);
            this.canContainer.Children.Add(cb1);
            d += 40;

            TextBox tb2 = new TextBox();
            tb2.Text = "Miktar : ";
            tb2.Name = "btn" + i;
            tb2.Margin = new Thickness(470, c, 0, 0);
            this.canContainer.Children.Add(tb2);
            c += 40;


            DoubleUpDown upDown = new DoubleUpDown();
            upDown.Width = 100;
            upDown.Name = "updown" + i;
            upDown.Margin = new Thickness(530,f,0,0);
            this.canContainer.Children.Add(upDown);
            f += 40;


            i++;


        }
    }
}
