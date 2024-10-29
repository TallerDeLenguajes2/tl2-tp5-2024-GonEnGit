

using EspacioModelos;
using EspacioRepositorios;
using Microsoft.AspNetCore.Mvc;


namespace EspacioControllers;

[ApiController]
[Route("ProductosController")]
public class ProductosController : ControllerBase
{
    private ProductoRepository repoProducto = new ProductoRepository();

    [HttpPost]
    public ActionResult CargarProducto(Productos producto)
    {
        repoProducto.CargarNuevoProducto(producto);

        return Ok("Producto cargado con exito.");
    }

    [HttpPut]
    public ActionResult ActualizarProducto(int id, string descripcion, double precio)
    {
        List<int> listaId = repoProducto.ObtenerListaId();
        bool existe = listaId.Any(deLaLista => deLaLista == id); // .Any() busca si almenos 1 coincide, todos los idProducto son unicos

        if (existe)
        {
            repoProducto.ActualizarProducto(id, descripcion, precio);
            return Ok("Producto actualizado correctamente.");
        }
        else
        {
            return NotFound("Este id no le corresponde a ningun producto.");
        }
    }

    [HttpGet]
    public ActionResult ListarProductos()
    {
        List<Productos> productosAMostrar = repoProducto.ListarProductos();

        return Ok(productosAMostrar);
    }
}