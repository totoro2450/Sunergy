using BlazorApp.Shared.Classes;
using System.Collections.Generic;

namespace BlazorApp.Shared.Data
{
    public static class ObjectsData
    {
        public static string DefaultCity = "Славутич";
        public static double defaultLatitude = 51.52124067360863;
        public static double defaultLongitude = 30.757261793445778;

        public static List<CalculateRequest> KnownObjects = new List<CalculateRequest>()
        {
            new CalculateRequest {
                Title = "Будівля магазину «Паляниця» (Арбат) asdf",
                Address = "Поліський квартал, 8",
                // {"Latitude":51.5221889,"Longitude":30.7457125}
                Coordinates = new Coordinates { Latitude = 51.522608721257775, Longitude = 30.760145618420076 },
                RoofArea = 701.3,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля універмагу «Десна» (Мінськ) asdf",
                Address = "Центральна площа, 5",
                Coordinates = new Coordinates { Latitude = 51.520937, Longitude = 30.755824 },
                RoofArea = 1182.1,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля Універсаму «Дніпро» asdf",
                Address = "Проспект Незалежності, 5",
                Coordinates = new Coordinates { Latitude = 51.520974446289394, Longitude = 30.75660786478983 },
                RoofArea = 2342.1,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля БПО \"Люкс\" ",
                Address = "Центральна площа, 3",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 998.1,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля «Промбудбанк» ",
                Address = "вул. Героїв Дніпра, 2/А",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1056,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "БМУ Промбуд-Адмін-побутовий комплекс бази ",
                Address = "вул. Залізнична,6    ",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 314.2,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "АОГ-Полігон зборки залізо-бетону, з пропарочною камерою",
                Address = "Будівельний проїзд, 12",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 389,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля «Будинок культури на 300 місць»",
                Address = "проспект Незалежності, 7",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1940,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля «Міжнародний Центр розвитку бізнесу «Славутич ХХІ століття» ",
                Address = "вул. Героїв Дніпра, 2",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 859.5,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля «Інкубатор малого бізнесу»",
                Address = "Ризький квартал, 3",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 530.7,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля «Центр професійного розвитку»",
                Address = "вул. Збройних Сил України, 3",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1894.1,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля інженерно – лабораторного корпусу «Абріс»",
                Address = "вул. Лісна, 4\r\n",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1715.6,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля складу матеріалів бази БМУ «Промбуд»",
                Address = "вул. Залізнична, 6/1",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 907.26,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "БПО «Полісся»",
                Address = "Поліський квартал, 3",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 120.13,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Адміністративно-побутовий корпус КП \"УЖКГ\"",
                Address = "вул. Військових будівельників, 7",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 874.67,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Адміністративно – побутовий корпус ЦТПК",
                Address = "Кленовий проїзд, 1/1",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 539.7,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Споруда «Ангар»",
                Address = "вул. Військових будівельників, 8",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 384.3,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Побутово – складські приміщення (виробничі) КП «УЖКГ»",
                Address = "вул. Військових будівельників, 8",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 4006.9,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Склад під навісом",
                Address = "вул. Військових будівельників, 8",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1626.5,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Закрита мийка",
                Address = "вул. Військових будівельників, 8",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 278,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Склад",
                Address = "вул. Військових будівельників, 8",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 56.7,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Комплекс «Центральна міська котельня»",
                Address = "Кленовий проїзд, 1",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 5500.4,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ЦТП -1",
                Address = "Поліський квартал",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 213.2,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ЦТП -2",
                Address = "Київський квартал",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 245.3,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ЦТП -3",
                Address = "Дніпровський квартал",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 349.1,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ЦТП -4",
                Address = "Ризький квартал",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 301,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ЦТП -5",
                Address = "Бакинський квартал",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 280.7,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ЦТП -6",
                Address = "Загально – міський центр",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 241.1,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ЦТП -7",
                Address = "Привокзальна площа",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 240,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ЦТП -8",
                Address = "Чернігівський квартал",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 245.3,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ЦТП -9",
                Address = "Добринінський квартал",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 211.8,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ЦТП -25",
                Address = "Єреванський квартал",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 47.6,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Адміністративно – побутовий корпус  ДЕД",
                Address = "вул. Військових будівельників, 11",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 488.1,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Механізована мийка",
                Address = "вул. Військових будівельників, 11",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 386.7,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Очисні споруди на базі ДЕД",
                Address = "вул. Військових будівельників, 11",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 295.4,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Виробничий корпус ДЕД",
                Address = "вул. Військових будівельників, 11",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 3580.8,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "База приготування протиожеледних сумішей",
                Address = "вул. Військових будівельників, 11",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 803.5,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Стоянка відділу комплектації обладнання",
                Address = "вул. Військових будівельників, 11",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 984.5,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Гараж на 10 легкових автомобілів",
                Address = "вул. Військових будівельників, 11",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 224.8,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля «Поліклініка»",
                Address = "вул. Збройних сил України, 5",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 2631.7,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля «Станція швидкої медичної допомоги»",
                Address = "вул. Збройних сил України, 7/7",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 624.3,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля Головного корпусу",
                Address = "вул. Збройних сил України, 7",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 4775.93,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля «Паталогоанатомічного корпусу» ",
                Address = "вул. Збройних сил України, 7/11",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 446.1,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля «Інфекційного корпусу»",
                Address = "вул. Збройних сил України, 7/9",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1441.04,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля “Акушерського корпусу”",
                Address = "вул. Збройних сил України, 7/6",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1836.9,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля “Харчоблоку”",
                Address = "вул. Збройних сил України, 7/8",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 694.2,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля архіву зберігання рентгенограм",
                Address = "вул. Збройних сил України, 7",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 72.7,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля «Господарського корпусу»",
                Address = "вул. Збройних сил України, 7/10",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 2439.1,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Адміністративно – побутовий корпус",
                Address = "вул. Залізнична, 30",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 527.2,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Виробничий корпус",
                Address = "вул. Залізнична, 30",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 644.9,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля «Інноваційний індустріальний бізнес-парк»",
                Address = "вул. Військових будівельників, 11а",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1345,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Міськвиконком Будівля, \"Будинок міської ради\"",
                Address = "Центральна площа, 7",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 811.5,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Нежитлова будівля “Загальноміський бібліотечно-інформаційний центр” з овочесховищем",
                Address = "Поліський квартал, 12",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1305,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Двухзальний кінотеатр на 738 місць з кафе на 50 місць і танцзалом на 75 пар",
                Address = "Центральна площа, 9",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 2099,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Дитяча школа мистецтв (Корпус1)",
                Address = "вул. Атомників, 4",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1601.2,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Дитяча школа мистецтв (Корпус2)",
                Address = "проспект Незалежності, 9",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1220.7,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Палац дітей та молоді",
                Address = "вул. Збройних сил України, 1",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1927,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ДНЗ (ясла-садок) №4 “МАРИТЕ”",
                Address = "Ризький квартал, 1",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1479.4,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ДНЗ (ясла-садок) комбінованого типу “Центр розвитку дитини”",
                Address = "Вільнюський квартал, 1",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 2835.4,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ДНЗ (ясла-садок) №6 “Крунк”",
                Address = "Єреванський квартал, 14",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1363,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ДНЗ (ясла-садок) №5 “ДЖЕРЕЛЬЦЕ”",
                Address = "Київський квартал, 15",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1879,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ДНЗ (ясла-садок) №1 “Калинка”",
                Address = "Деснянський квартал, 6",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1455.5,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ДНЗ (ясла-садок) №8 “Теремок”",
                Address = "Добринінський квартал, 2",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 2151,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Славутицький ліцей",
                Address = "вул. Героїв Дніпра, 6",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 3132.6,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Славутицька ЗОШ І-ІІІ ступенів №1",
                Address = "проспект Незалежності, 19",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 4843.3,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Славутицька гімназія «КрОкус»",
                Address = "вул.Атомників, 17",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 2450.23,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Славутицька ЗОШ І-ІІІ ступенів №3",
                Address = "проспект Незалежності, 1",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 2881.5,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Славутицька ЗОШ І-ІІІ ступенів №4, (ліцей “БезМеж”) (на балансі ліцею)",
                Address = "вул. Героїв Дніпра, 8",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 4050,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Дитячий будинок “Центр захисту дітей”, (переданий на баланс дитячого будинку “Родинний затишок”)",
                Address = "Бакинський квартал, 15",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1531,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Басейн «Дельфін»",
                Address = "Київський квартал, буд. 16",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1042,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Басейн «Лазурний»",
                Address = "вул. Збройних сил України, 1",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1272.1,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "СК «Олімпієць»",
                Address = "Чернігівський квартал, 14",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1389.3,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ФОК «Грація»",
                Address = "Тбіліський квартал, 2",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 945.5,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ФОК «Динамовець»",
                Address = "Талліннський квартал, 2",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 945.5,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ФОК «Олімп»",
                Address = "Київський квартал, 9",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 945.5,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "ФОК «Чемпіон»",
                Address = "Поліський квартал, 6",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 945.5,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "“Центр комплексної реабілітації дітей з інвалідністю та осіб з інвалідністю “БЛАГОДАР”",
                Address = "Чернігівський квартал, 13",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 916,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Реабілітаційний центр «ОУ»",
                Address = "вул. Збройних сил України, 10",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1307,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля БПО \"Чернігівський\"",
                Address = "Київський  квартал, 14",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 1000,
                CurrencyName = "Грн"
            },
            new CalculateRequest {
                Title = "Будівля БПО «Ризький»",
                Address = "Ризький  квартал, 14",
                Coordinates = new Coordinates { Latitude = defaultLatitude, Longitude = defaultLongitude },
                RoofArea = 375,
                CurrencyName = "Грн"
            },
        };
    }
}
