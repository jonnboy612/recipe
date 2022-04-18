namespace Recipe.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]

public class UserDataModel : EntityDataModel
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}