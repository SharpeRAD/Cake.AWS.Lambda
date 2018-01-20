#region Using Statements
using System.Collections.Generic;
#endregion



namespace Cake.AWS.Lambda
{
    /// <summary>
    /// The settings to use with downlad requests to Amazon Lambda
    /// </summary>
    public class CreateFunctionSettings : CodeSettings
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateFunctionCodeSettings" /> class.
        /// </summary>
        public CreateFunctionSettings()
        {

        }
        #endregion





        #region Properties
        /// <summary>
        /// Gets and sets the property FunctionName. The name you want to assign to the function you are uploading. The function names
        /// appear in the console and are returned in the ListFunctions API. Function names are used to specify functions to other AWS Lambda API operations, such as Invoke.
        /// Note that the length constraint applies only to the ARN. If you specify only the function name, it is limited to 64 characters in length.
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// Gets and sets the property Handler. The function within your code that Lambda calls to begin execution. For Node.js,
        /// it is the module-name.export value in your function. For Java, it can be package.class-name::handler or package.class-name. For more information, see Lambda Function Handler (Java).
        /// </summary>
        public string Handler { get; set; }



        /// <summary>
        /// Gets and sets the property Runtime.The runtime environment for the Lambda function you are uploading.
        /// To use the Python runtime v3.6, set the value to "python3.6". To use the Python runtime v2.7, set the value to "python2.7". To use the Node.js runtime v6.10,
        /// set the value to "nodejs6.10". To use the Node.js runtime v4.3, set the value to "nodejs4.3".
        /// Node v0.10.42 is currently marked as deprecated. You must migrate existing functions to the newer Node.js runtime versions available on AWS Lambda (nodejs4.3 or nodejs6.10)
        /// as soon as possible. You can request a one-time extension until June 30, 2017 by going to the Lambda console and following the instructions provided. Failure
        /// to do so will result in an invalid parmaeter error being returned. Note that you will have to follow this procedure for each region that contains functions written in the Node v0.10.42 runtime.
        /// </summary>
        public string Runtime { get; set; }

        /// <summary>
        /// Gets and sets the property Role. The Amazon Resource Name (ARN) of the IAM role that Lambda assumes when it executes
        /// your function to access any other Amazon Web Services (AWS) resources. For more information, see AWS Lambda: How it Works.
        /// </summary>
        public string Role { get; set; }



        /// <summary>
        /// Gets and sets the property Timeout. The function execution time at which Lambda should terminate the function. Because
        /// the execution time has cost implications, we recommend you set this value based on your expected execution time. The default is 3 seconds.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Gets and sets the property Tags. The list of tags (key-value pairs) assigned to the new function.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets and sets the property Publish. This boolean parameter can be used to request AWS Lambda to create the Lambda
        /// function and publish a version as an atomic operation.
        /// </summary>
        public bool Publish { get; set; }

        /// <summary>
        /// Gets and sets the property MemorySize. The amount of memory, in MB, your Lambda function is given. Lambda uses this
        /// memory size to infer the amount of CPU and memory allocated to your function. Your function use-case determines your CPU and memory requirements. For example,
        /// a database operation might need less memory compared to an image processing function. The default value is 128 MB. The value must be a multiple of 64 MB.
        /// </summary>
        public int MemorySize { get; set; }

        /// <summary>
        /// Gets and sets the property TracingConfig. The parent object that contains your function's tracing settings.
        /// </summary>
        public string TracingConfig { get; set; }

        /// <summary>
        /// Gets and sets the property KMSKeyArn. The Amazon Resource Name (ARN) of the KMS key used to encrypt your function's
        /// environment variables. If not provided, AWS Lambda will use a default service key.
        /// </summary>
        public string KMSKeyArn { get; set; }

        /// <summary>
        /// Gets and sets the property Environment.
        /// </summary>
        public Dictionary<string, string> Environment { get; set; }

        /// <summary>
        /// Gets and sets the property Description. A short, user-defined function description. 
        /// Lambda does not use this value. Assign a meaningful description as you see fit.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets and sets the property DeadLetterConfig.
        /// The parent object that contains the target ARN (Amazon Resource Name) of an Amazon SQS queue or Amazon SNS topic.
        /// </summary>
        public string DeadLetterConfig { get; set; }



        /// <summary>
        /// Gets and sets the property SecurityGroupIds. A list of one or more security groups IDs in your VPC.
        /// </summary>
        public List<string> VpcSecurityGroupIds { get; set; }

        /// <summary>
        /// Gets and sets the property SubnetIds. A list of one or more subnet IDs in your VPC.
        /// </summary>
        public List<string> VpcSubnetIds { get; set; }
        #endregion
    }
}