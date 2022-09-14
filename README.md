# Texthelp

This project is an answer to the challenge described here: https://github.com/wizkids/csharp-rocks-web
It consists of two parts: A backend API written in C# which both has a service running calls to a word-prediction web service, 
and also queries a simple dictionary database. The frontend is a simple SPA application written in Angular. 

How to run this project:
1) Either open the backend API project in Visual Studio and start debug, or from the command line (Mac or Linux), 
navigate into the project folder and execute: dotnet run

2) Open the folder of the frontend project in VS Code or from the command line. In terminal, execute the following command: ng serve --open
