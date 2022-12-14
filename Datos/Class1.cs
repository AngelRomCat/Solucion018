using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class Class1
    {
        public static NorthWindTuneadoDbContext _db = null;

        public Class1()
        {
            if (_db == null)
            {
                _db = new NorthWindTuneadoDbContext();
            }
        }

        public bool Create(Categoria categoria)
        {
            _db.Categoria.Add(categoria);
            return true;
        }

        public bool GuardarCambios()
        {
            bool ok = false;
            try
            {
                int resultado = 0;
                resultado = _db.SaveChanges();
                if (resultado > 0)
                {
                    ok = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ok;
        }

        public IList<Categoria> Read(int? id)
        {
            IList<Categoria> categorias = null;
            categorias = _db.Categoria.ToList();
            if (id != null && id > 0)
            {
                categorias = categorias.Where(x => x.CategoryID == id).ToList();
            }

            return categorias;
        }

        public bool Update(int id, string texto)
        {
            if (id > 0)
            {
                Categoria categoria = _db.Categoria.Where(x => x.CategoryID == id).FirstOrDefault();
                categoria.CategoryName = texto;
                return true;
            }

            return false;
        }

        public bool Delete(int id, string texto)
        {
            if (id > 0)
            {
                Categoria categoria = _db.Categoria.Where(x => x.CategoryID == id).FirstOrDefault();
                _db.Categoria.Remove(categoria);
                return true;
            }
            else
            {
                IList<Categoria> categorias = null;
                categorias = _db.Categoria.ToList();
                categorias = categorias.Where(x => x.CategoryName == texto).ToList();
                foreach(Categoria categoria in categorias)
                {
                    _db.Categoria.Remove(categoria);
                }

                return true;
            }
        }
    }
}
