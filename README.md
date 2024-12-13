**SWApiRest** es una API REST desarrollada con **.NET** para gestionar información de naves espaciales del universo Star Wars. Utiliza una arquitectura en capas siguiendo principios de **Clean Architecture** y buenas prácticas de desarrollo.

---

## 📁 **Estructura del Proyecto**

```
SWVUEL-master/
│
├── SWVUEL.sln                                     # Archivo de solución principal
│
├── SWVUEL.DistributedService.WebApi/           # Capa de presentación (API)
│   ├── Controllers/
│   │   └── StarshipController.cs               # Controlador principal para naves espaciales
│   ├── Program.cs                               # Punto de entrada de la API
│   ├── appsettings.json                         # Configuración general de la API
│   └── appsettings.Development.json             # Configuración para entorno de desarrollo
│
├── SWVUEL.Domain.Models/                        # Modelos de dominio
│   ├── StarshipModel.cs                         # Modelo para naves espaciales
│   └── StarshipsResponse.cs                     # Modelo para respuesta de la API
│
├── SWVUEL.Infrastructure.Contracts/             # Interfaces para el acceso a datos
│   └── IRepository.cs                          # Interfaz genérica del repositorio
│
├── SWVUEL.Infrastructure.Impl/                  # Implementación del acceso a datos
│   ├── Repository.cs                            # Implementación del repositorio genérico
│   └── DbContexts/
│       └── StarshipDbContext.cs                  # Contexto de base de datos con Entity Framework
│
├── SWVUEL.Library.Contracts/                    # Interfaces y DTOs de servicios
│   └── DTOs/
│       └── StarshipApiDto.cs                    # DTO para naves espaciales
│
├── SWVUEL.Library.Impl/                         # Implementación de servicios
│   └── Service.cs                              # Lógica de negocio para naves espaciales
│
├── SWVUEL.Testing.UnitTest/                     # Pruebas unitarias
│   ├── StarshipTests.cs                        # Pruebas para el modelo de naves espaciales
│   ├── RepositoryTests.cs                       # Pruebas para el repositorio
│   └── ServiceTests.cs                          # Pruebas para el servicio
│
└── SWVUEL.XCutting.Enums/                       # Enumeraciones de uso general
    └── ErrorCode.cs                            # Códigos de error
```

---
## 🔌 **Endpoints **

### **1. Obtener todas las naves espaciales**

```
GET /api/starship/GetStarships
```

### **2. Sincronizar naves espaciales**

```
POST /api/starship/SyncStarship
```

### **3. Actualizar el nombre y el modelo de una nave espacial**

```
PUT /api/starship/UpdateStarshipNameAndModel?id={id}
Content-Type: application/json

{
    "newName": "string",
    "newModel": "string"
}

