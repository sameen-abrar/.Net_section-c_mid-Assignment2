using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace assignment2_validation.Models
{
    public class dobValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Field cannot be empty");
            }
            var input = value as string;
            string[] dob = input.Split('-');

            int year = Convert.ToInt32(dob[0]);
            int month = Convert.ToInt32(dob[1]);
            int day = Convert.ToInt32(dob[2]);           

            if(year<2004)
            {
                return ValidationResult.Success;
            }
            else if(year==2004 && month == 1 && day == 1)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Age must be greater than 18 years old");


            //PropertyInfo property = validationContext.ObjectType.GetProperty(ID);
            //var comp = property.GetValue(validationContext.ObjectInstance);

            //if (comp == null || value == null)
            //{
            //    return new ValidationResult("Email must be ID@student.aiub.edu");
            //}

            //if (input == comp.ToString() + "@student.aiub.edu")
            //    return ValidationResult.Success;
        }
    }
}