using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("es-CO");
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("SISTEMA DE ATENCIÓN - CLÍNICA VETERINARIA");
Console.WriteLine("Registro de paciente y clasificación inicial de atención.\n");

Console.Write("Nombre del propietario: ");
string propietario = LeerTextoObligatorio();
Console.Write("Nombre de la mascota: ");
string mascota = LeerTextoObligatorio();
Console.Write("Especie (perro, gato u otra): ");
string especie = LeerTextoObligatorio();

Console.WriteLine("\nMotivo de consulta:");
Console.WriteLine("1. Dificultad respiratoria o inconsciencia (emergencia)");
Console.WriteLine("2. Sangrado, dolor intenso o lesión importante (urgente)");
Console.WriteLine("3. Vómito, diarrea o malestar persistente (prioritaria)");
Console.WriteLine("4. Vacunación, control o consulta general (programada)");
int motivo = LeerEntero("Seleccione el motivo (1-4): ", 1, 4);

Console.Write("¿La mascota tiene dificultad para respirar? (s/n): ");
bool dificultadRespiratoria = LeerSiNo();
Console.Write("¿Está inconsciente o no responde? (s/n): ");
bool inconsciente = LeerSiNo();
Console.Write("¿Presenta sangrado abundante? (s/n): ");
bool sangradoAbundante = LeerSiNo();

string nivel;
string indicacion;
int turno;

// Los signos críticos prevalecen sobre el motivo seleccionado.
if (dificultadRespiratoria || inconsciente)
{
    nivel = "EMERGENCIA";
    indicacion = "Avisar de inmediato al equipo veterinario y pasar a evaluación prioritaria.";
    turno = 1;
}
else if (sangradoAbundante || motivo == 2)
{
    nivel = "URGENTE";
    indicacion = "Informar al equipo veterinario para valoración prioritaria.";
    turno = 2;
}
else if (motivo == 3)
{
    nivel = "PRIORITARIA";
    indicacion = "Esperar en sala; el personal llamará al siguiente turno prioritario.";
    turno = 3;
}
else
{
    nivel = "PROGRAMADA";
    indicacion = "Esperar el llamado según el orden de llegada.";
    turno = 4;
}

string especieNormalizada = especie.Trim().ToLowerInvariant();
string categoriaEspecie = especieNormalizada switch
{
    "perro" or "perra" => "Canino",
    "gato" => "Felino",
    _ => "Otra especie"
};

Console.WriteLine("\n--- RESUMEN DE RECEPCIÓN ---");
Console.WriteLine($"Propietario: {propietario}");
Console.WriteLine($"Paciente: {mascota} ({categoriaEspecie})");
Console.WriteLine($"Clasificación: {nivel}");
Console.WriteLine($"Turno sugerido: {turno}");
Console.WriteLine($"Indicación: {indicacion}");
Console.WriteLine("\nNota: esta clasificación es académica y no reemplaza el criterio del profesional veterinario.");

static string LeerTextoObligatorio()
{
    while (true)
    {
        string valor = (Console.ReadLine() ?? string.Empty).Trim();
        if (!string.IsNullOrWhiteSpace(valor)) return valor;
        Console.Write("El dato no puede quedar vacío. Intente de nuevo: ");
    }
}

static int LeerEntero(string mensaje, int minimo, int maximo)
{
    while (true)
    {
        Console.Write(mensaje);
        if (int.TryParse(Console.ReadLine(), out int valor) && valor >= minimo && valor <= maximo)
            return valor;
        Console.WriteLine($"Opción inválida. Ingrese un número entre {minimo} y {maximo}.");
    }
}

static bool LeerSiNo()
{
    while (true)
    {
        string respuesta = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();
        if (respuesta is "s" or "si" or "sí") return true;
        if (respuesta is "n" or "no") return false;
        Console.Write("Responda s o n: ");
    }
}
