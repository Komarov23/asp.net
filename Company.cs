using System;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration.Ini;
using Microsoft.Extensions.Configuration;

namespace Comp
{
    public class Company
    {
        public string name { get; set; }
        public int income_money { get; set; }
        public string currency { get; set; }
        public int workers { get; set; }

        public Company(string name, int income_money, string currency, int workers)
        {
            this.name = name;
            this.income_money = income_money;
            this.currency = currency;
            this.workers = workers;
        }

        public Company()
        {

        }

        public string Info()
        {
            return ("Company name: " + this.name + "\nIncome money: " + this.income_money + " " + this.currency + "\nWorkers amount: " + this.workers);
        }

        public int RandNum()
        {
            return (new Random()).Next(0, 101);
        }

        public static Company compFromJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);

            Company temp = JsonSerializer.Deserialize<Company>(jsonString);

            return temp;
        }

        public static Company compFromXML(string filePath)
        {
            using (XmlReader reader = XmlReader.Create(filePath, new XmlReaderSettings { IgnoreWhitespace = true }))
            {
                reader.ReadStartElement("Company");

                string name = reader.ReadElementContentAsString("name", "");
                int incomeMoney = reader.ReadElementContentAsInt("income_money", "");
                string currency = reader.ReadElementContentAsString("currency", "");
                int workers = reader.ReadElementContentAsInt("workers", "");

                return new Company(name, incomeMoney, currency, workers);
            }
        }

        public static Company compFromIni(string filePath)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddIniFile(filePath)
                .Build();

            string name = config["Company:name"];
            int incomeMoney = Convert.ToInt32(config["Company:income_money"]);
            string currency = config["Company:currency"];
            int workers = Convert.ToInt32(config["Company:workers"]);

            return new Company(name, incomeMoney, currency, workers);
        }

    }
}


