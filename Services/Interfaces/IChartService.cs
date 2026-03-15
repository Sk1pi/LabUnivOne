using EquipmentSystem.DTO;

namespace EquipmentSystem.Services.Interfaces;

public interface IChartService
{
    Task<List<CategoryChartDTO>> GetEquipmentCategoryDataAsync(CancellationToken cancellationToken);
    Task<List<StatusChartDTO>> GetEquipmentStatusDataAsync(CancellationToken cancellationToken);
}