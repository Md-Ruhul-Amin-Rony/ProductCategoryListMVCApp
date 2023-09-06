# ProductCategoryListMVCApp
This is an MVC web application that manages product categories. It includes features like SQL database interaction, Entity Framework (EF), Razor views, client and server-side validation, TempData for messages, partial views, and Toastr alerts.

# Features
  -Index Page: Lists all categories.
  - Create Page: Allows you to create a new category.
  - Edit Page: Lets you edit an existing category.
  - Delete Page: Allows you to delete a category.
  - Client-Side Validation: Validates form data on the client side for a better user experience.
  - Server-Side Validation: Ensures data integrity and security.
  - TempData: Displays success and error messages.
  - Partial View: Utilizes a partial view to keep code DRY (Don't Repeat Yourself).
  - Toastr Alerts: Provides user-friendly alert messages.
## Prerequisites
Visual Studio or Visual Studio Code.
ASP.NET Core MVC.
Entity Framework (EF) for database interactions.
SQL Server for database storage.

## Installation
1.Clone this repository to your local machine.

2.Open the project in Visual Studio or Visual Studio Code.

3.Configure your database connection in the appsettings.json file.

4.Run the following command in the Package Manager Console to apply migrations and create the database:
![image](https://github.com/Md-Ruhul-Amin-Rony/ProductCategoryListMVCApp/assets/112938703/ab820608-da91-4473-b216-cf19714fdad9)

bash
Copy code
Update-Database
5.Build and run the application.

### Usage
Navigate to the application's home page to access the Category Controller.
Use the provided forms to create, edit, and delete categories.
Observe client-side validation for instant feedback.
Server-side validation ensures data integrity.
Toastr alerts display success and error messages.
