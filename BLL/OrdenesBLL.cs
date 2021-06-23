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
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes orden)
        {
            if (!Existe(orden.OrdenID))
                return Insertar(orden);
            else
                return Modificar(orden);
        }

        private static bool Insertar(Ordenes orden)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                contexto.Ordenes.Add(orden);
                found = contexto.SaveChanges() > 0;

                List<OrdenesDetalle> detalles = orden.Detalle;
                foreach (OrdenesDetalle d in detalles)
                {
                    Productos producto = ProductosBLL.Buscar(d.ProductoID);
                    producto.Inventario -= d.Cantidad;
                    ProductosBLL.Guardar(producto);
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

            return found;
        }

        public static bool Modificar(Ordenes orden)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                List<OrdenesDetalle> viejosDetalles = Buscar(orden.OrdenID).Detalle;
                foreach (OrdenesDetalle d in viejosDetalles)
                {
                    Productos producto = ProductosBLL.Buscar(d.ProductoID);
                    producto.Inventario += d.Cantidad;
                    ProductosBLL.Guardar(producto);
                }

                contexto.Database.ExecuteSqlRaw($"delete from OrdenesDetalle where OrdenID = {orden.OrdenID}");
                foreach (var anterior in orden.Detalle)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }

                List<OrdenesDetalle> nuevosDetalles = orden.Detalle;
                foreach (OrdenesDetalle d in nuevosDetalles)
                {
                    Productos producto = ProductosBLL.Buscar(d.ProductoID);
                    producto.Inventario -= d.Cantidad;
                    ProductosBLL.Guardar(producto);
                }

                contexto.Entry(orden).State = EntityState.Modified;
                found = contexto.SaveChanges() > 0;

            }
            catch (Exception)
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
                var orden = contexto.Ordenes.Find(id);

                if (orden != null)
                {
                    List<OrdenesDetalle> viejosDetalles = Buscar(orden.OrdenID).Detalle;
                    foreach (OrdenesDetalle d in viejosDetalles)
                    {
                        Productos producto = ProductosBLL.Buscar(d.ProductoID);
                        producto.Inventario += d.Cantidad;
                        ProductosBLL.Guardar(producto);
                    }

                    contexto.Ordenes.Remove(orden);
                    found = contexto.SaveChanges() > 0;
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

            return found;
        }

        public static Ordenes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ordenes orden;

            try
            {
                orden = contexto.Ordenes
                    .Include(o => o.Suplidor)
                    .Include(o => o.Detalle)
                    .Where(o => o.OrdenID == id)
                    .SingleOrDefault();

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

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool found = false;

            try
            {
                found = contexto.Ordenes.Any(o => o.OrdenID == id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return found;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> criterio)
        {
            List<Ordenes> list = new List<Ordenes>();
            Contexto contexto = new Contexto();

            try
            {
                list = contexto.Ordenes.Where(criterio).AsNoTracking().ToList();
            }
            catch (Exception)
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
