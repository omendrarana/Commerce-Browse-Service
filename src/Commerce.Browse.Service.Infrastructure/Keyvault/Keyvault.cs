using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Commerce.Browse.Service.Infrastructure.Keyvault
{
    public class Keyvault
    {
        public async Task<string> GetKeyVaultDetails(string secretName)
        {
            var kvUri = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            var secret = await client.GetSecretAsync(secretName);
            return secret.Value.Value;
        }
    }
}
