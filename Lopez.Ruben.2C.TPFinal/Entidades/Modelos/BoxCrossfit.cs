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


        /// <summary>
        /// Sobrecarga del operador de igualdad entre un box y un atleta, si el box tiene ese atleta en la lista de atletas que
        /// tiene como atributo, devuelve true, si el aleta no se encuentra devuelve false
        /// </summary>
        /// <param name="B"></param>
        /// <param name="A"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sobrecarga del operador suma entre un box y un atleta, si se quiere agregar un atleta a la lista de atletas del box y en
        /// ella se encuentra otro atleta con el mismo dni (utilizando la sobrecarga del operador == de persona) retorna false, 
        /// si no, retorna true y agrega el atleta a la lista del box  
        /// </summary>
        /// <param name="B"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public static bool operator + (BoxCrossfit B, Atleta A)
        {
            if(B is not null && A is not null && B != A)
            {
                B.listaAtletas.Add(A);
                return true;
            }
            return false;
        }

        /// <summary>
        /// obrecarga del operador resta entre un box y un atleta, si se quiere remover un atleta de la lista de atletas del box y en ella no se encuentra dicho atleta, retorna false,
        /// en cambio si el atleta si esta en la lista, es removido y retorna true
        /// </summary>
        /// <param name="B"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public static bool operator - (BoxCrossfit B, Atleta A)
        {
            if(A is not null && B is not null && B == A)
            {
                B.listaAtletas.Remove(A);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Utilizando la sobrecarga del operador resta entre un box y un atleta,
        /// remueve el atleta que recibe como parametro de la lista del box
        /// y retorna un mensaje en un string avisando si lo pudo remover o no
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public string ElimiarAtleta(Atleta A)
        {
            if(this - A)
            {
                return "Atleta eliminado de lista.";
            }
            return "No se encuentra en lista.";
        }

        /// <summary>
        /// Retorna en un string los datos de los atletas que se encuentren en la lista de atletas del box
        /// </summary>
        /// <returns></returns>
        public string ImprimirListaDeAtletas()
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
