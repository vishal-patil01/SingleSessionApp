using System;
using System.ComponentModel.DataAnnotations;

namespace SingleSession.ModelLayer.DBModel
{
    public class User
    {
        public int ID { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string SessionId { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
