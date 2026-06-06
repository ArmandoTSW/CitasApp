# CitasApp

## Descripción del proyecto

CitasApp es una aplicación web desarrollada con ASP.NET Core MVC para la gestión básica de citas médicas.

El sistema permite consultar pacientes registrados, médicos disponibles y una agenda de citas médicas. La información se maneja en memoria, por lo que no utiliza una base de datos en esta versión inicial.

Esta práctica tiene como objetivo implementar el patrón MVC, separando la aplicación en modelos, controladores y vistas.

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

## Funcionalidades

- Listar pacientes registrados.
- Ver el detalle de un paciente.
- Listar médicos disponibles.
- Ver el detalle de un médico.
- Mostrar la agenda completa de citas.
- Filtrar citas por paciente.
- Mostrar el nombre del paciente y del médico en cada cita.

## Estructura del proyecto

```text
CitasApp/
├── Controllers/
│   ├── PacienteController.cs
│   ├── MedicoController.cs
│   └── CitaController.cs
├── Data/
│   └── DatosMemoria.cs
├── Models/
│   ├── Paciente.cs
│   ├── Medico.cs
│   └── Cita.cs
├── ViewModels/
│   └── CitaViewModel.cs
├── Views/
│   ├── Paciente/
│   ├── Medico/
│   └── Cita/
└── Program.cs

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