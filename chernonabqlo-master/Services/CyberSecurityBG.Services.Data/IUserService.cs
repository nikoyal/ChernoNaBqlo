using System.Collections.Generic;

namespace CyberSecurityBG.Services.Data
{
    public interface IUserService
    {
        T GetUserByUsername<T>(string username);

        string GetProfilePicture(string username);

        IEnumerable<T> GetAll<T>(string name);
    }
}
