using FluentResults;
using Microsoft.AspNetCore.Mvc;
using PoaBank.Dto;
using PoaBank.Entity;
using PoaBank.Service;
using System.Collections.Generic;

namespace PoaBank.Controller
{
    [ApiController]
    [Route("/v1/[controller]")]
    public class BankController : ControllerBase
    {
        private BankService _bankService;
        public BankController(BankService bankService)
        {
            _bankService = bankService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateBankDto bankDto)
        {
            System.Console.WriteLine($"Entering Save[Code: {bankDto.Code}, Name: {bankDto.Name}]");
            Bank _bank = _bankService.Add(bankDto);
            return CreatedAtAction(nameof(GetById), new { id = _bank.Id }, _bank);
        }

        [HttpGet]
        public IActionResult Get()
        {
            System.Console.WriteLine("Entering GetBank");
            IEnumerable<Bank> _bank = _bankService.Get();
            if (_bank == null) return NotFound();
            return Ok(_bank);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            System.Console.WriteLine($"Entering GetBankById[id: {id}]");
            Bank _bank = _bankService.GetById(id);
            if (_bank == null) return NotFound();
            return Ok(_bank);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateBankDto bankDto)
        {
            System.Console.WriteLine($"Entering Update[Id: {id}, Code: {bankDto.Code}, Name: {bankDto.Name}]");
            Result result = _bankService.Update(id, bankDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            System.Console.WriteLine($"Entering Delete[Id: {id}]");
            Result result = _bankService.Delete(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }        
    }
}
