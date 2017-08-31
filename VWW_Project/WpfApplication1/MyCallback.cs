using System;
using System.ServiceModel;
using WpfApplication1.Proxy;

namespace WpfApplication1
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public class MyCallback : IChatServiceCallback
    {
        private MainWindow mw;

        public MyCallback(MainWindow mw)
        {
            this.mw = mw;
        }

        public void RecieveMessage(string user, string message)
        {
            //https://stackoverflow.com/a/8207299
            this.mw.Dispatcher.Invoke(new Action(() => {
                mw.chatRichTextBox.AppendText(
                   string.Format("{0}:{1} {2}\n", DateTime.Now.ToShortTimeString(), user, message)
                    );
                Console.Beep();
            }));
        }


        public void UpdateOnlineUsers()
        {
            //https://stackoverflow.com/a/8207299
            this.mw.Dispatcher.Invoke(new Action(() => {
                mw.UpdateUserList();
            }));
        }

        void IChatServiceCallback.UpdateCalendar()
        {
            UpdateCalendar();
        }

        void UpdateCalendar()
        {
            this.mw.Dispatcher.Invoke(new Action(() => {
                mw.UpdateCalendar();
            }));
        }

    }
}
