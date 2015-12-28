namespace G4.Mvc.ModelBinder
{
    using System.Web.Mvc;

    /// <summary>
    /// This model binder is used to automatically trim the empty space for any string.
    /// http://stackoverflow.com/questions/1718501/asp-net-mvc-best-way-to-trim-strings-after-data-entry-should-i-create-a-custo
    /// </summary>
    public class TrimModelBinder : IModelBinder
    {
        #region IModelBinder Members

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult == null || string.IsNullOrWhiteSpace(valueProviderResult.AttemptedValue))
                return null;
            return valueProviderResult.AttemptedValue.Trim();
        }

        #endregion
    }
}
