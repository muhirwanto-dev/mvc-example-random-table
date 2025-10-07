using Microsoft.AspNetCore.Mvc.ApplicationModels;
using SingleScope.Common.Extensions;

namespace TableGenerator.Api.Routing
{
    /// <summary>
    /// Convert [controller] naming convention to kebab-case.
    /// </summary>
    /// <example>
    /// For example:
    /// <code>
    ///     [Route("api/[controller]")]
    ///     public class AdminNotificationController : ControllerBase
    ///     {
    ///     }
    /// </code>
    /// 
    /// The final endpoint will be 'api/admin-notification' instead of 'api/AdminNotification'
    /// </example>
    public class ControllerRoutingConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            string converted = controller.ControllerName.ToKebabCase()!;

            // Modify the attribute routes of the action
            foreach (var selector in controller.Selectors)
            {
                selector.AttributeRouteModel ??= new AttributeRouteModel();
                selector.AttributeRouteModel.Template = selector.AttributeRouteModel.Template?.Replace("[controller]", converted);
            }
        }
    }
}
