﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StudyApi.Helper
{
    public class BindModleStringToList : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (!bindingContext.ModelMetadata.IsEnumerableType)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();

            if (string.IsNullOrWhiteSpace(value))
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }

            var elementType = bindingContext.ModelType.GetTypeInfo().GetGenericArguments()[0];
            var converter = TypeDescriptor.GetConverter(elementType);

            var values = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => converter.ConvertFrom(x.Trim())).ToArray();

            var typeValues = Array.CreateInstance(elementType, values.Length);
            values.CopyTo(typeValues, 0);
            bindingContext.Model = typeValues;
            bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
            return Task.CompletedTask;
        }
    }
}
