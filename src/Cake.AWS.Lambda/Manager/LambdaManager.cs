#region Using Statements
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Diagnostics;

using Amazon.Lambda;
using Amazon.Lambda.Model;
#endregion



namespace Cake.AWS.Lambda
{
    /// <summary>
    /// Implementation for accessing AWS Lambda
    /// </summary>
    public class LambdaManager : ILambdaManager
    {
        #region Fields
        private readonly IFileSystem _FileSystem;
        private readonly ICakeEnvironment _Environment;
        private readonly ICakeLog _Log;
        #endregion





        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LambdaManager" /> class.
        /// </summary>
        /// <param name="fileSystem">The file System.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="log">The log.</param>
        public LambdaManager(IFileSystem fileSystem, ICakeEnvironment environment, ICakeLog log)
        {
            if (fileSystem == null)
            {
                throw new ArgumentNullException(nameof(fileSystem));
            }
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }
            if (log == null)
            {
                throw new ArgumentNullException(nameof(log));
            }

            _FileSystem = fileSystem;
            _Environment = environment;
            _Log = log;
        }
        #endregion





        #region Methods
        private AmazonLambdaClient CreateClient(UpdateFunctionCodeSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
                
            if (settings.Region == null)
            {
                throw new ArgumentNullException(nameof(settings.Region));
            }

            if (settings.Credentials == null)
            {
                if (String.IsNullOrEmpty(settings.AccessKey))
                {
                    throw new ArgumentNullException(nameof(settings.AccessKey));
                }
                if (String.IsNullOrEmpty(settings.SecretKey))
                {
                    throw new ArgumentNullException(nameof(settings.SecretKey));
                }

                return new AmazonLambdaClient(settings.AccessKey, settings.SecretKey, settings.Region);
            }
            else
            {
                return new AmazonLambdaClient(settings.Credentials, settings.Region);
            }
        }



        /// <summary>
        /// Updates the AWS Lambda functions code.
        /// </summary>
        /// <param name="functionName">The name of an AWS Lambda function.</param>
        /// <param name="settings">The <see cref="UpdateFunctionCodeSettings"/> used during the request to AWS.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<bool> UpdateFunctionCode(string functionName, UpdateFunctionCodeSettings settings, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (String.IsNullOrEmpty(functionName))
            {
                throw new ArgumentNullException(nameof(functionName));
            }



            // Create Request
            AmazonLambdaClient client = this.CreateClient(settings);

            UpdateFunctionCodeRequest request = new UpdateFunctionCodeRequest()
            {
                FunctionName = functionName,

                Publish = settings.Publish,
                DryRun = settings.DryRun,

                S3Bucket = settings.S3Bucket,
                S3Key = settings.S3Key,
                S3ObjectVersion = settings.S3Version,

                ZipFile = settings.ZipFile
            };

            if (settings.ZipPath != null)
            {
                request.ZipFile = this.GetFileStream(settings.ZipPath, settings);
            }



            // Check Response
            UpdateFunctionCodeResponse response = await client.UpdateFunctionCodeAsync(request, cancellationToken);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                _Log.Verbose("Successfully updated function '{0}'", functionName);
                return true;
            }
            else
            {
                _Log.Error("Failed to pdated function '{0}'", functionName);
                return false;
            }
        }



        private void SetWorkingDirectory(CodeSettings settings)
        {
            DirectoryPath workingDirectory = settings.WorkingDirectory ?? _Environment.WorkingDirectory;

            settings.WorkingDirectory = workingDirectory.MakeAbsolute(_Environment);
        }

        private MemoryStream GetFileStream(FilePath path, CodeSettings settings)
        {
            this.SetWorkingDirectory(settings);

            string fullPath = path.MakeAbsolute(settings.WorkingDirectory).FullPath;
            IFile file = _FileSystem.GetFile(fullPath);

            if (file.Exists)
            {
                var memory = new MemoryStream();

                using (Stream read = file.OpenRead())
                {
                    read.CopyTo(memory);
                }

                memory.Seek(0, SeekOrigin.Begin);

                return memory;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}