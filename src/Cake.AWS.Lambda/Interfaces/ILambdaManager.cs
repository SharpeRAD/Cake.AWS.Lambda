#region Using Statements
using System.Threading;
using System.Threading.Tasks;
#endregion



namespace Cake.AWS.Lambda
{
    /// <summary>
    /// Implementation for accessing AWS Lambda
    /// </summary>
    public interface ILambdaManager
    {
        #region Methods
        /// <summary>
        /// Updates the AWS Lambda functions code.
        /// </summary>
        /// <param name="functionName">The name of an AWS Lambda function.</param>
        /// <param name="settings">The <see cref="UpdateFunctionCodeSettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<string> CreateFunction(string functionName, CreateFunctionSettings settings, CancellationToken cancellationToken = default(CancellationToken));



        /// <summary>
        /// Updates the AWS Lambda functions code.
        /// </summary>
        /// <param name="functionName">The name of an AWS Lambda function.</param>
        /// <param name="settings">The <see cref="UpdateFunctionCodeSettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<string> UpdateFunctionCode(string functionName, UpdateFunctionCodeSettings settings, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Publishes a version of your function from the current snapshot of $LATEST.
        /// </summary>
        /// <param name="functionName">The name of an AWS Lambda function.</param>
        /// <param name="settings">The <see cref="PublishVersionSettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<string> PublishVersion(string functionName, PublishVersionSettings settings, CancellationToken cancellationToken = default(CancellationToken));



        /// <summary>
        /// Creates an alias that points to the specified Lambda function version.
        /// </summary>
        /// <param name="functionName">The name of an AWS Lambda function.</param>
        /// <param name="settings">The <see cref="AliasSettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<bool> CreateAlias(string functionName, AliasSettings settings, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update an alias that points to the specified Lambda function version.
        /// </summary>
        /// <param name="functionName">The name of an AWS Lambda function.</param>
        /// <param name="settings">The <see cref="AliasSettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<bool> UpdateAlias(string functionName, AliasSettings settings, CancellationToken cancellationToken = default(CancellationToken));
        #endregion
    }
}
