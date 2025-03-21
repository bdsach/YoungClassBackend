namespace Domain.Interfaces;

public interface IBaseEntity
{
    DateTime CreatedUTC { get; set; }
    DateTime UpdatedUTC { get; set; }
    DateTime? DeletedUTC { get; set; }
}