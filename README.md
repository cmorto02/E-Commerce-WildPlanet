# ***Project Wild Planet***
---------------------------------
## We are deployed on Azure!

https://wildplanet.azurewebsites.net/


##Questions:
1. What is the product you are selling?

    Stuffed animals and Name rights for individual species that are endangered.

2. What claims are you capturing? Where? Why?

    On registration we are capturing claims : 

                                        FirstNameClaim - To store the first name of an user to render both first and last in custom message

                                        LastNameClaim - To store the last name of an user to render both the last and the first in a custom message

                                        BirthdayClaim - The birthday claim is not yet utilizes however we will be restricting our site to potentially only be checked out by an adult.

                                        LovesAnimalsClaim - This claim is required to access a policy page that is implimented

3. What Policies are you enforcing? Where? Why? Directions on how to test.

    We are enforcing the Loves animals claim in a policy for the "Exclusive" page of our website. this is so we can restrict the 
    accessability of our users, on our site. you can test this by making an account and NOT checking the "Loves animals" check box on registration,
    And then requesting to access the "Exclusive" page: This will result in a "Not authorized" and you will need to make another account that meets the requirements or not access that page.

---------------------------------
## Web Application

Our web application connects users to active wildlife conservation efforts through donation and the right to 
name individual members of critically endangered species that are among the subjects in ongoing conservation research. 
When you donate to a specific species on our webapp anything donated goes to active conservation efforts. Some of the 
efforts we support are conservation research efforts, anti-poaching efforts, and land and habitat management and rehabilitation. 

When you purchase the rights to name an animal through donation on our site, you will receive information about the species and the specific 
animal you are naming as well as a picture of the exact animal you are supporting, conservation efforts and a plush in that animals image.

The web application consists of a frontend written in Razor views, HTML, CSS,
Bootstrap, Popper, and jQuery. The backend was written in C# using ASP.NET Core 2, Entity Framework Core, and the MVC framework.

---------------------------------

## Tools Used
Microsoft Visual Studio Community 2017 (Version 15.5.7)

- C#
- ASP.Net Core
- Entity Framework
- MVC
- xUnit
- Bootstrap
- Azure
- Parallel Dots API

---------------------------------

## Recent Updates

#### V 1.0
*Site launch 30 April 2019

---------------------------

## Getting Started

Clone this repository to your local machine.
```
$ git clone https://github.com/YourRepo/YourProject.git
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2017 (or greater) to build the web application. The solution file is located in the AmandaFE subdirectory at the root of the repository.
```
cd YourRepo/YourProject
dotnet build
```
The dotnet tools will automatically restore any NuGet dependencies. Before running the application, the provided code-first migration will need to be applied to the SQL server of your choice configured in the /AmandaFE/AmandaFE/appsettings.json file. This requires the Microsoft.EntityFrameworkCore.Tools NuGet package and can be run from the NuGet Package Manager Console:
```
Update-Database
```
Once the database has been created, the application can be run. Options for running and debugging the application using IIS Express or Kestrel are provided within Visual Studio. From the command line, the following will start an instance of the Kestrel server to host the application:
```
cd YourRepo/YourProject
dotnet run
```
Unit testing is included in the AmandaFE/FrontendTesting project using the xUnit test framework. Tests have been provided for models, view models, controllers, and utility classes for the application.

---------------------------------

## Usage
***[Provide some images of your app with brief description as title]***

### Overview of Recent Posts
![Overview of Recent Posts](https://via.placeholder.com/500x250)

### Creating a Post
![Post Creation](https://via.placeholder.com/500x250)

### Enriching a Post
![Enriching Post](https://via.placeholder.com/500x250)

### Viewing Post Details
![Details of Post](https://via.placeholder.com/500x250)

---------------------------
## Data Flow (Frontend, Backend, REST API)
***[Add a clean and clear explanation of what the data flow is. Walk me through it.]***
![Data Flow Diagram](/assets/img/Flowchart.png)

---------------------------
## Data Model

### Overall Project Schema
Our Project consists of two databases, one for our Userdata and one for our Shop data. 
Our shop DB consists of:
Basket(tied to the user)
BasketItems(tied to the basket)
Order(created from basket on checkout)
OrderItems(created from BasketItems on checkout)
Products(holds all of our shop items available for purchase)
---------------------------
## Model Properties and Requirements

### Product

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| Name | string | YES |
| Price | double | YES |
| Description | string | YES |
| ImageStuffedAnimal | img jpeg/png | YES |
| ImageAnimal | img jpeg/png | YES |
| Summary | string | YES |
| AmountLeft | int | YES |

### Basket

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| TotalItems | int | YES |
| TotalPrice | double | YES |
| UserName | string | YES |
| BasketList | list | YES |


### BasketItems

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| BasketID | int | YES |
| ProductID | int | YES |
| Product | product | YES |
| Quantity | int | YES |
| LineItemAmount | double | YES |


### Order

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| UserID  | int | YES |
| FirstName  | string | YES |
| LastName  | string | YES |
| Address  | string | YES |
| City  | string | YES |
| Zip  | string | YES |
| Completed  | bool | YES |
| OrderItems | list | YES |
| GrandTotal | double | YES |
| OrderDate | date/time object | YES |

### OrderItems

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| ProductID | int | YES |
| Quantity | int | YES |
| OrderID | int | YES |


---------------------------

## Change Log
1.0: *Site launched 5/1/2019


------------------------------

## Authors
Tanner Percival
Chris Morton
##Collaberators
Amanda Iverson
Nate Tibbals
Dan Logerstedt & Andrew Curtis



------------------------------

For more information on Markdown: https://www.markdownguide.org/cheat-sheet