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
using WpfApplication.Model;
using WpfApplication.ServiceReference1;
using System.Threading;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        Service1Client client;
        public User me { get; set; }
        public User other { get; set; }
        public ObservableCollection<Message> messageList = new ObservableCollection<Message>();
        //Thread updateChat;
        
        public ChatWindow(User me, User other, string title)
        {
            InitializeComponent();
            client = new Service1Client();

            this.me = me;
            this.other = other;
            this.Title = title;

            CheckForNewMessages();
        }

        private void sendNewMessageButton_Click(object sender, RoutedEventArgs e)
        {
            CheckForNewMessages();
        }

        private void CheckForNewMessages() {

                if (me != null && other != null) {
                    List<MessageData> messageDataList = client.GetAllMessages(me.id, other.id).ToList();
                    messageList = new ObservableCollection<Message>();
                    foreach (MessageData md in messageDataList)
                    {
                        messageList.Add(new Message()
                        {
                            fromId = md.FromUserId,
                            toId = md.ToUserId,
                            text = md.text,
                            time = md.time
                        });
                    }

                    messagesListView.ItemsSource = messageList;
               
                }
                Console.WriteLine(DateTime.Now);
                Console.WriteLine(DateTime.Now);
                Console.WriteLine("gruesse vom updater");
            
        }
    }
}
