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
                userList.Add(new MyUser() {email = _me.email, isOnline = true, id = userList.Count() });
            }
        }


        public MainWindow()
        {
            InitializeComponent();


            //https://stackoverflow.com/a/10861795
            FullDayCheckBox.AddHandler(CheckBox.ClickEvent, new RoutedEventHandler(FulldayCheckBox_Checked));
            UntilWhenCheckBox.AddHandler(CheckBox.ClickEvent, new RoutedEventHandler(UntilWhenCheckBox_Checked));
            Submit.AddHandler(Button.ClickEvent, new RoutedEventHandler(Submit_Clicked));
            BackButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(BackButton_Clicked));


            
            GenerateDummyData();

            
           
        }

        private void FulldayCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(((CheckBox)sender).IsChecked ?? true)
            { //https://stackoverflow.com/a/31734331
                this.UntilWhenCheckBox.IsChecked = false;
                this.UntilWhenCheckBox.Visibility = Visibility.Collapsed;

            }
            else {
                this.UntilWhenCheckBox.Visibility = Visibility.Visible;
            }
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            Login lw = new Login();
            lw.Show();
            this.Close();
        }

        private void GenerateDummyData()
        {
            eventList.Add(new MyEvent() { Subject = "Baden gehen", Description = "Wasser einlassen, baden, abtrocknen", Start = new DateTime(), End = new DateTime(), Location = "Badezimmer", IsFullDay = false, IsShared = true, ThemeColor = "#f00", Id = userList.Count() });
            eventList.Add(new MyEvent() { Subject = "Duschen gehen", Description = "Fast wie baden, nur mit Wasser von oben", Start = new DateTime(), End = new DateTime(), Location = "Badezimmer", IsFullDay = false, IsShared = true, ThemeColor = "#ff0", Id = userList.Count() });
            eventList.Add(new MyEvent() { Subject = "Zaehne putzen gehen", Description = "Fast wie Duschen, nur mit Zahnbuerste", Start = new DateTime(), End = new DateTime(), Location = "Badezimmer", IsFullDay = false, IsShared = true, ThemeColor = "#f00", Id = userList.Count() });
            eventList.Add(new MyEvent() { Subject = "Fruehstuecken", Description = "fast wie  zaehneputzen, nur mit essen", Start = new DateTime(), End = new DateTime(), Location = "Kueche", IsFullDay = false, IsShared = true, ThemeColor = "#f00", Id = userList.Count() });
            eventList.Add(new MyEvent() { Subject = "nachhause gehen", Description = "den anderen Taetigkeiten unaehnlich", Start = new DateTime(), End = new DateTime(), Location = "Iregendwo", IsFullDay = false, IsShared = true, ThemeColor = "#f00", Id = userList.Count() });
            EventList.ItemsSource = eventList;


            userList.Add(new MyUser() { email = "hoho@haha.de", isOnline = true, id = userList.Count() });
            userList.Add(new MyUser() { email = "huhu@haha.de", isOnline = true, id = userList.Count() });
            userList.Add(new MyUser() { email = "haha@haha.de", isOnline = true, id = userList.Count() });
            userList.Add(new MyUser() { email = "hehe@haha.de", isOnline = true, id = userList.Count() });
            UserList.ItemsSource = userList;
        }

        private void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                eventList.Add(new MyEvent()
                {
                    Subject = this.SubjectTextBox.Text,
                    Description = this.DescriptionTextBox.Text,
                    Start = (DateTime)this.StartDateTimePicker.Value,
                    End = this.EndDateTimePicker.Value,
                    Location = this.LocationTextBox.Text,
                    IsFullDay = (this.FullDayCheckBox.IsChecked ?? true) ? true : false,
                    IsShared = (this.shareCheckBox.IsChecked ?? true) ? true : false,
                    ThemeColor = this.EventColorPicker.SelectedColor.ToString(),
                    UserId = userList.Count().ToString()


                });
            }
            catch (InvalidOperationException exc) {
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
            else {
                this.EndDateTimePicker.Text = "";
                this.EndDateTimePicker.Visibility = Visibility.Collapsed;
                this.FullDayCheckBox.Visibility = Visibility.Visible;
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
