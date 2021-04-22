﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcern.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            ValidationContext<object> context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if(result.IsValid==false)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
