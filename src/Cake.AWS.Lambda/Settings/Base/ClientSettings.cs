#region Using Statements
using Amazon;
using Amazon.Runtime;
#endregion



namespace Cake.AWS.Lambda
{
    /// <summary>
    /// The settings to use when connecting to Amazon Lambda
    /// </summary>
    public abstract class ClientSettings
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSettings" /> class.
        /// </summary>
        public ClientSettings()
        {
            this.Region = RegionEndpoint.EUWest1;
        }
        #endregion





        #region Properties
        /// <summary>
        /// The AWS Access Key ID
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// The AWS Secret Access Key.
        /// </summary>
        public string SecretKey { get; set; }

        internal AWSCredentials Credentials { get; set; }



        /// <summary>
        /// The endpoints available to AWS clients.
        /// </summary>
        public RegionEndpoint Region { get; set; }
        #endregion
    }
}