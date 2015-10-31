using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExtensibleUIAttribute;

namespace ExtensibleGUI
{
    public partial class ExtensibleGUI : Form
    {
        private readonly string pluginsPath = 
            ConfigurationManager.AppSettings["pluginsPath"];

        public ExtensibleGUI()
        {
            InitializeComponent();
            LoadPlugins(pluginsPath);
        }

        private IEnumerable<FileInfo> GetFileInfoFromPath(string path)
        {
            if (Directory.Exists(path))
            {
                return new DirectoryInfo(path).GetFiles();
            }
            throw new DirectoryNotFoundException(@"Plugins directory doesn't exist");
        }

        private void LoadPlugins(string pluginsPath)
        {
            foreach (var fileInfo in GetFileInfoFromPath(pluginsPath))
            {
                Assembly assembly = null;
                try
                {
                    assembly = Assembly.LoadFile(fileInfo.FullName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Unable to load assembly {0}: {1} warning",
                        fileInfo.Name, ex));
                }
                if (assembly != null)
                {
                    HandlePluginAssembly(assembly);
                }
            }
        }

        private void HandlePluginAssembly(Assembly assembly)
        {
            var assemblyTypes = assembly.GetTypes();
            foreach (var type in assemblyTypes)
            {
                if (type.BaseType == typeof (Form))
                {
                    HandleEmbedForms(type);
                }
            }
        }

        private void HandleEmbedForms(Type type)
        {
            object[] attributes = type.GetCustomAttributes(false);
            foreach (object attribute in attributes)
            {
                if (attribute is PanelLayoutAttribute)
                {
                    HandleLayoutAttribute(attribute as PanelLayoutAttribute, type);
                }
                if (attribute is TabLayoutAttribute)
                {
                    HandleLayoutAttribute(attribute as TabLayoutAttribute, type);
                }
                if (attribute is GroupBoxLayoutAttribute)
                {
                    HandleLayoutAttribute(attribute as GroupBoxLayoutAttribute, type);
                }
            }
        }

        private void HandleLayoutAttribute(GroupBoxLayoutAttribute groupBoxLayoutAttribute, Type type)
        {
            Form form = (Form)type.GetConstructor(new Type[0]).Invoke(null);
            form.Hide();
        }

        private void HandleLayoutAttribute(TabLayoutAttribute tabLayoutAttribute, Type type)
        {
            Form form = (Form)type.GetConstructor(new Type[0]).Invoke(null);
            form.Hide();
        }

        private void HandleLayoutAttribute(PanelLayoutAttribute attribute, Type type)
        {
            Form form = (Form)type.GetConstructor(new Type[0]).Invoke(null);
            form.Hide();
            var controls = new Control[form.Controls.Count];
            form.Controls.CopyTo(controls, 0);
            panelLeft.Controls.AddRange(controls);
            panelLeft.Size = form.Size;
        }
    }
}
