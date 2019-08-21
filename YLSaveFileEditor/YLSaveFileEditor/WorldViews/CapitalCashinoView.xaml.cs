using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YLSaveFileEditor.WorldViews
{
    /// <summary>
    /// Interaction logic for CapitalCashinoView.xaml
    /// </summary>
    public partial class CapitalCashinoView : UserControl
    {
        public CapitalCashinoView()
        {
            InitializeComponent();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            generalWorldView.lockedRadioButton.IsChecked = true;
            generalWorldView.allPagiesCheckBox.IsChecked = false;
            generalWorldView.allQuillsCheckBox.IsChecked = false;
            generalWorldView.healthExtenderCheckBox.IsChecked = false;
            generalWorldView.powerExtenderCheckBox.IsChecked = false;
            generalWorldView.allGhostWritersCheckBox.IsChecked = false;
            generalWorldView.PlayCoinCheckBox.IsChecked = false;
            generalWorldView.MollycoolCheckBox.IsChecked = false;
            allCashinoChipsCheckBox.IsChecked = false;
            spentCasinoChipsTextBox.Text = "0";
            foreach (var item in gameStatsDataGrid.ItemsSource.Cast<GameStat>().ToList())
            {
                item.Value = 0;
            }
        }
    }
}
