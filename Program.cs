var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Company comp1 = new Company("Nikel", 2, "grivnyas", 4.5f);

app.MapGet("/info", () => comp1.Info());

app.MapGet("/", () => comp1.RandNum());

app.Run();

class Company
{
    string name { get; set; }
    int income_money { get; set; }

    string currency { get; set; }

    float workers { get; set; }

    public Company(string name, int income_money, string currency, float workers)
    {
        this.name = name;
        this.income_money = income_money;
        this.currency = currency;
        this.workers = workers;
    }

    public string Info()
    {
        return ("Company name: " + this.name + "\nIncome money: " + this.income_money + " " +this.currency + "\nWorkers amount: " + this.workers); 
    }

    public int RandNum()
    {
        return (new Random()).Next(0, 101);
    }
}

