namespace EspacioRepositorios;

using EspacioModelos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

[ApiController]
[Route("ProductosController")]
public class PresupuestoController : ControllerBase
{
    private PresupuestoRepository repoPresupuestos = new PresupuestoRepository();

    [HttpPost("/api/Presupuesto")]
    public ActionResult CrearNuevoPresupuesto(Presupuesto presupuesto)
    {
        repoPresupuestos.CrearPresupuesto(presupuesto);

        return Ok("Presupuesto creado exitosamente.");
    }
}