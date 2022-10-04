using System;
using System.ComponentModel.DataAnnotations;

namespace Phone_Book.Models
{
    public class PhoneBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }

        public string PrivateCode { get; set; }
      
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
