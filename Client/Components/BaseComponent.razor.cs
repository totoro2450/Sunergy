using BlazorApp.Shared.Laguage;
using BlazorApp.Shared.Language;

using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Components
{
    public partial class BaseComponent : LayoutComponentBase
    {
        [Inject]
        protected LanguageService LanguageService { get; set; }

        protected string GetTranslation(LanguageKeys key)
        {
            return LanguageService.GetTraslation(key);
        }

        protected string T(LanguageKeys key)
        {
            return GetTranslation(key);
        }
    }
}
