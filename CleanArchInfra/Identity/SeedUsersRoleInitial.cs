using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Identity
{
    public class SeedUsersRoleInitial : ISeedUserRoleInitial
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUsersRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (_userManager.FindByEmailAsync("usuario@teste").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "teste@teste";
                user.PhoneNumber = "19999138267";
                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = true;
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.NormalizedEmail = "TESTE@teste";
                user.Email = "teste@teste";
                user.NormalizedUserName = "TESTE@teste";

                IdentityResult result = _userManager.CreateAsync(user, "rsrsrs@rs").Result;

                if (result.Succeeded) _userManager.AddToRoleAsync(user, "User").Wait();
            }

            if (_userManager.FindByEmailAsync("admin@teste").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@teste";
                user.PhoneNumber = "199991382677";
                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = true;
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.NormalizedEmail = "ADMIN@teste";
                user.Email = "admin@teste";
                user.NormalizedUserName = "ADMIN@teste";

                IdentityResult result = _userManager.CreateAsync(user, "rsrsrs@rs").Result;

                if (result.Succeeded) _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }

        public void SeedUsers()
        {
            if (!_roleManager.RoleExistsAsync("Users").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
