using AutoMapper;
using CinemasAPI.Entities;
using CinemasAPI.Models;

namespace CinemasAPI
{
    public class CinemaMappingProfile : Profile
    {
        public CinemaMappingProfile()
        {
            CreateMap<Cinema, CinemaClient>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Film, FilmClient>();

            CreateMap<CreateCinemaClient, Cinema>()
                .ForMember(c => c.Address, c => c.MapFrom(client => new Address()
                    { City = client.City, Street = client.Street, PostalCode = client.PostalCode }));
        }
    }
}
