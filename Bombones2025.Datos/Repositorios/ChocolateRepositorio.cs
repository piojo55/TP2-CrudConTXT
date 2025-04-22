using Bombones2025.Entidades;
using System.Xml.Linq;

namespace Bombones2025.Datos.Repositorios
{
    public class ChocolateRepositorio
    {
        private List<Chocolate> chocolates = new();
        private readonly string ruta = null!;
        public ChocolateRepositorio(string rutaArchivo)
        {
            ruta = rutaArchivo;
            LeerDatos();
        }

        public List<Chocolate> GetChocolates()
        {
            return chocolates.OrderBy(p => p.NombreChocolate).ToList();
        }

        private void LeerDatos()
        {
            if (!File.Exists(ruta))
            {
                return;
            }
            var registros = File.ReadAllLines(ruta);
            foreach (var registro in registros)
            {
                Chocolate chocolate = ConstruirChocolate(registro);
                chocolates.Add(chocolate);
            }

        }

        private Chocolate ConstruirChocolate(string registro)
        {
            var campos = registro.Split('|');
            var chocolateId = int.Parse(campos[0]);
            var nombreChocolate = campos[1];
            return new Chocolate()
            {
                NombreChocolate = nombreChocolate,
                ChocolateId = chocolateId,
            };
        }

        private int SetearChocolateId()
        {
            return chocolates.Max(p => p.ChocolateId) + 1;
        }

        public bool Existe(Chocolate chocolate)
        {
            return chocolate.ChocolateId == 0 ? chocolates.Any(p => p.NombreChocolate == chocolate.NombreChocolate) :
                chocolates.Any(p => p.NombreChocolate == chocolate.NombreChocolate && p.ChocolateId != chocolate.ChocolateId);
        }
        public void Agregar(Chocolate chocolate)
        {
            pais.PaisId = SetearPaisId();
            paises.Add(pais);
            if (File.Exists(ruta))
            {
                var registros = File.ReadAllText(ruta);
                if (!string.IsNullOrEmpty(registros) && !registros.EndsWith(Environment.NewLine))
                {
                    File.WriteAllText(ruta, Environment.NewLine);

                }
            }
            using (var escritor = new StreamWriter(ruta, true))
            {
                string linea = ConstruirLinea(pais);
                escritor.WriteLine(linea);
            }
        }

        private string ConstruirLinea(Pais pais)
        {
            return $"{pais.PaisId}|{pais.NombrePais}";
        }

        public void Borrar(Pais pais)
        {
            Pais? paisBorrar = paises.FirstOrDefault(p => p.NombrePais == pais.NombrePais);
            if (paisBorrar is null)
            {
                return;
            }
            paises.Remove(paisBorrar);

            var registros = paises.Select(p => ConstruirLinea(p)).ToArray();
            File.WriteAllLines(ruta, registros);

        }

        public void Editar(Pais pais)
        {
            var paisEditado = paises.FirstOrDefault(p => p.PaisId == pais.PaisId);
            if (paisEditado is null)
            {
                return;
            }
            paisEditado.NombrePais = pais.NombrePais;
            var registros = paises.Select(p => ConstruirLinea(p)).ToArray();
            File.WriteAllLines(ruta, registros);


        }
    }
}
