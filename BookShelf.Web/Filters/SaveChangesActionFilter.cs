using System.Linq;
using System.Net.Http;
using BookShelf.Core.Repositories;
using BookShelf.Web.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookShelf.Web.Filters
{
    public class SaveChangesActionFilter : IActionFilter
    {
        private static readonly HttpMethod[] UpdatingHttpMethods =
        {
            HttpMethod.Post,
            HttpMethod.Put,
            HttpMethod.Patch,
            HttpMethod.Delete
        };

        private readonly IUnitOfWork _unitOfWork;

        public SaveChangesActionFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (ShouldSaveChanges(context))
            {
                _unitOfWork.SaveChanges();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        private static bool ShouldSaveChanges(ActionExecutedContext context)
        {
            return context.Controller is IEntityController
                   && context.Exception == null && !context.Canceled
                   && UpdatingHttpMethods.Contains(new HttpMethod(context.HttpContext.Request.Method));
        }
    }
}