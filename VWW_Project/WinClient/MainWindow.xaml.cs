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

namespace WinClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<MyEvent> eventList = new ObservableCollection<MyEvent>();
        ObservableCollection<MyUser> userList = new ObservableCollection<MyUser>();


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


        public MainWindow()
        {
            InitializeComponent();


            //https://stackoverflow.com/a/10861795
            UntilWhenCheckBox.AddHandler(CheckBox.ClickEvent, new RoutedEventHandler(UntilWhenCheckBox_Checked));
            Submit.AddHandler(Button.ClickEvent, new RoutedEventHandler(Submit_Clicked));
            BackButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(BackButton_Clicked));


            
            GenerateDummyData();

            
           
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            Login lw = new Login();
            lw.Show();
            this.Close();
        }

        private void GenerateDummyData()
        {
            eventList.Add(new MyEvent() { EventName = "Baden gehen", EventStart = new DateTime(), EventEnd = new DateTime(), EventLocation = "Badezimmer"});
            eventList.Add(new MyEvent() { EventName = "Duschen gehen", EventStart = new DateTime(), EventEnd = new DateTime(), EventLocation = "Badezimmer"});
            eventList.Add(new MyEvent() { EventName = "Zaehne putzen gehen", EventStart = new DateTime(), EventEnd = new DateTime(), EventLocation = "Badezimmer"});
            eventList.Add(new MyEvent() { EventName = "Fruehstuecken", EventStart = new DateTime(), EventEnd = new DateTime(), EventLocation = "Kueche"});
            eventList.Add(new MyEvent() { EventName = "nachhause gehen", EventStart = new DateTime(), EventEnd = new DateTime(), EventLocation = "Badezimmer"});
            EventList.ItemsSource = eventList;


            userList.Add(new MyUser() { email = "hoho@haha.de", isOnline = true});
            userList.Add(new MyUser() { email = "huhu@haha.de", isOnline = true});
            userList.Add(new MyUser() { email = "haha@haha.de", isOnline = true});
            userList.Add(new MyUser() { email = "hehe@haha.de", isOnline = true});

            UserList.ItemsSource = userList;
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            /*string output = "";
            output += "Was: " + this.EventName.Text + "\n";
            output += "Wann: " + this.EventStart.Text + "\n";
            output += "Bis: " + this.EventEnd.Text + "\n";
            output += "Wo: " + this.EventLocation.Text + "\n";
            MessageBox.Show(output);*/

            eventList.Add(new MyEvent() {
                EventName = this.EventName.Text,
                EventStart = Convert.ToDateTime(this.EventStart.Text),
                EventEnd = Convert.ToDateTime(this.EventEnd.Text),
                EventLocation = this.EventLocation.Text
        });
        }

        private void UntilWhenCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //Make until datePicker visible
            if (((CheckBox)sender).IsChecked ?? true)
            { //https://stackoverflow.com/a/31734331
                this.EventEnd.Visibility = Visibility.Visible;
            }
            else {
                this.EventEnd.Visibility = Visibility.Collapsed;
            }
            
        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            //https://stackoverflow.com/a/7128002
            Button button = (Button)sender ;
            MyUser user = (MyUser)button.DataContext;
            Chat cw = new Chat() { other = user, me = me };
            cw.Show();
            this.Close();
        }
    }
}
