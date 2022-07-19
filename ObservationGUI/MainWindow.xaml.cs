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
using ObservationDAL;

namespace ObservationGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservationBL.IBL bl;

        public MainWindow()
        {
            InitializeComponent();
            observationMeansListView.ItemsSource = bl.ShowAllObservation();
            cbFilterByType.ItemsSource = Enum.GetValues(typeof(types));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //new AddObservation(bl).ShowDialog();
            //observationMeansListView.ItemsSource = bl.ShowAllObservation();


        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            deleteOk.Visibility = Visibility.Visible;
            codeToDelete.Visibility = Visibility.Visible;
            labelCode.Visibility = Visibility.Visible;
        }

        private void deleteOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.DeleteObservation(Convert.ToInt32(codeToDelete.Text));
                MessageBox.Show("The observation means has been successfully deleted");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            deleteOk.Visibility = Visibility.Hidden;
            codeToDelete.Visibility = Visibility.Hidden;
            labelCode.Visibility = Visibility.Hidden;
        }

        private void filterOK_Click(object sender, RoutedEventArgs e)
        {
            observationMeansListView.ItemsSource = bl.ShowObservationByType(cbFilterByType.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            observationMeansListView.ItemsSource = bl.ShowObservationSortedByRange();
        }

        private void showMinimum_Click(object sender, RoutedEventArgs e)
        {
            observationMeansListView.Items[0] = bl.ObservationWithFarthestRangeByMinimalFieldOfView(Convert.ToDouble(minimumField.Text));
            showMinimum.Visibility = Visibility.Hidden;
            minimumField.Visibility = Visibility.Hidden;
            lableMin.Visibility = Visibility.Hidden;
        }

        private void FarthestRangeWithMinimumField_Click(object sender, RoutedEventArgs e)
        {
            showMinimum.Visibility = Visibility.Visible;
            minimumField.Visibility = Visibility.Visible;
            lableMin.Visibility = Visibility.Visible;

        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            observationMeansListView.ItemsSource = bl.ShowAllObservation();

        }
    }
}
