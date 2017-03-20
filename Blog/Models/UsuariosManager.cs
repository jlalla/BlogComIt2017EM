﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class UsuariosManager
    {
        internal Usuario Validar(string email, string password)
        {
            Usuario usuario = new Models.Usuario();

            //1-Conexión.. a qué BBDD
            SqlConnection conexion = new SqlConnection("Server=JLALLA\\SQLEXPRESS;Database=Blog;Trusted_Connection=True;");
            //2-nos conectamos
            conexion.Open();
            //3-creamos el objeto que nos permite escribir la sentencia
            SqlCommand sentencia = conexion.CreateCommand();
            //4-escribrimos la sentencia
            sentencia.CommandText = "SELECT * FROM Usuarios WHERE Mail = @Mail AND Password = @Password";
            sentencia.Parameters.AddWithValue("@Mail", email);
            sentencia.Parameters.AddWithValue("@Password", password);

            //5-ejecutamos la consulta
            SqlDataReader reader = sentencia.ExecuteReader();
            if (reader.Read()) //mientras haya un registro para leer
            {
                usuario.Mail = reader["Mail"].ToString();
                usuario.Nombre = reader["Nombre"].ToString();
                usuario.Password = reader["Password"].ToString();
                //usuario.Imagen = reader["Mail"].ToString();
            }
            else
            {
                usuario = null;
            }

            //CERRAR EL READER AL TERMINAR DE LEER LOS REGISTROS
            reader.Close();
            //CERRAR LA CONEXION AL TERMINAR!!!!
            conexion.Close();

            return usuario;
        }
    }
}