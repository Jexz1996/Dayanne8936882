using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_MVC_PARCIAL2.Models
{
    public class UsuariosDAL
    {
        string connectionString = "Data Source=DESKTOP-42T8G8A;Initial Catalog=CRUD_MVC;Integrated Security=True";

        /// <summary>
        /// busqueda de los usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuarios> ListarUsuarios()
        {
            List<Usuarios> ListaUsuarios = new List<Usuarios>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios", con); cmd.CommandType = CommandType.Text;

                con.Open(); SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Usuarios oUsuarios = new Usuarios();

                    oUsuarios.ID = Convert.ToInt32(rdr["ID"]);
                    oUsuarios.NOMBRE = rdr["NOMBRE"].ToString();
                    oUsuarios.TELEFONO = rdr["TELEFONO"].ToString();
                    oUsuarios.EMAIL = rdr["EMAIL"].ToString();
                    oUsuarios.ESTADO_CIVIL = rdr["ESTADO_CIVIL"].ToString();
                    oUsuarios.HIJOS = rdr["HIJOS"].ToString();
                    oUsuarios.LIBROS_VALUE = rdr["LIBROS"].ToString() == "1" ? "SI" : "NO";
                    oUsuarios.MUSICA_VALUE = rdr["MUSICA"].ToString() == "1" ? "SI" : "NO";
                    oUsuarios.DEPORTES_VALUE = rdr["DEPORTES"].ToString() == "1" ? "SI" : "NO";
                    oUsuarios.OTROS_VALUE = rdr["OTROS"].ToString() == "1" ? "SI" : "NO";


                    ListaUsuarios.Add(oUsuarios);
                }
                con.Close();
            }
            return ListaUsuarios;
        }

        ///rutina para agregar registros a la tabla usuarios
        ///mediante parametros que recepcionan el valor de las propiedades atravez del metodo get
        public void AgregarUsuarios(Usuarios oUsuarios)
        {
            using (SqlConnection con = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO usuarios (NOMBRE, EMAIL, TELEFONO, ESTADO_CIVIL, HIJOS, LIBROS, MUSICA, DEPORTES, OTROS) VALUES(@NOMBRE, @EMAIL,@TELEFONO, @ESTADO_CIVIL, @HIJOS, @LIBROS,@MUSICA, @DEPORTES, @OTROS)", con); cmd.CommandType = CommandType.Text; 
 
                cmd.Parameters.AddWithValue("@NOMBRE", oUsuarios.NOMBRE);
                cmd.Parameters.AddWithValue("@EMAIL", oUsuarios.EMAIL);
                cmd.Parameters.AddWithValue("@TELEFONO", oUsuarios.TELEFONO);
                cmd.Parameters.AddWithValue("@ESTADO_CIVIL", oUsuarios.ESTADO_CIVIL);
                cmd.Parameters.AddWithValue("@HIJOS", oUsuarios.HIJOS);
                cmd.Parameters.AddWithValue("@LIBROS", oUsuarios.LIBROS);
                cmd.Parameters.AddWithValue("@MUSICA", oUsuarios.MUSICA);
                cmd.Parameters.AddWithValue("@DEPORTES", oUsuarios.DEPORTES);
                cmd.Parameters.AddWithValue("@OTROS", oUsuarios.OTROS);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Usuarios ObtenerDatosUsuario(int? ID)
        {
            Usuarios oUsuarios = new Usuarios();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM usuarios WHERE ID= " + ID; SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open(); SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    oUsuarios.ID = Convert.ToInt32(rdr["ID"]);
                    oUsuarios.NOMBRE = rdr["NOMBRE"].ToString();
                    oUsuarios.EMAIL = rdr["EMAIL"].ToString();
                    oUsuarios.TELEFONO = rdr["TELEFONO"].ToString();
                    oUsuarios.ESTADO_CIVIL = rdr["ESTADO_CIVIL"].ToString();
                    oUsuarios.HIJOS = rdr["HIJOS"].ToString();
                    oUsuarios.LIBROS_VALUE = rdr["LIBROS"].ToString() == "1" ? "SI" : "NO";
                    oUsuarios.MUSICA_VALUE = rdr["MUSICA"].ToString() == "1" ? "SI":"NO";
                    oUsuarios.DEPORTES_VALUE = rdr["DEPORTES"].ToString() == "1" ? "SI" : "NO"; ;
                    oUsuarios.OTROS_VALUE = rdr["OTROS"].ToString() == "1" ? "SI" : "NO"; ;

                    //valor para los checksbox
                    //se alamacena 1 o 0 por el tipo de dato bool
                    oUsuarios.LIBROS = rdr["LIBROS"].ToString() == "1" ? true : false; 
                    oUsuarios.MUSICA = rdr["MUSICA"].ToString() == "1" ? true : false;
                    oUsuarios.DEPORTES = rdr["DEPORTES"].ToString() == "1" ? true : false;
                    oUsuarios.OTROS = rdr["OTROS"].ToString() == "1" ? true : false;
                }
            }
            return oUsuarios;
        }


        public void BorrarUsuarios(int? ID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM usuarios WHERE ID=@ID", con); cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open(); cmd.ExecuteNonQuery(); con.Close();
            }
        }

                  
        public void ModificarUsuarios(Usuarios oUsuarios)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE usuarios SET NOMBRE=@NOMBRE, EMAIL=@EMAIL, TELEFONO=@TELEFONO, ESTADO_CIVIL=@ESTADO_CIVIL, HIJOS=@HIJOS, LIBROS=@LIBROS, MUSICA=@MUSICA, DEPORTES=@DEPORTES, OTROS=@OTROS  WHERE ID=@ID", con); cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", oUsuarios.ID);
                cmd.Parameters.AddWithValue("@NOMBRE", oUsuarios.NOMBRE);
                cmd.Parameters.AddWithValue("@EMAIL", oUsuarios.EMAIL);
                cmd.Parameters.AddWithValue("@TELEFONO", oUsuarios.TELEFONO);
                cmd.Parameters.AddWithValue("@ESTADO_CIVIL", oUsuarios.ESTADO_CIVIL);
                cmd.Parameters.AddWithValue("@HIJOS", oUsuarios.HIJOS);
                cmd.Parameters.AddWithValue("@LIBROS", oUsuarios.LIBROS);
                cmd.Parameters.AddWithValue("@MUSICA", oUsuarios.MUSICA);
                cmd.Parameters.AddWithValue("@DEPORTES", oUsuarios.DEPORTES);
                cmd.Parameters.AddWithValue("@OTROS", oUsuarios.OTROS);

                con.Open(); cmd.ExecuteNonQuery(); con.Close();
            }
        }

    }
}