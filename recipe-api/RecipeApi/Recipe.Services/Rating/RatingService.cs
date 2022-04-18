namespace Recipe.Services;

using System;
using System.Linq;
using AutoMapper;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Recipe.Data.Models;
using Recipe.Data.DataAccess;

public class RatingService : IRatingService
{
    private readonly IDataService _dataService;

    private readonly IMapper _mapper;

    public RatingService([NotNull] IDataService dataService,
                         [NotNull] IMapper mapper)
    {
        _dataService = dataService ?? throw new ArgumentException(nameof(dataService));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    public Rating Get(long id)
    {
        if (id < 1)
        {
            throw new ArgumentOutOfRangeException($"{id}");
        }

        var ratingDataModel= _dataService.Get<RatingDataModel>()
                                         .Where(x => x.Id == id && !x.IsDeleted);

        ratingDataModel = ratingDataModel.Include("Comments");

        return _mapper.Map<Rating>(ratingDataModel.FirstOrDefault());
    }
    public List<Rating> Get(bool includeDetail = false)
    {
  
        var ratingDataModel = _dataService.Get<RatingDataModel>()
                                          .Where(x => !x.IsDeleted);

        if (includeDetail)
        {
            ratingDataModel = ratingDataModel.Include("Comments");
        }
        
        var ratingModels = _mapper.Map<List<Rating>>(ratingDataModel);
        return ratingModels;
    }

    public Rating Create(Rating rating)
    {
        var ratingDataModel = _mapper.Map<RatingDataModel>(rating); 
        _dataService.Insert(ratingDataModel);
        _dataService.Save();
        

        return _mapper.Map<Rating>(ratingDataModel);
    }

    public Rating Update(Rating rating)
    {
        var ratingDataModel = _dataService.Get<RatingDataModel>(rating.ratingAvg);
        // if (ratingDataModel == null)
        // {
        //     throw new NullReferenceException($"no rating found{rating.Id}");
        // }
        
        ratingDataModel = _mapper.Map(rating, ratingDataModel);
        _dataService.Save();

        return _mapper.Map<Rating>(ratingDataModel);
    }
}
