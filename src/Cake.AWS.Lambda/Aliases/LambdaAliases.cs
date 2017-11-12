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
        public static async Task<string> UpdateLambdaFunctionCode(this ICakeContext context, string functionName, UpdateFunctionCodeSettings settings)
        {
            return await context.CreateManager().UpdateFunctionCode(functionName, settings);
        }

        /// <summary>
        /// Publishes a version of your function from the current snapshot of $LATEST.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="functionName">The name of an AWS Lambda function.</param>
        /// <param name="settings">The <see cref="PublishVersionSettings"/> used during the request to AWS.</param>
        /// [CakeMethodAlias]
        [CakeAliasCategory("Lambda")]
        public static async Task<string> PublishLambdaVersion(this ICakeContext context, string functionName, PublishVersionSettings settings)
        {
            return await context.CreateManager().PublishVersion(functionName, settings);
        }



        /// <summary>
        /// Creates an alias that points to the specified Lambda function version.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="functionName">The name of an AWS Lambda function.</param>
        /// <param name="settings">The <see cref="AliasSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Lambda")]
        public static async Task<bool> CreateLambdaAlias(this ICakeContext context, string functionName, AliasSettings settings)
        {
            return await context.CreateManager().CreateAlias(functionName, settings);
        }

        /// <summary>
        /// Update an alias that points to the specified Lambda function version.
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="functionName">The name of an AWS Lambda function.</param>
        /// <param name="settings">The <see cref="AliasSettings"/> used during the request to AWS.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Lambda")]
        public static async Task<bool> UpdateLambdaAlias(this ICakeContext context, string functionName, AliasSettings settings)
        {
            return await context.CreateManager().UpdateAlias(functionName, settings);
        }
    }
}