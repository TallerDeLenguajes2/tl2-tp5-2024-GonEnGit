

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
        repoProducto.ActualizarProducto(id, descripcion, precio);

        return Ok("Producto actualizado correctamente.");
    }

    [HttpGet]
    public ActionResult ListarProductos()
    {
        List<Productos> productosAMostrar;
        productosAMostrar = repoProducto.ListarProductos();

        return Ok(productosAMostrar);
    }
}