namespace Backend.Exceptions
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException() : base("Los datos enviados no son válidos.") { }

        public DomainValidationException(string message) : base(message) { }
    }
}
