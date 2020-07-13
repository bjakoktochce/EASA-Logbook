using Logbook.Tools;
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

namespace Logbook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            InitializeComponent();
            statusBarText.Text = "Ready";
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FuelConsumptionCalculator fuelConsumptionCalculator = new FuelConsumptionCalculator();
            fuelConsumptionCalculator.ShowDialog();
        }

        private void OptionsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.ShowDialog();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            statusBarText.Text = "Ready";
        }

        private void LogbookAddNewEntryMenuItem_Click(object sender, RoutedEventArgs e)
        {
            LogbookAddNewEntryWindow logbookAddNewEntryWindow = new LogbookAddNewEntryWindow();
            logbookAddNewEntryWindow.ShowDialog();
        }
    }
}
