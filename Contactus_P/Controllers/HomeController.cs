using Contactus_P.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contactus_P.Controllers
{
    
    public class HomeController : Controller
    {
        private static LMessage message = new LMessage();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(MessageModel messages)
        {
            message.listmessagemodel.Add(messages);
            return Redirect("/home/Message");
        }
        public IActionResult Message()
        {
            return View(message);
        }
    }
}
