using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BlogTemplate.Models;
using System.Xml.Linq;

namespace BlogTemplate.Data
{
    public class BlogUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
    {
        const string StorageFolder = "UserFiles";
        private IFileSystem _fileSystem;
        public BlogUserStore(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
            _fileSystem.CreateDirectory(StorageFolder);
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            //XDocument doc = new XDocument();
            //XElement rootNode = new XElement("User");

            //rootNode.Add(new XElement("UserName", user.UserName));

            //doc.Add(rootNode);
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            ApplicationUser foundUser = new ApplicationUser();
            foundUser.UserName = normalizedUserName;
            return Task.Run(() => foundUser);
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            string expectedFilePath = $"{StorageFolder}\\{user.UserName}.xml";
            if (_fileSystem.FileExists(expectedFilePath))
            {
                return null;
            }

            return Task.Run(() => "");
            }

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.Run(() => user.UserName);
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.Run(()=> user.UserName);
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            return Task.Run(() => "");
            //throw new NotImplementedException();
        }

        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
