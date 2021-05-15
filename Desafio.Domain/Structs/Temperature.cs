namespace Desafio.Domain.Structs
{
    public struct Temperature
    {
        private readonly decimal _temp;
        private Temperature(decimal value) => _temp = value;

        public static implicit operator Temperature(decimal value) => new Temperature(value);
        public static decimal ParseKelvinForCelcius(decimal value) => value - 273.15M;

    }
}
