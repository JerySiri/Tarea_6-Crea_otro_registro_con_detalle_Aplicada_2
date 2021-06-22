using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OtroRegistroConDetalle.Models;
using OtroRegistroConDetalle.DAL;
using Microsoft.EntityFrameworkCore;

namespace OtroRegistroConDetalle.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes orden)
        {
            if (!Existe(orden.ordenId))
                return Insertar(orden);
            else
                return Modificar(orden);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ordenes.Any(e => e.ordenId == id);
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

        private static bool Insertar(Ordenes orden)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Ordenes.Add(orden);
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

        public static bool Modificar(Ordenes orden)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM OrdenesDetalle Where ordenId={orden.ordenId}");

                foreach (var ListadeMoras in orden.OrdenesDetalle)
                {
                    contexto.Entry(ListadeMoras).State = EntityState.Added;
                }

                contexto.Entry(orden).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
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

        public static Ordenes Buscar(int id)
        {
            Ordenes orden = new Ordenes();
            Contexto contexto = new Contexto();

            try
            {
                orden = contexto.Ordenes
                    .Where(e => e.ordenId == id)
                    .Include(e => e.OrdenesDetalle)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return orden;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //buscar la entidad que se desea eliminar
                var orden = contexto.Ordenes.Find(id);

                if (orden != null)
                {
                    contexto.Ordenes.Remove(orden);//remover la entidad
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
    }
}
