using Comp;
using System.Text.Json;

namespace Me
{
    public class MySelf
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }

        public MySelf()
        {

        }

        public string MyInfo()
        {
            return ("Name: " + this.name + "\nSurname: " + this.surname + "\nAge: " + this.age);
        }

        public static MySelf meFromJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);

            MySelf me = JsonSerializer.Deserialize<MySelf>(jsonString);

            return me;
        }
    }
}
