using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WinClient.ServiceReference;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<EventData> eventList = new List<EventData>();
        List<UserData> userList = new List<UserData> ();
        
        public UserData me { get; set; }
        private Service1Client clnt;




        public MainWindow()
        {
            InitializeComponent();


            //https://stackoverflow.com/a/10861795
            FullDayCheckBox.AddHandler(CheckBox.ClickEvent, new RoutedEventHandler(FulldayCheckBox_Checked));
            UntilWhenCheckBox.AddHandler(CheckBox.ClickEvent, new RoutedEventHandler(UntilWhenCheckBox_Checked));
            Submit.AddHandler(Button.ClickEvent, new RoutedEventHandler(Submit_Clicked));
            BackButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(BackButton_Clicked));

            EventList.AddHandler(ListView.MouseDoubleClickEvent, new RoutedEventHandler(EventList_Clicked));



            clnt = new Service1Client();
        }

        public void UpdateCalendar() {
            UserList.ItemsSource = userList;
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            Login lw = new Login();
            lw.Show();
            this.Close();
        }


        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            

            eventList = clnt.AddEvent(new EventData() {
                subject = this.SubjectTextBox.Text,
                description = this.DescriptionTextBox.Text,
                start = (DateTime)this.StartDateTimePicker.Value,
                end = (DateTime)this.EndDateTimePicker.Value,
                location = this.LocationTextBox.Text,
                isFullDay = (this.FullDayCheckBox.IsChecked ?? true) ? true : false,
                isShared = (this.ShareCheckBox.IsChecked ?? true) ? true : false,
                themeColor = this.EventColorPicker.SelectedColor.ToString(),
                userId = me.id
            }).ToList();

            //todo:
            //Update list in window

            
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
            else {
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

       

        private void EventList_Clicked(object sender, RoutedEventArgs e)
        {
            var item = ((EventData)((FrameworkElement)e.OriginalSource).DataContext);//https://stackoverflow.com/a/4888542
            if (item != null)
            {
                EditEvent eew = new EditEvent() { me = me, event2Edit = item, mainWindow = this };
                eew.Show();
            }
        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            //https://stackoverflow.com/a/7128002
            Button button = (Button)sender;
            UserData user = (UserData)button.DataContext;
            Chat cw = new Chat() { other = user, me = me };
            cw.Show();
            this.Close();
        }
    }
}
