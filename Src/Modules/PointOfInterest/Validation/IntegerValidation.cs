using PontosDeInteresse.Src.lib;
using System.Text.RegularExpressions;

namespace PontosDeInteresse.Src.Modules.PointOfInterest.Validation
{
    public class IntegerValidation : PropertiesValidation
    {
        private Regex integerPattern = new Regex("^[\\d]+$");

        public IntegerValidation(int? value, bool isRequired, string fieldName) : base(isRequired, fieldName)
        {
            Validate(value);
        }

        private void Validate(int? value)
        {
            string? formatValue = value?.ToString();
            string describePattern = "Deve ser um número inteiro maior ou igual a zero.";

            if (string.IsNullOrEmpty(formatValue))
            {
                if (_isRequired)
                {
                    _message = "O campo precisa ser informado. " + describePattern;
                    return;
                }
            }

            if (formatValue is not null)
            {
                var success = integerPattern.Match(formatValue).Success;

                if (!success)
                {
                    _message = "Use apenas números de 0 a 9. " + describePattern;
                    return;
                }

                if (value < 0 || value % 1 != 0)
                {
                    _message = describePattern;
                    return;
                }
            }

            IsValid = true;
            return;
        }
    }
}
