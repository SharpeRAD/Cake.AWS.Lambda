


namespace Cake.AWS.Lambda
{
    /// <summary>
    /// Using this API you can update the function version to which the alias points and the alias description.
    /// </summary>
    public class AliasSettings : ClientSettings
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AliasSettings" /> class.
        /// </summary>
        public AliasSettings()
        {

        }
        #endregion





        #region Properties
        /// <summary>
        ///  Gets and sets the alias name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets the Lambda function version to which the alias points.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///  Gets and sets the alias Description.
        /// </summary>
        public string Description { get; set; }
        #endregion
    }
}