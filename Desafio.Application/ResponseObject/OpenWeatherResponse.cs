namespace Desafio.Application.ResponseObject
{
    public class OpenWeatherResponse
    {
        public main Main { get; set; }
    }

    public class main
    {
        public decimal temp { get; set; }
    }
}
