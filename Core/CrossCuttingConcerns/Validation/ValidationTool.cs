using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entty)
        {
            var context = new ValidationContext<object>(entty);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
        }

    }
}
