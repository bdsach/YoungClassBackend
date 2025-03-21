using Domain.Interfaces;

namespace Domain.Entities;

public class BaseEntity : IBaseEntity
{
    public DateTime CreatedUTC { get; set; }
    public DateTime UpdatedUTC { get; set; }
    public DateTime? DeletedUTC { get; set; }
}