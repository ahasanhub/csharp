using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using IdentityModel;
using IdentityServer4.Validation;
using OAuth.IdentityServer4.Serv.Models;

namespace OAuth.IdentityServer4.Serv.Configuration
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            using (IDbConnection db=new SqlConnection(@"server=SHAPLA-PC\SQLEXPRESS;database=CitiesInfo;UID=sa;PWD=mzaman9"))
            {
                var user = db.Query<User>("select * from Users where UserName=@UserName and Password=@Pass",new {UserName=context.UserName,Pass=context.Password}).SingleOrDefault<User>();
                if (user==null)
                {
                    context.Result=new GrantValidationResult(OidcConstants.TokenErrors.InvalidRequest,"Invalid user name or password.");
                    return Task.FromResult(0);
                }
                context.Result = new GrantValidationResult(user.UserId.ToString(), "password.");
                return Task.FromResult(0);
            }
        }
    }
}
