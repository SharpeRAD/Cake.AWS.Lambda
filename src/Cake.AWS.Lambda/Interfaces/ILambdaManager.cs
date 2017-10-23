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
        Task<bool> UpdateFunctionCode(string functionName, UpdateFunctionCodeSettings settings, CancellationToken cancellationToken = default(CancellationToken));
        #endregion
    }
}
