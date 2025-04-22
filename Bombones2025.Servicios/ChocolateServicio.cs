using Bombones2025.Datos.Repositorios;
using Bombones2025.Entidades;

namespace Bombones2025.Servicios
{
    public class ChocolateServicio
    {
        private readonly ChocolateRepositorio _chocolateRepositorio = null!;
        public ChocolateServicio(string ruta)
        {
            _chocolateRepositorio = new ChocolateRepositorio(ruta);
        }

        public void Borrar(Chocolate chocolate)
        {
            _chocolateRepositorio.Borrar(chocolate);
        }

        public bool Existe(Chocolate chocolate)
        {
            return _chocolateRepositorio.Existe(chocolate);
        }

        public List<Chocolate> GetChocolates()
        {
            return _chocolateRepositorio.GetChocolates();
        }

        public void Guardar(Chocolate chocolate)
        {
            if (chocolate.ChocolateId == 0)
            {
                _chocolateRepositorio.Agregar(chocolate);

            }
            else
            {
                _chocolateRepositorio.Editar(chocolate);
            }
        }
    }
}
