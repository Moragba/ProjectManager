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
using System.Windows.Shapes;
using ProjectManager.Programm;
using System.Xml.Linq;
using ProjectManager.Klassen;



namespace ProjectManager.Programm.Seiten
{
    public partial class ObjektFenster : Window
    {
        BauProjektList bauProjekte = new BauProjektList();
        
        //Stammdaten Eigenschaften
        bool EditModeOn = false;
        BauProjekt CurrentBauprojekt;
        List<TextBox> TextBoxList = new List<TextBox>();

        public ObjektFenster(BauProjekt bauProjekt)
        {
            InitializeComponent();
            BauProjektManager.InitializeXMLBauprojekte(bauProjekte);
            bauProjekte = BauProjektManager.LoadBauProjekteListeFromXML();
            _headerLabel.Content = $"{bauProjekt.o_Ort}, {bauProjekt.o_Bezeichnung}";
            CurrentBauprojekt = bauProjekt;
            LoadBauprojektDataIntoTextFields();
            InitializeTextBoxList();
        }       

        //Stammdaten Logic
        private void Bearbeiten_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.Visibility = Visibility.Hidden;
            Speichern_Button.Visibility = Visibility.Visible;
            ObjektLöschen_Button.Visibility = Visibility.Visible;
            EditModeOn = true;
            AkitvateEditMode(EditModeOn);
        }
        private void InitializeTextBoxList()
        {
            TextBoxList.Add(tb_01);
            TextBoxList.Add(tb_02);
            TextBoxList.Add(tb_03);
            TextBoxList.Add(tb_04);
            TextBoxList.Add(tb_05);
            TextBoxList.Add(tb_06);
            TextBoxList.Add(tb_07);
            TextBoxList.Add(tb_08);
            TextBoxList.Add(tb_09);
            TextBoxList.Add(tb_10);
            TextBoxList.Add(tb_11);
            TextBoxList.Add(tb_12);
            TextBoxList.Add(tb_13);
            TextBoxList.Add(tb_14);
            TextBoxList.Add(tb_15);
            TextBoxList.Add(tb_16);
            TextBoxList.Add(tb_17);
            TextBoxList.Add(tb_18);

        }
        private void AkitvateEditMode(bool editmodeon)
        {
            if (editmodeon)
            {
                foreach(TextBox tb in TextBoxList)
                {
                    tb.IsReadOnly = false;
                    tb.Background = Brushes.DeepSkyBlue;
                }
            }
        }
        private void DeakitvateEditMode(bool editmodeon)
        {
            if (!editmodeon)
            {
                foreach (TextBox tb in TextBoxList)
                {
                    tb.IsReadOnly = true;
                    tb.Background = Brushes.Gray;
                }
            }
        }
        private void Speichern_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.Visibility = Visibility.Hidden;
            Bearbeiten_Button.Visibility = Visibility.Visible;
            ObjektLöschen_Button.Visibility = Visibility.Hidden;
            EditModeOn = false;
            DeakitvateEditMode(EditModeOn);
            SaveBauprojektDataIntoBauprojekt();


// und hier noch das einfügen der datei in die liste und serialisieren
        }
        private void objekt_fenster_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window startwindow = new Start();
            startwindow.Show();
        }
        private void LoadBauprojektDataIntoTextFields()
        {
            Objektstatus.Text = CurrentBauprojekt.Objektstatus;

            tb_01.Text = CurrentBauprojekt.ag_Bezeichnung;
            tb_02.Text = CurrentBauprojekt.ag_Bezeichnung2;
            tb_03.Text = CurrentBauprojekt.ag_Straße;
            tb_04.Text = CurrentBauprojekt.ag_Hausnummer;
            tb_05.Text = CurrentBauprojekt.ag_Postleitzahl;
            tb_06.Text = CurrentBauprojekt.ag_Ort;

            tb_07.Text = CurrentBauprojekt.ab_Bezeichnung;
            tb_08.Text = CurrentBauprojekt.ab_Bezeichnung2;
            tb_09.Text = CurrentBauprojekt.ab_Straße;
            tb_10.Text = CurrentBauprojekt.ab_Hausnummer;
            tb_11.Text = CurrentBauprojekt.ab_Postleitzahl;
            tb_12.Text = CurrentBauprojekt.ab_Ort;

            tb_13.Text = CurrentBauprojekt.o_Bezeichnung;
            tb_14.Text = CurrentBauprojekt.o_Bezeichnung2;
            tb_15.Text = CurrentBauprojekt.o_Straße;
            tb_16.Text = CurrentBauprojekt.o_Hausnummer;
            tb_17.Text = CurrentBauprojekt.o_Postleitzahl;
            tb_18.Text = CurrentBauprojekt.o_Ort;
        }
        private void SaveBauprojektDataIntoBauprojekt()
        {
            var selectedObjectWithID = (from bauprojekt in bauProjekte
                                        where bauprojekt.o_ID == CurrentBauprojekt.o_ID
                                        select bauprojekt).First();

            selectedObjectWithID.ag_Bezeichnung = tb_01.Text;
            selectedObjectWithID.ag_Bezeichnung2 = tb_02.Text;
            selectedObjectWithID.ag_Straße = tb_03.Text;
            selectedObjectWithID.ag_Hausnummer = tb_04.Text;
            selectedObjectWithID.ag_Postleitzahl = tb_05.Text;
            selectedObjectWithID.ag_Ort = tb_06.Text;

            selectedObjectWithID.ab_Bezeichnung = tb_07.Text;
            selectedObjectWithID.ab_Bezeichnung2 = tb_08.Text;
            selectedObjectWithID.ab_Straße = tb_09.Text;
            selectedObjectWithID.ab_Hausnummer = tb_10.Text;
            selectedObjectWithID.ab_Postleitzahl = tb_11.Text;
            selectedObjectWithID.ab_Ort = tb_12.Text;

            selectedObjectWithID.o_Bezeichnung = tb_13.Text;
            selectedObjectWithID.o_Bezeichnung2 = tb_14.Text;
            selectedObjectWithID.o_Straße = tb_15.Text;
            selectedObjectWithID.o_Hausnummer = tb_16.Text;
            selectedObjectWithID.o_Postleitzahl = tb_17.Text;
            selectedObjectWithID.o_Ort = tb_18.Text;

            BauProjektManager.SaveBauProjekteListeToXML(bauProjekte);
            
        }
        private void ObjektLöschen_Button_Click(object sender, RoutedEventArgs e)
        {
            const string message = "Bist due sicher das du kdieses Objekt dauerhaft löschen möchtest?";
            var result = MessageBox.Show(message, "Objekt löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result!= MessageBoxResult.No)
            {
                var selectedObjectWithID = (from bauprojekt in bauProjekte
                                            where bauprojekt.o_ID == CurrentBauprojekt.o_ID
                                            select bauprojekt).First();
                bauProjekte.Remove(selectedObjectWithID);
                BauProjektManager.SaveBauProjekteListeToXML(bauProjekte);
            }
            this.Close();
        }

        private void Label_Stammdaten_Button_Click(object sender, RoutedEventArgs e)
        {
            Stammdaten_Grid.Visibility = Visibility.Visible;
        }

        private void Label_Placholder01_Button_Click(object sender, RoutedEventArgs e)
        {
            Stammdaten_Grid.Visibility = Visibility.Hidden;

        }
    }    
}
