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
using System.Windows.Media;
using System.ComponentModel;

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
            passwordBox.Password = "Qwerty123!";



            mainGrid.Visibility = Visibility.Collapsed;
            greetingPanel.Visibility = Visibility.Collapsed;

            context = new InstanceContext(new MyCallback(this));
            server = new Proxy.ChatServiceClient(context);

            ResetNewEventPanel();
        }

        private void ResetNewEventPanel()
        {
            editEventButton.Visibility = Visibility.Collapsed;
            addEventButton.Visibility = Visibility.Visible;
            cancelEditEventButton.Visibility = Visibility.Collapsed;

            subjectTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            //locationTextBox.Text = string.Empty;
            startDateTimePicker.Value = DateTime.Now;
            isEntireDay.IsChecked = false;
            endDateTimePicker.Value = DateTime.Now.AddHours(1);
            colorPicker.SelectedColor = (Color)ColorConverter.ConvertFromString("#f0f");
            isShared.IsChecked = false;
            idTextBlock.Text = string.Empty;
        }

        private void logInButton_Click(object sender, RoutedEventArgs e)
        {
            //server = new Proxy.ChatServiceClient(context);

            var username = userNameTextBox.Text;
            if (server.LogIn(userNameTextBox.Text, passwordBox.Password))
            {
                Console.WriteLine("Login ok");
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
            else {
                errorLoginTextBlock.Visibility = Visibility.Visible;
            }


        }

        public void UpdateCalendar()
        {
            List<EventData> myEvents = server.GetEventsByUser(me.id).ToList();
            eventsListView.ItemsSource = myEvents;
        }



        private void addEventButton_Click(object sender, RoutedEventArgs e)
        {
            
            server.AddEvent(subjectTextBox.Text,
                descriptionTextBox.Text,
                //locationTextBox.Text,
                startDateTimePicker.Value ?? DateTime.Now,
                isEntireDay.IsChecked ?? false,
                endDateTimePicker.Value ?? DateTime.Now.AddHours(1),
                colorPicker.SelectedColor.ToString() ?? "#f0f",
                isShared.IsChecked ?? false,
                me.id);

            ResetNewEventPanel();
        }

        

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            server.LogOut();
            mainGrid.Visibility = Visibility.Collapsed;
            greetingPanel.Visibility = Visibility.Collapsed;
            logInPanel.Visibility = Visibility.Visible;
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

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            //https://stackoverflow.com/a/7128002
            ListViewItem item = (ListViewItem)sender;
            EventData ed = (EventData)item.DataContext;


            subjectTextBox.Text = ed.subject;
            descriptionTextBox.Text = ed.description;
            //locationTextBox.Text = ed.location;
            startDateTimePicker.Value = ed.start;
            isEntireDay.IsChecked = ed.isEntireDay;
            endDateTimePicker.Value = ed.end;
            colorPicker.SelectedColor = (Color)ColorConverter.ConvertFromString(ed.color); ;
            isShared.IsChecked = ed.isShared;
            idTextBlock.Text = ed.id.ToString();
            
            editEventButton.Visibility = Visibility.Visible;
            addEventButton.Visibility = Visibility.Collapsed;
            cancelEditEventButton.Visibility = Visibility.Visible;
            
        }

        private void editEventButton_Click(object sender, RoutedEventArgs e)
        {
            server.EditEvent(subjectTextBox.Text,
                descriptionTextBox.Text,
                //locationTextBox.Text,
                startDateTimePicker.Value ?? DateTime.Now,
                isEntireDay.IsChecked ?? false,
                endDateTimePicker.Value ?? DateTime.Now.AddHours(1),
                colorPicker.SelectedColor.ToString() ?? "#f0f",
                isShared.IsChecked ?? false,
                int.Parse(idTextBlock.Text),
                me.id);
            ResetNewEventPanel();
        }

        private void cancelEditEventButton_Click(object sender, RoutedEventArgs e)
        {
            ResetNewEventPanel();
        }

        private void eventsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //https://stackoverflow.com/a/7128002
            int i = (sender as ListView).SelectedIndex;
            EventData ed = (EventData)eventsListView.Items.GetItemAt(i);

            if (ed.userId == me.id)
            {
                subjectTextBox.Text = ed.subject;
                descriptionTextBox.Text = ed.description;
                //locationTextBox.Text = ed.location;
                startDateTimePicker.Value = ed.start;
                isEntireDay.IsChecked = ed.isEntireDay;
                endDateTimePicker.Value = ed.end;
                colorPicker.SelectedColor = (Color)ColorConverter.ConvertFromString(ed.color); ;
                isShared.IsChecked = ed.isShared;
                idTextBlock.Text = ed.id.ToString();

                editEventButton.Visibility = Visibility.Visible;
                addEventButton.Visibility = Visibility.Collapsed;
                cancelEditEventButton.Visibility = Visibility.Visible;
            }
            else {
                ResetNewEventPanel();
            }
        }


        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            //https://msdn.microsoft.com/en-us/library/system.windows.window.closing(v=vs.110).aspx
            server.LogOut();
        }

        
    }
}
    