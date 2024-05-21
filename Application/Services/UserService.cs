using Application.IRepositories;
using Application.IServices;
using Application.ResponseModels;
using Application.ViewModels.AccountViewModels;
using AutoMapper;
using Domain.Enums.AccountEnums;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Types;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<Account> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Account> _userManager;
        private readonly IMapper _mapper;

        public UserService(IConfiguration configuration,
            UserManager<Account> userManager,
            SignInManager<Account> signInManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> SignUpAsync(AccountSignUpModel model)
        {
            var user = new Account
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Birthday = model.BirthDate,
                Status = "Is Active",
                UserName = model.AccountEmail,
                Sex = (int)model.Sex,
                Email = model.AccountEmail,
                PhoneNumber = model.AccountPhone,
                CreateAt = DateTime.Now,
            };
            var result = await _userManager.CreateAsync(user, model.AccountPassword);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(RoleAccountModel.Customer.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleAccountModel.Customer.ToString()));
                }
                if (await _roleManager.RoleExistsAsync(RoleAccountModel.Customer.ToString()))
                {
                    await _userManager.AddToRoleAsync(user, RoleAccountModel.Customer.ToString());
                }
                return true;
            }
            return false;
        }
    }
}