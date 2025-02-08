# onlineshop

#EF Commands
dotnet tool install --global dotnet-ef --version 8.0.12 // If No Ef Installed
 
dotnet ef migrations add InitialCreate --project Test.API
dotnet ef database update --project Test.API
