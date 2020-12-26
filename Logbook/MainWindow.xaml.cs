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
using System.Data.SQLite;

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
            //Imported.ItemsSource = LoadCollectionData();
            Database database = new Database();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //string messageBoxText = "Do you really want to exit ?";
            //string caption = "Logbook";
            //MessageBoxButton button = MessageBoxButton.OKCancel;
            //MessageBoxImage icon = MessageBoxImage.Warning;
            //MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            //switch (result)
            //{
            //    case MessageBoxResult.Cancel:
            //        break;
            //    case MessageBoxResult.OK:
            //        this.Close();
            //        break;
            //}
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

        private void OpenFIleMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Logbook"; 
            dlg.DefaultExt = ".db"; 
            dlg.Filter = "Logbook Database file (.db)|*.db"; 

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;

                Database.LoadDatabase(filename);
            }

            Imported.ItemsSource = Database.flights;
        }

        private void SaveAsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Logbook";
            dlg.DefaultExt = ".db"; 
            dlg.Filter = "Logbook Databse File (.db)|*.db"; 

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
            }

            
        }

        private void MassAndBalanceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MassAndBalance massAndBalance = new MassAndBalance();
            massAndBalance.ShowDialog();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Database.NewDatabase();
        }
    }
}
