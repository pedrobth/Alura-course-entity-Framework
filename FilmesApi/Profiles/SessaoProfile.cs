using System;
using AutoMapper;
using FilmesApi.Models;
using FilmesApi.Data.Dtos.Sessao;

namespace FilmesApi.Profiles
{
    public class SessaoProfile : Profile
    {

        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto =>
                    dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao *(-1))
                    )
                )
            ;
        }
    }
}
