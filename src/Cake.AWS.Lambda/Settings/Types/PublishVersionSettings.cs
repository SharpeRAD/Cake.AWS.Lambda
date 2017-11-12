


namespace Cake.AWS.Lambda
{
    /// <summary>
    /// Publishes a version of your function from the current snapshot of $LATEST. 
    /// That is, AWS Lambda takes a snapshot of the function code and configuration information from $LATEST and publishes a new version. 
    /// The code and configuration cannot be modified after publication.
    /// </summary>
    public class PublishVersionSettings : CodeSettings
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PublishVersionSettings" /> class.
        /// </summary>
        public PublishVersionSettings()
        {

        }
        #endregion





        #region Properties
        /// <summary>
        /// The SHA256 hash of the deployment package you want to publish. This provides validation on the code you are publishing. 
        /// If you provide this parameter value must match the SHA256 of the $LATEST version for the publication to succeed.
        /// </summary>
        public string CodeSha256 { get; set; }

        /// <summary>
        /// The description for the version you are publishing. If not provided, AWS Lambda copies the description from the $LATEST version.
        /// </summary>
        public string Description { get; set; }
        #endregion
    }
}