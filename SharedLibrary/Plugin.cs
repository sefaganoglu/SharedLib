using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class Plugin
    {
        public string MenuTitle { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public List<Plugin> Menu { get; set; }
    }
}
