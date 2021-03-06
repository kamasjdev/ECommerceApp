﻿using AutoMapper;
using ECommerceApp.Application.Mapping;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ECommerceApp.Application.ViewModels.User
{
    public class NewUserVm : IMapFrom<IdentityUser>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public List<string> UserRoles { get; set; }
        public List<RoleVm> Roles { get; set; }

        public string PasswordToChange { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentityUser, NewUserVm>();
        }
    }
    public class NewUserValidation : AbstractValidator<NewUserVm>
    {
        public NewUserValidation()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Nazwa użytkownika nie może być pusta")
                                    .EmailAddress().WithMessage("Proszę podać email");
            RuleFor(x => x.Email).NotNull().WithMessage("Email nie może być pusty")
                                 .EmailAddress().WithMessage("Proszę podać email");
        }
    }
}
