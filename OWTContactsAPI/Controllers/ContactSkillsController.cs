using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OWTContactsAPI.Models;

namespace OWTContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactSkillsController : ControllerBase
    {
        private readonly ContactsAPIContext _context;

        public ContactSkillsController(ContactsAPIContext context)
        {
            _context = context;
        }

        // GET: api/ContactSkills
        [HttpGet]
        public IEnumerable<ContactSkill> GetContactSkills()
        {
            return _context.ContactSkills;
        }

        // GET: api/ContactSkills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactSkill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactSkill = await _context.ContactSkills.FindAsync(id);

            if (contactSkill == null)
            {
                return NotFound();
            }

            return Ok(contactSkill);
        }

        // PUT: api/ContactSkills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactSkill([FromRoute] int id, [FromBody] ContactSkill contactSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactSkill.ContactId)
            {
                return BadRequest();
            }

            _context.Entry(contactSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactSkillExists(id))
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

        // POST: api/ContactSkills
        [HttpPost]
        public async Task<IActionResult> PostContactSkill([FromBody] ContactSkill contactSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ContactSkills.Add(contactSkill);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContactSkillExists(contactSkill.ContactId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContactSkill", new { id = contactSkill.ContactId }, contactSkill);
        }

        // DELETE: api/ContactSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactSkill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactSkill = await _context.ContactSkills.FindAsync(id);
            if (contactSkill == null)
            {
                return NotFound();
            }

            _context.ContactSkills.Remove(contactSkill);
            await _context.SaveChangesAsync();

            return Ok(contactSkill);
        }

        private bool ContactSkillExists(int id)
        {
            return _context.ContactSkills.Any(e => e.ContactId == id);
        }
    }
}