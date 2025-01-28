using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class Specialization : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public List<Craftsman> Craftsmen { get; set; } = [];
}