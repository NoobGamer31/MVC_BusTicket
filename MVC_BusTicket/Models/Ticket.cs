using MVC_BusTicket.Emuns;
using System.Text.Json.Serialization;
namespace MVC_BusTicket.Models
{
    public class Ticket
    {
        [JsonPropertyName("ticketType")]
        public EnumTicketType TicketType { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; private set; }
        [JsonPropertyName("keepedChange")]
        public bool KeepedChange { get; private set; }
        [JsonPropertyName("changeAmount")]
        public decimal ChangeAmount { get; private set; }

        // CONSTRUCTORS
        // Choose TicketType constructor 
        public Ticket(EnumTicketType ticketType) : this(ticketType, false, 0) { } 

        [JsonConstructor] // SESSION
        public Ticket(EnumTicketType ticketType, bool keepedChange, decimal changeAmount)
        {
            decimal price = 0;

            TicketType = ticketType;
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
                _ => throw new Exception("Internal Error") // No one should access here, close the code for safety
            };
            return price;
        }
        public void SetChange(bool keepedChange, decimal changeAmount)
        {
            if (changeAmount < 0)
                throw new ArgumentException("Change amount cannot be negative.");
            this.KeepedChange = keepedChange;
            this.ChangeAmount = changeAmount;
        }   
    }
}
