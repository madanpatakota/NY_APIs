// Nyayabharat.Domain/Common/AuditableEntity.cs
namespace Nyayabharat.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
