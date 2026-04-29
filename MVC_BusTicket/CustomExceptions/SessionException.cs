namespace MVC_BusTicket.CustomExceptions
{
    public class SessionException : Exception
    {
        public SessionException(string message ) : base(message) { }
    }
}
