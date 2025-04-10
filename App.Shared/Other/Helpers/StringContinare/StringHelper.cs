namespace App.Shared.Other.Helpers
{
    public static class StringHelper
    {
        public static string ToUniformedPath(this string path)
        {
            return path.Replace("\\", "/");
        }
    }
}
