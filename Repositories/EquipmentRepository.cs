using EquipmentSystem.DTO;
using EquipmentSystem.Models;
using EquipmentSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EquipmentSystem.Repositories;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly ApplicationDbContext _context;

    public EquipmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryChartDTO>> GetCountByCategoryAsync(CancellationToken cancellationToken)
    {
        return await _context.Equipment
            .Include(e => e.Category)
            .GroupBy(e => e.Category.Categoryname)
            .Select(group => new CategoryChartDTO(group.Key, group.Count()))
            .ToListAsync(cancellationToken);
    }

    public async Task<List<StatusChartDTO>> GetCountByStatusAsync(CancellationToken cancellationToken)
    {
        return await _context.Equipment
            .GroupBy(e => e.Status)
            .Select(group => new StatusChartDTO(group.Key, group.Count()))
            .ToListAsync(cancellationToken);
    }
}