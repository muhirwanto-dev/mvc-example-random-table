using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TableGenerator.Application.Core.Commands.BulkInsertPersonalData;
using TableGenerator.Contracts.Dtos;
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

        [HttpPost]
        public IActionResult Submit([FromBody] IList<PersonalDataRequestDto> data)
        {
            var command = new BulkInsertPersonalDataCommand(
                new BulkInsertPersonalDataRequestDto(
                    Name: "Test User",
                    Age: 30,
                    Email: "",
                    Payload: data
                    ));
            var result = _mediator.Send(command).Result;

            return result.Match(
                onValue: value => Ok(),
                onError: Problem);
        }
    }
}
