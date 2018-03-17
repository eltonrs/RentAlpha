﻿using AutoMapper;

namespace RentAlpha.MVC.AutoMapper
{
  public class AutoMapperConfig
  {
    public static void RegisterMappings()
    {
      Mapper.Initialize(cfg =>
      {
        cfg.AddProfile<DomainToViewModelMappingProfile>();
        cfg.AddProfile<ViewModelToDomainMappingProfile>();
      });
    }
  }
}