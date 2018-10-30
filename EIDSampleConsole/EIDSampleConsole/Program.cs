using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace EIDSampleConsole
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var model = Controller.CreateFromEIDReader();
            if (model.HasData)
            {
                Clipboard.SetText(Newtonsoft.Json.JsonConvert.SerializeObject(model));
            }
            else
                Clipboard.SetText("NO DATA");
        }
    }
}
