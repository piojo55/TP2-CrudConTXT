namespace Bombones2025.Entidades
{
    public class Chocolate
    {
        public int ChocolateId { get; set; }
        public string NombreChocolate { get; set; } = null!;
        public override string ToString()
        {
            return $"{NombreChocolate}";
        }
    }
}
