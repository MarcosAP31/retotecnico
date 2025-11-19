1. clonar el proyecto: git clone https://github.com/MarcosAP31/retotecnico.git

2. crear la base de datos: CREATE DATABASE BooksDB;

3. configurar la cadena de conexion 

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BooksDB;User Id=usuario;Password=contraseña;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

4. para ejecutar las migraciones

 dotnet ef migrations add InitialCreate
 
5. para actualizar la base de datos con las tablas creadas
dotnet ef database update

6. para ejecutar el proyecto 
dotnet run  
La api estará disponible en http://localhost:5000

7. Endpoints disponibles
Método	Ruta	         Descripción	                      Body / Parámetros
GET	/api/books	Obtener todos los libros	            Ninguno
GET	/api/books/{id}	Obtener un libro por ID	id (int)
POST	/api/books	Crear un nuevo libro	              { "titulo": "", "autor": "", "anoPublicacion": 0, "editorial": "", "cantidadPaginas": 0, "categoria": "", "descripcion": "" }
PUT	/api/books/{id}	Actualizar un libro existente	       id (int) y cuerpo JSON igual a POST
DELETE	/api/books/{id}