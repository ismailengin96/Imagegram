# Imagegram
Imagegram .Net Core Web API

# Prerequisites
.Net 5.0 </br>
Docker </br>
Visual Studio (recommended)

# Instructions
-Open terminal </br>
-Go to root file </br>
-Run "docker-compose up -d" command in order to configure PostgreSQL with Docker. </br>
-Launch pgadmin and create a new server with these credentials which can be found inside the docker-compose.yml file

<b>Admin Credentials:</b> </br>
pgadmin email: pgadmin4@pgadmin.org </br>
pgadmin password: 1234 </br>

<b>Server Credentials:</b> </br>
Host name: postgresql_database </br>
Port: 5432 </br>
database: imagegramDB </br>
Username: admin </br>
Password: 1234 </br>

-Open the project with Visual Studİo and restore all nuget packages </br>
-Go to Imagegram.Data and run "dotnet tool install --global dotnet-ef" command from Package Manager Console </br>
-Run "Update-Database" command from Package Manager Console in order to execute migrations. </br>
-Launch ImagegramWebAPI </br>
-Visit http://localhost:5000/swagger/index.html for API documentation and making requests
