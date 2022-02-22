using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestForIntegrium
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetUserByIdAsync().Wait();
            //CreateUserAsync().Wait();
            //UpdateUserAsync().Wait();
            DeleteUserAsync().Wait();
        }

        static async Task GetUserByIdAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12189/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/User/1");

                if (response.IsSuccessStatusCode)
                {
                    User user = await response.Content.ReadAsAsync<User>();
                    Console.WriteLine("Firstname: {0}\tLastname: {1}", user.FirstName, user.LastName);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
        }

        static async Task CreateUserAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12189/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var user = new User { FirstName = "Сергей",
                                      Patronymic = "Сергеевич",
                                      LastName = "Сергеев",
                                      DateOfBirth = new DateTime(1975, 3,28),
                                      NumberOfPassport = 14235,
                                      Inn = 48754
                };

                HttpResponseMessage response = await client.PostAsJsonAsync("api/user", user);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("You created User");
                }
            }
        }

        static async Task UpdateUserAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12189/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var user = new User { UserId = 7, FirstName = "Андрей" };

                HttpResponseMessage response = await client.PutAsJsonAsync("api/user", user);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("You updated User");
                }
            }
        }

        static async Task DeleteUserAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12189/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                int userId = 8;

                HttpResponseMessage response = await client.DeleteAsync("api/User/" + userId);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("You deleted User");
                }
            }
        }

    }

    
}
