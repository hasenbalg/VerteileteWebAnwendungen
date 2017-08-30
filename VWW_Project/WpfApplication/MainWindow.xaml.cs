using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using WpfApplication.Model;
using WpfApplication.ServiceReference1;
using Xceed.Wpf.Toolkit;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Service1Client client;
        public User me { get; set; }
        public ObservableCollection<Event> eventList = new ObservableCollection<Event>();
        public ObservableCollection<User> onlineUserList = new ObservableCollection<User>();


        public MainWindow()
        {
            InitializeComponent();
            mainPanel.Visibility = Visibility.Collapsed;
            ResetNewEventFields();


            userNameTextBox.Text = "fr";
            passwordPasswordBox.Password = "huhu";


        }

        public void UpdateOnlineUsers() {
            List<UserData> onlineUsersData = client.GetOnlineUsers().ToList();

            onlineUserList = new ObservableCollection<User>();
            foreach (UserData olu in onlineUsersData)
            {
                onlineUserList.Add(new User() {
                    firstName = olu.firstName,
                    lastname = olu.lastname,
                    isOnline = true,
                    userName = olu.userName,
                    id = olu.id
                });
            }
            userListView.ItemsSource = onlineUserList;
        }

        //Login
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            loginPanel.Visibility = Visibility.Collapsed;
            mainPanel.Visibility = Visibility.Visible;

            client = new Service1Client();
            UserData meData = client.Login(userNameTextBox.Text, passwordPasswordBox.Password);
            me = new User() {
                id = meData.id,
                userName = meData.userName,
                firstName = meData.firstName,
                lastname = meData.lastname
            };

            greetingTextBox.Text += me.userName;
            UpdateCalender();
            
            UpdateOnlineUsers(); // das vllt schon im konstuktor machen

        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            loginPanel.Visibility = Visibility.Visible;
            mainPanel.Visibility = Visibility.Collapsed;
            client.Close();
        }

        //Kalender
        private void UpdateCalender()
        {
            eventList = new ObservableCollection<Event>();
            List<EventData> eventListData = client.GetAllEvents(me.id).ToList();
            
            foreach (EventData ed in eventListData) {
                Event tmpEvent = new Event()
                {
                    subject = ed.subject,
                    desciption = ed.description,
                    startDay = ed.start,
                    isFullDay = ed.isFullDay,
                    startTime = ed.start.TimeOfDay.ToString(),
                    endDay = ed.end,
                    endTime = ed.end.TimeOfDay.ToString(),
                    location = ed.location,
                    color = ed.themeColor,
                    isShared = ed.isShared
                };
                eventList.Add(tmpEvent);
                Console.WriteLine(eventList.Count);
            }

            eventListView.ItemsSource = eventList;

        }

        private void UpdateCalender(List<EventData> eventListData)
        {
            eventList = new ObservableCollection<Event>();

            foreach (EventData ed in eventListData)
            {
                Event tmpEvent = new Event()
                {
                    subject = ed.subject,
                    desciption = ed.description,
                    startDay = ed.start,
                    isFullDay = ed.isFullDay,
                    startTime = ed.start.TimeOfDay.ToString(),
                    endDay = ed.end,
                    endTime = ed.end.TimeOfDay.ToString(),
                    location = ed.location,
                    color = ed.themeColor,
                    isShared = ed.isShared
                };
                eventList.Add(tmpEvent);
                Console.WriteLine(eventList.Count);
            }

            eventListView.ItemsSource = eventList;

        }

        private void sendNewEventButton_Click(object sender, RoutedEventArgs e)
        {
            EventData event2Save = new EventData() {
                subject = subjectTextBox.Text,
                description = descriptionTextBox.Text,
                location = locationTextBox.Text,
                userId = me.id
            };

            if (startDateTimePicker.Value != null) {
                event2Save.start = (DateTime)startDateTimePicker.Value;
            }
            if (isFullDayCheckBox.IsChecked != null) {
                event2Save.isFullDay = (bool)isFullDayCheckBox.IsChecked;
            }
            if (endDateTimePicker.Value != null) {
                event2Save.end = (DateTime)endDateTimePicker.Value;
            }
            if (colorPicker.SelectedColor != null) {
                event2Save.themeColor = colorPicker.SelectedColor.ToString();
            }
            if (isSharedCheckBox.IsChecked != null) {
                event2Save.isShared = (bool)isSharedCheckBox.IsChecked;
            }
            
            UpdateCalender(client.AddEvent(event2Save).ToList());

            ResetNewEventFields();
        }

        private void ResetNewEventFields()
        {
            //Eingabe Aufraeumen
            subjectTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            locationTextBox.Text = string.Empty;
            isFullDayCheckBox.IsChecked = false;
            startDateTimePicker.Value = DateTime.Now;
            endDateTimePicker.Value = DateTime.Now.AddHours(1);
            colorPicker.SelectedColor = Colors.LightBlue;
            isSharedCheckBox.IsChecked = false;
        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            //https://stackoverflow.com/a/7128002
            Button button = (Button)sender;
            User user = (User)button.DataContext;
            ChatWindow cw = new ChatWindow(me, user, user.userName);
            cw.Show();
        }
    }
}
