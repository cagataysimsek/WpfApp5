﻿using Models;
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
    /// Interaction logic for DealerUpdate.xaml
    /// </summary>
    public partial class DealerUpdate : Window
    {
        StockAutomationDBContext context = new StockAutomationDBContext();
        public DealerUpdate()
        {
            InitializeComponent();
        }

        private void buttonGüncellemeİsleminiTamamla_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(comboDealerName.Text))
            {
                var item = (from x in context.Dealers where x.DealerName == comboDealerName.Text.ToString() select x).FirstOrDefault();
                if (item == null)
                {
                    var item2 = (from x in context.Dealers where x.DealerName == lblDealer.Content.ToString() select x).FirstOrDefault();
                    item2.DealerName = comboDealerName.Text;
                    context.SaveChanges();
                    MessageBox.Show(lblDealer.Content + " Dağıtıcısının Adı " + comboDealerName.Text + " Olarak Değiştirildi.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(comboDealerName.Text + " Dağıtıcısı Daha Once Tanımlanmış! Lütfen Başka Sistemde Olmayan Bir isim Giriniz!");
                    comboDealerName.SelectedValue = null;
                }

            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!");
            }
        }
    }
}
