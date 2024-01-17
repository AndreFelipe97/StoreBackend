using Api.Domain.Interfaces;

namespace Api.Domain.Entities
{
    public abstract class PersonEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
