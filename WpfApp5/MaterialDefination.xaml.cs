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
            //if (radioAdd.IsChecked == true)
            //{
            //    if (!string.IsNullOrEmpty(comboMaterialName.Text) && comboOlcuBirimi.SelectedValue != null)
            //    {
            //        var item = (from x in context.Materials where x.MaterialName == comboMaterialName.Text select x).FirstOrDefault();
            //        if (item == null)
            //        {
            //            var NewItem = new Material();
            //            NewItem.MaterialName = comboMaterialName.Text;
            //            NewItem.DefId = Convert.ToInt32(comboOlcuBirimi.SelectedValue);
            //            context.Materials.Add(NewItem);
            //            context.SaveChanges();
            //            MessageBox.Show(comboMaterialName.Text + " Materyali " + comboOlcuBirimi.Text + " Ölçü Birimiyle Sisteme Kayıt Edildi.");
            //            comboMaterialName.Text = "";
            //            comboOlcuBirimi.SelectedValue = null;
            //            comboMaterialNameShow();
            //            radioAdd.IsChecked = false;
            //        }
            //        else
            //        {
            //            MessageBox.Show(comboMaterialName.Text + " Materyali Zaten Var.");
            //            comboMaterialName.Text = "";
            //            comboOlcuBirimi.SelectedValue = null;
            //            radioAdd.IsChecked = false;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Materyal Adı veya Ölçü Birimi Boş Bırakılamaz!");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Gerçekleştirilecek İşlemi Doğru İşaretlemediniz!");
            //}
            if (!string.IsNullOrEmpty(comboMaterialName.Text) && comboOlcuBirimi.SelectedValue!=null)
            {
                var item = context.Materials.Where(x => x.MaterialName == comboMaterialName.Text).FirstOrDefault();
                if (item==null)
                {
                    var newItem = new Material();
                    newItem.MaterialName = comboMaterialName.Text;
                    newItem.DefId =(int) comboOlcuBirimi.SelectedValue;
                    context.Materials.Add(newItem);
                    context.SaveChanges();
                    MessageBox.Show(comboMaterialName.Text+" Kayıdı Başarıyla Eklendi");
                    comboMaterialName.Text = "";
                    comboOlcuBirimi.SelectedValue = null;
                    comboMaterialNameShow();
                }
                else
                {
                    MessageBox.Show(comboMaterialName.Text+" Adında Bir Materyal Zaten Bulunuyor!!!");
                    comboMaterialName.Text = "";
                    comboOlcuBirimi.SelectedValue = null;
                }
            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!");
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
            if (!string.IsNullOrEmpty( comboMaterialName.Text) && comboOlcuBirimi.SelectedValue!=null)
            {
                var item = context.Materials.Where(x => x.MaterialName == comboMaterialName.Text && x.DefId == (int)comboOlcuBirimi.SelectedValue).FirstOrDefault();
                if (item!=null)
                {
                    MaterialUpdate m = new MaterialUpdate();
                    m.lblMaterialName.Content = comboMaterialName.Text;
                    m.lblMeasurementUnit.Content = comboOlcuBirimi.Text;
                    m.previusMaterialId = item.Id;
                    this.Close();
                    m.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ölçü Birimi " + comboOlcuBirimi.Text + " Olan " + comboMaterialName.Text + " Adında Bir Materyal Bulunmamaktadır!!!");
                    comboMaterialName.Text = "";
                    comboOlcuBirimi.SelectedValue = null;
                }
            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!!!");
            }
        }

        private void buttonSil_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty( comboMaterialName.Text) && comboOlcuBirimi.SelectedValue!=null)
            {
                var item = context.Materials.Where(x => x.MaterialName == comboMaterialName.Text && x.DefId == (int)comboOlcuBirimi.SelectedValue).FirstOrDefault();
                if (item != null)
                {
                    context.Materials.Remove(item);
                    context.SaveChanges();
                    MessageBox.Show(comboMaterialName.Text + " Materiyali Başarıyla Silindi.");
                    comboMaterialName.Text = "";
                    comboOlcuBirimi.SelectedValue = null;
                    comboMaterialNameShow();
                }
                else
                {
                    MessageBox.Show("Ölçü Birimi "+comboOlcuBirimi.Text+" Olan "+comboMaterialName.Text + " Adında Bir Materyal Bulunmamaktadır!!!");
                    comboMaterialName.Text = "";
                    comboOlcuBirimi.SelectedValue = null;
                }
            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!!!");
            }
           
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboOlcuBirimi.ItemsSource = context.Definations.Where(x => x.DefType ==(int) Definition.Unit).ToList();
            comboOlcuBirimi.DisplayMemberPath = "DefValue";
            comboOlcuBirimi.SelectedValuePath = "Id";
            comboMaterialNameShow();
        }

    }
}
