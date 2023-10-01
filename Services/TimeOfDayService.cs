namespace lab1.Services
{
    public class TimeOfDayService
    {
        public string GetTimeOfDay()
        {
            DateTime now = DateTime.Now;

            if (now.Hour >= 12 && now.Hour < 18) return "Зараз день";
            else if (now.Hour >= 18 && now.Hour < 24) return "Зараз вечір";
            else if (now.Hour >= 0 && now.Hour < 6) return "Зараз ніч";
            else return "Зараз ранок";
        }
    }
}
