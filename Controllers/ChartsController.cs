using EquipmentSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChartsController : ControllerBase
{
    private readonly IChartService _chartService;

    public ChartsController(IChartService chartService)
    {
        _chartService = chartService;
    }

    [HttpGet("equipmentByCategory")]
    public async Task<JsonResult> GetEquipmentByCategory(CancellationToken cancellationToken)
    {
        var data = await _chartService.GetEquipmentCategoryDataAsync(cancellationToken);
        return new JsonResult(data.Select(d => new { category = d.Category, count = d.Count }));
    }

    [HttpGet("equipmentByStatus")]
    public async Task<JsonResult> GetEquipmentByStatus(CancellationToken cancellationToken)
    {
        var data = await _chartService.GetEquipmentStatusDataAsync(cancellationToken);
        return new JsonResult(data.Select(d => new { status = d.Status, count = d.Count }));
    }
}