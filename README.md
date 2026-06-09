# CitasApp

## Descripción del proyecto

CitasApp es una aplicación web desarrollada con ASP.NET Core MVC para la gestión básica de citas médicas.

El sistema permite consultar pacientes registrados, médicos disponibles y una agenda de citas médicas. También permite filtrar las citas por paciente y mostrar la información relacionada del paciente y del médico.

El proyecto fue refactorizado a una arquitectura hexagonal multi-proyecto, separando el dominio, la infraestructura y la aplicación web.

## Tecnologías usadas

- C#
- ASP.NET Core MVC
- .NET
- Razor Views
- HTML
- CSS
- Bootstrap
- Visual Studio
- Git
- GitHub

## Arquitectura del proyecto

El proyecto utiliza una arquitectura hexagonal básica, separando responsabilidades en diferentes proyectos:

CitasApp: proyecto web MVC. Contiene controladores, vistas, ViewModels y configuración principal.
CitasApp.Domain: contiene los modelos del dominio y las interfaces de repositorio.
CitasApp.Infrastructure: contiene las implementaciones de los repositorios en memoria.
PetConnect.TEST: proyecto de pruebas.

Esta separación permite que la lógica principal del sistema no dependa directamente de la forma en la que se almacenan los datos.

## Funcionalidades

- Listar pacientes registrados.
- Ver el detalle de un paciente.
- Listar médicos disponibles.
- Ver el detalle de un médico.
- Mostrar la agenda completa de citas.
- Filtrar citas por paciente.
- Mostrar el nombre del paciente y del médico en cada cita.

## Estructura del proyecto
```
CitasApp/
├── Controllers/
│ ├── PacienteController.cs
│ ├── MedicoController.cs
│ └── CitaController.cs
├── Models/
│ └── ErrorViewModel.cs
├── ViewModels/
│ └── CitaViewModel.cs
├── Views/
│ ├── Paciente/
│ ├── Medico/
│ └── Cita/
├── screenshots/
├── Program.cs
└── README.md

CitasApp.Domain/
├── Models/
│ ├── Paciente.cs
│ ├── Medico.cs
│ └── Cita.cs
└── Interfaces/
├── IPacienteRepository.cs
├── IMedicoRepository.cs
└── ICitaRepository.cs

CitasApp.Infrastructure/
└── Repositories/
├── PacienteRepositoryMemoria.cs
├── MedicoRepositoryMemoria.cs
└── CitaRepositoryMemoria.cs
```

## Capturas de pantalla

### Pacientes

![Pantalla de pacientes](screenshots/Paciente.png)

### Detalle de paciente

![Detalle de paciente](screenshots/DetalleP.png)

### Médicos

![Pantalla de médicos](screenshots/Medico.png)

### Detalle de médico

![Detalle de médico](screenshots/DetalleM.png)

### Agenda de citas

![Agenda de citas](screenshots/Cita.png)

### Detalle / citas por paciente

![Citas por paciente](screenshots/DetalleC.png)