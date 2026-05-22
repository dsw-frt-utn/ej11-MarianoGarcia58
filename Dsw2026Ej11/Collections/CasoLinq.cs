using Dsw2026Ej11.Domain;
namespace Dsw2026Ej11.Collections;

/*
 * Para cada punto crear un método que permita:
 * 1. Obtener el primer libro (GetPrimero)
 * 2. Obtener el último libro (GetUltimo)
 * 3. Obtener la suma de precios (GetTotalPrecios)
 * 4. Obtener el promedio de precios (GetPromedioPrecios)
 * 5. Obtener la lista de libros con Id mayor a 15 (GetListById)
 * 6. Obtener una lista de cada libro con su título y precio en formato moneda (GetLibros) (debe retornar una lista de string)
 * 7. Obtener el libro con el precio más alto (GetMayorPrecio)
 * 8. Obtener el libro con el precio más bajo (GetMenorPrecio)
 * 9. Obtener los libros cuyo precio sea mayor al promedio (GetMayorPromedio)
 * 10. Obtener los libros ordenados por título de forma descendente
 * En todos los casos debe aplicarse LINQ
 */
public class CasoLinq
{
    private List<Libro> Libros { get; set; }

    public CasoLinq()
    {
        Libros = Libro.CrearLista();
    }

    public Libro? GetPrimero() => Libros.FirstOrDefault();

    public Libro? GetUltimo() => Libros.LastOrDefault();

    public decimal GetTotalPrecios() => Libros.Sum(l => l.Precio);

    public decimal GetPromedioPrecios() => Libros.Count > 0 ? Libros.Average(l => l.Precio) : 0;

    public List<Libro> GetListById() => Libros.Where(l => l.Id > 15).ToList();

    public List<string> GetLibros()
    {
        // El formato :C aplica el símbolo de moneda local (ej. $ en Argentina)
        return Libros.Select(l => $"{l.Titulo} - {l.Precio:C}").ToList();
    }

    public Libro? GetMayorPrecio() => Libros.MaxBy(l => l.Precio);

    public Libro? GetMenorPrecio() => Libros.MinBy(l => l.Precio);

    public List<Libro> GetMayorPromedio()
    {
        var promedio = GetPromedioPrecios();
        return Libros.Where(l => l.Precio > promedio).ToList();
    }

    public List<Libro> GetOrdenadosDescendente()
    {
        return Libros.OrderByDescending(l => l.Titulo).ToList();
    }
}