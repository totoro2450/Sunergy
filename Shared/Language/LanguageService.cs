using BlazorApp.Shared.Language;
using System;
using System.Collections.Generic;

namespace BlazorApp.Shared.Laguage
{
    public class LanguageService
    {
        public string CurrentLanguageTag { get; set; } = "English";
        public Dictionary<LanguageKeys, string> CurrentLanguage { get; set; } = new Dictionary<LanguageKeys, string>();
        public Dictionary<LanguageKeys, string> DefaulLanguage { get; set; } = LanguageData.English;

        public LanguageService(string languageTag = "English")
        {
            CurrentLanguageTag = languageTag;
            SetLaguage(CurrentLanguageTag);
        }

        public void SetLaguage(string laguage)
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

        public string GetTraslation(LanguageKeys key)
        {
            if (CurrentLanguage.ContainsKey(key)) 
                return CurrentLanguage[key];
            if (DefaulLanguage.ContainsKey(key)) 
                return DefaulLanguage[key];

            return nameof(key);
        }

        public string GetTraslation(string key)
        {
            if (Enum.TryParse<LanguageKeys>(key, out var result))
                return GetTraslation(result);

            return key;
        }
    }
}
