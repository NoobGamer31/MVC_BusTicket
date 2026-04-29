using Microsoft.AspNetCore.Mvc;
using MVC_BusTicket.Models;
using System.Diagnostics;
using MVC_BusTicket.Extensions;
using MVC_BusTicket.ViewModels;
using MVC_BusTicket.Emuns;

namespace MVC_BusTicket.Controllers
{
    public class ClientController : Controller
    {
        // === INDEX
        public IActionResult Index()
        {
            HttpContext.Session.Clear(); // Prevent session data from previous users
            return View();
        }

        // === CHOOSE TICKET TYPE
        [HttpGet]
        public IActionResult ChooseTicketType()
        {
            // Getting the Enum values
            
            return View();
        }

        [HttpPost] // To handle the form submission
        public IActionResult ChooseTicketType(SummaryViewModel summaryViewModel)
        {
            return RedirectToAction("Action", "Client");
        }

        // === PAYMENT
        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Payment(SummaryViewModel summaryViewModel)
        {
            return RedirectToAction("Change", "Client");
        }

        // === CHANGE
        [HttpGet]
        public IActionResult Change()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Change(SummaryViewModel summaryViewModel)
        {
            return RedirectToAction("Summary", "Client");
        }

        // === SUMMARY
        [HttpGet]
        public IActionResult Summary()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Summary(SummaryViewModel summaryViewModel)
        {
            return RedirectToAction("Index", "Client");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
