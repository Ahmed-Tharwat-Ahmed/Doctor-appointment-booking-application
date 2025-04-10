using App.Shared.Other.Constants;
using Newtonsoft.Json;

namespace App.Shared.Other.Helpers.LocalizationContinare
{
    public static class LocalizerHelper
    {
        public static string? LocalizeMessage(string key, string lang, string? path = null)
        {
            if (string.IsNullOrEmpty(path))
                path = DefaultPaths.GeneralLocalizationPath;

            return Localize(path, key, lang);
        }

        public static string LocalizeValidation(string key, string lang, string? path = null, params object[] inputs)
        {
            if (string.IsNullOrEmpty(path))
                path = DefaultPaths.ValidationLocalizationPath;

            var message = Localize(path, key, lang);
            if (message == null)
                return string.Empty;

            return string.Format(message, inputs);
        }

        private static string? Localize(string path, string key, string lang)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;

            var json = File.ReadAllText(path);
            List<LocalizerModel>? localization = JsonConvert.DeserializeObject<List<LocalizerModel>>(json);

            if (localization == null || !localization.Any())
                return string.Empty;

            var target = localization.FirstOrDefault(x => x.key == key);
            if (target != null)
            {
                return lang == "ar" ? target.ValueAr : target.ValueEn;
            }
            return key;
        }
    }


}
