namespace Backend.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("El recurso solicitado no existe.") { }

        public NotFoundException(string message) : base(message) { }
    }
}
