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
using WinClient.ServiceReference;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        
    
        public UserData me{ get; set; }


        public UserData other { get; set; }


        List<MessageData> msgs;

        private Service1Client clnt;


        public Chat()
        {
            InitializeComponent();

            BackButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(BackButton_Clicked));
            SendMessageButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(SendMessageButton_Clicked));


            clnt = new Service1Client();

            PutMsgsInView();

            
        }

        private void PutMsgsInView()
        {
            msgs = clnt.GetAllMessages(me.id, other.id).ToList();
        }

        private void SendMessageButton_Clicked(object sender, RoutedEventArgs e)
        {
            msgs = clnt.SendMessage(new MessageData() { FromUserId = me.id, ToUserId = other.id, text = NewMessageTextBox.Text }).ToList();
            //todo:
            // update message list in view
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow() {me = me };
            mw.Show();
            this.Close();
        }

       
    }
}
