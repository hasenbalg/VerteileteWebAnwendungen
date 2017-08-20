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

namespace WinClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<MyEvent> eventList = new List<MyEvent>();
        List<MyUser> userList = new List<MyUser>();


        public MainWindow()
        {
            InitializeComponent();


            //https://stackoverflow.com/a/10861795
            UntilWhenCheckBox.AddHandler(CheckBox.ClickEvent, new RoutedEventHandler(UntilWhenCheckBox_Checked));
            Submit.AddHandler(Button.ClickEvent, new RoutedEventHandler(Submit_Clicked));

            GenerateDummyData();
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
            string output = "";
            output += "Was: " + this.EventName.Text + "\n";
            output += "Wann: " + this.EventStart.Text + "\n";
            output += "Bis: " + this.EventEnd.Text + "\n";
            output += "Wo: " + this.EventLocation.Text + "\n";
            MessageBox.Show(output);
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
    }
}
