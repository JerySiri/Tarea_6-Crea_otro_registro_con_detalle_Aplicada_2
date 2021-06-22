using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OtroRegistroConDetalle.Models;
using OtroRegistroConDetalle.DAL;
using Microsoft.EntityFrameworkCore;

namespace OtroRegistroConDetalle.BLL
{
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidor)
        {
            if (!Existe(suplidor.suplidorId))
                return Insertar(suplidor);
            else
                return Modificar(suplidor);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Suplidores.Any(e => e.suplidorId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Modificar(Suplidores suplidor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(suplidor).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Insertar(Suplidores suplidor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Suplidores.Add(suplidor);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //buscar la entidad que se desea eliminar
                var suplidor = contexto.Suplidores.Find(id);

                if (suplidor != null)
                {
                    contexto.Suplidores.Remove(suplidor);//remover la entidad
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Suplidores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Suplidores suplidor;

            try
            {
                suplidor = contexto.Suplidores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return suplidor;
        }

        public static List<Suplidores> GetSuplidor()
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Suplidores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

    }
}
