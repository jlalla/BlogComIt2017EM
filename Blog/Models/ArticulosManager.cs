using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class ArticulosManager
    {
        public void Insertar(Articulo articulo)
        {
            //1-Conexión.. a qué BBDD
            SqlConnection conexion = new SqlConnection("Server=JLALLA\\SQLEXPRESS;Database=Blog;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia
            sentencia.CommandText = "insert into Articulos (Fecha, Titulo, Texto, Imagen, Autor) VALUES (getdate(), @Titulo, @Texto, @Imagen, @Autor)";
            //sentencia.Parameters.AddWithValue("@Fecha", articulo.Fecha);
            sentencia.Parameters.AddWithValue("@Titulo", articulo.Titulo);
            sentencia.Parameters.AddWithValue("@Texto", articulo.Texto);
            sentencia.Parameters.AddWithValue("@Imagen", articulo.Imagen);
            sentencia.Parameters.AddWithValue("@Autor", "jorgegutierrez@gmail.com");
            //5-Ejecutar!
            sentencia.ExecuteNonQuery();

            //CERRAR LA CONEXION AL TERMINAR!!!!
            conexion.Close();
        }

        public void Eliminar(Articulo articulo)
        {
            this.Eliminar(articulo.ID);
        }

        public void Eliminar(long ID)
        {

        }

        public void Actualizar(Articulo articulo)
        {

        }

        public List<Articulo> ConsultarTodos()
        {
            List<Articulo> articulos = new List<Articulo>();

            //1-Conexión.. a qué BBDD
            SqlConnection conexion = new SqlConnection("Server=JLALLA\\SQLEXPRESS;Database=Blog;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia
            sentencia.CommandText = "SELECT * FROM Articulos";
            //5-ejecutamos la consulta
            SqlDataReader reader = sentencia.ExecuteReader();
            while(reader.Read()) //mientras haya un registro para leer
            {
                //creo el artículo, le completo los datos 
                Articulo articulo = new Articulo();
                articulo.Titulo = reader["Titulo"].ToString();
                articulo.Texto = (string) reader["Texto"];
                articulo.Imagen = reader["Imagen"].ToString();
                articulo.ID = (long) reader["Id"];
                articulo.Fecha = (DateTime)reader["Fecha"];

                articulos.Add(articulo);
            }

            //CERRAR EL READER AL TERMINAR DE LEER LOS REGISTROS
            reader.Close();
            //CERRAR LA CONEXION AL TERMINAR!!!!
            conexion.Close();

            return articulos;
        }

        public Articulo Consultar(long ID)
        {
            return new Articulo();
        }

        /// <summary>
        /// Trae los artículos escrito por el autor pasado por parámetro
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        public List<Articulo> Consultar(Usuario autor)
        {
            return new List<Articulo>();
        }
    }
}