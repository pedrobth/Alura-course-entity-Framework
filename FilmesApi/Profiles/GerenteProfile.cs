﻿using System;
using System.Linq;
using AutoMapper;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                    .MapFrom(gerente => gerente.Cinemas.Select(
                        cine => new
                        {
                            cine.Id,
                            cine.Nome,
                            cine.Endereco
                        }
                    ))
                );
        }
    }
}
