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

namespace WinClient
{
    /// <summary>
    /// Interaction logic for EditEvent.xaml
    /// </summary>
    public partial class EditEvent : Window
    {
        private MyEvent _event2Edit;
        public MyEvent event2Edit
        {
            get
            {
                return this._event2Edit;
            }

            set
            {
                _event2Edit = value;
                SubjectTextBox.Text = event2Edit.Subject;
                DescriptionTextBox.Text = event2Edit.Description;
                StartDateTimePicker.Value = event2Edit.Start;
                EndDateTimePicker.Value = event2Edit.End;
                LocationTextBox.Text = event2Edit.Location;
                FullDayCheckBox.IsChecked = event2Edit.IsFullDay;
                ShareCheckBox.IsChecked = event2Edit.IsShared;
                EventColorPicker.SelectedColor = (Color)ColorConverter.ConvertFromString(event2Edit.ThemeColor); 

                
            }
        }

        private MyUser _me;
        public MyUser me
        {
            get
            {
                return this._me;
            }

            set
            {
                _me = value;
                UserGreeterText.Text += _me.email;
            }
        }

        public MainWindow mainWindow { get; internal set; }

        public EditEvent()
        {
            InitializeComponent();

            Submit.AddHandler(Button.ClickEvent, new RoutedEventHandler(Submit_Clicked));

        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            Login lw = new Login();
            lw.Show();
            this.Close();
        }


        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                event2Edit = new MyEvent()
                {
                    Subject = this.SubjectTextBox.Text,
                    Description = this.DescriptionTextBox.Text,
                    Start = (DateTime)this.StartDateTimePicker.Value,
                    End = this.EndDateTimePicker.Value,
                    Location = this.LocationTextBox.Text,
                    IsFullDay = (this.FullDayCheckBox.IsChecked ?? true) ? true : false,
                    IsShared = (this.ShareCheckBox.IsChecked ?? true) ? true : false,
                    ThemeColor = this.EventColorPicker.SelectedColor.ToString() //https://stackoverflow.com/a/2109938

                };
                mainWindow.UpdateCalendar();
                this.Close();
            }
            catch (InvalidOperationException exc)
            {
                ErrorTextBlock.Visibility = Visibility.Visible;
            }


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
