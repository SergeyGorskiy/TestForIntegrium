using System;
using System.Collections.Generic;
using System.Linq;

namespace TestForIntegrium
{
    public class Logic
    {
        public IEnumerable<User> UsersInService;

        public int GetInnByPassport(User user)
        {
            int inn = UsersInService.Where(u => u.FirstName == user.FirstName
                                                   && u.Patronymic == user.Patronymic
                                                   && u.LastName == user.LastName
                                                   && u.DateOfBirth == user.DateOfBirth
                                                   && u.NumberOfPassport == user.NumberOfPassport)
                .Select(u => u.Inn)
                .FirstOrDefault();

            return inn;
        }
    }
}