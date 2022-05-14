# HorizonEvents

Event menagement application build with .NET 5 and Angular 13. 

## Back-end
First thing you need to do is download .NET 5 sdk (Microsoft website). Than, in the HorizonEvents.API folder, run:

`dotnet build`

Now, if you don't have EF Core installed, you'll need to download it (v. 5.0.2):

`dotnet tool install --version 5.0.2 --global dotnet-ef`

The used version in the project is 5.0.2, so i recommend you to use the same. After that, run: 

`dotnet ef database update`

To run the back-end project:

`dotnet run`

Navigate to `http://localhost:5000/swagger/index.html` to acess the Swagger documentation.

## Front-end
First, you need to have Node installed in your computer. Then, on the HorizonEvents-App folder, run:

`npm install`

And then, it's just run the project:

`ng serve`

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 13.1.2.

Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.
