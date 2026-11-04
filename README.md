# 🛒 GestiónCatalogo

**Entrega de fin de curso — Nivel 3 de Maxi Programa**  
C# .NET · ASP.NET Web Forms · HTML/CSS · JavaScript

> Sistema web de gestión de catálogo de productos con panel de administración, autenticación de usuarios y búsqueda avanzada.

---

## 📋 Descripción

*GestiónCatalogo* es una aplicación web desarrollada como entrega del **Curso de Programación Nivel 3** de **Maxi Programa**. El proyecto permite administrar un catálogo de productos, gestionar usuarios con roles de administrador/guest, realizar búsquedas filtradas por nombre, marca y categoría, y contar con un panel de administración completo con paginación, ordenamiento y eliminación segura de registros.

---

## 🛠️ Tecnologías

| Capa | Tecnología |
|------|------------|
| **Frontend** | HTML5, CSS3, JavaScript, ASP.NET Web Forms, Master Pages |
| **Backend** | C# 8.0, ASP.NET Web Forms, Session State |
| **Datos** | SQL Server (o SQL Server Express), ADO.NET (capa `Negocio` / `AccesoDatos`) |
| **Seguridad** | Autenticación de usuarios, roles (Admin/Guest), timeout de sesión, validación de cliente y servidor |
| **HERAMENTO** | Archivos de configuración `Web.config`, `Web.Debug.config`, `Web.Release.config` |

---

## 📁 Estructura del proyecto

```
TpFinalNivel3BlancoGabriel/
├── GestionCatalogo.Web/          # Aplicación Web (ASP.NET Web Forms)
│   ├── admin/                    # Panel de administración
│   │   ├── PanelArticulos.aspx   # Listado de artículos con paginación y ordenamiento
│   │   ├── FormularioArticulo.aspx # Formulario de agregar/editar artículo
│   │   └── ...
│   ├── Default.aspx              # Página principal del catálogo (búsqueda y grilla)
│   ├── Login.aspx                # Formulario de acceso de usuarios
│   ├── Error.aspx                # Página de manejo de errores
│   ├── Favoritos.aspx            # Gestión de favoritos
│   ├── MiPerfil.aspx             # Perfil del usuario
│   ├── Master.Master             # Master Page (plantilla común)
│   └── Web.config                # Configuración de la aplicación
├── dominio/                      # Entidades y modelos del dominio
│   └── Articulo.cs               # Clase principal del dominio
├── negocio/                      # Lógica de negocio y acceso a datos
│   ├── ArticuloNegocio.cs        # Lógica de negocio de Artículo
│   ├── MarcaNegocio.cs           # Lógica de negocio de Marca
│   ├── CategoriaNegocio.cs       # Lógica de negocio de Categoría
│   ├── AccesoDatos.cs            # Acceso a datos (ADO.NET)
│   └── ...
├── database/                     # Scripts de base de datos
│   ├── ScriptBaseDatos.sql       # Script de creación de la base de datos
│   └── ...
├── TpFinalNivel3BlancoGabriel.sln
└── README.md                     # Este archivo
```

---

## ✨ Características

### Catálogo público (`Default.aspx`)
- Listado de productos con paginación (9 por página)
- Filtros avanzados: nombre, marca, categoría y precio máximo
- Estado de carga (`Loading`) y estado vacío (`No hay artículos disponibles`)
- Ordenamiento por columnas
- Previsualización de imágenes de productos

### Panel de administración (`admin/PanelArticulos.aspx`)
- Listado de artículos con paginación y ordenamiento
- Búsqueda y filtrado
- **Confirmación de borrado** con modal
- Mensajes de error descriptivos
- Autenticación de administradores

### Seguridad y sesión
- **Login** con validación de cliente y servidor
- Control de sesión con **timeout** y redirección segura
- Roles: `Admin` y `Guest`
- Válidación de campos obligatorios y formatos (email, precio, etc.)

### Mejoras implementadas
- Manejo de excepciones con preservación de stack trace (`AccesoDatos.cs`)
- Contador de artículos en el menú de administración
- Validación de cliente en formularios de login
- Estado de carga y mensaje de "no resultados" en la grilla

---

## 🚀 Requisitos

- **.NET Framework 4.7.2** o superior (Windows)
- **SQL Server 2017** o superior (o SQL Server Express)
- **Visual Studio 2019** o superior (opcional, para desarrollo)
- Navegador web moderno (Chrome, Firefox, Edge)

---

## 📦 Instalación y configuración

### 1. Clonar el repositorio
```bash
git clone https://github.com/Blan25ga/tp-final-nivel3-blanco-gabriel.git
cd TpFinalNivel3BlancoGabriel
```

### 2. Crear la base de datos
Abrir `database/ScriptBaseDatos.sql` en SQL Server Management Studio (SSMS) y ejecutar:
```sql
-- Crea la base de datos y los usuarios de prueba
-- Usuario admin: admin@admin.com / admin123
-- Usuario guest: guest@guest.com / guest123
```

### 3. Configurar la cadena de conexión
Editar `GestionCatalogo.Web/Web.config`:
```xml
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=GestionCatalogo;Integrated Security=True;Pooling=False"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4. Ejecutar la aplicación
- Abrar `TpFinalNivel3BlancoGabriel.sln` en Visual Studio
- O usar el generador de sitios web .NET (Kestrel / IIS Express)
- Acceder a `http://localhost:PORT/`

---

## 📫 Contacto

Si tienes preguntas o comentarios sobre el proyecto, puedes contactarme:

- **GitHub**: https://github.com/Blan25ga/tp-final-nivel3-blanco-gabriel
- **Correo**: gabriel.blanco@maxi.com.ar

---

## ℹ️ Notas del proyecto

- Este repositorio es una **entrega académica** del curso *Maxi Programa – Nivel 3*
- El proyecto tiene **20 commits** en la rama `master`
- La versión más reciente incluye información actualizada de la documentación
- Para consultas sobre la arquitectura o la implementación, revisar los commits y el código fuente

---

## 📈 Mejoras futuras

- [ ] Implementación de pruebas unitarias
- [ ] Pestañas dinámicas en el panel de administración
- [ ] Exportación de datos a CSV/PDF
- [ ] Optimización de consultas SQL
- [ ] Implementación de audit logging
- [ ] Diseño responsive completo

---

📫 **Contacto**: gabriel.blanco@maxi.com.ar  
🔗 **Repositorio**: https://github.com/Blan25ga/tp-final-nivel3-blanco-gabriel
