using Bombones2025.Datos.Repositorios;
using Bombones2025.Entidades;

namespace Bombones2025.Servicios
{
    public class FrutoSecoServicio
    {
        private readonly FrutoSecoRepositorio _frutoRepositorio = null!;
        public FrutoSecoServicio(string ruta)
        {
            _frutoRepositorio = new FrutoSecoRepositorio(ruta);
        }

        public List<FrutoSeco> GetLista()
        {
            return _frutoRepositorio.GetLista();
        }

        public bool Existe(FrutoSeco frutoSeco)
        {
            return _frutoRepositorio.Existe(frutoSeco);
        }
        public void Borrar(FrutoSeco frutoSeco)
        {
            _frutoRepositorio.Borrar(frutoSeco);
        }
        public void Guardar(FrutoSeco frutoSeco)
        {
            if (frutoSeco.FrutoSecoId == 0)
            {
                _frutoRepositorio.Agregar(frutoSeco);

            }
            else
            {
                _frutoRepositorio.Editar(frutoSeco);
            }
        }
    }
}
