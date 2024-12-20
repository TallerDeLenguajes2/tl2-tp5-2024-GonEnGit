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

// tendrias que consultar si esto está bien
    [HttpPost("/api/Presupuesto/{id}/PresupuestoDetalle")]
    public ActionResult AgregarDetalle(PresupuestoDetalle detalle)
    {
        repoPresupuestos.AgregarDetalle(detalle.IdPresupuesto, detalle.IdProducto, detalle.Cantidad);

        return Ok("Detalle agregado correctamente.");
    }

    [HttpGet("/api/Presupuesto")]
    public ActionResult ConsultarPresupuestos()
    {
        List<Presupuesto> presupuestos = repoPresupuestos.ConsultarPresupuestos();

        return Ok(presupuestos);
    }

    [HttpPut("/api/Presupuesto/{idPresupuesto}")]
    public ActionResult ActualizarDetalle(PresupuestoDetalle detalle)
    {
        repoPresupuestos.ActualizarDetalle(detalle.IdPresupuesto, detalle.IdProducto, detalle.Cantidad);

        return Ok("Detalle actualizado.");
    }
}