# Tarea 3 - Gestión de Empleados

**Nombre:** Elfred Adal Juárez González
**Carnet:** C34106  
**Curso:** IF-3001 Algoritmos y Estructuras de Datos  

---

##  Descripción del sistema

Este proyecto consiste en un sistema web desarrollado con **ASP.NET Core MVC** y **Entity Framework Core** que permite la gestión de empleados.

El sistema incluye funcionalidades para:

- Registrar nuevos empleados
- Editar información existente
- Buscar empleados por nombre, apellidos o departamento
- Mostrar resultados con paginación
- Activar o dar de baja empleados sin eliminarlos físicamente

---

##  Funcionalidad de Paginación

El sistema implementa paginación para mejorar la visualización de datos.

- Se muestran **5 empleados por página**
- Se utilizan los métodos:
  - `Skip()` → omite registros anteriores
  - `Take()` → limita la cantidad de resultados

### Ejemplo:
- Página 1 → registros del 1 al 5  
- Página 2 → registros del 6 al 10  

El sistema incluye botones:
- **Anterior**
- **Siguiente**

---

##  Funcionalidad de Búsqueda

Permite filtrar empleados por:

- Nombre
- Apellidos
- Departamento

Se implementa mediante el método `Contains()` en el repositorio.

### 🔗 Ejemplo de URL con búsqueda

```
/Empleados?busqueda=TI
```

Otro ejemplo:

```
/Empleados?busqueda=Ana
```

---

##  Tecnologías utilizadas

- ASP.NET Core MVC  
- Entity Framework Core  
- SQL Server  
- Bootstrap 5  

---

##  Instrucciones de ejecución

### 1️ Clonar el repositorio

```bash
git clone https://github.com/TU_USUARIO/Tarea3_GestionEmpleados_C34106.git
```

---

### 2️ Abrir el proyecto

Abrir la solución en:

```
Visual Studio 2022
```

---

### 3️ Configurar la base de datos

Abrir la **Consola del Administrador de paquetes NuGet** y ejecutar:

```powershell
Add-Migration Inicial
Update-Database
```

Esto creará automáticamente la base de datos y las tablas necesarias.

---

### 4️ Ejecutar el sistema

Presionar:

```
F5 o botón "Iniciar"
```

Luego ingresar a:

```
https://localhost:XXXX/Empleados
```

---

##  Script SQL

El script de la base de datos se encuentra en:

```
/script_sql/script.sql
```

Este archivo contiene la creación de la base de datos y la tabla de empleados.

---

##  Notas importantes

- Los empleados **no se eliminan físicamente**
- Se utiliza una baja lógica mediante el campo `Activo`
- El cambio de estado se realiza desde la interfaz principal
- Se implementa el patrón repositorio
- Se respeta la arquitectura MVC

---
