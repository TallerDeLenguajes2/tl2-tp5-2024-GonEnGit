

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
    public ActionResult CargarProducto([FromBody] Productos producto)
    {
        repoProducto.CargarNuevoProducto(producto);

        return Ok("Producto cargado con exito.");
    }

    [HttpGet]
    public ActionResult ListarProductos()
    {
        List<Productos> productosAMostrar;
        productosAMostrar = repoProducto.ListarProductos();

        return Ok(productosAMostrar);
    }
}