using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Cuota
    {
        public enum EMetodoDePago { Efectivo, Debito, Credito, MercadoPago };

        private EMetodoDePago metodoDePago;
        private int importe;
        private Atleta.EPase pase;
        private DateTime fechaDeCuota;
        private string mesCuota;
        private string anioCuota;
        private int dniAtleta;                // VA A SER MI FK EN LA BASE DE DATOS 


        public Cuota() { }

        public Cuota(EMetodoDePago metodoDePago, int importe, Atleta.EPase pase, DateTime fechaDeCuota, int dniAtleta)
        {
            this.metodoDePago = metodoDePago;
            this.importe = importe;
            this.pase = pase;
            this.fechaDeCuota = fechaDeCuota;
            this.mesCuota = ConvertirStringCuotaMes(fechaDeCuota);
            this.anioCuota = ConvertirStringCuotaAnio(fechaDeCuota);
            this.dniAtleta = dniAtleta;
        }

        public EMetodoDePago MetodoDePago { get { return metodoDePago; } set { metodoDePago = value; } }
        public int Importe { get { return importe; } set { importe = value; } }
        public Atleta.EPase Pase { get { return pase; } set { pase = value; } }
        public DateTime FechaDeCuota { get { return fechaDeCuota; } set { fechaDeCuota = value; } }
        public string MesCuota { get { return mesCuota; } set { mesCuota = value; } }
        public string AnioCuota { get { return anioCuota; } set { anioCuota = value; } }
        public int DniAtleta { get { return dniAtleta; } set { dniAtleta = value; } }


        /// <summary>
        /// Extrae del atributo fechaDeCuota, que es del tipo DateTime, el mes y lo guarda como string
        /// </summary>
        /// <param name="fechaCuota"></param>
        /// <returns></returns>
        private string ConvertirStringCuotaMes(DateTime fechaCuota)
        {
            string cuotaMes = string.Empty;
            cuotaMes = FechaDeCuota.ToString("MM");
            return cuotaMes;
        }

        /// <summary>
        /// Extrae del atributo fechaDeCuota, que es del tipo DateTime, el año y lo guarda como string
        /// </summary>
        /// <param name="fechaCuota"></param>
        /// <returns></returns>
        private string ConvertirStringCuotaAnio(DateTime fechaCuota)
        {
            string cuotaAnio = string.Empty;
            cuotaAnio = FechaDeCuota.ToString("yyyy");
            return cuotaAnio;
        }
        
        public static bool operator == (Cuota c1,  Cuota c2)
        {
            if(c1.mesCuota == c2.mesCuota && c1.anioCuota == c2.anioCuota)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad dos cuotas, si las cuotas tienen iguales los atributos
        /// mesCuota y mesAnio, devuelve true 
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator !=(Cuota c1, Cuota c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// Override del metodo ToString para la clase cuota para retornar los datos del objeto instanciado
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Año: {this.AnioCuota}, Mes: {this.MesCuota}, Metodo de Pago: {this.MetodoDePago}, Importe: ${this.Importe}";
        }

    }
}
