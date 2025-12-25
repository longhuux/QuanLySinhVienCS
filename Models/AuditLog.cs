namespace StudentManagement.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Action { get; set; } = string.Empty; // "Create", "Update", "Delete"
        public string EntityType { get; set; } = string.Empty; // "Student", "Score", etc.
        public string EntityID { get; set; } = string.Empty;
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string? Description { get; set; }

        public AuditLog()
        {
            Timestamp = DateTime.Now;
        }

        public AuditLog(string action, string entityType, string entityId, string userName, string? description = null)
        {
            Action = action;
            EntityType = entityType;
            EntityID = entityId;
            UserName = userName;
            Description = description;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{Timestamp:yyyy-MM-dd HH:mm:ss}] {Action} {EntityType} {EntityID} by {UserName}";
        }
    }
}

