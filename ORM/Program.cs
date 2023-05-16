using ORM;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

Menu();
GestorRespuesta<bool> EliminarPersona(int id)
{
    try
    {
        using (var context = new AppDbContext())
        {
            var persona = context.Personas.First(p => p.Id == id);

            context.Personas.Remove(persona);
            context.SaveChanges();

            return new GestorRespuesta<bool>(true);
        }
    }
    catch (Exception ex)
    {
        return new GestorRespuesta<bool>(true, $"Error: {ex.Message}");
    }
}
GestorRespuesta<Persona> ModificarNombre(int id, string nombreNuevo)
{
    try
    {
        using (var context = new AppDbContext())
        {
            var persona = context.Personas.First(p => p.Id == id);
            persona.Nombre = nombreNuevo;
            context.SaveChanges();

            return new GestorRespuesta<Persona>(persona);
        }
    }
    catch (Exception ex)
    {
        return new GestorRespuesta<Persona>(true, $"Error: {ex.Message}");
    }
}
List<Persona> BuscarPorNombre(string nombreABuscar)
{
    using (var context = new AppDbContext())
    {
        var busqueda = context.Personas
            .Where( x => x.Nombre.Contains(nombreABuscar) )
            .ToList();

        return busqueda;
    }
}
List<Persona> Listar()
{
    using (var context = new AppDbContext())
    {
        return context.Personas.ToList();
    }
}
GestorRespuesta<Persona> Registrar(Persona persona)
{
    try
    {
        using (var context = new AppDbContext())
        {
            context.Personas.Add(persona);

            context.SaveChanges();

            return new GestorRespuesta<Persona>(persona);
        }
    }
    catch (Exception ex)
    {
        return new GestorRespuesta<Persona>(true, $"Error: {ex.Message}");
    }
}
Persona BuscarPorId(int id)
{
    using (var context = new AppDbContext())
    {
        return context.Personas.First(x => x.Id == id);
    }
}

void Menu()
{
    Console.Clear();
    int opcion;

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(" -- CRUD EF CORE -- ");
    Console.ResetColor();
    Console.WriteLine(" 1- Listar personas ");
    Console.WriteLine(" 2- Registrar Persona ");
    Console.WriteLine(" 3- Modificar nombre persona ");
    Console.WriteLine(" 4- Eliminar persona por Id ");
    Console.WriteLine(" 5- Buscar por nombre ");
    Console.WriteLine();
    Console.Write("Escriba una opcion y presione enter-> ");

    var opc = Console.ReadLine();
    try
    {
        opcion = int.Parse(opc);
    }
    catch (Exception)
    {
        Menu();
    }


    switch (opcion)
    {
        case 1:
            Console.Clear();
            Listar();
            break;

        case 2:
            Console.Clear();

            Persona p = new Persona();

            Console.Write("Nombre: ");
            p.Nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            p.Apellido = Console.ReadLine();

            var res = Registrar(p);

            if (res.HayError)
            {
                Console.WriteLine(res.MensajeError);
            }
            else
            {
    Console.WriteLine($"Se registro la persona con id: {res.Respuesta.Id}");
            }

            break;

        case 3:
            Console.Clear();
            ModificarNombre();
            break;

        case 4:
            Console.Clear();
            EliminarPersona();
            break;

        case 5:
            Console.Clear();
            BuscarPorNombre();
            break;

        default:
            Console.Clear();
            Menu();
            break;

    }
    Console.WriteLine();
    Console.Write("Presione una tecla para continuar..");
    Console.ReadKey();
    Menu();
}