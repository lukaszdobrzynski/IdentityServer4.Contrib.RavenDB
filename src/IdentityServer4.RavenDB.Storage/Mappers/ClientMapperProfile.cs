﻿using System.Collections.Generic;
using AutoMapper;
using IdentityServer4.Models;

using Client = IdentityServer4.Models.Client;
using Secret = IdentityServer4.Models.Secret;

namespace IdentityServer4.RavenDB.Storage.Mappers
{
    internal class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<Entities.Client, Client>()
                .ForMember(dest => dest.ProtocolType, opt => opt.Condition(srs => srs != null))
                .ForMember(x => x.AllowedIdentityTokenSigningAlgorithms,
                    opt => opt.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter,
                        x => x.AllowedIdentityTokenSigningAlgorithms))
                .ReverseMap()
                .ForMember(x => x.AllowedIdentityTokenSigningAlgorithms,
                    opt => opt.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter,
                        x => x.AllowedIdentityTokenSigningAlgorithms));

            CreateMap<Entities.ClientClaim, ClientClaim>(MemberList.None)
                .ReverseMap();

            CreateMap<Entities.Secret, Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();

            CreateMap<Entities.Property, KeyValuePair<string, string>>()
                .ReverseMap();
        }
    }
}
