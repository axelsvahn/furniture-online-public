# Inredning Online
Web-based order management application for home decor store (ASP.NET Core MVC, MSSQL, xUnit)

## 1. Background

Created during fall term 2020 as course assignment. Part of higher vocational education: Webbutvecklare .NET (Web Developer .NET), 2020-2022, Jönköping University, Sweden.  
Name of course: Dynamiska Webbapplikationer 1 (Dynamic Web Applications 1)

## 2. Technologies/techniques used

* ASP.NET Core MVC (.NET Core 3.1)
* ASP.NET Core Identity for authentication and authorization
* Entity Framework Core for relational database management (MSSQL v13)
* xUnit for unit testing
* Twitter Bootstrap (4.6) for styling of frontend
* Various principles and practices such as dependency injection, Repository and Model-View-Controller patterns and separation of concerns.  

## 3. What I learned

I learned how to use, or increased my understanding of, the technologies and concepts listed above.

## 4. How to use

### Using Visual Studio 2019:

The application can be run using Visual Studio 2019 by accessing it through the solution file and clicking the "run" button after
first restoring the project dependencies. The MSSQL database has been set to InMemory mode to facilitate running the app on various systems.

Register as "ingrid@ballong.se" using a password of your choice and navigate to "visa projekt" to test admin functionality. Two
pre-seeded projects will be shown, along with the total cost.

Register as "pelle@ballong.se" and/or "kalle@ballong.se" to test the functionality available to ordinary registered users.
One pre-seeded project will be displayed per user. 