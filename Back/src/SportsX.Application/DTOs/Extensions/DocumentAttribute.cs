using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using SportsX.Application.Utils;

namespace SportsX.Application.DTOs.Extensions
{
    public class DocumentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage = "CPF ou CNPJ inválido";

            try
            {
                if (DocumentUtils.IsDocumentValid(value.ToString()))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult(errorMessage);
            }
            catch (System.Exception)
            {
                return new ValidationResult(errorMessage);
            }
        }
    }
}