using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Xceed.Wpf.Toolkit;
using WpfApplication1.Proxy;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Proxy.UserData me;
        Proxy.ChatServiceClient server;

        InstanceContext context;
        public MainWindow()
        {
            InitializeComponent();

            userNameTextBox.Text = "fr";
            passwordBox.Password = "huhu";

            //Background = Brushes.Green;


            mainGrid.Visibility = Visibility.Collapsed;
            greetingPanel.Visibility = Visibility.Collapsed;

            context = new InstanceContext(new MyCallback(this));
            server = new Proxy.ChatServiceClient(context);
        }

        private void logInButton_Click(object sender, RoutedEventArgs e)
        {
            //server = new Proxy.ChatServiceClient(context);

            var username = userNameTextBox.Text;
            if (server.LogIn(userNameTextBox.Text, passwordBox.Password))
            {

                server.Join(userNameTextBox.Text);
                mainGrid.Visibility = Visibility.Visible;
                greetingPanel.Visibility = Visibility.Visible;
                logInPanel.Visibility = Visibility.Collapsed;

                me = server.GetUser(userNameTextBox.Text);

                greetingTextBlock.Text += me.userName;
                Console.WriteLine(me.id);

                UpdateCalendar();
                UpdateUserList();
            }


        }

        public void UpdateCalendar()
        {
            List<EventData> myEvents = server.GetEventsByUser(me.id).ToList();
            eventsListView.ItemsSource = myEvents;

        }

        private void addEvent_Click(object sender, RoutedEventArgs e)
        {
            Proxy.EventData tmpEvent = new Proxy.EventData();
            tmpEvent.subject = subjectTextBox.Text;
            tmpEvent.description = descriptionTextBox.Text;
            tmpEvent.location = locationTextBox.Text;
            server.AddEvent(subjectTextBox.Text,
                descriptionTextBox.Text,
                locationTextBox.Text,
                startDateTimePicker.Value ?? DateTime.Now,
                isEntireDay.IsChecked ?? false,
                endDateTimePicker.Value ?? DateTime.Now.AddHours(1),
                colorPicker.SelectedColor.ToString() ?? "#f0f",
                isShared.IsChecked ?? false);

        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateUserList();
        }

        //UserList
        public void UpdateUserList()
        {
            List<UserData> allUsers = server.GetOnlineUsers().ToList();
            Console.Write(allUsers.Count);
            usersListView.ItemsSource = allUsers;
        }

        private void sendNewMessageButton_Click(object sender, RoutedEventArgs e)
        {
            server.SendMessage(newMessagetxtBox.Text);
            newMessagetxtBox.Text = string.Empty;
        }
    }


}
