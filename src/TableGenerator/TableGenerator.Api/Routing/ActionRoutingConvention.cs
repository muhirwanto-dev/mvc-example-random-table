using Microsoft.AspNetCore.Mvc.ApplicationModels;
using SingleScope.Common.Extensions;

namespace TableGenerator.Api.Routing
{
    /// <summary>
    /// Convert [action] naming convention to kebab-case.
    /// </summary>
    /// <example>
    /// For example:
    /// <code>
    ///     [Route("api/[controller]/[action]")]
    ///     public class AdminNotificationController : ControllerBase
    ///     {
    ///         [HttpGet]
    ///         public IActionResult DoWork()
    ///         {
    ///         }
    ///     }
    /// </code>
    /// 
    /// The final endpoint will be 'api/<controller>/do-work' instead of 'api/<controller>/DoWork'
    /// </example>
    public class ActionRoutingConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            foreach (var selector in action.Selectors)
            {
                if (selector.AttributeRouteModel != null)
                {
                    selector.AttributeRouteModel.Template = selector.AttributeRouteModel.Template.ToKebabCase();
                }
            }
        }
    }
}
