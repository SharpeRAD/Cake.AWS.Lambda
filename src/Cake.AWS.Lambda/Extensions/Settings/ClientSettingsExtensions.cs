#region Using Statements
using System;

using Amazon;
#endregion



namespace Cake.AWS.Lambda
{
    /// <summary>
    /// Contains extension methods for <see cref="ClientSettings" />.
    /// </summary>
    public static class ClientSettingsExtensions
    {
        /// <summary>
        /// Specifies the AWS Access Key to use as credentials.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="key">The AWS Access Key</param>
        /// <returns>The same <see cref="UpdateFunctionCodeSettings"/> instance so that multiple calls can be chained.</returns>
        public static ClientSettings SetAccessKey(this ClientSettings settings, string key)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.AccessKey = key;
            return settings;
        }

        /// <summary>
        /// Specifies the AWS Secret Key to use as credentials.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="key">The AWS Secret Key</param>
        /// <returns>The same <see cref="ClientSettings"/> instance so that multiple calls can be chained.</returns>
        public static ClientSettings SetSecretKey(this ClientSettings settings, string key)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.SecretKey = key;
            return settings;
        }



        /// <summary>
        /// Specifies the endpoints available to AWS clients.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="region">The endpoints available to AWS clients.</param>
        /// <returns>The same <see cref="ClientSettings"/> instance so that multiple calls can be chained.</returns>
        public static ClientSettings SetRegion(this ClientSettings settings, string region)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Region = RegionEndpoint.GetBySystemName(region);
            return settings;
        }

        /// <summary>
        /// Specifies the endpoints available to AWS clients.
        /// </summary>
        /// <param name="settings">The LoadBalancing settings.</param>
        /// <param name="region">The endpoints available to AWS clients.</param>
        /// <returns>The same <see cref="UpdateFunctionCodeSettings"/> instance so that multiple calls can be chained.</returns>
        public static ClientSettings SetRegion(this ClientSettings settings, RegionEndpoint region)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Region = region;
            return settings;
        }
    }
}
