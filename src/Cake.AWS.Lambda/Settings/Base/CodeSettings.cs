#region Using Statements
using System.IO;

using Cake.Core.IO;
#endregion



namespace Cake.AWS.Lambda
{
    /// <summary>
    /// The settings to use when uploading code to Amazon Lambda
    /// </summary>
    public abstract class CodeSettings : ClientSettings
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeSettings" /> class.
        /// </summary>
        public CodeSettings()
        {
            this.S3Bucket = null;
            this.S3Key = null;
            this.S3Version = null;

            this.ZipFile = null;
        }
        #endregion





        #region Properties
        /// <summary>
        /// Gets or sets the working directory for the process to be started.
        /// </summary>
        public DirectoryPath WorkingDirectory { get; set; }



        /// <summary>
        /// The name of the Amazon S3 bucket where the bundled artifacts are stored.
        /// </summary>
        public string S3Bucket { get; set; }

        /// <summary>
        /// The name of the Amazon S3 object that represents the bundled artifacts you want to upload.
        /// </summary>
        public string S3Key { get; set; }

        /// <summary>
        /// A specific version of the Amazon S3 object that represents the bundled artifacts you want to upload.
        /// </summary>
        public string S3Version { get; set; }



        /// <summary>
        /// The contents of your zip file containing your deployment package.
        /// </summary>
        public MemoryStream ZipFile { get; set; }

        /// <summary>
        /// The path to your zip file containing your deployment package.
        /// </summary>
        public FilePath ZipPath { get; set; }
        #endregion
    }
}