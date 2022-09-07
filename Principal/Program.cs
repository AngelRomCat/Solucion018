using Datos;
using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal
{
    internal class Program
    {
        public static Class1 _class1 = null;
        static void Main(string[] args)
        {
            Program program = null;
            program = new Program();
            _class1 = new Class1();
            //CRUD
            program.Create();
        }

        private void Create()
        {
            Categoria categoria = null;
            categoria = new Categoria();
            //categoria.CategoryID = ??
            categoria.CategoryName = "Chisme";
            categoria.Description = "Utensilio cuya utilidad no se ha demostrado de momento";
            bool ok = false;
            ok = _class1.Create(categoria);

            ok = _class1.GuardarCambios();

            Console.WriteLine("El resultado de Create ha sido: " + ok);
        }



    }
}
