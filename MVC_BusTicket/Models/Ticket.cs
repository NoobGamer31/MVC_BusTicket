using MVC_BusTicket.Emuns;
namespace MVC_BusTicket.Models
{
    public class Ticket
    {
        public EnumTicketType TicketType { get; set; }
        public decimal Price { get; private set; }
        public bool KeepedChange { get; private set; }
        public decimal ChangeAmount { get; private set; }

        // CONSTRUCTORS
        public Ticket(EnumTicketType enumTicketType, bool keepedChange, decimal changeAmount)
        {
            decimal price = 0;

            TicketType = enumTicketType;
            Price = SetPrice(price);
            KeepedChange = keepedChange;
            ChangeAmount = changeAmount;
        }

        // METHODS
        private decimal SetPrice(decimal price)
        {
            if(price < 0)
                throw new ArgumentException("Price cannot be negative.");

            // Set price according to the ticket type
            price = (int)TicketType switch
            {
                0 => 3.00m, // Normal
                1 => 1.50m, // Old Age
                2 => 1.00m, // Student
                3 => 0.00m, // Free
                _ => throw new Exception("Internal Error") // No one should access here, close the code
            };
            return price;
        }
    }
}
