namespace Recipe.Services;

using System;
using System.Linq;
using AutoMapper;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Recipe.Data.Models;
using Recipe.Data.DataAccess;

public class RecipeService : IRecipeService
{

    private readonly IDataService _dataService;

    /// <summary>
    /// The auto mapper.
    /// </summary>
    private readonly IMapper _mapper;

    public RecipeService([NotNull] IDataService dataService,
                         [NotNull] IMapper mapper)
    {
        _dataService = dataService ?? throw new ArgumentException(nameof(dataService));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    public Recipe Get(long id)
    {
        if (id < 1) 
        {
            throw new ArgumentOutOfRangeException($"{id}");
        }

        var recipeDataModel = _dataService.Get<RecipeDataModel>()
                                          .Where(x => x.Id == id && !x.IsDeleted);

        recipeDataModel = recipeDataModel.Include("Ingredients")
                                         .Include("Steps");
        return _mapper.Map<Recipe>(recipeDataModel.FirstOrDefault());
    }

    public List<Recipe> Get(bool includeDetail = false)
    {
        var recipeDataModels = _dataService.Get<RecipeDataModel>()
                                           .Where(x => !x.IsDeleted);

        if (includeDetail)
        {
            recipeDataModels = recipeDataModels.Include("Ingredients")
                                               .Include("Steps");
        }

        var recipeModels = _mapper.Map<List<Recipe>>(recipeDataModels);
        return recipeModels;
    }

    public Recipe Create(Recipe recipe)
    {
        var recipeDataModel = _mapper.Map<RecipeDataModel>(recipe);
        _dataService.Insert(recipeDataModel);
        _dataService.Save();

        return _mapper.Map<Recipe>(recipeDataModel);
    }

    public Recipe Update(Recipe recipe)
    {
        var recipeDataModel =_dataService.GetById<long, RecipeDataModel>(recipe.Id);
        if (recipeDataModel == null)
        {
            throw new NullReferenceException($"No recipe could be found using ID {recipe.Id}");
        }
        recipeDataModel = _mapper.Map(recipe, recipeDataModel);
        _dataService.Save();

        return _mapper.Map<Recipe>(recipeDataModel);
    }

    public bool Delete(long id)
    {
        var recipeDataModel =_dataService.GetById<long, RecipeDataModel>(id);
        if (recipeDataModel == null)
        {
            throw new NullReferenceException($"No recipe could be found using ID {id}");
        }

        recipeDataModel.IsDeleted = true;
        _dataService.Save();

        return true;
    }
}
