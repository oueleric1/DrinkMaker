using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DrinkMaker.Models;
using System.Device.Gpio;
using System.Threading;

namespace DrinkMaker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DispenseLeft()
        {
            var pinNumber = 23;
            var dispenseTime = 25000;
            using (GpioController controller = new GpioController())
            {
                controller.OpenPin(pinNumber, PinMode.Output);
                controller.Write(pinNumber, PinValue.Low);
                Thread.Sleep(dispenseTime);
                controller.Write(pinNumber, PinValue.High);
            }

            return View("Index");
        }

        public IActionResult DispenseRight()
        {
            var pinNumber = 18;
            var dispenseTime = 25000;
            using (GpioController controller = new GpioController())
            {
                controller.OpenPin(pinNumber, PinMode.Output);
                controller.Write(pinNumber, PinValue.Low);
                Thread.Sleep(dispenseTime);
                controller.Write(pinNumber, PinValue.High);
            }

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
