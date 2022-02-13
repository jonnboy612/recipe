namespace Recipe.Api.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipe.Data.Models;
using Recipe.Services;

[ApiController]
[Route("v1/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly ILogger<RecipesController> _logger;

    private readonly IRecipeService _recipeService;

    private readonly IMapper _mapper;

    public RecipesController(ILogger<RecipesController> logger,
                            IMapper mapper, 
                            IRecipeService recipeService)
    {
        _logger = logger;
        _mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
        _recipeService = recipeService ?? throw new NullReferenceException(nameof(recipeService));

        Console.WriteLine(_recipeService);
    }

    [HttpGet("")]
    public IActionResult Get(bool includeDetail = false, int page = 1, int limit = 10)
    {
        var recipes = _recipeService.Get(includeDetail);

        return Ok(_mapper.Map<List<RecipeViewModel>>(recipes));
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var recipe = _recipeService.Get(id);

        return Ok(_mapper.Map<RecipeViewModel>(recipe));
    }

    [HttpPost("")]
    public IActionResult Create(RecipeViewModel recipe)
    {
        var recipeModel = _mapper.Map<Recipe>(recipe);
        var savedRecipe = _recipeService.Create(recipeModel);

        return Ok(_mapper.Map<RecipeViewModel>(savedRecipe));
    }

    [HttpPut("")]
    public IActionResult Update(RecipeViewModel recipe)
    {
        var recipeModel = _recipeService.Get(recipe.Id);
        recipeModel = _mapper.Map(recipe, recipeModel);

        var savedRecipe = _recipeService.Update(recipeModel);
        return Ok(_mapper.Map<RecipeViewModel>(savedRecipe));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _recipeService.Delete(id);
        return Ok();
    }
}