namespace TodoApi.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public string State { get; set; }
        public DateTime TodaysDate { get; set; }
        public string Warnings { get; set; }
        public string Temperature { get; set; }
    }
}
