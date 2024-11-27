using PontosDeInteresse.Src.lib;
using System.Text.RegularExpressions;

namespace PontosDeInteresse.Src.Modules.PointOfInterest.Validation
{
    public class NameValidation : PropertiesValidation
    {
        private Regex namePattern = new Regex("^[a-z]([a-z\\s]{1,48})?[a-z]$");

        public NameValidation(string? value, bool isRequired, string fieldName) : base(isRequired, fieldName)
        {
            Validate(value);
        }

        private void Validate(string? value)
        {
            value = value?.ToLower().Trim();

            if (string.IsNullOrEmpty(value))
            {
                if (_isRequired)
                {
                    _message = "Um nome deve ser informado para";
                    return;
                }
            }

            if (value is not null)
            {
                var success = namePattern.Match(value).Success;

                if (!success)
                {
                    _message = "Deve conter apenas letras de A-Z, de 2 a 50 caracteres.";
                    return;
                }
            }

            IsValid = true;
            return;
        }
    }
}
