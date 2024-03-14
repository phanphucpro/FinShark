using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController: ControllerBase
    {
        private readonly ApllicationDBContext _context;
        public StockController(ApllicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var stocks = _context.Stock.ToList();

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stock.Where(s => s.Id == id).FirstOrDefault();

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }
    }
}