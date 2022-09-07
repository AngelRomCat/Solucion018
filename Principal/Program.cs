using Datos;
using Datos.Datos;
using System;
using System.Collections.Generic;

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
            //program.Create();
            //program.Read();
            //program.Update();
            program.Read();
            program.Delete();
            program.Read();
        }

        private void Create()
        {
            Categoria categoria = null;
            categoria = new Categoria();
            //categoria.CategoryID = ??

            Console.WriteLine("Dime el NOMBRE del nuevo registro");
            string texto = Console.ReadLine();
            if (texto != null && texto != "")
            {
                categoria.CategoryName = texto;

                Console.WriteLine("Dime la DESCRIPCIÓN del nuevo registro");
                texto = Console.ReadLine();
                if (texto != null && texto != "")
                {
                    categoria.Description = texto; // "Utensilio cuya utilidad no se ha demostrado de momento";
                }
                bool ok = false;
                ok = _class1.Create(categoria);

                ok = _class1.GuardarCambios();

                Console.WriteLine("El resultado de Create ha sido: " + ok);

                Console.ReadLine();
            }
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

        private void Update()
        {
            Console.WriteLine("Dime el ID del registro a modificar");
            string texto = Console.ReadLine();
            if (texto != null && texto != "")
            {
                int id = 0;
                if (int.TryParse(texto, out id) == true)
                {
                    id = int.Parse(texto);
                    Console.WriteLine("Dime el nuevo NOMBRE del registro");
                    texto = Console.ReadLine();
                }
                if (texto != null && texto != "")
                {
                    bool ok = false;
                    ok = _class1.Update(id, texto);
                    if (ok == true)
                    {
                        ok = _class1.GuardarCambios();
                    }
                    Console.WriteLine("El resultado de Update ha sido: " + ok);
                    Console.ReadLine();
                }
            }
        }

        private void Delete()
        {
            Console.WriteLine("Dime el ID o el NOMBRE del registro a eliminar");
            string texto = Console.ReadLine();
            if (texto != null && texto != "")
            {
                int id = 0;
                if (int.TryParse(texto, out id) == true)
                {
                    id = int.Parse(texto);
                }
                bool ok = false;
                ok = _class1.Delete(id, texto);
                if (ok == true)
                {
                    ok = _class1.GuardarCambios();
                }
                Console.WriteLine("El resultado de Delete ha sido: " + ok);
                Console.ReadLine();
            }

        }
    }
}
