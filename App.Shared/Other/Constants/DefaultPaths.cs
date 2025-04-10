using App.Shared.Other.Helpers;

namespace App.Shared.Other.Constants
{
    internal class DefaultPaths
    {
        public readonly static string DomainUrl = "https://localhost:7293/";
        //public readonly static string DomainUrl = "";


        public static string GeneralLocalizationPath => Path.Combine(Hosting.WebRootPath, "Localization", "general-localization.json").ToUniformedPath();
        public static string ValidationLocalizationPath => Path.Combine(Hosting.WebRootPath, "Localization", "fluent-validation-localization.json").ToUniformedPath();

    }
}
