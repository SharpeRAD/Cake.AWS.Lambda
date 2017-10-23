#region Using Statements
using System.Threading;
using System.Threading.Tasks;

using Cake.Core;
using Cake.Core.Annotations;
#endregion



namespace Cake.AWS.Lambda
{
    /// <summary>
    /// Contains Cake aliases for configuring Amazon Lambda functions
    /// </summary>
    [CakeAliasCategory("AWS")]
    [CakeNamespaceImport("Amazon")]
    [CakeNamespaceImport("Amazon.Lambda")]
    public static class LambdaAliases
    {
        private static ILambdaManager CreateManager(this ICakeContext context)
        {
            return new LambdaManager(context.FileSystem, context.Environment, context.Log);
        }



        /// <summary>
        /// Updates the AWS Lambda functions code.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="functionName">The name of an AWS Lambda function.</param>
        /// <param name="settings">The <see cref="UpdateFunctionCodeSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Lambda")]
        public static async Task<bool> UpdateLambdaFunctionCode(this ICakeContext context, string functionName, UpdateFunctionCodeSettings settings)
        {
            return await context.CreateManager().UpdateFunctionCode(functionName, settings);
        }

        /// <summary>
        /// Updates the AWS Lambda functions code.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="functionName">The name of an AWS Lambda function.</param>
        /// <param name="settings">The <see cref="UpdateFunctionCodeSettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("EC2")]
        public static async Task<bool> UpdateLambdaFunctionCode(this ICakeContext context, string functionName, UpdateFunctionCodeSettings settings, CancellationToken cancellationToken)
        {
            return await context.CreateManager().UpdateFunctionCode(functionName, settings, cancellationToken);
        }
    }
}