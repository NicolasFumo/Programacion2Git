using FluentValidation;
using FluentValidation.Validators;

var nuevoAlumno = new Alumno()
{
    Cursos = new List<Asignatura>(),
    Nombre = "Carlos",
    Apellido = "Zanabria"
};

void RegistrarAlumno(Alumno nuevoAlumno)
{
    var validacionAlumno = new AlumnoValidator();
    var resultado = validacionAlumno.Validate(nuevoAlumno);

    if (resultado.IsValid)
    {
        Console.WriteLine("Se registro el alumno");
    }
    else
    {
        Console.WriteLine("Error al registrar alumno");
        Console.WriteLine( resultado.ToString() );
    }
}

class Alumno
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public List<Asignatura> Cursos { get; set; }
    public string DNI { get; set; }
}

class Asignatura
{
    public List<Examen> Examenes { get; set; } // Esto ultimo
    public string Nombre { get; set; }
    public string Horarios { get; set; }

}

// Esto ultimo
class Examen
{
    public string Horario { get; set; }
    public int Nota { get; set; }
}

class AlumnoValidator : AbstractValidator<Alumno>
{
    public AlumnoValidator()
    {
        // aquí todas las reglas
        RuleFor(a => a.Nombre)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(40);

        RuleFor(a => a.DNI)
            .Length(8, 8);

        RuleFor(a => a.Cursos)
            .NotNull();

        RuleForEach(a => a.Cursos).SetValidator(new AsignaturaValidator());
    }
}

class AsignaturaValidator : AbstractValidator<Asignatura>
{
    public AsignaturaValidator()
    {
        RuleForEach(a => a.Examenes).SetValidator(new ExamenValidator());
        RuleForEach(a => a.Examenes).SetValidator(new ExamenValidator());
    }
}

class ExamenValidator : AbstractValidator<Examen>
{
    public ExamenValidator()
    {

    }
}

/*
using FluentValidation;

var secretario = new Usuario();

secretario.Edad = 5;

secretario.Direccion = new Direccion();

EnviarEmail(secretario);


void EnviarEmail(Usuario user)
{
    var validarUsuario = new UsuarioValidator();

    var resultado = validarUsuario.Validate(user, options => 
    options.IncludeRuleSets("DatosPersonales", "default"));

    if (resultado.IsValid)
    {
        Console.WriteLine($"Se envio el email a {user.NombrePersona}");
    }
    else
    {
        foreach (var error in resultado.Errors)
        {
            Console.WriteLine(error.PropertyName);
        }
        Console.WriteLine(resultado.ToString());
    }
}

class Usuario
{
    public List<string> Telefonos { get; set; }
    public Direccion Direccion { get; set; }
    public List<Direccion> Direcciones { get; set; }
    public string NombrePersona { get; set; }
    public int Edad { get; set; }
}

class Direccion
{
    public string Calle { get; set; }
    public string Ciudad { get; set; }
    public string CodigoPostal { get; set; }
}

class UsuarioValidator : AbstractValidator<Usuario>
{
    public UsuarioValidator()
    {
        //ruleset
        RuleSet("DatosPersonales", () => {

            RuleFor(x => x.NombrePersona)
            .NotNull().WithMessage("No podes dejar nulo el {PropertyName}")
            .NotEmpty().WithMessage("El {PropertyName} no puede estar vacio");

            RuleFor(x => x.Edad)
                .GreaterThanOrEqualTo(18).WithMessage("Solo mayores de {ComparisonValue} años");

            RuleForEach(x => x.Telefonos)
                .NotEmpty().WithMessage("El telefono no puede estar vacio");

            RuleFor(x => x.Telefonos)
            .NotNull().WithMessage("El listado de telefonos no puede ser nulo");

            RuleFor(x => x.Direcciones)
           .NotNull().WithMessage("El listado de direcciones no puede ser nulo");

            RuleForEach(x => x.Direcciones)
                .SetValidator(new DireccionValidator());
        });

        RuleFor(x => x.Direccion).SetValidator(new DireccionValidator());
    }
}

class DireccionValidator : AbstractValidator<Direccion>
{
    public DireccionValidator()
    {
        RuleFor(d => d.Calle)
            .NotEmpty()
            .NotNull();
    }
}

*/