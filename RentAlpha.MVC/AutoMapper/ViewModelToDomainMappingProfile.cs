using AutoMapper;
using RentAlpha.Domain.Entities;
using RentAlpha.MVC.ViewModels;

namespace RentAlpha.MVC.AutoMapper
{
  public class ViewModelToDomainMappingProfile : Profile
  {
    public override string ProfileName
    {
      get { return "DomainToViewModelMappings"; }
    }

    protected override void Configure()
    {
      Mapper.CreateMap<Friend, FriendViewModel>();
      Mapper.CreateMap<Game, GameViewModel>();
    }
  }
}