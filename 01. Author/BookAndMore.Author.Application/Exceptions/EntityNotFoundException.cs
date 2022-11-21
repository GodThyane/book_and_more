namespace BookAndMore.Author.Application.Exceptions;

public class EntityNotFoundException : Exception
{
    protected static Type EntityType { get; set; } = null!;
    protected static object EntityId { get; set; } = null!;
    protected static string EntityField { get; set; } = null!;

    public override string Message => $"[{EntityType.Name}] con [{EntityField}] [{EntityId}] no encontrado";
    public EntityNotFoundException(Type entityType, object entityId, string entityField)
    {
        EntityType = entityType;
        EntityId = entityId;
        EntityField = entityField;
    }
    
}