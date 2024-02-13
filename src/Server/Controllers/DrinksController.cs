using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactBffProxy.Shared;

namespace ReactBffProxy.Server.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class DrinksController : ControllerBase
{
    private readonly DrinksService _drinksService;

    public DrinksController(DrinksService drinksService)
    {
        _drinksService = drinksService;
    }

    [HttpGet]
    public ActionResult<IList<DrinkModel>> GetAll()
    {
        var drinks = _drinksService.GetAll();
        return Ok(drinks);
    }
}
