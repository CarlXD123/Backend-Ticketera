# Backend-Ticketera

Aplicación web full stack para la gestión de tickets, desarrollada con ASP.NET Core la parte del Backend. Permite crear, editar, filtrar y eliminar tickets, asignar responsables y gestionar estados.

Backend

. ASP.NET Core = 9.0.312
. SQL Server

Funcionalidades

Crear tickets
Editar tickets
Eliminar tickets
Cambiar estado (Nuevo, En Proceso, Resuelto, Cancelado)
Asignar responsable
Filtrar por estado
UI tipo tablero (estilo Jira)

Uso

Abrir la solucion del proyecto en Visual Studio y ejecutar el proyecto en http, https o IIS.

Decisiones tecnicas

- Opte por clean architecture para la organizacion de las carpetas para mantener un orden mediante el uso de DTO, Mapper que sirver para no exponer en capas mas sensibles 
algunos campos.

Si hubiera tenido mas tiempo

Hubiera colocado la funcion de colocar comentarios en los tickets y ver que persona lo coloco tipo Jira.
