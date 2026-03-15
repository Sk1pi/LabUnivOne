using EquipmentSystem.DTO;

namespace EquipmentSystem.Repositories.Interfaces;

public interface IEquipmentRepository
{
    Task<List<CategoryChartDTO>> GetCountByCategoryAsync(CancellationToken cancellationToken);
    Task<List<StatusChartDTO>> GetCountByStatusAsync(CancellationToken cancellationToken);
}