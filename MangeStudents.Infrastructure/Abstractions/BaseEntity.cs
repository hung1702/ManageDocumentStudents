﻿
namespace ManageStudents.Infrastructure.Abstractions;

public abstract class BaseEntity
{ }

public interface IIdentifiableEntity<T>
{
    T Id { get; set; }
}

public interface IAuditableEntity
{
    DateTime CreatedDate { get; set; }
    Guid CreatedBy { get; set; }
    DateTime? UpdatedDate { get; set; }
    Guid? UpdatedBy { get; set; }
}

public interface IDeletableEntity
{
    bool IsDeleted { get; set; }
    DateTime? DeletedDateTime { get; set; }
    Guid? DeletedBy { get; set; }
}

public abstract class IdentifiableEntity<T> : BaseEntity, IIdentifiableEntity<T>
{
    public T Id { get; set; }
}

public abstract class AuditableEntity<T> : IdentifiableEntity<T>, IAuditableEntity
{
    public DateTime CreatedDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Guid? UpdatedBy { get; set; }
}

public abstract class DeletableEntity<T> : IdentifiableEntity<T>, IAuditableEntity, IDeletableEntity
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDateTime { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Guid? UpdatedBy { get; set; }
}