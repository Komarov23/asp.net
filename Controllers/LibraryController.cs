using Comp;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace lab1.Controllers
{
    [Route("Library")]
    public class LibraryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Content("Привітання!");
        }

        [HttpGet("Books")]
        public IActionResult ListBooks()
        {
            string jsonString = System.IO.File.ReadAllText("./books.json");

            List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonString);

            return Content("<h2>Список книг</h2>" +
                "<table>" +
                "<tr><th>Назва книги</th><th>Автор</th></tr>" +
                string.Join("", books.Select(book =>
                    $"<tr><td>{book.Title}</td><td>{book.Author}</td></tr>")) +
                "</table>",
                "text/html; charset=utf-8"

            );
        }
        [HttpGet("Profile/{id?}")]
        public IActionResult Profile(int? id)
        {
            var jsonString = System.IO.File.ReadAllText("./profiles.json");
            var profiles = JsonSerializer.Deserialize<Dictionary<string, Profiles>>(jsonString);

            if (id.HasValue && id >= 0 && id <= 5 && profiles.ContainsKey(id.ToString()))
            {
                var userInfo = profiles[id.ToString()];
                return Content($"Id: {userInfo.Id}<br>Name: {userInfo.Name}<br>Age: {userInfo.Age}", "text/html; charset=utf-8");
            }
            else if (profiles.ContainsKey("CurrentUser"))
            {
                var currentUserInfo = profiles["CurrentUser"];
                return Content($"Id: {currentUserInfo.Id}<br>Name: {currentUserInfo.Name}<br>Age: {currentUserInfo.Age}", "text/html; charset=utf-8");
            }
            else
            {
                return Content("Немає інформації про користувача", "text/html; charset=utf-8");
            }
        }


    }
}
