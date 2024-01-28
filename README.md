# EventsApp

1. Dirigirse a esta pagina https://dotnet.microsoft.com/es-es/download y descargar .net.
2. Descargar e importar la base de datos, en este caso se utilizo mySql como base de datos.
3. Abrir el archivo appsettings.json, cambiar los valores correspondientes para conectar a su base de datos en SQLdata.
4. En caso de usar la terminal dirigirse a la carpeta del proyecto y luego utilizar el comando dotnet run --project "nombre del proyecto".
5. Tambien puede correrse desde visualStudio, el proyecto esta hecho con .net 6.0.


# metodologías utilizadas
En este caso aplique algunos de los principios de Clean Code con el objetivo de crear una aplicacion mas escalable.
El principio DRY (don't repeat yourself) de manera que las funciones puedan ser utilizadas en muchas clases y no repetir codigo.
Utilice interfaces para poder tener mayor control sobre los datos y automapper de manera de poder centralizar el mapeo de datos que van hacia la base de datos.

Es importante recalcar que el metodo post y put no funcionan de manera correcta, creo que me equivoque en el diseno de la base de datos, al hacer el mapeo de la data obtenida por el metodo post ocurre un error al momento de tratar de insertarla en la base de datos, la unica manera que si funciona el metodo es enviando un email de un usuario nuevo (el email no puede repetirse en la tabla usuarios). 

Se me dificulto aplicar estos conceptos en el proceso debido que es la segunda vez que trabajo con c#, por lo que si tienen alguna sugerencia se agradece.
