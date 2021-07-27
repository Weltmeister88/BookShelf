using BookShelf.Core.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookShelf.Web.Filters
{
    public class SaveChangesActionFilter : IActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaveChangesActionFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null && !context.Canceled)
            {
                _unitOfWork.SaveChanges();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}