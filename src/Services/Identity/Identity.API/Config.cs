using IdentityServer4.Models;

namespace Identity.API
{
    public class Config
    {
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
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("catalogAPI", "Catalog API")
        };

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {

        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {

        };
    }
}
