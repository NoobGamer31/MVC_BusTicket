using MVC_BusTicket.Emuns;
using System.ComponentModel.DataAnnotations;

namespace MVC_BusTicket.ViewModels
{
    public class ChooseTicketTypeViewModel
    {
        [Required(ErrorMessage = "Please select a ticket type.")]
        [EnumDataType(typeof(EnumTicketType), ErrorMessage = "Invalid ticket type selected.")] // Validates the enum value (ensures it's in range of EnumTicketType)
        public EnumTicketType EnumTicketType { get; set; }
    }
}
