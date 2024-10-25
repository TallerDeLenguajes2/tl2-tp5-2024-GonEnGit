namespace EspacioRepositorios;

using EspacioModelos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

public class ProductoRepository
{
    string cadenaDeConexion = "Data Source = db\\Tienda.db";
    public void CargarNuevoProducto(Productos producto)
    {
        Productos nuevo = new Productos();
        string peticion = @"INSERT INTO Productos(Descripcion,Precio) VALUES (@Descripcion,@Precio)";

        using (SqliteConnection coneccion = new SqliteConnection(cadenaDeConexion))
        {
            SqliteCommand comando = new SqliteCommand(peticion, coneccion);
            coneccion.Open();
            comando.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
            comando.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
            comando.ExecuteNonQuery();
            coneccion.Close();
        }
    }
}