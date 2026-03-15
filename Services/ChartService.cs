using EquipmentSystem.DTO;
using EquipmentSystem.Repositories.Interfaces;
using EquipmentSystem.Services.Interfaces;

namespace EquipmentSystem.Services;

public class ChartService : IChartService
{
    private readonly IEquipmentRepository _equipmentRepository;

    public ChartService(IEquipmentRepository equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }

    public async Task<List<CategoryChartDTO>> GetEquipmentCategoryDataAsync(CancellationToken cancellationToken)
    {
        return await _equipmentRepository.GetCountByCategoryAsync(cancellationToken);
    }

    public async Task<List<StatusChartDTO>> GetEquipmentStatusDataAsync(CancellationToken cancellationToken)
    {
        return await _equipmentRepository.GetCountByStatusAsync(cancellationToken);
    }
}