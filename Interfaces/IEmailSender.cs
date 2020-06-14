namespace multiple_interface_implementation.Controllers.Interfaces
{
    public interface IEmailSender
    {
        string providerName { get; }
        void sendEmail(string emailAddress, string message);
    }
}