using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


namespace ProjectManager.Klassen
{
    static class BauProjektManager
    {
        public static string XMLBauprojektePath = @"D:\Sicherung 29.082023\vs2019\ProjectManager\ProjectManager\bin\Debug\Objekte.xml";

        public static void InitializeXMLBauprojekte(BauProjektList bauProjekte)
        {
            if (!File.Exists(XMLBauprojektePath))
            {
                FileStream fileStream = new FileStream(XMLBauprojektePath, FileMode.CreateNew);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BauProjektList));
                TextWriter writer = new StreamWriter(fileStream);
                xmlSerializer.Serialize(writer,bauProjekte);
                fileStream.Close();
            }
            else
            {
                
                
            }
        }
        public static void AddBauprojekt(BauProjektList bauProjekte, string bauProjektBaustelle, string bauProjektAusführungsort)
        {
            BauProjekt bauProjekt = new BauProjekt(bauProjektBaustelle, bauProjektAusführungsort);
            bauProjekte.Add(bauProjekt);
            SaveBauProjekteListeToXML(bauProjekte);
        }

        public static void SaveBauProjekteListeToXML(BauProjektList bauProjekte)
        {
            FileStream fileStream = new FileStream(XMLBauprojektePath, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BauProjektList));
            TextWriter writer = new StreamWriter(fileStream);
            xmlSerializer.Serialize(writer, bauProjekte);
            fileStream.Close();
        }   
        public static BauProjektList LoadBauProjekteListeFromXML()
        {
            FileStream fileStream = new FileStream(XMLBauprojektePath, FileMode.Open);
            try
            {                
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BauProjektList));
                return (BauProjektList)xmlSerializer.Deserialize(fileStream);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
