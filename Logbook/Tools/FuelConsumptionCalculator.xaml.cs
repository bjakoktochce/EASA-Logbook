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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Logbook.Tools
{
    /// <summary>
    /// Interaction logic for FuelConsumptionCalculator.xaml
    /// </summary>
    public partial class FuelConsumptionCalculator : Window
    {
        public FuelConsumptionCalculator()
        {
            InitializeComponent();
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void TextBoxConsumptionPerHour_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private void TextBoxTimeOfFlight_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxConsumptionPerHour.Text.Length == 0)
            {
                TextBoxConsumptionPerHour.BorderBrush = Brushes.Red;
            }
            //else TextBoxTimeOfFlight.BorderBrush = Brushes.Black;

            if (TextBoxTimeOfFlight.Text.Length == 0)
            {
                TextBoxTimeOfFlight.BorderBrush = Brushes.Red;
            }

            //else TextBoxTimeOfFlight.BorderBrush = Brushes.Black;

            if ((TextBoxConsumptionPerHour.Text.Length != 0) && (TextBoxTimeOfFlight.Text.Length != 0))
            {
                Double fuelNeeded = 0;
                fuelNeeded = Convert.ToDouble(TextBoxConsumptionPerHour.Text) * Convert.ToDouble(TextBoxTimeOfFlight.Text) / 60;

                TextBoxFuelNeeded.Text = Convert.ToString(fuelNeeded);

            }
           
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }       
    }
}
