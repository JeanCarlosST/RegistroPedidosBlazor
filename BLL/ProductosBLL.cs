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
    public class ProductosBLL
    {
        public static bool Guardar(Productos producto)
        {
            if (!Existe(producto.ProductoID))
                return Insertar(producto);
            else
                return Modificar(producto);
        }
        private static bool Insertar(Productos producto)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {;
                contexto.Productos.Add(producto);
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
        public static bool Modificar(Productos producto)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                contexto.Entry(producto).State = EntityState.Modified;
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
                var producto = contexto.Productos.Find(id);

                if (producto != null)
                {
                    contexto.Productos.Remove(producto);
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
        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos producto;

            try
            {
                producto = contexto.Productos
                    .Where(p => p.ProductoID == id)
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

            return producto;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                found = contexto.Productos.Any(p => p.ProductoID == id);
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

        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> list = new List<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                list = contexto.Productos.Where(criterio).AsNoTracking().ToList();
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
