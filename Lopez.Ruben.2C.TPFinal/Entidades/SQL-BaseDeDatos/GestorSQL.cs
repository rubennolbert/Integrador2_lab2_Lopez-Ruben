using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades.Modelos;
using Entidades.Excepciones;

namespace Entidades.SQL_BaseDeDatos
{
    public class GestorSQL
    {
        private static string cadenaConexion;

        static GestorSQL()
        {
            GestorSQL.cadenaConexion = "Server = . ; Database = ATLETAS_TEST_DB ;Trusted_Connection = True";
        }

        /// <summary>
        /// Metodo para leer la lista de atletas de la base SQL, la devuelve en una lista de atletas
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ExceptionSQL"></exception>
        public static List<Atleta> LeerDatosAtleta()
        {
            List<Atleta> listaAtletas = new List<Atleta>();
            string query = "select * from atletas";
            try
            {
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int dni = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        DateTime fechaNacimiento = reader.GetDateTime(3);
                        int pase = reader.GetInt32(4);

                        Atleta atleta = new Atleta(nombre, apellido, dni, fechaNacimiento, (Atleta.EPase)pase);
                        listaAtletas.Add(atleta);
                    }
                }
                return listaAtletas;
            }
            catch (Exception ex)
            {
                throw new ExceptionSQL("Error al leer los atletas de la base de datos", ex);
            }
        }

        /// <summary>
        /// Usando los metodos para traer atletas y cuotas de la base de datos, los carga en un box
        /// </summary>
        /// <param name="Box"></param>
        public static void LeerDatosBoxCrossfit(BoxCrossfit Box)
        {
            Box.ListaAtletas = LeerDatosAtleta();
            foreach (Atleta atleta in Box.ListaAtletas)
            {
                atleta.HistorialDePagos = LeerCuotasDeAtleta(atleta);
            }
        }

        /// <summary>
        /// Carga un atleta en la tabla atletas de la base de datos
        /// </summary>
        /// <param name="a"></param>
        /// <exception cref="ExceptionSQL"></exception>
        public static void AltaAtleta(Atleta a)
        {
            string query = "insert into atletas (nombre, apellido, dni, fecha_nacimiento, pase) values (@nombre, @apellido, @dni, @fecha_nacimiento, @pase)";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(GestorSQL.cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("nombre", a.Nombre);
                cmd.Parameters.AddWithValue("apellido", a.Apellido);
                cmd.Parameters.AddWithValue("dni", a.Dni);
                cmd.Parameters.AddWithValue("fecha_nacimiento", a.FechaNacimiento);
                cmd.Parameters.AddWithValue("pase", (int)a.Pase);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ExceptionSQL("Error al dar de alta en la base de datos", ex);
            }
            finally        //siempre    
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Actualiza los datos de un atleta en la base de datos, el atleta es identificado por su dni 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="dni"></param>
        /// <exception cref="ExceptionSQL"></exception>
        public static void ModificarAtleta(Atleta a, int dni)
        {
            string query = "update atletas set nombre = @nombre, apellido = @apellido, fecha_nacimiento = @fecha_nacimiento, passe = @pase where dni = @dni";
            try
            {
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("dni", dni);
                    cmd.Parameters.AddWithValue("nombre", a.Nombre);
                    cmd.Parameters.AddWithValue("apellido", a.Apellido);
                    cmd.Parameters.AddWithValue("fecha_nacimiento", a.FechaNacimiento);
                    cmd.Parameters.AddWithValue("pase", a.Pase);
                     connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ExceptionSQL("Error al modificar el atleta en la base de datos", ex);
            }
        }

        /// <summary>
        /// Elimina un atleta de la base de datos
        /// </summary>
        /// <param name="dni"></param>
        /// <exception cref="ExceptionSQL"></exception>
        public static void EliminarAtleta(int dni)
        {
            string query = "delete from atletas where dni = @dni";
            try
            {
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("dni", dni);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new ExceptionSQL("Error al eliminar el atleta en la base de datos", ex);
            }
        }

        /// <summary>
        /// Agrega una cuota en la tabla de cuotas de la base
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <exception cref="ExceptionSQL"></exception>
        public static void AltaCuota(Atleta a, Cuota c)
        {
            string query = "insert into cuotas (metodo_de_pago, pase, importe, fecha_cuota, dni) values (@metodo_de_pago, @pase, @importe, @fecha_cuota, @dni)";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(cadenaConexion);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("metodo_de_pago", (int)c.MetodoDePago);
                cmd.Parameters.AddWithValue("pase", (int)c.Pase);
                cmd.Parameters.AddWithValue("importe", c.Importe);
                cmd.Parameters.AddWithValue("fecha_cuota", c.FechaDeCuota);
                cmd.Parameters.AddWithValue("dni", c.DniAtleta);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ExceptionSQL("Error al dar de alta la cuota en la base de datos.", ex);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Trae de la base las cuotas de un atleta determinado
        /// </summary>
        /// <param name="atleta"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionSQL"></exception>
        public static List<Cuota> LeerCuotasDeAtleta(Atleta atleta)
        {
            List<Cuota> listaDeCuotas = new List<Cuota>();
            string datos = string.Empty;

            string query = $"select cuotas.metodo_de_pago, cuotas.importe, cuotas.pase, cuotas.fecha_cuota, cuotas.dni from atletas join cuotas on atletas.dni = cuotas.dni where atletas.dni = {atleta.Dni};";
            try
            {
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int metodoDePago = reader.GetInt32(0);
                        int importe = reader.GetInt32(1);
                        int pase = reader.GetInt32(2);
                        DateTime fechaCuota = reader.GetDateTime(3);
                        int dni = reader.GetInt32(4);
                        Cuota cuota = new Cuota((Cuota.EMetodoDePago)metodoDePago, importe, (Atleta.EPase)pase, fechaCuota, dni);

                        listaDeCuotas.Add(cuota);
                    }
                }
                return listaDeCuotas;
            }
            catch (Exception ex)
            {
                throw new ExceptionSQL("Error al leer las cuotas", ex);
            }
        }



    }
}
