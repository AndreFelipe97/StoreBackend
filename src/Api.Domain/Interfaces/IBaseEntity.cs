using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Interfaces
{
    public interface IBaseEntity
    {
        [Key]
        int Id { get; set; }
        [DataType(DataType.DateTime)]
        DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        DateTime UpdatedAt { get; set; }
    }
}
