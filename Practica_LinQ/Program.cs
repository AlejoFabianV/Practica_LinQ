using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_LinQ
{
    class Empresa
    {
        public string Nombre { get; set; }
        public int Id { get; set; }

        public void DatosEmpresa()
        {
            Console.WriteLine("Empresa {0} con Id {1}", Nombre, Id);
        }
       
    }

    class Empleado
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public double Sueldo { get; set; }

        // clave foranea 
        public int EmpresaId { get; set; }

        public void DatosEmpleados()
        {
            Console.WriteLine("Empleado {0} con Id {1}, con un sueldo de {2}, pertenece a la empresa {3}", Nombre, Id, Sueldo, EmpresaId);
        }

    }

    class ControlEmpresaEmpleado
    {
        public List<Empresa> ListaEmpresas;
        public List<Empleado> ListaEmpleados;

        public ControlEmpresaEmpleado()
        {
            ListaEmpresas = new List<Empresa>();
            ListaEmpleados = new List<Empleado>();

            ListaEmpresas.Add(new Empresa { Nombre = "Microsoft", Id = 1});
            ListaEmpresas.Add(new Empresa { Nombre = "Google", Id = 2 });

            ListaEmpleados.Add(new Empleado { Nombre = "alejo", Id = 1, Sueldo = 200, EmpresaId = 1});
            ListaEmpleados.Add(new Empleado { Nombre = "fabian", Id = 2, Sueldo = 150, EmpresaId = 1 });
            ListaEmpleados.Add(new Empleado { Nombre = "ale", Id = 3, Sueldo = 100, EmpresaId = 2 });
            ListaEmpleados.Add(new Empleado { Nombre = "homero", Id = 4, Sueldo = 500, EmpresaId = 2 });

        }

        public void GetEmpleadoIDEMpresa(int id)
        {
            IEnumerable<Empleado> empleados = from empleadosID in ListaEmpleados join empresaID in ListaEmpresas
                                             on empleadosID.EmpresaId equals empresaID.Id
                                             where empresaID.Id==id
                                             select empleadosID;

            foreach (Empleado empleadoById in empleados)
            {
                empleadoById.DatosEmpleados();
            }
        }

        /*public void GetEmpresas()
        {
            IEnumerable<Empresa> allEmpresas = from empresas in ListaEmpresas select empresas;

            foreach (Empresa AllEmpresas in allEmpresas)
            {
                AllEmpresas.DatosEmpresa();
            }
        }

        public void GetEmpleados()
        {
            IEnumerable<Empleado> allEmpleados = from empleados in ListaEmpleados select empleados;

            foreach (Empleado allEmpleado in allEmpleados)
            {
                allEmpleado.DatosEmpleados();
            }
        }

        public void GetSalario()
        {
            IEnumerable<Empleado> Salarios= from MayorSalario in ListaEmpleados where MayorSalario.Sueldo > 150 select MayorSalario;

            foreach (Empleado mayorSalario in Salarios)
            {
                mayorSalario.DatosEmpleados();

            }
        }*/
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            ControlEmpresaEmpleado empleadoId = new ControlEmpresaEmpleado();
            Console.WriteLine("Ingrese id de empresa:");
            string entrada = Console.ReadLine();

            try
            {
                int entradaId = Convert.ToInt32(entrada);
                if (entradaId == 1 || entradaId ==2)
                {
                    empleadoId.GetEmpleadoIDEMpresa(entradaId);
                }else
                {
                    Console.WriteLine("Este id de empresa no existe");
                }

            } catch (Exception)
            {
                Console.WriteLine("El id es erroneo");
            }
            
            Console.ReadKey();
        }
    }
}
