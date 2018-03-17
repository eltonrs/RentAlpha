using AutoMapper;
using RentAlpha.Domain.Entities;
using RentAlpha.MVC.ViewModels;

namespace RentAlpha.MVC.AutoMapper
{
  public class DomainToViewModelMappingProfile : Profile
  {
    public override string ProfileName
    {
      get { return "ViewModelToDomainMappings"; }
    }

    protected override void Configure()
    {
      Mapper.CreateMap<FriendViewModel, Friend>();
      Mapper.CreateMap<GameViewModel, Game>();
    }
  }
}