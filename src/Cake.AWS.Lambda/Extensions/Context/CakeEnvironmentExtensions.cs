#region Using Statements
using System;

using Cake.Core;

using Amazon;
using Amazon.Runtime;
#endregion



namespace Cake.AWS.Lambda
{
    /// <summary>
    /// Contains extension methods for <see cref="ICakeEnvironment" />.
    /// </summary>
    public static class CakeEnvironmentExtensions
    {
        /// <summary>
        /// Helper method to get the AWS Credentials from environment variables
        /// </summary>
        /// <param name="environment">The cake environment.</param>
        /// <param name="settings">The Labda settings.</param>
        /// <returns>The same <see cref="ClientSettings"/> instance so that multiple calls can be chained.</returns>
        private static T Initialize<T>(this T settings, ICakeEnvironment environment) where T : ClientSettings
        {
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            //AWS Fallback
            AWSCredentials creds = FallbackCredentialsFactory.GetCredentials();
            if (creds != null)
            {
                settings.Credentials = creds;
            }

            string region = environment.GetEnvironmentVariable("AWS_REGION");
            if (!String.IsNullOrEmpty(region))
            {
                settings.Region = RegionEndpoint.GetBySystemName(region);
            }

            return settings;
        }



        /// <summary>
        /// Helper method to get the AWS Credentials from environment variables
        /// </summary>
        /// <param name="environment">The cake environment.</param>
        /// <returns>A new <see cref="UpdateFunctionCodeSettings"/> instance to be used in calls to the <see cref="ILambdaManager"/>.</returns>
        [Obsolete("Please use Initalize extension method instead")]
        public static UpdateFunctionCodeSettings CreateUpdateFunctionCodeSettings(this ICakeEnvironment environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            return new UpdateFunctionCodeSettings().Initialize(environment);
        }
    }
}
