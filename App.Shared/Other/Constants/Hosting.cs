using Microsoft.AspNetCore.Hosting;

namespace App.Shared.Other.Constants
{
    internal static class Hosting
    {
        public static IWebHostEnvironment Environment { get; set; }
        public static string EnvironmentName => Environment.EnvironmentName;
        public static string ContentRootPath => Environment.ContentRootPath;
        public static string WebRootPath => Environment.WebRootPath;
    }
}
