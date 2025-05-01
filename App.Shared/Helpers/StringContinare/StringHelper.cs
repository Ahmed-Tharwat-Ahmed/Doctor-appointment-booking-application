namespace App.Shared.Helpers.StringContinare
{
    public static class StringHelper
    {
        public static string ToUniformedPath(this string path)
        {
            return path.Replace("\\", "/");
        }
    }
}
