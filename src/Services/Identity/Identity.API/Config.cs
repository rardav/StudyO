using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace Identity.API
{
    public class Config
    {
        private static IConfiguration _configuration { get; set; }

        public Config(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId = "catalogClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "catalogAPI" }
            },
            new Client
            {
                ClientId = "web_spa",
                ClientName = "Web SPA",
                AllowedGrantTypes = GrantTypes.Code,
                AllowRememberConsent = false,
                RedirectUris = new List<string>()
                {
                    $"{_configuration.GetSection("ApiSettings").GetSection("ClientUri").Value}/login"
                },
                PostLogoutRedirectUris = new List<string>()
                {
                    $"{_configuration.GetSection("ApiSettings").GetSection("ClientUri").Value}/login"
                },
                ClientSecrets = new List<Secret>()
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = new List<string>()
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("catalogAPI", "Catalog API")
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {

        };

        public static List<TestUser> TestUsers => new List<TestUser>()
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "test",
                Password = "test",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.GivenName, "test"),
                    new Claim(JwtClaimTypes.FamilyName, "testescu"),
                }
            }
        };
    }
}
