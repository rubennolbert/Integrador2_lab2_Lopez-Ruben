using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class BoxCrossfit
    {
        private string nombre;
        private List<Atleta> listaAtletas;

        public string Nombre { get { return nombre; } set { nombre = value; } }
        public List<Atleta> ListaAtletas { get { return listaAtletas; } set { listaAtletas = value; } }

        public BoxCrossfit(string nombre)
        {
            this.nombre = nombre;
            this.listaAtletas = new List<Atleta>();
        }

        public BoxCrossfit(string nombre, List<Atleta> listaAtletas)
        {
            this.Nombre = nombre;
            this.listaAtletas = listaAtletas;
        }



        public static bool operator == (BoxCrossfit B, Atleta A)
        {
            if(B is not null && A is  not null)
            {
                foreach(Atleta item in B.listaAtletas)
                {
                    if(item == A)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator !=(BoxCrossfit B, Atleta A)
        {
            return !(B == A);
        }

        public static bool operator + (BoxCrossfit B, Atleta A)
        {
            if(B is not null && A is not null && B != A)
            {
                B.listaAtletas.Add(A);
                return true;
            }
            return false;
        }

        public static bool operator - (BoxCrossfit B, Atleta A)
        {
            if(A is not null && B is not null && B == A)
            {
                B.listaAtletas.Remove(A);
                return true;
            }
            return false;
        }

        public string ElimiarAtleta(Atleta A)
        {
            if(this - A)
            {
                return "Atleta eliminado de lista.";
            }
            return "No se encuentra en lista.";
        }

        public string ImprirListaDeAtletas()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach(Atleta item in this.listaAtletas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }






    }
}
