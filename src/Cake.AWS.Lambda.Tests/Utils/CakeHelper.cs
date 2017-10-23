#region Using Statements
using System.IO;

using Cake.Core;
using Cake.Testing;
#endregion



namespace Cake.AWS.Lambda.Tests
{
    internal static class CakeHelper
    {
        #region Methods
        public static ICakeEnvironment CreateEnvironment()
        {
            var environment = FakeEnvironment.CreateWindowsEnvironment();
            
            environment.WorkingDirectory = Directory.GetCurrentDirectory();
            environment.WorkingDirectory = environment.WorkingDirectory.Combine("../../../");

            return environment;
        }



        public static ILambdaManager CreateLambdaManager()
        {
            var environment = CakeHelper.CreateEnvironment();

            return new LambdaManager(new FakeFileSystem(environment), environment, new DebugLog());
        }
        #endregion
    }
}
