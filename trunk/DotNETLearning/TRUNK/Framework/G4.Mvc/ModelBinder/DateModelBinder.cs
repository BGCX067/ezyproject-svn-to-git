namespace G4.Mvc.ModelBinder
{
    using System;
    using System.Globalization;
    using System.Web.Mvc;

    /// <summary>
    /// Custom datetime type model binder with specific culture-variant
    /// </summary>
    public class DateModelBinder : IModelBinder
    {

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);
            if (value != null)
            {
                try
                {
                    var date = value.ConvertTo(typeof(DateTime?), CultureInfo.CurrentCulture);
                    return date;
                }
                catch
                {
                    //If something wrong, validation should take care
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format("{0} format is incorrect", bindingContext.ModelName));
                    return value;
                }
            }

            return value;
        }
    }
}
