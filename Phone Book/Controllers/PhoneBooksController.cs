using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Phone_Book.Data;
using Phone_Book.Models;
using sun.security.util;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Phone_Book.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PhoneBooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public object _authService { get; private set; }

        public PhoneBooksController()
        {
            _context = new AppDbContext();
        }

        [HttpPost]
        public IActionResult Add(PhoneBook phoneBook)
        {
            var data = _context.PhoneBooks.Add(phoneBook);
            _context.SaveChanges();

            var dictionary = new Dictionary<string, object>();
            dictionary.Add("data", data.Entity);
            dictionary.Add("message", "Telefon rehberine eklendi.");

            return Ok(dictionary);
        }

        [HttpDelete("/{id}")]
        public IActionResult Delete(int id)

        {
            var data = _context.PhoneBooks.Find(id);
            if (data != null)
            {
                _context.PhoneBooks.Remove(data);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound("Kişi bulunamadı.");

        }

        [HttpPut]
        public IActionResult Update(PhoneBook phoneBook)
        {
            var data = _context.PhoneBooks.Update(phoneBook);
            _context.SaveChanges();

            var dictionary = new Dictionary<string, object>();
            dictionary.Add("data", data.Entity);
            dictionary.Add("message", "Kişi güncellendi.");

            return Ok(dictionary);
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var data = _context.PhoneBooks.ToList();

            var dictionary = new Dictionary<string, object>();
            dictionary.Add("data", data);
            dictionary.Add("message", "Telefon rehberi listelendi.");

            return Ok(dictionary);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var data = _context.PhoneBooks.FirstOrDefault(t => t.Id==id);

            var dictionary = new Dictionary<string, object>();
            dictionary.Add("data", data);
            dictionary.Add("message", "Telefon rehberi listelendi.");

            return Ok(dictionary);
        }

    

    }
}