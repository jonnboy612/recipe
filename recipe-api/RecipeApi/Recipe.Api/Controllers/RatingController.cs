namespace Recipe.Api.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Recipe.Data.Models;
using Recipe.Services;

[ApiController]
[Route("v1/[controller]")]
public class RatingController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    private readonly IRatingService _ratingService;

    private readonly IMapper _mapper;

    public RatingController(ILogger<UserController> logger,
                        IMapper mapper,
                        IRatingService ratingService)
    {
        _logger = logger;
        _mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
        _ratingService = ratingService ?? throw new NullReferenceException(nameof(ratingService));

        Console.WriteLine(_ratingService);
    }

    [HttpGet("")]
    public IActionResult Get(bool includeDetail = false, int page = 1, int limit = 10)
    {
        var rating = _ratingService.Get(includeDetail);

        return Ok(_mapper.Map<List<RatingViewModel>>(rating));
    }
    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var rating = _ratingService.Get(id);

        return Ok(_mapper.Map<RecipeViewModel>(rating));
    }

    [HttpPost("")]
    public IActionResult Create(RatingViewModel rating)
    {
        
        if (rating.rating > 0 || rating.rating < 5)
        {
            
            var ratingModel = _mapper.Map<Rating>(rating);
            var savedRating = _ratingService.Create(ratingModel);
            
            var avgList = new List<int>(){rating.ratingAvg};
            double avgRating = avgList.Average();

            //update 
            var savedAvg = _ratingService.Update();
     
            return Ok(_mapper.Map<RatingViewModel>(savedRating));
        }
        else
        {
            throw new ArgumentOutOfRangeException($"{rating} is not valid");
        }

    }
}