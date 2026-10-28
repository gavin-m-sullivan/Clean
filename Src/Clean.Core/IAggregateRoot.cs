namespace Clean.Core
{
    /// <summary>
    /// Base abstraction for all domain model aggregate roots.
    /// Used as a marker class by objects taking only aggregate root models.
    /// </summary>
    public interface IAggregateRoot : IIdentity
    {
    }
}
