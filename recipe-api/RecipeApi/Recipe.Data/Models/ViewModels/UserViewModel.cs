namespace Recipe.Data.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class UserViewModel : EntityDataModel
{
    public string? Username { get; set; }

    public string? Password { get; set; }
}