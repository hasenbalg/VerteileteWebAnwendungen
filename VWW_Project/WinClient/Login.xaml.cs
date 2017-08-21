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
using System.Windows.Shapes;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MyUser me;

        public Login()
        {
            InitializeComponent();
            LoginButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(LoginButton_Clicked));
        }

        private void LoginButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (UserIsValid(emailText.Text, passwordText.Password))
            {

                me = new MyUser() {email = emailText.Text, isOnline = true };
                MainWindow mw = new MainWindow() { me = me};
                mw.Show();
                this.Close();
            }
            else {
                ErrorText.Visibility = Visibility.Visible;
            }
        }

        private bool UserIsValid(string email, string password)
        {
            return true;
        }
    }
}
