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
using ProjectManager.Programm;
using System.Xml.Linq;


namespace ProjectManager
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //XElement xuserdata = XElement.Load(@"D:\Sicherung 29.082023\vs2019\ProjectManager\ProjectManager\bin\Debug\User.xml");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            TryToLoggin(e.Key);
        }
        public void TryToLoggin(Key Key)
        {

           
            /*if (Key == Key.Enter)
            {
                var user = from xuser in xuserdata.Descendants("User")
                           where xuser.Element("Name").Value == _textbox_Username.Text && xuser.Element("Passwort").Value == _passwordbox_Passwort.Password
                                   select xuser ;
                if (user.Count() == 1)
                {
                    Start startrWindow = new Start();
                    startrWindow.Show();
                    Close();
                }
                else if(user.Count() == 0)
                {
                    MessageBox.Show("Nutzername oder Passwort waren falsch oder exextieren nicht.");
                }
                else
                {
                    MessageBox.Show("Ein fehler ist Aufgetreten. Loggindaten wurden mehrfach vergeben. Kontaktieren Sie bitte den Administrator.");
                };
            }
            */

//Das Hier ist der Debbug login, deaktivieren bei launch
            if (Key == Key.Enter)
            {
                Start startrWindow = new Start();
                startrWindow.Show();
                Close();
            }
            
        }
    }
}
