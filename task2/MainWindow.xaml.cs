using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Appointment> _appointments;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Appointment> Appointments
        {
            get => _appointments;
            set
            {
                _appointments = value;
                OnPropertyChanged(nameof(Appointments));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Appointments = new ObservableCollection<Appointment>();
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParseExact(timeTextBox.Text, "HH:mm", null, System.Globalization.DateTimeStyles.None, out _))
            {
                string newAppointmentTime = timeTextBox.Text;

                if (!Appointments.Any(appointment => appointment.Time == newAppointmentTime))
                {
                    var newAppointment = new Appointment { Time = newAppointmentTime };
                    Appointments.Add(newAppointment);
                    timeTextBox.Clear();
                }
                else { MessageBox.Show("Time already taken."); }
            }
            else { MessageBox.Show("Invalid time format."); }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Appointment
    {
        public string Time { get; set; }
    }
}
