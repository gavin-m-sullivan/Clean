using System.ComponentModel.DataAnnotations;

namespace Clean.Core
{
    /// <summary>
    /// Used to encapsulate results of operations that may fail.
    /// </summary>
    /// <typeparam name="TValue">The type of the successful operation.</typeparam>
    public class Result<TValue>
    {
        /// <summary>
        /// The value contained in the successful Result.
        /// </summary>
        /// <remarks>Throws if the Result is failed.</remarks>
        public TValue Value => !this.errors.Any() ?
            this.value : 
            throw new InvalidOperationException("Failed Result has no value.");
        /// <summary>
        /// The errors contained in the failed Result.
        /// </summary>
        /// <remarks>Throws if the Result is successful.</remarks>
        public IEnumerable<ValidationResult> Errors => this.errors.Any() ? 
            this.errors : 
            throw new InvalidOperationException("Successful Result has no errors.");
        /// <summary>
        /// Indicates the state of the Result.
        /// </summary>
        public bool Succeeded => !this.errors.Any();

        private readonly List<ValidationResult> errors = new();
        private readonly TValue value;

        private Result(TValue value)
        {
            this.value = value;
        }

        private Result(ValidationResult error)
        {
            this.value = default!;
            this.errors.Add(error);
        }

        /// <summary>
        /// Creates a failed Result with the errors collection containing the passed error.
        /// </summary>
        /// <param name="validationResult">The error value.</param>
        /// <returns>A failed Result.</returns>
        public static Result<TValue> Fail(ValidationResult validationResult)
        {
            return new(validationResult);
        }

        /// <summary>
        /// Creates a successful Result with the value containing the passed value.
        /// </summary>
        /// <param name="value">The successful value.</param>
        /// <returns>A successful Result.</returns>
        public static Result<TValue> Success(TValue value)
        {
            return new(value);
        }

        /// <summary>
        /// Makes a successful Result a failed Result adding the error to the errors collection.
        /// An already failed Result has this passed error added to the errors collection.
        /// </summary>
        /// <param name="validationResult">The error value.</param>
        public void Failed(ValidationResult validationResult)
        {
            this.errors.Add(validationResult);
        }
    }
}
