using FluentResults;
using Microsoft.AspNetCore.Mvc;
using PoaBank.Context;
using PoaBank.Entity;
using PoaBank.Entity.DTO;
using PoaBank.Service;
using System.Collections.Generic;

namespace PoaBank.Controller
{
    [ApiController]
    [Route("/v1/[controller]")]
    public class BankController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add([FromBody] CreateBankDto bankDto, [FromServices] BankService _bankService)
        {
            System.Console.WriteLine($"Entering Save[Code: {bankDto.Code}, Name: {bankDto.Name}]");
            Bank _bank = _bankService.Add(bankDto);
            return CreatedAtAction(nameof(GetById), new { id = _bank.Id }, _bank);
        }

        [HttpGet]
        public IActionResult Get([FromServices] BankService _bankService)
        {
            System.Console.WriteLine("Entering GetBank");
            IEnumerable<Bank> _bank = _bankService.Get();
            if (_bank == null) return NotFound();
            return Ok(_bank);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromServices] BankService _bankService)
        {
            System.Console.WriteLine($"Entering GetBankById[id: {id}]");
            Bank _bank = _bankService.GetById(id);
            if (_bank == null) return NotFound();
            return Ok(_bank);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateBankDto bankDto, [FromServices] BankService _bankService)
        {
            System.Console.WriteLine($"Entering Update[Id: {id}, Code: {bankDto.Code}, Name: {bankDto.Name}");
            Bank _bank = _bankService.GetById(id);
            if (_bank == null) return NotFound();
            _bankService.Update(id, bankDto.Code, bankDto.Name);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] BankService _bankService)
        {
            System.Console.WriteLine($"Entering Delete[Id: {id}]");

            if(_bankService.Delete(id).IsSuccess)
            {
                return Ok();
            }
            else
            {
                return NoContent();
            }

        }        
    }
}
