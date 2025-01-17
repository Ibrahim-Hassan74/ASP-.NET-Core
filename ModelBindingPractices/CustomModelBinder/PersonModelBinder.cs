using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBindingPractices.Models;

namespace ModelBindingPractices.CustomModelBinder
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var person = new Person();
            if (bindingContext.Check("PersonName"))
                person.PersonName = bindingContext.GetValue("PersonName");

            if (bindingContext.Check("Email"))
                person.Email = bindingContext.GetValue("Email");

            if (bindingContext.Check("Password"))
                person.Password = bindingContext.GetValue("Password");

            if (bindingContext.Check("ConfirmPassword"))
                person.ConfirmPassword = bindingContext.GetValue("ConfirmPassword");

            if (bindingContext.Check("Phone"))
                person.Phone = bindingContext.GetValue("Phone");

            if (bindingContext.Check("Id"))
                person.Id = Convert.ToInt32(bindingContext.GetValue("Id"));

            if (bindingContext.Check("DateOfBirth"))
                person.DateOfBirth = Convert.ToDateTime(bindingContext.GetValue("DateOfBirth"));

            bindingContext.Result = ModelBindingResult.Success(person);

            return Task.CompletedTask;
        }
    }

    public static class ModelBinderExtension
    {
        public static bool Check(this ModelBindingContext bindingContext, string key)
        {
            return !string.IsNullOrEmpty(bindingContext.GetValue(key));
        }

        public static string? GetValue(this ModelBindingContext bindingContext, string key)
        {
            return bindingContext.ValueProvider.GetValue(key).FirstValue;
        }
    }
}
