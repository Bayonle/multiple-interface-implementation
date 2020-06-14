using System.Diagnostics;
using multiple_interface_implementation.Controllers.Interfaces;

namespace multiple_interface_implementation.Implementations
{
    public class EmailSenderA : IEmailSender
    {
        public string providerName => "Provider_A";
        public void sendEmail(string emailAddress, string message)
        {
            Debug.WriteLine("Sending mail with provider A");
        }
    }

    public class EmailSenderB : IEmailSender
    {
        public string providerName => "Provider_B";
        public void sendEmail(string emailAddress, string message)
        {
            Debug.WriteLine("Sending mail with provider B");
        }
    }
}