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
using ObservationBL;


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
            bl = new BL();
            DataSource.Initialize();
            observationMeansListView.ItemsSource = bl.ShowAllObservation();
            cbFilterByType.ItemsSource = Enum.GetValues(typeof(types));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddObservation(bl).ShowDialog();
            //observationMeansListView.ItemsSource = bl.ShowAllObservation();

            observationMeansListView.ItemsSource = DataSource.Observation;

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
                int x = Convert.ToInt32(codeToDelete.Text);
                bl.DeleteObservation(x);
                MessageBox.Show("The observation means has been successfully deleted");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            deleteOk.Visibility = Visibility.Hidden;
            codeToDelete.Visibility = Visibility.Hidden;
            labelCode.Visibility = Visibility.Hidden;
            observationMeansListView.ItemsSource = bl.ShowAllObservation();

        }

        private void filterOK_Click(object sender, RoutedEventArgs e)
        {
            observationMeansListView.ItemsSource = bl.ShowObservationByType((types)cbFilterByType.SelectedItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            observationMeansListView.ItemsSource = bl.ShowObservationSortedByRange();
        }

        private void showMinimum_Click(object sender, RoutedEventArgs e)
        {
            List<MeansOfObservation> l = new List<MeansOfObservation>();
            l.Add(bl.ObservationWithFarthestRangeByMinimalFieldOfView(Convert.ToDouble(minimumField.Text)));
            observationMeansListView.ItemsSource = l;
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
