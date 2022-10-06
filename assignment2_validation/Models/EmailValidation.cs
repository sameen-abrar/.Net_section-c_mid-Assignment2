using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace assignment2_validation.Models
{
    //[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class EmailValidation:ValidationAttribute
    {
        public string ID { get; set; }
        
        public EmailValidation(string id)
        {
            ID = id;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var input = value as string;
            PropertyInfo property = validationContext.ObjectType.GetProperty(ID);
            var comp = property.GetValue(validationContext.ObjectInstance);

            if(comp == null || value == null)
            {
                return new ValidationResult("Email must be ID@student.aiub.edu");
            }

            if (input == comp.ToString() + "@student.aiub.edu")
                return ValidationResult.Success;

            return new ValidationResult("Email must be ID@student.aiub.edu");
        }

    }

    //public class ExcludeChar : ValidationAttribute
    //{
    //    private readonly string _chars;
    //    public ExcludeChar(string chars)
    //        : base("{0} contains invalid character.")
    //    {
    //        _chars = chars;
    //    }
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        if (value != null)
    //        {
    //            for (int i = 0; i < _chars.Length; i++)
    //            {
    //                var valueAsString = value.ToString();
    //                if (valueAsString.Contains(_chars[i]))
    //                {
    //                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
    //                    return new ValidationResult(errorMessage);
    //                }
    //            }
    //        }
    //        return ValidationResult.Success;
    //    }
    //}
}