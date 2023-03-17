# Doctorly

Based on the requirements, I firstly started to make initial structure of the project based on Clean Architecture with DDD approach.
1.	I created Domain project (Domain Model) and created Attendee & Event aggregates with Email as a Value Object. 
2.	I created the contract IRepository interfaces for domain business needs in the Domain project 
3.	I also created a Unit Tests project to test functionality of the Email value object and passed the tests successfully. 
4.	After that I created Application project to cover our business logics using CQRS pattern. I used MediatR NuGet for these purposes as an external library. 
5.	 I also created an Email service to manage sending emails. But I only created its interface and the implementation can be done using SMTP or other techs in future due to limit time.
6.	I created Dependency Injection class to register all my services and command handlers which have been implemented using MediatR.
7.	After that I created Infrastructure project as persistence layer. I created my DbContext using EF Core and used PostgreSQL as my database. 
8.	After that I created Entity type configuration classes for each of my entities to configure them while DB migration. I put length limit on some of my properties as you wanted. 
9.	After that I created my first migration and the DB created successfully based on entities structure and their relationships.
10.	I finally implemented my repositories in the infrastructure project for DB communications.
11.	I also created a Dependency Injection class to register all my repositories and also created connection string configurations in the infrastructure project.
12.	After that I created Web API project using OpenAPI (Swagger) to create final endpoints with our controllers. I used MediatR to call my commands and queries. 
13.	I have already declared my PostgreSQL connection string in appsettings.json file of Web API project. 
14.	I also did some refactors to improve the codes and fixing bugs. 
15.	After testing the functionality of the project, I committed all my changes to GitHub for your kind consideration.
16.	In real-world coding, I prefer to write all above-mentioned steps in per clean commit messages. 
