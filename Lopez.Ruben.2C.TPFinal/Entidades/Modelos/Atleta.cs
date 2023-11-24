using System.Text;

namespace Entidades.Modelos
{
    public sealed class Atleta : Persona
    {
        public enum EPase { Libre, UnaClase}

        private EPase pase;
        private List<Cuota> historialDePagos;

        public Atleta(string nombre, string apellido, int dni,  DateTime fechaNacimiento, EPase pase) : base(nombre,apellido,dni,fechaNacimiento)
        {
            this.pase = pase;
            this.historialDePagos = new List<Cuota>();
        }
        public Atleta() : this(String.Empty, String.Empty, -1, DateTime.Now, EPase.UnaClase) 
        {
            this.historialDePagos = new List<Cuota>();
        }

        public EPase Pase { get { return pase; } set { pase = value; } }
        public List<Cuota> HistorialDePagos { get { return historialDePagos; } set { historialDePagos = value; } }


        /// <summary>
        /// Sobrecarga del operador de igualdad entre un atleta y una cuota, si el atleta tiene esa cuota en la lista de cuotas que
        /// tiene como atributo, devuelve true, si la cuota no se encuentra devuelve false
        /// </summary>
        /// <param name="A"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public static bool operator == (Atleta A, Cuota C)
        {
            if(A is not null && C is not null)
            {
                foreach(Cuota item in A.HistorialDePagos)
                {
                    if(item == C)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator !=(Atleta A, Cuota C)
        {
            return !(A == C);
        }

        /// <summary>
        /// Sobrecarga del operador suma entre un atleta y una cuota, si el atleta no tiene esa cuota en la lista de cuotas que
        /// tiene como atributo la cuota se agrega a la lista y devuelve true
        /// </summary>
        /// <param name="A"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        public static bool operator + (Atleta A, Cuota C)
        {
            if( A is not null && C is not null && A != C)
            {
                A.historialDePagos.Add(C);
                return true;
            }
            return false;
        }



        /// <summary>
        /// Si se quiere agregar una cuota a la lista de cuotas del atleta y en ella se encuentra otra cuota con mismo mes y anio
        /// se arroja una exception del tipo RegistroPagoCuotaException
        /// </summary>
        /// <param name="A"></param>
        /// <param name="C"></param>
        /// <returns></returns>
        /// <exception cref="RegistroPagoCuotaException"></exception>
        public static bool RegistroPago(Atleta A, Cuota C)
        {
            if (!(A != C && A + C))
            {
                throw new RegistroPagoCuotaException("Este mes ya esta pago");
                
            }
            return true;
        }

        /// <summary>
        /// Recorre la lista de cuotas del atleta en busca de una cuota con el mismo mes y anio al momento de la consulta,
        /// retorna true si la encuentra
        /// </summary>
        /// <returns></returns>
        public bool VerificacionPagoAlDia()
        {
            string mesActual = DateTime.Now.ToString("MM");   
            string anioActual = DateTime.Now.ToString("yyyy");

            foreach(Cuota cuota in this.historialDePagos)
            {
                if(cuota.MesCuota == mesActual && cuota.AnioCuota == anioActual)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Override del metodo ToString para la clase atleta para retornar los datos del objeto instanciado
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.ToString()}");
            sb.Append($"Pase: {this.pase}");
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve en un string los datos de la persona instanciada de un dato por linea y llamando al metodo para verificar si esta al dia
        /// modifica la linea de estado de cuenta
        /// </summary>
        /// <returns></returns>
        public override string Imprimir()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.Imprimir()}");
            sb.AppendLine($"Pase:  {this.pase}\n");
            sb.Append($"ESTADO DE CUENTA: ");
            if (this.VerificacionPagoAlDia())
            {
                sb.AppendLine("PAGO AL DIA.\n");
            }
            else
            {
                sb.AppendLine("ADEUDA CUOTA.\n");
            }
            sb.AppendLine($"Historia de pagos:");
            foreach (Cuota cuota in this.historialDePagos)
            {
                sb.AppendLine($"{cuota.ToString()}");
            }
            return sb.ToString();
        }


    }
}