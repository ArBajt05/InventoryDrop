using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InventoryDroppingPlugin
{
    public class Configuration : IRocketPluginConfiguration
    {
        public bool ShouldShowDropMessage;
        public string DropMessageIcon;

        public void LoadDefaults()
        {
            ShouldShowDropMessage = true;
            DropMessageIcon = "";
        }
    }
}

