namespace Recipe.Services;

using System;
using System.Linq;
using AutoMapper;
using  JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Recipe.Data.Models;
using Recipe.Data.DataAccess;

public class UserService : IUserService
{
    private readonly IDataService _dataService;

    /// <summary>
    /// The auto mapper.
    /// </summary>
    private readonly IMapper _mapper;

    public UserService([NotNull] IDataService dataService,
                        [NotNull] IMapper mapper)
    {
        _dataService = dataService ?? throw new ArgumentException(nameof(dataService));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    public User Get(string username)
    {
        var userDataModel = _dataService.Get<UserDataModel>()
                                        .Where(x => x.Username == username);
        
        return _mapper.Map<User>(userDataModel.FirstOrDefault());
    }

    public List<User> Get(bool includeDetail = false)
    {
        var userDataModel = _dataService.Get<UserDataModel>()
                                        .FirstOrDefault(x => !x.IsDeleted);
        
        var userModels = _mapper.Map<List<User>>(userDataModel);
        return userModels;
    }

    public User Create(User user)
    {
        var userDataModel = _mapper.Map<UserDataModel>(user);
        _dataService.Insert(userDataModel);
        _dataService.Save();

        return _mapper.Map<User>(userDataModel);
    }

    public User Update(User user)
    {
        var userDataModel = _dataService.Get<UserDataModel>();
        if (userDataModel == null)
        {
            throw new NullReferenceException($"user not found{user.Username}");
        }

        userDataModel = _mapper.Map(user, userDataModel);
        _dataService.Save();

        return _mapper.Map<User>(userDataModel);
    }

    public bool Delete(string username)
    {
        var userDataModel = _dataService.Get<UserDataModel>()
                                        .Where(userDataModel => userDataModel.Username == username)
                                        .First();
        if (userDataModel == null)
        {
            throw new NullReferenceException($"user not found{username}");
        }

        userDataModel.IsDeleted = true;
        _dataService.Save();

        return true;
    }
}