namespace Domain.Core;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Entity()
    {
        
    }
    protected Entity(Guid id)
    {
        Id = id;
    }
}