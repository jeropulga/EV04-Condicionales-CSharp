using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("es-CO");
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("TALLER DE ESTRUCTURAS CONDICIONALES EN C#");
Console.WriteLine("Ejercicios: clasificación de nota, descuento y menú de operaciones.\n");

// Ejercicio 1: if / else if / else para clasificar una nota.
decimal nota = LeerDecimal("Ingrese una nota entre 0 y 5: ", 0, 5);
if (nota >= 4.5m)
    Console.WriteLine("Desempeño: Superior");
else if (nota >= 4.0m)
    Console.WriteLine("Desempeño: Alto");
else if (nota >= 3.0m)
    Console.WriteLine("Desempeño: Básico");
else
    Console.WriteLine("Desempeño: Bajo");

// Ejercicio 2: condiciones compuestas para calcular un descuento.
decimal compra = LeerDecimal("\nIngrese el valor de la compra: $", 0, 1_000_000_000);
bool esClienteFrecuente = LeerSiNo("¿Es cliente frecuente? (s/n): ");
decimal porcentajeDescuento = compra >= 200_000m && esClienteFrecuente ? 0.15m
    : compra >= 200_000m ? 0.10m
    : esClienteFrecuente ? 0.05m
    : 0m;
decimal descuento = compra * porcentajeDescuento;
Console.WriteLine($"Descuento aplicado: {porcentajeDescuento:P0} ($ {descuento:N0})");
Console.WriteLine($"Total a pagar: $ {(compra - descuento):N0}");

// Ejercicio 3: switch para seleccionar una operación.
Console.WriteLine("\nOperaciones: 1) Sumar  2) Restar  3) Multiplicar  4) Dividir");
int opcion = LeerEntero("Seleccione una opción: ", 1, 4);
decimal primero = LeerDecimal("Primer número: ", decimal.MinValue, decimal.MaxValue);
decimal segundo = LeerDecimal("Segundo número: ", decimal.MinValue, decimal.MaxValue);

switch (opcion)
{
    case 1:
        Console.WriteLine($"Resultado: {primero + segundo:N2}");
        break;
    case 2:
        Console.WriteLine($"Resultado: {primero - segundo:N2}");
        break;
    case 3:
        Console.WriteLine($"Resultado: {primero * segundo:N2}");
        break;
    case 4 when segundo != 0:
        Console.WriteLine($"Resultado: {primero / segundo:N2}");
        break;
    case 4:
        Console.WriteLine("No se puede dividir entre cero.");
        break;
}

static decimal LeerDecimal(string mensaje, decimal minimo, decimal maximo)
{
    while (true)
    {
        Console.Write(mensaje);
        string entrada = (Console.ReadLine() ?? string.Empty).Trim().Replace(',', '.');
        if (decimal.TryParse(entrada, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal valor)
            && valor >= minimo && valor <= maximo)
            return valor;
        Console.WriteLine($"Entrada inválida. Ingrese un número entre {minimo} y {maximo}.");
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

static bool LeerSiNo(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string respuesta = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();
        if (respuesta is "s" or "si" or "sí") return true;
        if (respuesta is "n" or "no") return false;
        Console.WriteLine("Responda s o n.");
    }
}
