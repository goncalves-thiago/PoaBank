using Microsoft.AspNetCore.Mvc;
using PoaBank.Context;
using PoaBank.Entity;
using PoaBank.Service;

namespace PoaBank.Controller
{
    [ApiController]
    [Route("/v1/[controller]")]
    public class BankController : ControllerBase
    {
        [HttpPost]
        public ActionResult Save([FromBody]Bank bank, [FromServices] BankService _bankService)
        {
            System.Console.WriteLine($"Entering Save[Id: {bank.Id}, Code: {bank.Code}, Name: {bank.Name}]");

            _bankService.Save(bank);
            return CreatedAtAction(nameof(GetBank), nameof(BankController), new { id = bank.Id, name = bank.Name });
        }

        [HttpGet]
        public ActionResult<Bank> GetBank(int id, [FromServices] BankService _bankService)
        {
            System.Console.WriteLine($"Entering GetBank[id: {id}]");
            return Ok(_bankService.GetById(id));
        }

    }
}
