using MVC_BusTicket.Models;
using System.ComponentModel.DataAnnotations;
namespace MVC_BusTicket.ViewModels
{
    public class SummaryViewModel
    {
        [Required]
        public Ticket Ticket { get; set; }
    }
}
