namespace EspacioRepositorios;

using EspacioModelos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

public class ProductoRepository
{
// esta cadena de conexion es parte de la clase no de los metodos
    string cadenaDeConexion = "Data Source = db\\Tienda.db";
    public void CargarNuevoProducto(Productos producto)
    {
    // no te comas las @, estan para mapear los atributos mas abajo
        string peticion = @"INSERT INTO Productos(Descripcion,Precio) VALUES (@Descripcion,@Precio)";
        Productos nuevo = new Productos();
        
    // a esot lo podes seguir como está en la teoria
        using (SqliteConnection conexion = new SqliteConnection(cadenaDeConexion))
        {
            SqliteCommand comando = new SqliteCommand(peticion, conexion);
            conexion.Open();
        // esto mencionaron en la teoria, 'Parameters' lo usas
        // para ligar el parametro del query con el valor que corresponda
            comando.Parameters.Add(new SqliteParameter("@Descripcion", producto.Descripcion));
            comando.Parameters.Add(new SqliteParameter("@Precio", producto.Precio));
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }

    public List<Productos> ListarProductos()
    {
        List<Productos> lista = new List<Productos>();
        string peticion = @"SELECT * FROM Productos";

        using(SqliteConnection conexion = new SqliteConnection(cadenaDeConexion))
        {
            SqliteCommand comando = new SqliteCommand(peticion, conexion);
            conexion.Open();
            using(SqliteDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Productos productoLeido = new Productos();
                    productoLeido.Id = Convert.ToInt32(lector["idProducto"]);
                    productoLeido.Descripcion = lector["Descripcion"].ToString();
                    productoLeido.Precio = Convert.ToDouble(lector["Precio"]);

                    lista.Add(productoLeido);
                }
            }
            conexion.Close();

            return lista;
        }
    }
}