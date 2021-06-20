# PasswordChecker
Password checker repository contains 4 projects
1. Password Checker: An MVC API .Net Core 3.1 project with a very primitive UI
2. Password Checker Client: A console .Net Core 3.1 project that connects to the Password Checker API and calls it.
3. IO.Swagger: An auto generated class library .Net Core 3.1 project that facilitates the handling of the API calls. https://editor.swagger.io/ was used to generate this library.
4. Password Checker Unit Test: A simple MSTest project that runs multiple tests to the Password Checker Algorithm.

1. Password Checker: The App was created from ground up. I have the Swagger utility integrated in it which means if you concatenate "/swagger" to the URL after running the project,
you can get an automated UI that allows you to test the different APIs in the project. Also will allow you to see the json file that describes all the models for the APIs.
This json file was used in https://editor.swagger.io/ to generate a .net library project. The swagger extension is only enabled in debug.
The APIController has 3 methods, one of the index which displays a view by default that has the steps to test the functionality of the API. The second is a test connection method
that is used to verify the connection from the client. The third is the CheckPassword method that takes a password as string and returns back an object that contains the strength of
the password, any information message and the number of breaches if any. The Password needs to be at least 6 characters with Uppercase, lowercase and a digit. If it doesn't meet this 
requirements, it is not tested for breach and displays a message with the first error encountered i.e. short password, missing an upper case letter,.... If it contains a symbol or is
more than 6 characters or more than 8 then it gets higher strength each time it meets on of these requirements.

2. Password Checker Client. The app was created from ground up. It is a simple client that asks for a url for the API, then it asks the user to enter the password where it calls the 
API and displays the result from the API.

3. IO.Swagger: This app was automatically generated. The project was created to target .Net Core 3.1 then the rest of the project files were added from the originally generated project.
The project is also included in the Password Checker Client solution as the client depends on it to connect to the API

4. Password Checker Unit Test: This app was created from the ground up to test the functionality of the Password Checker algorithm.

