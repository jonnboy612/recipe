namespace Recipe.Services;

using Recipe.Data.Models;

public interface IUserService
{
    User Get(string username);

    List<User> Get(bool includeDetail = false);

    User Create(User user);

    User Update(User user);

    bool Delete(string username);
}