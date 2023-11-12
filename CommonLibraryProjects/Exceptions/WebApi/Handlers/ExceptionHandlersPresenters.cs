using System.Reflection;

namespace CommonLibraryProjects.Exceptions.WebApi.Handlers
{
    public static class ExceptionHandlersPresenters
    {
        //
        // Resumen:
        //     Gets executing assembly.
        public static Assembly Assembly => System.Reflection.Assembly.GetExecutingAssembly();
    }
}
