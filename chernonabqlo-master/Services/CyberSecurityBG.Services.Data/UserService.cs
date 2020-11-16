using CyberSecurityBG.Data.Common.Repositories;
using CyberSecurityBG.Data.Models;
using CyberSecurityBG.Services.Mapping;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyberSecurityBG.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepository, UserManager<ApplicationUser> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        public string GetProfilePicture(string username)
        {
            lock (this.userRepository)
            {
                var imageurl = this.userRepository.All().Where(x => x.UserName == username).FirstOrDefault().ImageUrl;
                return imageurl;
            }
        }

        public T GetUserByUsername<T>(string username)
        {
            lock (this.userRepository)
            {
                var user = this.userRepository.All().Where(x => x.UserName == username).To<T>().FirstOrDefault();
                return user;
            }
        }

        public IEnumerable<T> GetAll<T>(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                IQueryable<ApplicationUser> query = this.userRepository.All().OrderBy(x => x.UserName);
                return query.To<T>().ToList();
            }
            else
            {
                IQueryable<ApplicationUser> query = this.userRepository.All().Where(x => x.UserName == name);
                return query.To<T>().ToList();
            }
        }
    }
}
