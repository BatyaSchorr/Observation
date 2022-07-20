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
    /// Interaction logic for AddObservation.xaml
    /// </summary>
    public partial class AddObservation : Window
    {
        private ObservationBL.IBL bl;
        private static int code = 1;
        public AddObservation(ObservationBL.IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
            cbType.ItemsSource = Enum.GetValues(typeof(types));

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (cbType.Text == "")
                {
                    throw new Exception("No type selected");
                }
                if (Convert.ToInt32(FieldOfVision.Text) > 360)
                {
                    throw new Exception("Field of view cannot be above 360 degrees");
                }
                bl.AddObservation(new MeansOfObservation(code++, (types)cbType.SelectedItem, Convert.ToDouble(range.Text), Convert.ToDouble(FieldOfVision.Text)));
                MessageBox.Show("The Observation successfully added");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
