using SportsX.Application.Utils;
using System.ComponentModel.DataAnnotations;

namespace SportsX.Application.DTOs.Extensions
{
    public class DocumentAttribute : ValidationAttribute
    {
        /// <summary>
        /// DataAnnotation auxiliar para verificar se o CPF ou CNPJ e valido
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage = "CPF ou CNPJ inválido";

            try
            {
                if (value == null) return ValidationResult.Success;

                if (string.IsNullOrEmpty(value.ToString())) return ValidationResult.Success;

                if (DocumentUtils.IsDocumentValid(value.ToString()))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(errorMessage);

                }

            }
            catch (System.Exception)
            {
                return new ValidationResult(errorMessage);
            }
        }
    }
}