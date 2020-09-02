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
    /// Interaction logic for MaterialUpdate.xaml
    /// </summary>
    public partial class MaterialUpdate : Window
    {
        public int previusMaterialId;
        StockAutomationDBContext context = new StockAutomationDBContext();
        public MaterialUpdate()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboOlcuBirimi.ItemsSource = context.Definations.Where(x => x.DefType == (int)Definition.Unit).ToList();
            comboOlcuBirimi.DisplayMemberPath = "DefValue";
            comboOlcuBirimi.SelectedValuePath = "Id";
            comboMaterialName.ItemsSource = context.Materials.ToList();
            comboMaterialName.DisplayMemberPath = "MaterialName";
        }

        private void buttonGüncellemeİsleminiTamamla_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(comboMaterialName.Text) && comboOlcuBirimi.SelectedValue != null)
            {
                var item = context.Materials.Where(x => x.Id == previusMaterialId).FirstOrDefault();
                if (comboMaterialName.Text == lblMaterialName.Content.ToString())
                {
                    item.DefId = (int)comboOlcuBirimi.SelectedValue;
                    context.SaveChanges();
                    MessageBox.Show("Güncelleme Öncesi: \nMateryal Adı:" + lblMaterialName.Content + " ,Materyalin Ölçü Birimi:" + lblMeasurementUnit.Content + "\nGüncelleme Sonrası:\nMateeryal Adı:" + comboMaterialName.Text + " ,Materyal Ölçü Birimi:" + comboOlcuBirimi.Text);
                    this.Close();
                }
                else if (comboMaterialName.Text != lblMaterialName.Content.ToString())
                {
                    var item2 = context.Materials.Where(x => x.MaterialName == comboMaterialName.Text).FirstOrDefault();
                    if (item2 == null)
                    {
                        item.MaterialName = comboOlcuBirimi.Text;
                        item.DefId = (int)comboOlcuBirimi.SelectedValue;
                        context.SaveChanges();
                        MessageBox.Show("Güncelleme Öncesi: \nMateryal Adı:" + lblMaterialName.Content + " ,Materyalin Ölçü Birimi:" + lblMeasurementUnit.Content + "\nGüncelleme Sonrası:\nMateeryal Adı:" + comboMaterialName.Text + " ,Materyal Ölçü Birimi:" + comboOlcuBirimi.Text);
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show(comboMaterialName.Text + " Adında Bir Materyal Zaten Bulunuyor!!!");
                        comboMaterialName.Text = "";
                        comboOlcuBirimi.SelectedValue = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Herhangi Bir Alan Boş Bırakılamaz!!!");
            }

        }


        //var item = context.Materials.Where(x => x.MaterialName == comboMaterialName.Text).FirstOrDefault();
        //if (item == null)
        //{
        //    var item2 = context.Materials.Where(x => x.Id == previusMaterialId).FirstOrDefault();
        //    item2.MaterialName = comboMaterialName.Text;
        //    item2.DefId = (int)comboOlcuBirimi.SelectedValue;
        //}
        //else
        //{
        //    MessageBox.Show(comboMaterialName.Text + " Adında Bir Materyal Zaten Bulunuyor!!!");
        //    comboMaterialName.Text = "";
        //    comboOlcuBirimi.SelectedValue = null;
        //}



    }
}

