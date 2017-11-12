# Cake.AWS.Lambda
Cake Build addin for Amazon Lambda

[![Build status](https://ci.appveyor.com/api/projects/status/fdmccfihkycqd0lj?svg=true)](https://ci.appveyor.com/project/SharpeRAD/cake-aws-Lambda)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake)



## Table of contents

1. [Implemented functionality](https://github.com/SharpeRAD/Cake.AWS.Lambda#implemented-functionality)
2. [Referencing](https://github.com/SharpeRAD/Cake.AWS.Lambda#referencing)
3. [Usage](https://github.com/SharpeRAD/Cake.AWS.Lambda#usage)
4. [Example](https://github.com/SharpeRAD/Cake.AWS.Lambda#example)
5. [Plays well with](https://github.com/SharpeRAD/Cake.AWS.Lambda#plays-well-with)
6. [License](https://github.com/SharpeRAD/Cake.AWS.Lambda#license)
7. [Share the love](https://github.com/SharpeRAD/Cake.AWS.Lambda#share-the-love)



## Implemented functionality

* Update lambda code
* Publish lambda version
* Create lambda alias
* Update lambda alias
* Uses AWS fallback credentials (app.config / web.config file, SDK store or credentials file, environment variables, instance profile)



## Referencing

[![NuGet Version](http://img.shields.io/nuget/v/Cake.AWS.Lambda.svg?style=flat)](https://www.nuget.org/packages/Cake.AWS.Lambda/)

Cake.AWS.Lambda is available as a nuget package from the package manager console:

```csharp
Install-Package Cake.AWS.Lambda
```

or directly in your build script via a cake addin directive:

```csharp
#addin "Cake.AWS.Lambda"
```



## Usage

```csharp
#addin "Cake.AWS.Lambda"

Task("Update-Function-Code")
    .Description("Updates the AWS Lambda functions code.")
    .Does(async () =>
{
    var settings = new UpdateFunctionCodeSettings()
    {
        RevisionBucket = "company-deployments",
        RevisionKey = "AwesomeFunction.zip"
    }.Initialize(Environment);

    var version = await UpdateFunctionCode("MyFunction", settings);
});

Task("Publish-Version")
    .Description("Publishes a version of your function")
    .Does(async () =>
{
    var settings = new PublishVersionSettings()
    {
        RevisionBucket = "company-deployments",
        RevisionKey = "AwesomeFunction.zip",
        Description = "v1.0"
    }.Initialize(Environment);

    var version = await PublishLambdaVersion("MyFunction", settings);
});

Task("Create-Alias")
    .Description("Update an alias that points to the specified Lambda function version.")
    .Does(async () =>
{
    var version = "12345";
    var settings = new PublishVersionSettings()
    {
        Name = "Production",
        Version = version,
        Description = "v1.0"
    }.Initialize(Environment);

    await CreateLambdaAlias("MyFunction", settings);
});

Task("Update-Alias")
    .Description("Update an alias that points to the specified Lambda function version.")
    .Does(async () =>
{
    var version = "12345";
    var settings = new UpdateVersionSettings()
    {
        Name = "Production",
        Version = version,
        Description = "v1.0"
    }.Initialize(Environment);

    await UpdateLambdaAlias("MyFunction", settings);
});

RunTarget("Update-Function-Code");
```



## Example

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.AWS.Lambda/blob/master/test/build.cake).



## Plays well with

If your deploying applications to AWS its worth checking out [Cake.AWS.S3](https://github.com/SharpeRAD/Cake.AWS.CodeDeploy), if your deploying websites to IIS its worth checking out [Cake.IIS](https://github.com/SharpeRAD/Cake.IIS) or if your deploying windows services check out [Cake.Services](https://github.com/SharpeRAD/Cake.Services).

If your looking for a way to trigger cake tasks based on windows events or at scheduled intervals then check out [CakeBoss](https://github.com/SharpeRAD/CakeBoss).



## License

Copyright (c) 2015 - 2016 Phillip Sharpe

Cake.AWS.Lambda is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/SharpeRAD/Cake.AWS.Lambda/blob/master/LICENSE).



## Share the love

If this project helps you in anyway then please :star: the repository.
