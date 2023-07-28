using Aquality.Selenium.Core.Utilities;

namespace Aquality.Selenium.Template.Utilities
{
    public class JsonReader
    {
        public static string UseTestData(string data)
        {
            JsonSettingsFile testData = new JsonSettingsFile(@"TestData.json");
            return testData.GetValue<string>(data);
        }
        public static int GetRequiredInterests()
        {
            string maxInterestsRequiredStr = UseTestData("RequiredInterests");
            return int.Parse(maxInterestsRequiredStr);
        }
        public static string GetBaseUrl()
        {
            string baseUrl = UseTestData("URL");
            return baseUrl;
        }
    }
}
