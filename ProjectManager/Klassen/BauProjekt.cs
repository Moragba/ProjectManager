using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Klassen
{   [Serializable]
    public class BauProjekt
    {
        //Eigenschaften

        //Allgemeine Eigenschaften
        public string Objektstatus { get; set; }

        //Objekt_Anschrift
        public long o_ID { get; set; }
        public string o_Bezeichnung { get; set; }
        public string o_Bezeichnung2 { get; set; }
        public string o_Postleitzahl { get; set; }
        public string o_Ort { get; set; }
        public string o_Straße { get; set; }
        public string o_Hausnummer { get; set; }

        //Architekten_Anschrift
        public string ab_Bezeichnung { get; set; }
        public string ab_Bezeichnung2 { get; set; }
        public string ab_Postleitzahl { get; set; }
        public string ab_Ort { get; set; }
        public string ab_Straße { get; set; }
        public string ab_Hausnummer { get; set; }

        //Auftraggeber_Anschrift
        public string ag_Bezeichnung { get; set; }
        public string ag_Bezeichnung2 { get; set; }
        public string ag_Postleitzahl { get; set; }
        public string ag_Ort { get; set; }
        public string ag_Straße { get; set; }
        public string ag_Hausnummer { get; set; }



        //Methoden

        public BauProjekt(string bauProjektBaustellenBezeichnung, string bauProjektAusführungsort)
        {
            o_ID = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            o_Ort = bauProjektAusführungsort;
            o_Bezeichnung = bauProjektBaustellenBezeichnung;
            Objektstatus = " Hier Status eingeben";            
        }
        public BauProjekt()
        {

        }
    }

}
