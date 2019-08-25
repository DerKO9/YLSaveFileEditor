using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace YLSaveFileEditor
{
    /// <summary>
    /// Interaction logic for PlayerView.xaml
    /// </summary>
    public partial class PlayerView : UserControl
    {
        public PlayerView()
        {
            InitializeComponent();
        }

        private void AllMovesCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newVal = (AllMovesCheckBox.IsChecked == true);
            CamoCloakCheckBox.IsChecked = newVal;
            SonarShotCheckBox.IsChecked = newVal;
            SonarSplosionCheckBox.IsChecked = newVal;
            SonarShieldCheckBox.IsChecked = newVal;
            RollCheckBox.IsChecked = newVal;
            SlurpShotCheckBox.IsChecked = newVal;
            SlurpStateCheckBox.IsChecked = newVal;
            ReptileRushCheckBox.IsChecked = newVal;
            GlideCheckBox.IsChecked = newVal;
            FlappyFlightCheckBox.IsChecked = newVal;
            BuddySlamCheckBox.IsChecked = newVal;
            LizardLeapCheckBox.IsChecked = newVal;
            BuddyBubbleCheckBox.IsChecked = newVal;
            LizardLashCheckBox.IsChecked = newVal;
            GroundAttackCheckBox.IsChecked = newVal;
            AirAttackCheckBox.IsChecked = newVal;
        }

        private void MoveCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            AllMovesCheckBox.IsChecked = null;
            if ((CamoCloakCheckBox.IsChecked == true) && (SonarShotCheckBox.IsChecked == true)
                && (SonarSplosionCheckBox.IsChecked == true) && (SonarShieldCheckBox.IsChecked == true)
                && (RollCheckBox.IsChecked == true) && (SlurpShotCheckBox.IsChecked == true)
                && (SlurpStateCheckBox.IsChecked == true) && (ReptileRushCheckBox.IsChecked == true)
                && (GlideCheckBox.IsChecked == true) && (FlappyFlightCheckBox.IsChecked == true)
                && (BuddySlamCheckBox.IsChecked == true) && (LizardLeapCheckBox.IsChecked == true)
                && (BuddyBubbleCheckBox.IsChecked == true) && (LizardLashCheckBox.IsChecked == true)
                && (GroundAttackCheckBox.IsChecked == true) && (AirAttackCheckBox.IsChecked == true))
            {
                AllMovesCheckBox.IsChecked = true;
            }
            if ((CamoCloakCheckBox.IsChecked == false) && (SonarShotCheckBox.IsChecked == false)
                && (SonarSplosionCheckBox.IsChecked == false) && (SonarShieldCheckBox.IsChecked == false)
                && (RollCheckBox.IsChecked == false) && (SlurpShotCheckBox.IsChecked == false)
                && (SlurpStateCheckBox.IsChecked == false) && (ReptileRushCheckBox.IsChecked == false)
                && (GlideCheckBox.IsChecked == false) && (FlappyFlightCheckBox.IsChecked == false)
                && (BuddySlamCheckBox.IsChecked == false) && (LizardLeapCheckBox.IsChecked == false)
                && (BuddyBubbleCheckBox.IsChecked == false) && (LizardLashCheckBox.IsChecked == false)
                && (GroundAttackCheckBox.IsChecked == false) && (AirAttackCheckBox.IsChecked == false))
            {
                AllMovesCheckBox.IsChecked = false;
            }
        }

        private void AllTonicsCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newVal = (AllTonicsCheckBox.IsChecked == true);
            WellardCheckBox.IsChecked = newVal;
            BallerCheckBox.IsChecked = newVal;
            SuperSlamCheckBox.IsChecked = newVal;
            BruiserCheckBox.IsChecked = newVal;
            LivewireCheckBox.IsChecked = newVal;
            FallproofCheckBox.IsChecked = newVal;
            HoarderCheckBox.IsChecked = newVal;
            SalmonCheckBox.IsChecked = newVal;
            HunterCheckBox.IsChecked = newVal;
            LoadedCheckBox.IsChecked = newVal;
            PeekabooCheckBox.IsChecked = newVal;
            ButterthreeCheckBox.IsChecked = newVal;
            HeliumCheckBox.IsChecked = newVal;
            AthleteCheckBox.IsChecked = newVal;
            SixtyFourBitCheckBox.IsChecked = newVal;
            PantsCheckBox.IsChecked = newVal;
        }

        private void TonicCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            AllTonicsCheckBox.IsChecked = null;
            if ((WellardCheckBox.IsChecked == true) && (BallerCheckBox.IsChecked == true)
                && (SuperSlamCheckBox.IsChecked == true) && (BruiserCheckBox.IsChecked == true)
                && (LivewireCheckBox.IsChecked == true) && (FallproofCheckBox.IsChecked == true)
                && (HoarderCheckBox.IsChecked == true) && (SalmonCheckBox.IsChecked == true)
                && (HunterCheckBox.IsChecked == true) && (LoadedCheckBox.IsChecked == true)
                && (PeekabooCheckBox.IsChecked == true) && (ButterthreeCheckBox.IsChecked == true)
                && (HeliumCheckBox.IsChecked == true) && (AthleteCheckBox.IsChecked == true)
                && (SixtyFourBitCheckBox.IsChecked == true) && (PantsCheckBox.IsChecked == true))
            {
                AllTonicsCheckBox.IsChecked = true;
            }
            if ((WellardCheckBox.IsChecked == false) && (BallerCheckBox.IsChecked == false)
                && (SuperSlamCheckBox.IsChecked == false) && (BruiserCheckBox.IsChecked == false)
                && (LivewireCheckBox.IsChecked == false) && (FallproofCheckBox.IsChecked == false)
                && (HoarderCheckBox.IsChecked == false) && (SalmonCheckBox.IsChecked == false)
                && (HunterCheckBox.IsChecked == false) && (LoadedCheckBox.IsChecked == false)
                && (PeekabooCheckBox.IsChecked == false) && (ButterthreeCheckBox.IsChecked == false)
                && (HeliumCheckBox.IsChecked == false) && (AthleteCheckBox.IsChecked == false)
                && (SixtyFourBitCheckBox.IsChecked == false) && (PantsCheckBox.IsChecked == false))
            {
                AllTonicsCheckBox.IsChecked = false;
            }
        }

        private bool _haveGivenMacHealthWarning = false;
        private void HealthExtenderTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int x;
            Int32.TryParse(HealthExtenderTextBox.Text, out x);
            if (x > 7 && _haveGivenMacHealthWarning == false)
            {
                MessageBox.Show("Having more than 7 health extenders will cause the game to make an" +
                    " annoying beeping sound, but otherwise the extra health works as expected.",
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                _haveGivenMacHealthWarning = true;
            }
        }
    }
}
