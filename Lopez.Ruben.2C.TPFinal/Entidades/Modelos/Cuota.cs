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
        private int dniAtleta;                // VA A SER MI FK EN LA BASE DE DATOS ****borrar esto****}


        public Cuota() { }
        public Cuota(EMetodoDePago metodoDePago, int importe, Atleta.EPase pase, DateTime fechaDeCuota, int dniAtleta)
        {
            this.metodoDePago = metodoDePago;
            this.importe = importe;
            this.pase = pase;
            this.fechaDeCuota = fechaDeCuota;
            this.mesCuota = ConvertirStringCuotaMes(fechaDeCuota);
            this.anioCuota = ConvertirStringCuotaAnio(FechaDeCuota);
            this.dniAtleta = dniAtleta;
        }

        public EMetodoDePago MetodoDePago { get { return metodoDePago; } set { metodoDePago = value; } }
        public int Importe { get { return importe; } set { importe = value; } }
        public Atleta.EPase Pase { get { return pase; } set { pase = value; } }
        public DateTime FechaDeCuota { get { return fechaDeCuota; } set { fechaDeCuota = value; } }
        public string MesCuota { get { return mesCuota; } set { mesCuota = value; } }
        public string AnioCuota { get { return anioCuota; } set { anioCuota = value; } }
        public int DniAtleta { get { return dniAtleta; } set { dniAtleta = value; } }


        private string ConvertirStringCuotaMes(DateTime fechaCuota)
        {
            string cuotaMes = FechaDeCuota.ToString("MM");
            return cuotaMes;
        }

        private string ConvertirStringCuotaAnio(DateTime fechaCuota)
        {
            string cuotaAnio = FechaDeCuota.ToString("YYYY");
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

        public static bool operator !=(Cuota c1, Cuota c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return $"Año: {this.AnioCuota}, Mes: {this.MesCuota}, Metodo de Pago: {this.MetodoDePago}, Importe: ${this.Importe}";
        }

    }
}
