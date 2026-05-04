using System.ComponentModel.DataAnnotations;

namespace MVC_BusTicket.Emuns
{
    public enum EnumTicketType
    {
        Normal,
        [Display(Name = "Old Age")]
        OldAge,
        Student,
        Free
    }
}
