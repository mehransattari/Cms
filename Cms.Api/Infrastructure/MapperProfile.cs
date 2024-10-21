using AutoMapper;
using Cms.Api.ViewModels;
using Cms.Application.Users.AddAddress;
namespace Cms.Api.Infrastructure;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AddUserAddressCommand, AddUserAddressViewModel>().ReverseMap();
    }
}