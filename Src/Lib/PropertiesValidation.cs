namespace PontosDeInteresse.Src.lib
{
    public class PropertiesValidation(bool isRequired, string fieldValidate)
    {
        protected bool _isRequired = isRequired;
        protected string _field = fieldValidate;
        protected string? _message;

        public bool IsValid { get; protected set; } = false;

        public object GetError()
        {
            return new
            {
                property = _field,
                message = _message,
            };
        }
    }
}
