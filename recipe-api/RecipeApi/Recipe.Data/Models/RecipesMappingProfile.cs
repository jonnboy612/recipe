namespace Recipe.Data.Models;

using AutoMapper;

public class RecipeMappingProfile : Profile
{
    public RecipeMappingProfile()
    {
        CreateMap<RecipeDataModel, Recipe>();
        CreateMap<Recipe, RecipeDataModel>();

        CreateMap<RecipeViewModel, Recipe>();
        CreateMap<Recipe, RecipeViewModel>();

        CreateMap<IngredientDataModel, Ingredient>();
        CreateMap<Ingredient, IngredientDataModel>();

        CreateMap<IngredientViewModel, Ingredient>();
        CreateMap<Ingredient, IngredientViewModel>();

        CreateMap<StepDataModel, Step>();
        CreateMap<Step, StepDataModel>();

        CreateMap<StepViewModel, Step>();
        CreateMap<Step, StepViewModel>();
    }
}