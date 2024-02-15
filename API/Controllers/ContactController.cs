using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ContactController(ScheduleContext context) : ControllerBase
    {
        private readonly ScheduleContext _context = context;

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = contact.Id}, contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _context.Contacts.Find(id);
            return (contact != null) ? Ok(contact) : NotFound("Contact not found!");

        }
        
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            var contacts = _context.Contacts
                                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                                .ToList();

            return Ok(contacts);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            var ContactInDb = _context.Contacts.Find(id);

            if(ContactInDb == null)
                return NotFound("Contact not found!");

            ContactInDb.Name = contact.Name;
            ContactInDb.Phone = contact.Phone;
            ContactInDb.Active = contact.Active;

            _context.Contacts.Update(ContactInDb);
            _context.SaveChanges();

            return (ContactInDb != null) ? Ok(ContactInDb) : NotFound("Contact not found!");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ContactInDb = _context.Contacts.Find(id);

            if(ContactInDb == null)
                return NotFound("Contact Not Found!");

            _context.Contacts.Remove(ContactInDb);
            _context.SaveChanges();
            return NoContent();
        }
    }
}