using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TableGenerator.Web.Models;

namespace TableGenerator.Web.Controllers
{
    public class HomeController(
        ISender _mediator)
        : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
