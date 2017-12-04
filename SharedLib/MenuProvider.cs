using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIPlugin
{
    public class MenuProvider
    {
        public List<Plugin> GetMenuList()
        {
            var result = new List<Plugin>();

            for (int i = 0; i < 3; i++)
            {
                result.Add(new Plugin
                {
                    ActionName = $"ActionName{i}",
                    ControllerName = $"ControllerName{i}",
                    MenuTitle = $"MenuTitle{i}",
                    Menu = new List<Plugin> {
                        new Plugin
                        {
                            ActionName = $"ActionName{i}",
                            ControllerName = $"ControllerName{i}",
                            MenuTitle = $"SubMenuTitle{i}",
                            Menu = new List<Plugin> {  }
                        },
                        new Plugin
                        {
                            ActionName = $"ActionName{i + 1}",
                            ControllerName = $"ControllerName{i + 1}",
                            MenuTitle = $"SubMenuTitle{i + 1}",
                            Menu = new List<Plugin> {  }
                        },
                    }
                });
            }

            return result;
        }
    }
}
