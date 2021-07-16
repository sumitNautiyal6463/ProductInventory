﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.CustomAttribute
{
    public class ProductItem : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.DisplayName == "Name")
            {
                string name = (string)value;
                if (string.IsNullOrEmpty(name))
                    return new ValidationResult("Product Item is required!");
            }
            else if (validationContext.DisplayName == "Description")
            {
                string description = (string)value;
                if (string.IsNullOrEmpty(description))
                    return new ValidationResult("Description is required!");
            }
            else if (validationContext.DisplayName == "Quantity")
            {
                int quantity = (int)value;
                if (quantity == 0)
                    return new ValidationResult("Quantity is required!");
            }
            else if (validationContext.DisplayName == "Price")
            {
                decimal price = (decimal)value;
                if (price == 0)
                    return new ValidationResult("Price is required!");
            }
            return ValidationResult.Success;
        }
    }
}
