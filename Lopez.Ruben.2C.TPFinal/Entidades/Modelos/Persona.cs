using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        private DateTime fechaNacimiento;
        private int edad;

        protected Persona() { }
        protected Persona(string nombre, string apellido, int dni, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
            this.edad = CalcularEdad();
        }

 
        public string Nombre { get { return this.nombre; }  set { this.nombre = value; } }
        public string Apellido { get { return this.apellido; } set { this.apellido = value; }  }
        public int Dni { get { return this.dni; }  set { this.dni = value; } }
        public DateTime FechaNacimiento { get { return this.fechaNacimiento; } set { this.fechaNacimiento = value; } }
        public int Edad { get { return this.edad; } }


        private int CalcularEdad()
        {
            TimeSpan edad = DateTime.Now - this.fechaNacimiento;
            return (int)(edad.TotalDays / 365.25);
        }

        public override string ToString()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-AR");//probar
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.Nombre}");
            sb.AppendLine($"Apellido: {this.Apellido}");
            sb.AppendLine($"Dni: {this.Dni}");
            sb.AppendLine($"Fecha de nacimiento: {this.FechaNacimiento.ToShortDateString()}");
            sb.AppendLine($"Edad: {this.Edad}");
            return sb.ToString();           
        }

        public virtual string Imprimir()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Tipo:       {this.GetType().Name}");
            sb.AppendLine($"Nombre:     {this.Nombre}");
            sb.AppendLine($"Apellido:   {this.Apellido}");
            sb.AppendLine($"DNI:        {this.Dni}");
            sb.AppendLine($"Fecha Nac.: {this.FechaNacimiento.ToShortDateString()}");
            return sb.ToString();
        }

        public static bool operator == (Persona p1, Persona p2)
        {
            return (p1.dni == p2.dni);
        }

        public static bool operator !=(Persona p1, Persona p2)
        {
            return !(p1 == p2);
        }
    }
}
