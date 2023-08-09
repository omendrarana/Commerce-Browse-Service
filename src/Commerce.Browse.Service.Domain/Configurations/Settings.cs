
namespace Commerce.Browse.Service.Domain.Configurations
{
    public static class Settings
    {
        public static string ProjectKey { get; private set; }


        /// <summary>
        /// Set Current project key
        /// </summary>
        /// <param name="projectKey"></param>
        public static void SetCurrentProjectKey(string projectKey)
        {
            ProjectKey = projectKey;
        }


    }
}
