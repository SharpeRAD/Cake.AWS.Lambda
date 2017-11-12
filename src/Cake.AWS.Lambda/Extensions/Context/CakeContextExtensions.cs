#region Using Statements
using System;

using Cake.Core;
#endregion



namespace Cake.AWS.Lambda
{
    /// <summary>
    /// Contains extension methods for <see cref="ICakeContext" />.
    /// </summary>
    public static class CakeContextExtensions
    {
        /// <summary>
        /// Helper method to get the AWS Credentials from environment variables
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <returns>A new <see cref="UpdateFunctionCodeSettings"/> instance to be used in calls to the <see cref="ILambdaManager"/>.</returns>
        [Obsolete("Please use Initalize extension method instead")]
        public static ClientSettings CreateUpdateFunctionCodeSettings(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.Environment.CreateUpdateFunctionCodeSettings();
        }
    }
}
