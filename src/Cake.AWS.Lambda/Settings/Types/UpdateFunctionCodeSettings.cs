


namespace Cake.AWS.Lambda
{
    /// <summary>
    /// The settings to use with downlad requests to Amazon Lambda
    /// </summary>
    public class UpdateFunctionCodeSettings : CodeSettings
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateFunctionCodeSettings" /> class.
        /// </summary>
        public UpdateFunctionCodeSettings()
        {
            this.Publish = true;
            this.DryRun = false;
        }
        #endregion





        #region Properties
        /// <summary>
        ///  Used to request AWS Lambda to update the Lambda function and publish a version as an atomic operation.
        /// </summary>
        public bool Publish { get; set; }

        /// <summary>
        ///  This boolean parameter can be used to test your request to AWS Lambda to update the Lambda function and publish a version as an atomic operation. It will do
        ///  all necessary computation and validation of your code but will not upload it or a publish a version.
        /// </summary>
        public bool DryRun { get; set; }
        #endregion
    }
}