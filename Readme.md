# A Simple Calculator

The application is divided into
1. A Micro Service which does the calculation
2. A Console application which ask user the data about calculation
3. A Unit test project to the services application
4. AWS Lambda function to do the calculation
5. A Unit test project for the AWS Lambda function

Currently the AWS Lambda function is not integration with the console application but can be tested seperately.

The supported operation and the equivalent values to be entered by the user in the console application are 
1. Addition = 1
2. Substraction = 2
3. Division = 3
4. Multiplication = 4

The user inputs the type of operation and two values on which the operation has to be performed.

# Setup
 Build the solution
 
 Run the Calculator.Service Project : `dotnet run --project Calculator.Service`

 Run the MainApplication (Console App) : `dotnet run --project  MainApplication\MainApplication.csproj`


 # AWS Lambda Function

 The support for Mock testing of the lambda function has been included in the project
 
 Build the project `AWSLambda.Calc` in Visual Studio and run the launch profile `Mock Lambda Test Tool`

 It will open a browser to test the functionality. 
 The sample request payload should look like 
 `{
    "OperationType": 1,
    "FirstValue": 2,
    "SecondValue": 3
}`

