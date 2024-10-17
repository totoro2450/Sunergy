using System;
using System.Collections.Generic;

namespace BlazorApp.Shared.Language
{
    public class LanguageService
    {
        public string CurrentLanguageTag { get; set; } = "English";
        public Dictionary<LanguageKeys, string> CurrentLanguage { get; set; } = new Dictionary<LanguageKeys, string>();
        public Dictionary<LanguageKeys, string> DefaulLanguage { get; set; } = LanguageData.English;

        public LanguageService(string languageTag = "English")
        {
            CurrentLanguageTag = languageTag;
            SetLanguage(CurrentLanguageTag);
        }

        public void SetLanguage(string laguage)
        {
            switch (laguage)
            {
                case "Ukrainian":
                    CurrentLanguage = LanguageData.Ukrainian;
                    break;
                case "English":
                    CurrentLanguage = LanguageData.English;
                    break;
                default:
                    CurrentLanguage = LanguageData.English;
                    break;
            }
        }

        public string GetTranslation(LanguageKeys key)
        {
            if (CurrentLanguage.ContainsKey(key)) 
                return CurrentLanguage[key];
            if (DefaulLanguage.ContainsKey(key)) 
                return DefaulLanguage[key];

            return nameof(key);
        }

        public string GetTranslation(string key)
        {
            if (Enum.TryParse<LanguageKeys>(key, out var result))
                return GetTranslation(result);

            return key;
        }
    }
}
