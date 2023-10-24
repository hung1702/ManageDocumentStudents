using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc
{
    public static class AuthExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                var userIdClaim = user.FindFirst(x => x.Type == "sub" || x.Type.ToLower() == "id");
                if (userIdClaim == default)
                    throw new Exception("No userId claim");
                if (Guid.TryParse(userIdClaim.Value, out Guid userId))
                {
                    return userId;
                }
                throw new Exception("Not valid userId");
            }
            throw new Exception("Not authenicated");
        }

        public static Guid GetLocationId(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                //staff do not have locations
                if (user.IsInRole("staff"))
                    return default;

                var locationIdClaim = user.FindFirst(x => x.Type.ToLower() == "location_id");
                if (locationIdClaim == default)
                    throw new Exception("No locationId claim");
                if (Guid.TryParse(locationIdClaim.Value, out Guid locationId))
                {
                    return locationId;
                }
                throw new Exception("Not valid locationId");
            }
            throw new Exception("Not authenicated");
        }

        public static List<Guid> GetStaffLocationIds(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                if (!user.IsInRole("staff"))
                    return default;

                var locationIdClaim = user.FindFirst(x => x.Type.ToLower() == "location_id");
                if (locationIdClaim == default)
                    throw new Exception("No locationId claim");
                var locationIds = JsonConvert.DeserializeObject<List<Guid>>(locationIdClaim.Value);
                return locationIds;
                throw new Exception("Not valid locationId");
            }
            throw new Exception("Not authenicated");
        }

        public static string GetLanguage(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                var language = user.FindFirst(x => x.Type.ToLower() == "lang");
                if (language == default)
                    return string.Empty;

                return language.Value;
            }

            throw new Exception("Not authenicated");
        }

        public static string GetLocale(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                var locale = user.FindFirst(x => x.Type.ToLower() == "locale");
                if (locale == default)
                    throw new Exception("No locale claim");

                return locale.Value;
            }

            throw new Exception("Not authenicated");
        }
    }
}
