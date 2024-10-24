using System.ComponentModel.DataAnnotations;

namespace SummervilleLibrary.Models.DatabaseEntities
{
    public abstract class DatabaseObject
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public void SetCreated(string createdBy)
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void SetUpdated(string updatedBy)
        {
            UpdatedDate = DateTime.UtcNow;
            UpdatedBy = updatedBy;
        }

        public void SoftDelete()
        {
            IsDeleted = true;
            SetUpdated("System"); // Optionally, use "System" or a user identifier
        }

        public void Restore()
        {
            IsDeleted = false;
            SetUpdated("System"); // Optionally, use "System" or a user identifier
        }
    }
}
