namespace Shop.Server.DAL.Core;

public abstract class Entity<TKey>
{
    public TKey Id { get; set; }
}