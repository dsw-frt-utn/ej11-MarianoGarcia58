using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;

internal class Ejemplos
{
    // ==========================================
    // 1. EJEMPLO LIST
    // ==========================================
    public static void EjemploList()
    {
        Console.WriteLine("--- EJEMPLO LIST ---");
        CasoList casoList = new CasoList();

        // Agregar 3 alumnos a la lista usando tu constructor
        var alu1 = new Alumno(101, "Mariano Garcia", 7.5);
        var alu2 = new Alumno(102, "Ana Lopez", 9.0);
        var alu3 = new Alumno(103, "Carlos Perez", 8.5);

        casoList.AgregarAlumno(alu1);
        casoList.AgregarAlumno(alu2);
        casoList.AgregarAlumno(alu3);

        // Listar por consola los alumnos (aprovechando tu ToString())
        Console.WriteLine("\nLista inicial de alumnos:");
        foreach (var alu in casoList.ObtenerAlumnos())
        {
            Console.WriteLine(alu);
        }

        // Buscar por nombre un alumno que exista y mostrar por consola
        Console.WriteLine("\nBuscando a 'Ana Lopez':");
        var encontrado = casoList.BuscarPorNombre("Ana Lopez");
        Console.WriteLine(encontrado != null ? $"Encontrado -> {encontrado}" : "No existe");

        // Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
        Console.WriteLine("\nBuscando a 'Juan Gomez':");
        var noEncontrado = casoList.BuscarPorNombre("Juan Gomez");
        Console.WriteLine(noEncontrado != null ? $"Encontrado -> {noEncontrado}" : "No existe");

        // Eliminar un alumno y listar por consola los alumnos
        Console.WriteLine($"\nEliminando al alumno: {alu3.Nombre}...");
        casoList.EliminarAlumno(alu3);

        Console.WriteLine("Lista después de eliminar:");
        foreach (var alu in casoList.ObtenerAlumnos())
        {
            Console.WriteLine(alu);
        }

        // Eliminar el primer elemento de la lista y listar por consola los alumnos
        Console.WriteLine("\nEliminando el primer elemento (posición 0)...");
        casoList.EliminarPorPosicion(0);

        Console.WriteLine("Lista final de alumnos:");
        foreach (var alu in casoList.ObtenerAlumnos())
        {
            Console.WriteLine(alu);
        }
    }

    // ==========================================
    // 2. EJEMPLO DICTIONARY
    // ==========================================
    public static void EjemploDictionary()
    {
        Console.WriteLine("\n--- EJEMPLO DICTIONARY ---");
        CasoDictionary casoDic = new CasoDictionary();

        // Agregar 3 alumnos al diccionario usando tu constructor
        casoDic.AgregarAlumno(new Alumno(5001, "Lucia Fernandez", 7.8));
        casoDic.AgregarAlumno(new Alumno(5002, "Mateo Diaz", 8.2));
        casoDic.AgregarAlumno(new Alumno(5003, "Sofia Martinez", 9.5));

        // Listar por consola los alumnos
        Console.WriteLine("\nAlumnos en el diccionario:");
        foreach (var kvp in casoDic.ObtenerDiccionario())
        {
            Console.WriteLine($"Clave (Legajo): {kvp.Key} -> Alumno: {kvp.Value}");
        }

        // Buscar un alumno por clave y mostrar por consola
        Console.WriteLine("\nBuscando alumno con clave 5002:");
        var aluDic = casoDic.BuscarAlumno(5002);
        Console.WriteLine(aluDic != null ? $"Encontrado: {aluDic}" : "No existe");

        // Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
        Console.WriteLine("\nBuscando alumno con clave 9999:");
        var aluFalso = casoDic.BuscarAlumno(9999);
        Console.WriteLine(aluFalso != null ? $"Encontrado: {aluFalso}" : "No existe");

        // Eliminar un alumno por clave y listar por consola los alumnos
        Console.WriteLine("\nEliminando alumno con clave 5001...");
        casoDic.EliminarAlumno(5001);

        Console.WriteLine("Diccionario final:");
        foreach (var kvp in casoDic.ObtenerDiccionario())
        {
            Console.WriteLine($"Clave: {kvp.Key} -> Alumno: {kvp.Value}");
        }
    }

    // ==========================================
    // 3. EJEMPLO LINQ
    // ==========================================
    public static void EjemploLinq()
    {
        Console.WriteLine("\n--- EJEMPLO LINQ ---");
        CasoLinq casoLinq = new CasoLinq();

        // 1. Primer Libro
        var primero = casoLinq.GetPrimero();
        Console.WriteLine($"1. Primer libro: {primero?.Titulo} - {primero?.Precio:C}");

        // 2. Último Libro
        var ultimo = casoLinq.GetUltimo();
        Console.WriteLine($"2. Último libro: {ultimo?.Titulo} - {ultimo?.Precio:C}");

        // 3. Suma de precios
        Console.WriteLine($"3. Total suma de precios: {casoLinq.GetTotalPrecios():C}");

        // 4. Promedio de precios
        decimal promedio = casoLinq.GetPromedioPrecios();
        Console.WriteLine($"4. Promedio de precios: {promedio:C}");

        // 5. Libros con ID > 15
        Console.WriteLine("5. Libros con ID > 15:");
        foreach (var lib in casoLinq.GetListById())
        {
            Console.WriteLine($"   - [ID: {lib.Id}] {lib.Titulo}");
        }

        // 6. Lista en formato string moneda
        Console.WriteLine("6. Lista de libros (Formato String Moneda):");
        foreach (var strLibro in casoLinq.GetLibros())
        {
            Console.WriteLine($"   - {strLibro}");
        }

        // 7. Precio más alto
        var masCaro = casoLinq.GetMayorPrecio();
        Console.WriteLine($"7. Libro más caro: {masCaro?.Titulo} ({masCaro?.Precio:C})");

        // 8. Precio más bajo
        var masBarato = casoLinq.GetMenorPrecio();
        Console.WriteLine($"8. Libro más barato: {masBarato?.Titulo} ({masBarato?.Precio:C})");

        // 9. Libros con precio mayor al promedio
        Console.WriteLine($"9. Libros con precio mayor al promedio ({promedio:C}):");
        foreach (var lib in casoLinq.GetMayorPromedio())
        {
            Console.WriteLine($"   - {lib.Titulo} ({lib.Precio:C})");
        }

        // 10. Ordenados descendente por título
        Console.WriteLine("10. Libros ordenados por título (Z-A):");
        foreach (var lib in casoLinq.GetOrdenadosDescendente())
        {
            Console.WriteLine($"   - {lib.Titulo}");
        }
    }
}