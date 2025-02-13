using AutoMapper;
using Data.Entities;

public class MyMappingProfile : Profile
{
    public MyMappingProfile()
    {
        CreateMap<Category, CategoryModel>().ReverseMap();

        CreateMap<Product, ProductModel>().ReverseMap();
    }
}