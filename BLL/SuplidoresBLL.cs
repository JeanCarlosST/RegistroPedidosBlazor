using Microsoft.EntityFrameworkCore;
using RegistroPedidosBlazor.DAL;
using RegistroPedidosBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroPedidosBlazor.BLL
{
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidor)
        {
            if (!Existe(suplidor.SuplidorID))
                return Insertar(suplidor);
            else
                return Modificar(suplidor);
        }
        private static bool Insertar(Suplidores suplidor)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {;
                contexto.Suplidores.Add(suplidor);
                found = contexto.SaveChanges() > 0;
            }
            catch
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return found;
        }
        public static bool Modificar(Suplidores suplidor)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                contexto.Entry(suplidor).State = EntityState.Modified;
                found = contexto.SaveChanges() > 0;
            }
            catch
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return found;
        }
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                var suplidor = contexto.Suplidores.Find(id);

                if (suplidor != null)
                {
                    contexto.Suplidores.Remove(suplidor);
                    found = contexto.SaveChanges() > 0;
                }
            }
            catch
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return found;
        }
        public static Suplidores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Suplidores suplidor;

            try
            {
                suplidor = contexto.Suplidores
                    .Where(s => s.SuplidorID == id)
                    .SingleOrDefault();
            }
            catch
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return suplidor;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                found = contexto.Suplidores.Any(s => s.SuplidorID == id);
            }
            catch
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return found;
        }

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> criterio)
        {
            List<Suplidores> list = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try
            {
                list = contexto.Suplidores.Where(criterio).AsNoTracking().ToList();
            }
            catch
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return list;
        }
    }
}
