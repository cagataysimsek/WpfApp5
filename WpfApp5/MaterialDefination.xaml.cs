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
    /// Interaction logic for MaterialDefination.xaml
    /// </summary>
    public partial class MaterialDefination : Window
    {
        StockAutomationDBContext context = new StockAutomationDBContext();
        public MaterialDefination()
        {
            InitializeComponent();
        }

        private void buttonEkle_Click(object sender, RoutedEventArgs e)
        {
            if (radioAdd.IsChecked == true)
            {
                if (!string.IsNullOrEmpty(comboMaterialName.Text) && comboOlcuBirimi.SelectedValue != null)
                {
                    var item = (from x in context.Materials where x.MaterialName == comboMaterialName.Text select x).FirstOrDefault();
                    if (item == null)
                    {
                        var NewItem = new Material();
                        NewItem.MaterialName = comboMaterialName.Text;
                        NewItem.DefId = Convert.ToInt32(comboOlcuBirimi.SelectedValue);
                        context.Materials.Add(NewItem);
                        context.SaveChanges();
                        MessageBox.Show(comboMaterialName.Text + " Materyali " + comboOlcuBirimi.Text + " Ölçü Birimiyle Sisteme Kayıt Edildi.");
                        comboMaterialName.Text = "";
                        comboOlcuBirimi.SelectedValue = null;
                        comboMaterialNameShow();
                        radioAdd.IsChecked = false;
                    }
                    else
                    {
                        MessageBox.Show(comboMaterialName.Text + " Materyali Zaten Var.");
                        comboMaterialName.Text = "";
                        comboOlcuBirimi.SelectedValue = null;
                        radioAdd.IsChecked = false;
                    }
                }
                else
                {
                    MessageBox.Show("Materyal Adı veya Ölçü Birimi Boş Bırakılamaz!");
                }
            }
            else
            {
                MessageBox.Show("Gerçekleştirilecek İşlemi Doğru İşaretlemediniz!");
            }


        }

        private void comboMaterialNameShow()
        {
            comboMaterialName.ItemsSource = context.Materials.ToList();
            comboMaterialName.DisplayMemberPath = "MaterialName";
            comboMaterialName.SelectedValuePath = "Id";
        }

        private void buttonGuncelle_Click(object sender, RoutedEventArgs e)
        {
        }

        private void buttonSil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboOlcuBirimi.ItemsSource = context.Definations.Where(x => x.DefType == 2).ToList();
            comboOlcuBirimi.DisplayMemberPath = "DefValue";
            comboOlcuBirimi.SelectedValuePath = "Id";
            comboMaterialNameShow();
        }

        private void comboMaterialName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (radioGüncelle.IsChecked==true && comboMaterialName.SelectedValue!=null)
            {
                var item = context.Materials.Where(x => x.Id == Convert.ToInt32(comboMaterialName.SelectedValue)).FirstOrDefault();
                comboOlcuBirimi.SelectedValue = item.DefId;
            }
            


        }

        private void radioGüncelle_Checked(object sender, RoutedEventArgs e)
        {
            comboMaterialName.IsEditable = true;
            comboMaterialName.Text = null;
            comboOlcuBirimi.Text = null;
        }
        private void radioAdd_Checked(object sender, RoutedEventArgs e)
        {
            comboMaterialName.IsEditable = true;
            comboMaterialName.Text = null;
            comboOlcuBirimi.Text = null;
            

        }
    }
}
