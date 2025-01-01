namespace Blog.Domain.Common.Models;

public abstract class AggregateRoot<TID>(TID id) : Entity<TID>(id)
    where TID : notnull { }
