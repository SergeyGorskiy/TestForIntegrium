using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestForIntegrium.WebApi.Models;

namespace TestForIntegrium.WebApi.EF
{
    public class SeedData
    {
        public static void SeedDataBase(DataContext context)
        {
            context.Database.Migrate();

            if (!context.Users.Any())
            {
                context.Users.AddRange(
    new User
                {
                    FirstName = "Иван",
                    Patronymic = "Иванович",
                    LastName = "Иванов",
                    DateOfBirth = new DateTime(1986,10,14),
                    NumberOfPassport = 142514253,
                    Inn = 123456
                    },
                new User
                {
                    FirstName = "Петр",
                    Patronymic = "Петрович",
                    LastName = "Петров",
                    DateOfBirth = new DateTime(1976, 5, 23),
                    NumberOfPassport = 321456987,
                    Inn = 654321
                },
                new User
                {
                    FirstName = "Сидор",
                    Patronymic = "Сидорович",
                    LastName = "Сидоров",
                    DateOfBirth = new DateTime(1980, 7, 10),
                    NumberOfPassport = 258741369,
                    Inn = 789654
                });

                context.SaveChanges();
            }
        }
    }
}