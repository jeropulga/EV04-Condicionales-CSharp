# EV04 - Estructuras de control condicional en C#

Solución de consola con los dos proyectos solicitados en la evidencia 220501097-04-AA1-EV04.

## Contenido

- `TallerCondicionales`: clasificación de notas con `if/else if/else`, cálculo de descuentos con condiciones compuestas y selección de operaciones con `switch`.
- `ClinicaVeterinaria`: captura de datos básicos, selección del motivo de consulta, clasificación inicial del nivel de atención mediante condicionales y resumen de recepción.

## Requisitos

- SDK de .NET 10 o compatible con `net10.0`.
- Terminal y editor de código (por ejemplo, Visual Studio Code).

## Ejecución

Desde la carpeta raíz:

```bash
dotnet build TallerCondicionales/TallerCondicionales.csproj
dotnet build ClinicaVeterinaria/ClinicaVeterinaria.csproj
dotnet run --project TallerCondicionales/TallerCondicionales.csproj
dotnet run --project ClinicaVeterinaria/ClinicaVeterinaria.csproj
```

Cada proyecto pide los datos por consola y valida las entradas numéricas y de sí/no. Para probar rutas diferentes, cambie las respuestas ingresadas. Por ejemplo, en la clínica elija motivo 1 o responda sí a dificultad respiratoria para observar la ruta de emergencia.

## Lógica principal del reto veterinario

1. La dificultad respiratoria o la inconsciencia llevan a emergencia.
2. El sangrado abundante o un motivo de lesión/dolor intenso llevan a urgencia.
3. El motivo de vómito, diarrea o malestar persistente es prioritario.
4. Los controles y consultas generales quedan como programados.

La clasificación es un ejercicio académico y no reemplaza el criterio del profesional veterinario.

## Alcance del taller

La guía de aprendizaje remite a un taller alojado en Notion, pero ese recurso no estuvo accesible durante la preparación. El proyecto `TallerCondicionales` contiene ejercicios propios que cubren estructuras condicionales básicas y el uso de `switch`; conviene cotejar sus enunciados con el taller del LMS antes de entregar si el instructor exige los ejercicios exactos del recurso.

## Publicación en GitHub

El proyecto está listo para inicializarse como repositorio. Después de crear el repositorio remoto en GitHub, se puede publicar con:

```bash
git init
git add .
git commit -m "Completa evidencia EV04 de condicionales en C#"
git branch -M main
git remote add origin URL_DEL_REPOSITORIO
git push -u origin main
```

Adjunte al LMS el enlace del repositorio y capturas propias de ambos programas ejecutándose en consola.



