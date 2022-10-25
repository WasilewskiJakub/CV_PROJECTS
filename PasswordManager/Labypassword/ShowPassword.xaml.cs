using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
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
using System;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;

namespace Labypassword
{
    /// <summary>
    /// Interaction logic for ShowPassword.xaml
    /// </summary>
    public partial class ShowPassword : UserControl
    {
        Passworditem pass;
        PasswordData prevframe;
        PasswordNode list;
        public ShowPassword(sendEditpassword pp)
        {
            pass = pp.pasit;
            prevframe = pp.passwindow;
            list = pp.list;
            this.DataContext = pass;
           
            InitializeComponent();
            //ShowIcon.Source = pass.icon;
            //NameBox.Text = pass.Name;
            //mailbox.Text = pass.Email;
            //loginbox2.Text = pass.Login;
            passbox.Password = pass.Password;
            //webbox.Text = pass.Website;
            //notebox.Text = notebox.Text;
            //string date = pass.lastedit.ToString();
            lasted.Text = pass.lastedit.ToString();
            creatim.Text = pass.create.ToString();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            prevframe.addbuton.IsEnabled = false;
            prevframe.listaccounts.IsEnabled = false;
            prevframe.MorePassword.Navigate(new AddPasword(new sendEditpassword(pass, prevframe,list)));
        }

        private void Copymail(object sender, RoutedEventArgs e)
        {
        }
        private void CopyLogin(object sender, RoutedEventArgs e)
        {

        }
        private void CopyWeb(object sender, RoutedEventArgs e)
        {
           
        }

        private void openWeb(object sender, RoutedEventArgs e)
        {
            try
            {
                string tmp = $"{pass.Website}";
                tmp = tmp.Contains("https://") ? tmp : "https://" + tmp;
                Process.Start($"https://{pass.Website}");
            }
            catch(Exception f)
            {
                MessageBox.Show("Invalid Web URL", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Sendmail(object sender, RoutedEventArgs e)
        {
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("tmp@mail.com");
            mailMessage.Subject = "";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<span style='font-size: 12pt; color: red;'></span>";

            //mailMessage.Attachments.Add(new Attachment("C://Myfile.pdf"));

            var filename = "C://Temp/mymessage.eml";

            //save the MailMessage to the filesystem
            mailMessage.Save(filename);

            //Open the file with the default associated application registered on the local machine
            try
            {
                Process.Start(filename);
            }
            catch
            {
                MessageBox.Show($"Can not send Email to this addres", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            list.passwords.Remove(pass);
            prevframe.MorePassword.Navigate(new RBlank());
        }
    }
    public static class MailUtility
    {
        //Extension method for MailMessage to save to a file on disk
        public static void Save(this MailMessage message, string filename, bool addUnsentHeader = true)
        {
                using (var filestream = File.Open(filename, FileMode.Create))
                {
                    if (addUnsentHeader)
                    {
                        var binaryWriter = new BinaryWriter(filestream);
                        //Write the Unsent header to the file so the mail client knows this mail must be presented in "New message" mode
                        binaryWriter.Write(System.Text.Encoding.UTF8.GetBytes("X-Unsent: 1" + Environment.NewLine));
                    }

                    var assembly = typeof(SmtpClient).Assembly;
                    var mailWriterType = assembly.GetType("System.Net.Mail.MailWriter");

                    // Get reflection info for MailWriter contructor
                    var mailWriterContructor = mailWriterType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Stream) }, null);

                    // Construct MailWriter object with our FileStream
                    var mailWriter = mailWriterContructor.Invoke(new object[] { filestream });

                    // Get reflection info for Send() method on MailMessage
                    var sendMethod = typeof(MailMessage).GetMethod("Send", BindingFlags.Instance | BindingFlags.NonPublic);

                    sendMethod.Invoke(message, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { mailWriter, true, true }, null);

                    // Finally get reflection info for Close() method on our MailWriter
                    var closeMethod = mailWriter.GetType().GetMethod("Close", BindingFlags.Instance | BindingFlags.NonPublic);

                    // Call close method
                    closeMethod.Invoke(mailWriter, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { }, null);
                }
        }
    }
}
