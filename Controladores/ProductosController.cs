

using EspacioModelos;
using EspacioRepositorios;
using Microsoft.AspNetCore.Mvc;


namespace EspacioControllers;

[ApiController]
[Route("ProductosController")]
public class ProductosController : ControllerBase
{
    public ProductosController() {}

    private ProductoRepository repoProducto = new ProductoRepository();

    [HttpPost]
    public ActionResult CargarProducto([FromBody] Productos producto)
    {
        repoProducto.CargarNuevoProducto(producto);

        return Ok("Producto cargado con exito.");
    }   
}