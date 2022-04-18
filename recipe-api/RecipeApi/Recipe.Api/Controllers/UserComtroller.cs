namespace Recipe.Api.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipe.Data.Models;
using Recipe.Services;

[ApiController]
[Route("v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    private readonly IUserService _userService;

    private readonly IMapper _mapper;

    public UserController(ILogger<UserController> logger,
                        IMapper mapper,
                        IUserService userService)
    {
        _logger = logger;
        _mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
        _userService = userService ?? throw new NullReferenceException(nameof(userService));

        Console.WriteLine(_userService);
    }

    [HttpGet("")]
    public IActionResult Get(bool includeDetail = false, int page = 1, int limit = 10)
    {
        var users = _userService.Get(includeDetail);

        return Ok(_mapper.Map<List<UserViewModel>>(users));
    }

    [HttpGet("{username}")]
    public IActionResult Get(string username)
    {
        var usernames = _userService.Get(username);

        return Ok(_mapper.Map<List<UserViewModel>>(usernames));
    }
    [HttpPost("")]
    public IActionResult Create(UserViewModel user)
    {
        var userModel = _mapper.Map<User>(user);
        var savedUser = _userService.Create(userModel);

        return Ok(_mapper.Map<UserViewModel>(savedUser));
    }
    
    [HttpPut("")]
    public IActionResult Update(UserViewModel user)
    {
        if (user.Username == null)
        {
            throw new NullReferenceException($"{user} found");
        }
        var userModel = _userService.Get(user.Username);
        userModel = _mapper.Map(user, userModel);

        var saveUser = _userService.Update(userModel);

        return Ok(_mapper.Map<UserViewModel>(saveUser));
    }
    
    [HttpDelete("")]
    public IActionResult Delete(string username)
    {
        _userService.Delete(username);
        return Ok();
    }
}