using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_GestaoFinanceira
{
    public class WeatherForecast
    {
        public int Id { get; set; }

        public string DateString { get; set; }

        [NotMapped]
        public DateOnly Date
        {
            get => DateOnly.Parse(DateString);
            set => DateString = value.ToString("yyyy-MM-dd");
        }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
