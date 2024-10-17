using System.Collections.Generic;

namespace BlazorApp.Shared.Language
{
    public static class LanguageData
    {
        public static Dictionary<LanguageKeys, string> English = new Dictionary<LanguageKeys, string>
        {
            { LanguageKeys.Title, "Title" },
            { LanguageKeys.Latitude, "Latitude" },
            { LanguageKeys.Longitude, "Longitude" },
            { LanguageKeys.Calculate, "Calculate" },
            { LanguageKeys.KnownLocations, "Known Locations" },
            { LanguageKeys.GetMapToken, "Get Map Token" },
            { LanguageKeys.TokenNotFound, "Token Not Found..." },
            { LanguageKeys.InvalidRequestPayload, "Invalid request payload." },
            { LanguageKeys.PowerName, "MWt" },
            { LanguageKeys.Month, "Month" },
            { LanguageKeys.Year, "Year" },
            { LanguageKeys.Hour, "Hour" },
            { LanguageKeys.Summary, "Summary" },
            { LanguageKeys.Date, "Date" },
            { LanguageKeys.AddNewObject, "Add New Object" },
            { LanguageKeys.CalculatorHeader, "Enter address to find your object" },
            { LanguageKeys.ShowDetailsAboutCalculations, "Show Details About Calculations" },
            { LanguageKeys.HideDetailsAboutCalculations, "Hide Details About Calculations" },
            { LanguageKeys.Address, "Address" },
            { LanguageKeys.RoofArea, "Roof Area" },
            { LanguageKeys.InvestmentPrice, "Investment Price" },
            { LanguageKeys.InvestmentPriceNote, "For default - left empty. Default value: " },
            { LanguageKeys.EnergyPrice, "Energy Price" },
            { LanguageKeys.EnergyPriceNote, "For default - left empty. Default value: " },
            { LanguageKeys.CurrencyName, "Currency Name" },
            { LanguageKeys.TotalInvestment, "Total Investment" },
            { LanguageKeys.AvgGeneration, "Average Generation" }, // Average Generation. MWt/Year
            { LanguageKeys.MinGenetation, "Minimum Generation" }, // Minimum Generation. MWt/Month
            { LanguageKeys.MaxGeneration, "Maximum Generation" }, // Maximum Generation MWt/Month
            { LanguageKeys.TotalIncome, "Average total income per Year" },
            { LanguageKeys.Coordinates, "Coordinates" },
            { LanguageKeys.EffectiveRoofArea, "Effective Roof Area" },

            // Errors
            { LanguageKeys.ServerError, "Server Error. Please try later. " },

            // NavMenu
            { LanguageKeys.HomeNavMenuItem, "Home" },
            { LanguageKeys.CalculatorNavMenuItem, "Calculator" },
            { LanguageKeys.ServicesNavMenuItem, "Services" },
            { LanguageKeys.PartnersNavMenuItem, "Partners" },
            { LanguageKeys.SupportNavMenuItem, "Support" },
            { LanguageKeys.AboutUsNavMenuItem, "About Us" },
            { LanguageKeys.ContactUsNavMenuItem, "Contact Us" }
        };

        public static Dictionary<LanguageKeys, string> Ukrainian = new Dictionary<LanguageKeys, string>
        {
            { LanguageKeys.Title, "Заголовок" },
            { LanguageKeys.Latitude, "Широта" },
            { LanguageKeys.Longitude, "Довгота" },
            { LanguageKeys.Calculate, "Обчислити" },
            { LanguageKeys.KnownLocations, "Відомі місця" },
            { LanguageKeys.GetMapToken, "Отримати токен карти" },
            { LanguageKeys.TokenNotFound, "Токен не знайдено..." },
            { LanguageKeys.InvalidRequestPayload, "Недійсний запит." },
            { LanguageKeys.PowerName, "МВт" },
            { LanguageKeys.Month, "Місяць" },
            { LanguageKeys.Year, "Рік" },
            { LanguageKeys.Hour, "год." },
            { LanguageKeys.Summary, "Опис" },
            { LanguageKeys.Date, "Дата" },
            { LanguageKeys.AddNewObject, "Додати новий об'єкт" },
            { LanguageKeys.CalculatorHeader, "Введіть адресу для пошуку об’єкта дослідження" },
            { LanguageKeys.ShowDetailsAboutCalculations, "Показати деталі по розрахунку" },
            { LanguageKeys.HideDetailsAboutCalculations, "Приховати деталі по розрахунку" },
            { LanguageKeys.Address, "Адреса" },
            { LanguageKeys.RoofArea, "Площа поверхні" },
            { LanguageKeys.InvestmentPrice, "Ціна інвестиції" },
            { LanguageKeys.InvestmentPriceNote, "За метр квадратний. Можна залишити пустим." },
            { LanguageKeys.EnergyPrice, "Ціна енергії" },
            { LanguageKeys.EnergyPriceNote, "Можна залишити пустим. Значення за замовченням: " },
            { LanguageKeys.CurrencyName, "Назва валюти" },
            { LanguageKeys.TotalInvestment, "Загальні інвестиції" },
            { LanguageKeys.AvgGeneration, "Середня генерація" }, // "Середня генерація, МВт/Рік"
            { LanguageKeys.MinGenetation, "Мінімальна генерація" }, // "Мінімальна генерація, МВт/Місяц"
            { LanguageKeys.MaxGeneration, "Максимальна генерація" }, // "Максимальна генерація, МВт/Місяц"
            { LanguageKeys.TotalIncome, "Середній загальний дохід за рік" },
            { LanguageKeys.Coordinates, "Координати" },
            { LanguageKeys.EffectiveRoofArea, "Ефективна площа даху" },

            // Errors
            { LanguageKeys.ServerError, "Помилка сервера. Будь ласка, спробуйте пізніше. " },

            // NavMenu
            { LanguageKeys.HomeNavMenuItem, "Головна" },
            { LanguageKeys.CalculatorNavMenuItem, "Калькулятор" },
            { LanguageKeys.ServicesNavMenuItem, "Сервіси" },
            { LanguageKeys.PartnersNavMenuItem, "Партнери" },
            { LanguageKeys.SupportNavMenuItem, "Підтримка" },
            { LanguageKeys.AboutUsNavMenuItem, "Про нас" },
            { LanguageKeys.ContactUsNavMenuItem, "Написати" }
        };
    }
}
