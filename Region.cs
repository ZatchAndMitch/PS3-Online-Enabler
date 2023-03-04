using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS3_Online_Enabler
{
    public class Region
    {
        private const string updateListTemplate = "# {0}\r\nDest={1};ImageVersion=00000000;SystemSoftwareVersion=0.00;CDN=http://d{2}01.ps3.update.playstation.net/update/ps3/image/{3}/nodata;CDN_Timeout=30;";

        private string name;
        private string code;
        private string number;
        private string updatelist;

        public Region(string code, string number, string name)
        {
            Code = code;
            Number = number;
            Name = name;
            generateUpdateList();
        }

        private void generateUpdateList() => updatelist = String.Format(updateListTemplate, Code.ToUpper(), Number, Code, Code);

        public string Code { get => code; set => code = value; }
        public string Number { get => number; set => number = value; }
        public string Name { get => name; set => name = value; }
        public string UpdateList { get => updatelist; }
    }
}
