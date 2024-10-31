Explicación de Arquitectura
Web API
-	Se utilizo .NET Core Web Api con del framework de Net 8
-	Se utilizo EFCore para el acceso a datos utilizando la técnica Code FIrst, LINQ.
-	Se generaron los diferentes controles para definición de métodos por Entidad
APP Front
-	Se utilizo .net MAUI 8 para la construcción del front del proyecto
-	Para el control del patrón MVVM, se utilizó Muai Community Toolkit.
-	Para el proceso de interacción con los WS Rest se utilizaron interfaces e implementaciones para los métodos de acceso al API.
-	Como parte de poder exponer la experiencia en desarrollo Xamarin-Maui, se colocó un ejemplo para manejar handlers a nivel de controles( en este caso para un Entry).
-	Se utilizo inyección de dependencias
-	La navegación se hace a través del Shell
Base de dato
-	Se utilizo Sql Server.

Pasos para correr la api y app
1.-Abrir la solución y seleccionar como proyecto de inicio el proyecto api “BackendTestApp”, seguido abrimos la consola de administrador de paquetes y le digitamos “update-database”, para generar de manera automática la base de datos localmente, la misma que se configura en:
 ![image](https://github.com/user-attachments/assets/88daca61-1013-4f55-a984-7b3f540f7b0c)

Nota: si le ven necesario cambiar la cadena de conexión a la instancia deseado, sino de manera local debería funcionar sin problema.

 ![image](https://github.com/user-attachments/assets/df039369-9fbf-470d-97ae-6b79eb10c57c)
![image](https://github.com/user-attachments/assets/3834e9c5-887d-44de-bcfd-5aff710675d2)

 
2.- Una vez generada la base de datos mandamos a correr nuestro API, para generar los datos iniciales en la base de datos.
3.- Ya con los datos iniciales corremos el proyecto del api dando click derecho escogemos la siguiente opción
 ![image](https://github.com/user-attachments/assets/60dc7145-34e8-43ba-bdce-6c08ac85fc4a)

-	
-	
-	
-	Con esto tendremos ya el api corriendo en el puerto asignado, el mismo que está configurado en:
 
 ![image](https://github.com/user-attachments/assets/48ee9ee9-f352-47f5-9d8e-a946b0c9c660)

 ![image](https://github.com/user-attachments/assets/3eaa976a-37bd-476a-8b63-44af130bdbb2)

4.- Con esto realizado, nos cambiamos al proyecto de MAUI para correrlo en el emulador de Android que se disponga instalado.

![image](https://github.com/user-attachments/assets/7be04f7e-3044-4999-9d5e-d25a954dd91e)


5.- La primera ves que se corra el aplicativo móvil nos mostrara una pantalla de login, para lo cual las credenciales de acceso son:

Usuario: Admin
Password: 123456

 ![image](https://github.com/user-attachments/assets/bc6df0dd-492e-42ef-9197-b0b38a5a7660)





EVIDENCIA DE FUNCIONAMIENTO

1.- Listado de Prospectos con búsqueda rápida y scroll infinito
 
![image](https://github.com/user-attachments/assets/f938363a-f018-4577-8b81-cf5badfceaba)

2.- Creación de actividades por prospecto

![image](https://github.com/user-attachments/assets/8c71899a-772e-4eb2-bb15-212e91c7d859)
![image](https://github.com/user-attachments/assets/7cea9842-650e-4c78-a74c-14fad63b613c)

  
3.- listado de actividades por prospecto y edición de información

![image](https://github.com/user-attachments/assets/f81e3504-dd93-4cf6-ba82-cf007cc49d07)
![image](https://github.com/user-attachments/assets/29395590-6cee-477f-9e16-a2f0d59f96d6)
![image](https://github.com/user-attachments/assets/8b586c7d-7da9-4db4-a19c-18da612defd4)

4.- eliminación de actividades de prospecto

  ![image](https://github.com/user-attachments/assets/56976ede-352a-493a-9e25-f6ed640e2ad7)
  ![image](https://github.com/user-attachments/assets/578c4e06-0ccc-4f3f-8dc4-2508cf1941b1)


5.-Plus pantalla de perfil, para cerrar sesión.
 
![image](https://github.com/user-attachments/assets/7786154d-6586-41ee-ab9e-b8fe12fc2c34)
![image](https://github.com/user-attachments/assets/2fb4e3d3-cfe8-4e81-a6cc-6415bf9531db)


