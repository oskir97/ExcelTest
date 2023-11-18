using System.Reflection;

namespace CommonLibraryProjects.Exceptions.WebApi.Handlers
{
    public static class ExceptionHandlersPresenters
    {
        public static Assembly Assembly => System.Reflection.Assembly.GetExecutingAssembly();
    }
}
