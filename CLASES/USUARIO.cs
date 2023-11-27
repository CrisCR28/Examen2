using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace examenII.CLASES
{
    public class USUARIO : System.Web.UI.Page
    {

        /*UsuarioId INT	IDENTITY primary key,
        Nombre varchar(50) not null,
	CorreoElectronico varchar(50),
	Telefono varchar(50) unique,*/

        public int UsuarioId { get; set; }
        public String Nombre { get; set; }
            public String CorreoElectronico { get; set; }
        public String Telefono { get; set; }

        public USUARIO(int USUARIOID, String NOMBRE,String CORREOELECTRONICO, String TELEFONO)
        {
            UsuarioId = USUARIOID;
            Nombre = NOMBRE;
            CorreoElectronico = CORREOELECTRONICO;
            Telefono = TELEFONO;
                
        }
        public int Agregar()
        
       {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INGRESARTIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombreusuario", Nombre));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }
        public int Borrar()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRARTIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGOUSSUARIO", UsuarioId));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;


        }
        public void Consultar()
        { 
        
        
        }
        public void Modificar()
        { 
            
            }
           public static List<USUARIO> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<USUARIO> usuarios = new List<USUARIO>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("consultar_filtroUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            {
                                USUARIO USUARIOs    = new USUARIO (reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));  // instancia
                            usuarios.Add(USUARIOs);
                            
                        }
                        

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return usuarios;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return usuarios;
        }

        public static List<USUARIO> ObtenerTipos()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<USUARIO> usuarios = new List<USUARIO>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("consultar ", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            USUARIO USUARiOs = new USUARIO (reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));  // instancia
                            usuarios.Add(USUARiOs);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return usuarios;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return usuarios;
        }


    }
}
   