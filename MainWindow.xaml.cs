using System.Net;
using System.Net.Mail;
using System.Windows;

namespace SendEmail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Send_Email(object sender, RoutedEventArgs e)
        {
            string sendemail = SendEmail.Text;
            string getemail = GetEmail.Text;
            string pass = GetPassword.Text;
            //In this part i combined text to string 
            using (MailMessage mail = new(sendemail, getemail)) //create new mailmessage/ Worked on message
            {
                mail.Subject = "Тема";
                mail.IsBodyHtml = true;
                mail.Body = Textes.Text;
                //mail worked on the message
                using (SmtpClient Client = new("smtp.mail.ru", 587))//smtpclient who Receive host and port
                {
                    Client.Credentials = new NetworkCredential(sendemail, pass);
                    Client.EnableSsl = true;
                    Client.UseDefaultCredentials = false;
                    Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    Client.Send(mail);//This method Sending email
                    MessageBox.Show("Mail is sucess!"); //if mail send,message box show Mail is sucess!
                }
            }
        }
    }
}
