using ManageStudents.API.Application.Model.Enums;
using ManageStudents.API.Application.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ManageStudents.API.Abstraction;

namespace ManageStudents.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IGiangVienService _giangVienService;
        private readonly ISinhVienService _sinhVienService;
        public UserController(
            IUserService userService,
            IGiangVienService giangVienService,
            ISinhVienService sinhVienService)
        {
            _userService = userService;
            _giangVienService = giangVienService;
            _sinhVienService = sinhVienService;
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Route("category/{categoryId}/list")]
        //public async Task<ActionResult<CategoryPagingModel>> GetInCategory([FromRoute] Guid categoryId, [FromQuery] int page = 1, [FromQuery] int items = 10, [FromQuery] string search = "", [FromQuery] SubcategoryStatus status = SubcategoryStatus.Active,
        //    [FromQuery] CategoryColumns sort = CategoryColumns.CategoryName,
        //    [FromQuery] SortDirection direction = SortDirection.Ascending)
        //{
        //    var userId = User.GetUserId();
        //    _logger.LogInformation("---- User: {UserId} requested list of all SubCatgories in category: {categoryId} --- page: {page} --- search term: {search}", categoryId, userId, page, search);
        //    if (page < 1)
        //        page = 1;
        //    if (items < 0)
        //        items = 10;
        //    var result = await _requestService.GetSubCategories(categoryId, page, items, search, status, sort, direction);
        //    if (result == default(PagingModel<CategoryModel>))
        //        return NotFound();
        //    return Ok(result);
        //}

    }
}
