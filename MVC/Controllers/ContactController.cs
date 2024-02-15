using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Context;
using MVC.Models;

namespace MVC.Controllers
{
    public class ContactController: Controller
    {
        private readonly ScheduleContext _context;

        public ContactController(ScheduleContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contacts = _context.Contacts.ToList();
            return View(contacts);
        }

        public IActionResult Create() //GET
        {
            return View();
        }

        [HttpPost] //POST
        public IActionResult Create(Contact contact)
        {
            if(ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        public IActionResult Update(int id)
        {
            var contact = _context.Contacts.Find(id);

            if(contact == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Update(Contact contact)
        {
            var ContactInDb = _context.Contacts.Find(contact.Id);

            ContactInDb.Name = contact.Name;
            ContactInDb.Phone = contact.Phone;
            ContactInDb.Active = contact.Active;

            _context.Contacts.Update(ContactInDb);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.Find(id);

            if(contact == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);

            if(contact == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            var ContactInDb = _context.Contacts.Find(contact.Id);
            
            _context.Contacts.Remove(ContactInDb);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}