using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuffMeUp.Backend.Common;

public static class Utils
{
    public static object GetErrorsObject(ModelStateDictionary modelState)
    {
        return new
        {
            Errors = modelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray() ?? new[] { "" })
        };
    }
}
