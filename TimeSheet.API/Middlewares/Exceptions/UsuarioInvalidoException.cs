using System;

namespace TimeSheet.API.Middlewares.Exceptions
{
    public class UsuarioInvalidoException : Exception
    {
        public UsuarioInvalidoException(string message) : base(message)
        {

        }
    }
}
