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
        public Atleta() : this(String.Empty, String.Empty, -1, DateTime.Now, EPase.UnaClase) //// revisar
        {
            this.historialDePagos = new List<Cuota>();
        }

        public EPase Pase { get { return pase; } set { pase = value; } }
        public List<Cuota> HistorialDePagos { get { return historialDePagos; } set { historialDePagos = value; } }



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
        public static bool operator + (Atleta A, Cuota C)
        {
            if( A is not null && C is not null && A != C)
            {
                A.historialDePagos.Add(C);
                return true;
            }
            return false;
        }





        public static bool RegistroPago(Atleta A, Cuota C)
        {
            if (!(A != C && A + C))
            {
                throw new RegistroPagoCuotaException("Este mes ya esta pago");
                
            }
            return true;
        }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.ToString()}");
            sb.Append($"Pase: {this.pase}");
            return sb.ToString();
        }

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