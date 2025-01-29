using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using ProjectManager.Klassen;
using ProjectManager.Programm.Seiten;

namespace ProjectManager.Programm
{
    
    public partial class Start : Window
    {
        BauProjektList bauProjekte = new BauProjektList();

        public Start()
        {
            InitializeComponent();
            BauProjektManager.InitializeXMLBauprojekte(bauProjekte);
            bauProjekte = BauProjektManager.LoadBauProjekteListeFromXML();
            RefreshDataInListBoxItem();
        }
        private void BtnCl_AngeboteAbgegeben(object sender, RoutedEventArgs e)
        {
            newObjectStackPanel.Visibility = Visibility.Hidden;
        }
        public void BtnCl_AktuelleObjekte(object sender, RoutedEventArgs e)        
        {
            newObjectStackPanel.Visibility = Visibility.Hidden;
        }
        public void BtnCl_AlteObjekte(object sender, RoutedEventArgs e)
        {
            newObjectStackPanel.Visibility = Visibility.Hidden;
        }
        private void BtnCl_NeuesObjektAnlegen(object sender, RoutedEventArgs e)
        {
            newObjectStackPanel.Visibility = Visibility.Visible;
        }
        private void BtnCl_NewObjectOK(object sender, RoutedEventArgs e)
        {
            BauProjektManager.AddBauprojekt(bauProjekte, newObject_Objektbezeichnung_StackPanelField.Text, newObject_Ort_StackPanelField.Text);
            RefreshDataInListBoxItem();
            newObjectStackPanel.Visibility = Visibility.Hidden;
            newObject_Objektbezeichnung_StackPanelField.Text = "";
            newObject_Ort_StackPanelField.Text = "";
        }
        private void DblCl_ListItems(object sender, MouseButtonEventArgs e)
        {
            ListBox listBox = (ListBox)sender;            
            long tempLong = GetIDasLong(listBox.SelectedItem as string);
            try
            {
                var selectedObjectWithID = (from bauprojekt in bauProjekte
                                            where bauprojekt.o_ID == tempLong
                                            select bauprojekt).First();
                Window objektWindow = new ObjektFenster(selectedObjectWithID);
                objektWindow.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
            
           
        }
        private long GetIDasLong(string stringFromLabel)
        {              
            char[] temp = new char[14];
            long id = 0;
            for (int i = 0; i < 14; i++)
            {     
                temp[i] = stringFromLabel[stringFromLabel.Length + i-14];
            }
            string tempString = new string(temp);
            return id = (long)Convert.ToInt64(tempString);
        }

        private void RefreshDataInListBoxItem()
        {
            ListDisplay.Items.Clear();
            foreach (BauProjekt bp in bauProjekte)
            {
                
                ListDisplay.Items.Add($"{bp.o_Ort}, {bp.o_Bezeichnung}, {bp.o_ID}");
            }          
        }        
    }
}
