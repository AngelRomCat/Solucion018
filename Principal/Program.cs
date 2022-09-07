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
            program.Read();
        }

        private void Create()
        {
            Categoria categoria = null;
            categoria = new Categoria();
            //categoria.CategoryID = ??

            Console.WriteLine("Dime el NOMBRE del nuevo registro");
            string texto = Console.ReadLine();
            if (texto != null)
            {
                categoria.CategoryName = texto;
            }

            Console.WriteLine("Dime la DESCRIPCIÓN del nuevo registro");
            texto = Console.ReadLine();
            if (texto != null)
            {
                categoria.Description = texto; // "Utensilio cuya utilidad no se ha demostrado de momento";
            }
            bool ok = false;
            ok = _class1.Create(categoria);

            ok = _class1.GuardarCambios();

            Console.WriteLine("El resultado de Create ha sido: " + ok);

            Console.ReadLine();
        }

        private void Read()
        {
            IList<Categoria> categorias = null;

            Console.WriteLine("Dime el id del registro a mostrar");
            string texto = Console.ReadLine();
            if (texto == null || texto == "")
            {
                categorias = _class1.Read(null);
            }
            else
            {
                int id = 0;
                if (int.TryParse(texto, out id) == true)
                {
                    id = int.Parse(texto);
                }
                categorias = _class1.Read(id);
            }

            foreach(Categoria categoria in categorias)
            {
                Console.WriteLine(categoria.CategoryID + " " + categoria.CategoryName);
            }
            Console.ReadLine();
        }



    }
}
