using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegCustomerController : ControllerBase
    {
        private readonly RegistrationDBContext _context;

        public RegCustomerController(RegistrationDBContext context)
        {
            _context = context;
        }

        // GET: api/RegCustomer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegCustomer>>> GetRegCustomers()
        {
            return await _context.RegCustomers.ToListAsync();
        }

        // GET: api/RegCustomer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegCustomer>> GetRegCustomer(int id)
        {
            var regCustomer = await _context.RegCustomers.FindAsync(id);

            if (regCustomer == null)
            {
                return NotFound();
            }

            return regCustomer;
        }

        // PUT: api/RegCustomer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, RegCustomer regCustomer)
        {
            regCustomer.id = id;

            _context.Entry(regCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegCustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DCandidate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RegCustomer>> PostDCandidate(RegCustomer regCustomer)
        {
            _context.RegCustomers.Add(regCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegCustomer", new { id = regCustomer.id }, regCustomer);
        }

        // DELETE: api/DCandidate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegCustomer>> DeleteRegCustomer(int id)
        {
            var regCustomer = await _context.RegCustomers.FindAsync(id);
            if (regCustomer == null)
            {
                return NotFound();
            }

            _context.RegCustomers.Remove(regCustomer);
            await _context.SaveChangesAsync();

            return regCustomer;
        }

        private bool RegCustomerExists(int id)
        {
            return _context.RegCustomers.Any(e => e.id == id);
        }
    }
}
