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
using System.Windows.Shapes;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        
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

        private MyUser _other;

        public MyUser other
        {
            get
            {
                return this._other;
            }

            set
            {
                _other = value;
                OtherNameTextBox.Text += _other.email;
            }
        }

        //public List<MyMessage> msgs;

        public ObservableCollection<MyMessage> msgs = new ObservableCollection<MyMessage>();

        public Chat()
        {
            InitializeComponent();

            BackButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(BackButton_Clicked));
            SendMessageButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(SendMessageButton_Clicked));


            GenerateMessages();

            
        }

        private void SendMessageButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (NewMessageTextBox.Text.Length > 0) {
                msgs.Add(new MyMessage() { sender = me, time = DateTime.Now, text = NewMessageTextBox.Text });
            }
            NewMessageTextBox.Text = "";
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow() {me = me };
            mw.Show();
            this.Close();
        }

        private void GenerateMessages()
        {
            msgs = new ObservableCollection<MyMessage>(); //https://stackoverflow.com/a/4489112

            msgs.Add(new MyMessage() { sender = other, time = new DateTime(), text = "nachicht1" });
            msgs.Add(new MyMessage() { sender = other, time = new DateTime(), text = "nachicht2" });
            msgs.Add(new MyMessage() { sender = other, time = new DateTime(), text = "nachicht3" });
            msgs.Add(new MyMessage() { sender = other, time = new DateTime(), text = "nachicht4" });

            MessagesListBox.ItemsSource = msgs;
        }
    }
}
