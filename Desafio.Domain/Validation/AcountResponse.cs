namespace Desafio.Domain.Validation
{
    public class AcountResponse : ValidationResponse
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }

    }
}
