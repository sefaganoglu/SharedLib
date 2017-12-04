using SharedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string GetExePath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace(@"file:\", "");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.LoadFrom($"{GetExePath()}\\Plugins\\UIPlugin.dll");
            var type = assembly.GetType("UIPlugin.MenuProvider");

            var method = type.GetMethod("GetMenuList", BindingFlags.Instance | BindingFlags.Public);

            var instance = Activator.CreateInstance(type);


            var result = method.Invoke(instance, null);

            AddMenuItem((List<Plugin>)result);
        }

        private void AddMenuItem(List<Plugin> menuItems, ToolStripItem toolStripItem = null)
        {
            foreach (Plugin menuItem in menuItems)
            {
                ToolStripItem toolStripItemX = toolStripItem == null ? menuStrip1.Items.Add(menuItem.MenuTitle) : (toolStripItem is ToolStripMenuItem ? ((ToolStripMenuItem)toolStripItem).DropDownItems.Add(menuItem.MenuTitle) : null);
                if (toolStripItemX != null && menuItem.Menu?.Count > 0)
                    AddMenuItem(menuItem.Menu, toolStripItemX);
            }

        }

    }
}
