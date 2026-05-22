using Dsw2026Ej11.Domain;
namespace Dsw2026Ej11.Collections;

//Crear un diccionario donde la clave sea el legajo y el valor el alumno
//Incluir un método para agregar un alumno al diccionario
//Incluir un método para buscar un alumno utilizando la clave
//Incluir un método para retornar el diccionario
//Incluir un método para eliminar un alumno utilizando la clave
public class CasoDictionary
{
    private Dictionary<int, Alumno> alumnos = new Dictionary<int, Alumno>();

    public void AgregarAlumno(Alumno alumno)
    {
        alumnos.Add(alumno.Id, alumno);
    }
    public Alumno? BuscarAlumno(int id)
    {
        alumnos.TryGetValue(id, out Alumno? alumno);
        return alumno;
    }
    public Dictionary<int, Alumno> ObtenerDiccionario()
    {
        return alumnos;
    }
    public bool EliminarAlumno(int id)
    {
        return alumnos.Remove(id);
    }
}