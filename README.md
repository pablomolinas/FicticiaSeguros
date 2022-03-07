
### Backend Api Rest y Frontend SPA React

El proyecto Backend esta desarrollado en el framework Net Core 6 con C#, 
utilizando EntityFramework 6 con SQL Server y Auntenticacion Jwt.

El Frontend esta desarrollado en React, consiste en login de usuario administrador,
la aplicacion consume la api Rest antes mencionada, utilizando Jwt, 
CRUD para la entidad Personas con las especificaciones detalldas en Requerimientos.

Cada proyecto contiene su propio Readme donde se describen con mas detalle las tecnologias empleadas.

#### Requerimientos

La empresa Ficticia S.A. está incursionando en la venta de seguros de vida, 
pero tiene una problemática en conocer a sus clientes actuales. 
Para ésto requieren el desarrollo de un sistema donde se puedan registrar personas, incluyendo datos como:
- Nombre completo
- Identificación
- Edad
- Género
- Estado (Activo o no)
Atributos adicionales
- ¿Maneja?
- ¿Usa lentes?
- ¿Diabético?
- ¿Padece alguna otra enfermedad? ¿Cuál?
** Pueden aparecer adicionales.
Se espera que el diseño del sistema permita realizar alta, baja y modificación de los datos mencionados.

##### La aplicación debe contar con (idealmente):
* Frontend web
* Backend C# (o java) en tres capas
* Validaciones de negocios (por ejemplo datos obligatorios o dentro de un rango en particular)
* Base de datos SQL
* Autenticación