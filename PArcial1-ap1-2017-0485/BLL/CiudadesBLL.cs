using Microsoft.EntityFrameworkCore;
using PArcial1_ap1_2017_0485.DAL;
using PArcial1_ap1_2017_0485.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PArcial1_ap1_2017_0485.BLL
{
    public class CiudadesBLL
    {
        public static bool Guardar(Ciudades ciudad)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Ciudades.Add(ciudad) != null)
                    paso = db.SaveChanges() > 0;
            }
             catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;

        }

        public static bool Modificar(Ciudades ciudad)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(ciudad).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar (int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Ciudades.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static Ciudades Buscar(int id)
        {
            Contexto db = new Contexto();
            Ciudades ciudad = new Ciudades();
            try
            {
                ciudad = db.Ciudades.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return ciudad;
        }

        public static List<Ciudades> GetList(Expression<Func<Ciudades, bool>> evaluacion)
        {
            var lista = new List<Ciudades>();
            var db = new Contexto();
            try
            {
                lista = db.Ciudades.Where(evaluacion).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;

        }

    }
}
