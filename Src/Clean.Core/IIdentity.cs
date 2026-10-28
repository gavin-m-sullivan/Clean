namespace Clean.Core
{
    /// <summary>
    /// Base abstraction for all domain models.
    /// </summary>
    public interface IIdentity
    {
        /// <summary>
        /// Gets the ID of the model.
        /// </summary>
        Guid Id { get; }
    }
}
