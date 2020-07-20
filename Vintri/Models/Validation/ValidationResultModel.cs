using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Vintri.Models.Validation
{
    public class ValidationResultModel
    {
        public string Message { get; }

        public List<ValidationError> Errors { get; }

        /// <summary>
        /// One entry for each error in modelState
        /// </summary>
        /// <param name="modelState">
        /// Key = property name
        /// Value = Error related to the field in key
        /// </param>
        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Message = "Validation Failed";
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
        }
    }
}
