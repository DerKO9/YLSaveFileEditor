using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace YLSaveFileEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // here you take control
            //MessageBox.Show("Startup");
            AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) =>
            {
                MessageBox.Show("A fatal error occurred.\nCheck to see if your save file is valid and up to date. \n \n"
                    + eventArgs.ExceptionObject.ToString(), "Error ¯\\_(ツ)_/¯", MessageBoxButton.OK, MessageBoxImage.Error);
            };
        }
    }
}
