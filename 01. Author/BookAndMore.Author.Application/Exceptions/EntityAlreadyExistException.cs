namespace BookAndMore.Author.Application.Exceptions;
public class EntityAlreadyExistException : EntityNotFoundException
{
    
    public override string Message => $"[{EntityType.Name}] con {EntityField} [{EntityId}] ya existe";
    
    public EntityAlreadyExistException(Type entityType, object entityId, string entityField) : base(entityType, entityId, entityField)
    {
    }
}