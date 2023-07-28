namespace Aquality.Selenium.Template.Utilities
{
    public static class PathUtil
    {
        private const string RelativeImagePath = @"..\..\..\Resources\images\avatar.jpg";

        public static string GetAbsolutePath(string relativePath)
        {
            string currentDirectory = Environment.CurrentDirectory;
            string absolutePath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));
            return absolutePath;
        }

        public static string GetAvatarImagePath()
        {
            return GetAbsolutePath(RelativeImagePath);
        }
    }
}
