using Bombones2025.Entidades;

namespace Bombones2025.Datos.Repositorios
{
    public class FrutoSecoRepositorio
    {
        //Atributo privado del repo donde se almacenan los paises
        private List<FrutoSeco> frutosSecos = new();
        private readonly string ruta = null!;
        public FrutoSecoRepositorio(string rutaArchivo)
        {
            ruta=rutaArchivo;
            LeerDatos();
        }
        /// <summary>
        /// Método para enviar la lista de países a otra capa
        /// </summary>
        /// <returns></returns>
        public List<FrutoSeco> GetLista()
        {
            return frutosSecos;
        }
        /// <summary>
        /// Método para leer los países desde el archivo secuencial
        /// </summary>
        /// <param name="ruta">Se pasa el nombre del archivo</param>
        private void LeerDatos()
        {
            if (!File.Exists(ruta))
            {
                return;
            }
            var registros = File.ReadAllLines(ruta);
            foreach (var registro in registros)
            {
                FrutoSeco fruto = ConstruirFruto(registro);
                frutosSecos.Add(fruto);
            }

        }
        /// <summary>
        /// Método privado para obtener un fruto seco
        /// </summary>
        /// <param name="registro">Recibe un string con los datos del país separados por |</param>
        /// <returns>Un pais</returns>
        private FrutoSeco ConstruirFruto(string registro)
        {
            var campos = registro.Split('|');
            var frutoSecoId = int.Parse(campos[0]);
            var descripcion = campos[1];
            return new FrutoSeco()
            {
                Descripcion = descripcion,
                FrutoSecoId = frutoSecoId
            };
        }
        public bool Existe(FrutoSeco frutoSeco)
        {
            return frutoSeco.FrutoSecoId == 0 ? frutosSecos.Any(p => p.Descripcion == frutoSeco.Descripcion) :
                frutosSecos.Any(p => p.Descripcion == frutoSeco.Descripcion && p.FrutoSecoId != frutoSeco.FrutoSecoId);
        }

        public void Agregar(FrutoSeco frutoSeco)
        {
            frutoSeco.FrutoSecoId = SetearFrutoSecoId();
            frutosSecos.Add(frutoSeco);
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
                string linea = ConstruirLinea(frutoSeco);
                escritor.WriteLine(linea);
            }
        }
        private int SetearFrutoSecoId()
        {
            return frutosSecos.Max(p => p.FrutoSecoId) + 1;
        }
        private string ConstruirLinea(FrutoSeco frutoSeco)
        {
            return $"{frutoSeco.FrutoSecoId}|{frutoSeco.Descripcion}";
        }

        public void Editar(FrutoSeco frutoSeco)
        {
            var frutoSecoEditado = frutosSecos.FirstOrDefault(p => p.FrutoSecoId == frutoSeco.FrutoSecoId);
            if (frutoSecoEditado is null)
            {
                return;
            }
            frutoSecoEditado.Descripcion = frutoSeco.Descripcion;
            var registros = frutosSecos.Select(p => ConstruirLinea(p)).ToArray();
            File.WriteAllLines(ruta, registros);


        }
        public void Borrar(FrutoSeco frutoSeco)
        {
            FrutoSeco? frutoSecoBorrar = frutosSecos.FirstOrDefault(p => p.Descripcion == frutoSeco.Descripcion);
            if (frutoSecoBorrar is null)
            {
                return;
            }
            frutosSecos.Remove(frutoSecoBorrar);

            var registros = frutosSecos.Select(p => ConstruirLinea(p)).ToArray();
            File.WriteAllLines(ruta, registros);

        }
    }
}
