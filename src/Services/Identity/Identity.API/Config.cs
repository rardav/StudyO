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
                ClientId = "webSpa",
                ClientName = "Web SPA",

                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                AllowRememberConsent = false,
                RedirectUris = new List<string>()
                {
                    $"{_configuration.GetSection("ApiSettings").GetSection("ClientUri").Value}/auth-callback"
                },
                PostLogoutRedirectUris = new List<string>()
                {
                    $"{_configuration.GetSection("ApiSettings").GetSection("ClientUri").Value}"
                },
                ClientSecrets = new List<Secret>()
                {
                    new Secret("secret".Sha256())
                },
                AllowedCorsOrigins = new List<string>()
                {
                    $"{_configuration.GetSection("ApiSettings").GetSection("ClientUri").Value}/auth/login"
                },
                AllowedScopes = new List<string>()
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "catalogApi"
                },
                AllowAccessTokensViaBrowser = true
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
                Username = "student1",
                Password = "password",
                Claims = new List<Claim>
                {
                    new Claim("role", "student")
                }
            },
            new TestUser
            {
                SubjectId = "2",
                Username = "creator1",
                Password = "password",
                Claims = new List<Claim>
                {
                    new Claim("role", "creator")
                }
            },
            new TestUser
            {
                SubjectId = "3",
                Username = "admin1",
                Password = "password",
                Claims = new List<Claim>
                {
                    new Claim("role", "admin")
                }
            }
        };
    }
}
