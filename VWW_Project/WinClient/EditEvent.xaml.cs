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
using WinClient.ServiceReference;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for EditEvent.xaml
    /// </summary>
    public partial class EditEvent : Window
    {
        public EventData event2Edit
        {
            get
            {
                return this.event2Edit;
            }

            set
            {
                event2Edit = value;
                SubjectTextBox.Text = event2Edit.subject;
                DescriptionTextBox.Text = event2Edit.description;
                StartDateTimePicker.Value = event2Edit.start;
                EndDateTimePicker.Value = event2Edit.end;
                LocationTextBox.Text = event2Edit.location;
                FullDayCheckBox.IsChecked = event2Edit.isFullDay;
                ShareCheckBox.IsChecked = event2Edit.isShared;
                EventColorPicker.SelectedColor = (Color)ColorConverter.ConvertFromString(event2Edit.themeColor); 

                
            }
        }

        public UserData me
        {
            get
            {
                return this.me;
            }

            set
            {
                me = value;
                UserGreeterText.Text += me.userName;
            }
        }

        public MainWindow mainWindow { get; internal set; }
        public Service1Client clnt { get; private set; }

        public EditEvent()
        {
            InitializeComponent();

            Submit.AddHandler(Button.ClickEvent, new RoutedEventHandler(Submit_Clicked));

            clnt = new Service1Client();

        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            Login lw = new Login();
            lw.Show();
            this.Close();
        }


        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {

            clnt.EditEvent( new EventData()
                {
                    subject = this.SubjectTextBox.Text,
                    description = this.DescriptionTextBox.Text,
                   start = (DateTime)this.StartDateTimePicker.Value,
                    end = (DateTime)this.EndDateTimePicker.Value,
                    location = this.LocationTextBox.Text,
                    isFullDay = (this.FullDayCheckBox.IsChecked ?? true) ? true : false,
                    isShared = (this.ShareCheckBox.IsChecked ?? true) ? true : false,
                    themeColor = this.EventColorPicker.SelectedColor.ToString() //https://stackoverflow.com/a/2109938

                });
                mainWindow.UpdateCalendar();
                this.Close();
           
        }

        private void UntilWhenCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //Make until datePicker visible
            if (((CheckBox)sender).IsChecked ?? true)
            { //https://stackoverflow.com/a/31734331
                this.EndDateTimePicker.Visibility = Visibility.Visible;

                this.FullDayCheckBox.IsChecked = false;
                this.FullDayCheckBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.EndDateTimePicker.Text = "";
                this.EndDateTimePicker.Visibility = Visibility.Collapsed;
                this.FullDayCheckBox.Visibility = Visibility.Visible;
            }

        }

        private void FulldayCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (((CheckBox)sender).IsChecked ?? true)
            { //https://stackoverflow.com/a/31734331
                this.UntilWhenCheckBox.IsChecked = false;
                this.UntilWhenCheckBox.Visibility = Visibility.Collapsed;

            }
            else
            {
                this.UntilWhenCheckBox.Visibility = Visibility.Visible;
            }
        }
    }
}
