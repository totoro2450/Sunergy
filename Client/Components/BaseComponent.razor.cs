using BlazorApp.Shared.Language;

using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Components
{
    public partial class BaseComponent : ComponentBase
    {
        [Inject]
        protected LanguageService LanguageService { get; set; }

        protected string GetTranslation(LanguageKeys key)
        {
            return LanguageService.GetTranslation(key);
        }

        protected string GetTranslation(string key)
        {
            return LanguageService.GetTranslation(key);
        }
    }
}
