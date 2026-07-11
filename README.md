# 🛠️ Sistema de Gestión Hardware Store

Proyecto Integrador — Tecnologias de Desarrollo de Software IDE

## 👥 Integrantes

| Nombre | Legajo | Email |
|---|---|---|
| [Gil Agustin] | [50412] | [agussv360@gmail.com] |
| [Fiorini Mauricio] | [50475] | [mauriciofiorini911@gmail.com] |
| [Herrera Nicolas] | [51541] | [herreranico2703@gmail.com] |

---

## 📋 Descripción

Sistema de gestión para una hardware store que permite administrar clientes, productos y órdenes de compra. El proyecto fue desarrollado como trabajo integrador aplicando los conceptos de arquitectura, persistencia de datos y buenas prácticas de programación en .NET.

## ⚙️ Funcionalidades principales

- 🧑‍💼 **Gestión de clientes**: alta, baja, modificación y consulta de clientes.
- 📦 **Gestión de productos**: catálogo de productos con stock, precio y categoría.
- 🧾 **Gestión de órdenes**: creación de órdenes de compra asociadas a clientes, con el detalle de productos y cantidades.
- 📊 **Reportes**: reportes

## 💻 Tecnologías utilizadas

- **Lenguaje**: C#
- **Framework**: .NET [versión]
- **Acceso a datos**: Entity Framework Core
- **Base de datos**: SQL Server
- **Interfaz**: [ASP.NET Core MVC / Blazor / WPF / Windows Forms — ajustar según corresponda]

## 🏗️ Arquitectura del proyecto

El sistema está organizado en capas:

- **Capa de Presentación**: interfaz de usuario.
- **Capa de Lógica de Negocio**: reglas y validaciones del dominio.
- **Capa de Acceso a Datos**: repositorios y contexto de EF Core.
- **Capa de Entidades**: modelos de dominio (Cliente, Producto, Orden, DetalleOrden, etc.)

## 🗂️ Diagrama de clases

<!-- Insertar aquí la imagen del diagrama de clases -->
![Diagrama de clases](ruta/a/tu/imagen.png)

## 🚀 Instalación y ejecución

1. Clonar el repositorio:
   ```bash
   git clone [URL del repositorio]
   ```
2. Restaurar las dependencias:
   ```bash
   dotnet restore
   ```
3. Configurar la cadena de conexión en `appsettings.json`.
4. Aplicar las migraciones:
   ```bash
   dotnet ef database update
   ```
5. Ejecutar el proyecto:
   ```bash
   dotnet run
   ```

## 📁 Estructura del repositorio

```
├── src/
│   ├── [Proyecto].Domain/
│   ├── [Proyecto].DataAccess/
│   ├── [Proyecto].BusinessLogic/
│   └── [Proyecto].Presentation/
├── docs/
│   └── diagrama-clases.png
└── README.md
```

## 📄 Licencia

Proyecto académico desarrollado con fines educativos. 🎓
