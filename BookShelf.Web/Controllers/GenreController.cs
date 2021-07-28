using System;
using System.Collections.Generic;
using BookShelf.Core.Models;
using BookShelf.Web.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        [HttpGet]
        [ResponseCache(Duration = 600, Location = ResponseCacheLocation.Client)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SelectItemDto<int>>))]
        public ActionResult<IEnumerable<SelectItemDto<int>>> Get()
        {
            return Ok(GetEnumValues(typeof(Genre)));
        }

        private static IEnumerable<SelectItemDto<int>> GetEnumValues(Type enumType)
        {
            foreach (int value in Enum.GetValues(enumType))
            {
                yield return new SelectItemDto<int>
                {
                    Id = value,
                    Description = Enum.GetName(enumType, value)
                };
            }
        }
    }
}