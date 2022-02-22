using System;

namespace TestForIntegrium.WebApi.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int NumberOfPassport { get; set; }

        public int Inn { get; set; }
    }
}