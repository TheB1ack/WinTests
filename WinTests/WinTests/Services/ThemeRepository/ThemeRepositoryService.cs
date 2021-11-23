using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WinTests.Enums;
using WinTests.Extentions;
using WinTests.Models.Subtheme;
using WinTests.Models.Test;
using WinTests.Models.TestOptions;
using WinTests.Models.Tests;
using WinTests.Models.Theme;

namespace WinTests.Services.ThemeRepository
{
    public class ThemeRepositoryService : IThemeRepositoryService
    {
        public Task<IList<ThemeViewModel>> GetThemesCollectionAsync()
        {
            IList<ThemeViewModel> result = null;

            try
            {
                result = new List<ThemeViewModel>();

                var modelsCollection = GetThemesCollection();

                result = ConvertThemesToViewModels(modelsCollection);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error catched in " + nameof(ThemeRepositoryService) + ". Details : /n" + ex.Message);
            }

            return Task.FromResult(result);
        }

        private IList<ThemeViewModel> ConvertThemesToViewModels(IEnumerable<ThemeModel> themeModels)
        {
            IList<ThemeViewModel> viewModels = null;

            if (themeModels != null)
            {
                viewModels = new List<ThemeViewModel>();

                foreach (var model in themeModels)
                {
                    var viewModel = model.ToViewModel();

                    var collection = ConvertSubThemesToViewModels(model.SubThemes);
                    viewModel.SubThemes = new ObservableCollection<SubThemeViewModel>(collection);

                    viewModels.Add(viewModel);
                }
            }

            return viewModels;
        }

        private IList<SubThemeViewModel> ConvertSubThemesToViewModels(IEnumerable<SubThemeModel> subThemeModels)
        {
            IList<SubThemeViewModel> viewModels = null;

            if (subThemeModels != null)
            {
                viewModels = new List<SubThemeViewModel>();

                foreach (var model in subThemeModels)
                {
                    var viewModel = model.ToViewModel();

                    var collection = ConvertTestsToViewModels(model.Tests);
                    viewModel.Tests = new ObservableCollection<TestViewModel>(collection);

                    viewModels.Add(viewModel);
                }
            }

            return viewModels;
        }

        private IList<TestViewModel> ConvertTestsToViewModels(IEnumerable<TestModel> testsModels)
        {
            IList<TestViewModel> viewModels = null;

            if (testsModels != null)
            {
                viewModels = new List<TestViewModel>();

                foreach (var model in testsModels)
                {
                    var viewModel = model.ToViewModel();

                    var collection = ConvertOptionsToViewModels(model.Options);
                    viewModel.Options = new ObservableCollection<TestOptionViewModel>(collection);

                    viewModels.Add(viewModel);
                }
            }

            return viewModels;
        }

        private IList<TestOptionViewModel> ConvertOptionsToViewModels(IEnumerable<TestOptionModel> optionsModels)
        {
            IList<TestOptionViewModel> viewModels = null;

            if (optionsModels != null)
            {
                viewModels = new List<TestOptionViewModel>();

                foreach (var model in optionsModels)
                {
                    var viewModel = model.ToViewModel();

                    viewModels.Add(viewModel);
                }
            }

            return viewModels;
        }

        private List<ThemeModel> GetThemesCollection()
        {
            var collection = new List<ThemeModel>();

            //Options
            var optionsSingleList = new List<TestOptionModel>();
            optionsSingleList.Add(new TestOptionModel
            {
                Id = 0,
                OptionType = ETestType.Single,
                Title = "Программа, состоящая из чистых функций",
                IsCorrect = true,
            });
            optionsSingleList.Add(new TestOptionModel
            {
                Id = 1,
                OptionType = ETestType.Single,
                Title = "Программа, состоящая только из функций ",
            });
            optionsSingleList.Add(new TestOptionModel
            {
                Id = 2,
                OptionType = ETestType.Single,
                Title = "Программа, что может содержать чистые функции",
            });
            //Tests
            var testsList = new List<TestModel>();
            testsList.Add(new TestModel
            {
                Question = "Что такое функциональная программа?",
                Options = optionsSingleList,
            });
            //SubTheme
            var list = new List<SubThemeModel>();
            list.Add(new SubThemeModel
            {
                Tests = testsList,
                Title = "Лаконичность функционального программирования",
                TestTitle = "Тест",
                Content = "Функциональное программирование — это очень забавная парадигма. С одной стороны, про неё все знают, и все любят пользоваться всякими паттерн матчингами и лямбдами, с другой - на чистом ФП языке обычно мало кто пишет. Поэтому понимание о том, что же это такое, восходит больше к мифам и городским легендам, которые весьма далеко ушли от истины, а у людей складывается мнение, что \"ФП подходит для всяких оторванных от жизни программок расчетов фракталов, а для настоящих задач есть зарекомендовавший себя в бою проверенный временем ООП\".,Хотя люди обычно признают удобства ФП фич, ведь намного приятнее писать:, int Factorial(int n), {,     Log.Info($\"Computing factorial of {n}\");,     return Enumerable.Range(1, n).Aggregate((x, y) => x * y); }чем ужасные императивные программы вроде int Factorial(int n) {     int result = 1;     for (int i = 2; i <= n; i++)  { result *= i;    }  return result; }Так ведь? С одной стороны да. А с другой - именно вторая программа в отличие от первой является функциональной.",
            });

            //Options
            var optionsSingleList1 = new List<TestOptionModel>();
            optionsSingleList1.Add(new TestOptionModel
            {
                Id = 0,
                OptionType = ETestType.Single,
                Title = "Функция f является чистой если выражение f(x) является ссылочно прозрачным для всех ссылочно прозрачных x",
                IsCorrect = true,
            });
            optionsSingleList1.Add(new TestOptionModel
            {
                Id = 1,
                OptionType = ETestType.Single,
                Title = "Функция f является чистой если выражение f(x) является ссылочно прозрачным для любых x",
            });
            optionsSingleList1.Add(new TestOptionModel
            {
                Id = 2,
                OptionType = ETestType.Single,
                Title = "Функция f является чистой если выражение f(x ) является ссылочно прозрачным для всех ссылочно прозрачных x",
            });
            //Tests
            var testsList1 = new List<TestModel>();
            testsList1.Add(new TestModel
            {
                Question = "Выберите правильное утверждение",
                Options = optionsSingleList1,
            });
            //SubTheme
            list.Add(new SubThemeModel
            {
                Tests = testsList1,
                Title = "Общие принципы",
                TestTitle = "Тест",
                Content = "Как же так, разве не наоборот? Красивый флюент интерфейс, трансформация данных и лямбды это функционально, а грязные циклы которые мутируют локальные переменные — наследие прошлого? Так вот, оказывается, что нет. " +
                "Итак, почему же так получается? Дело в том, что по общепринятому определению, программа считается написанной в функциональном стиле когда она состоит только из чистых функций. Так и запишем:" +
                "Функциональная программа — программа, состоящая из чистых функций." +
                "Ок, это мы знали, но что такое чистая функция? Чистая функция — функция, результат вызова которой является ссылочно прозрачным. Или, если формально:" +
                "Функция f является чистой если выражение f(x) является ссылочно прозрачным для всех ссылочно прозрачных x" +
                "А вот тут начинаются различия с тем, что люди обычно представляют под \"чистой функцией\". Разве чистая функция — это не та, которая стейт не мутирует? Или там в глобальные переменные не залезает? Да и что это за \"ссылочная прозрачность\" такая? На самом деле корреляция с этими вещами действительно есть, но сама суть чистоты не в том, чтобы ничего не мутировать, а именно эта самая прозрачность." +
                "Так что же это такое? А вот что:" +
                "Ссылочная прозрачность — свойство, при котором замена выражения на вычисленный результат этого выражения не изменяет желаемых свойств программы" +
                "Это значит что если у нас где-то написано var x = foo() то мы всегда можем заменить это на var x = result_of_foo и поведение программы не поменяется. Именно это и является главным требованием чистоты. Никаких других требований (вроде неизменяемости) ФП не накладывает. Единственный момент тут — философский, что считать \"поведением программы\". Его можно определить интуитивно как свойства, которые нам критично важно соблюдать. Например, если исполнение кода выделяет чуть больше или чуть меньше тепла на CPU — то нам скорее всего это не столь важно (хотя если нет, то мы можем с этим работать специальным образом). А вот если у нас программа в базу ходить перестала и закэшировала одно старое значение — то это нас очень даже волнует!" +
                "Вернемся к нашим примерам. Давайте проверим, выполняется ли наше правило для первой функции? Оказывается, что нет, потому что если мы заменим где-нибудь Factorial(5) на 120 то у нас поменяется поведение программы — в логи перестанет писаться информация которая раньше записывалась (хотя если мы не будем считать это желаемым поведением, то программу можно будет считать чистой. Но, наверное мы не просто так ту строчку в функции написали, и логи в кибане все же хотели бы увидеть, поэтому сочтем такую точку зрения маловероятной)." +
                "А что насчет второго варианта? Во втором случае всё остается как было: можно все вхождения заменить на результат функции и ничего не изменится." +
                "Важно отметить, что это свойство должно работать и в обратную сторону, то есть мы должны иметь возможность поменять все var x = result_of_foo на var x = foo() без изменения поведения программы. Это называется \"Equational reasoning\", то есть \"Рассуждения в терминах эквивалентности\". В рамках этой парадигмы что функции, что значения — суть одно и то же, и можно менять одно на другое совершенно безболезненно." +
                "Отсюда важное следствие: программа не обязана работать с неизменяемыми данными, чтобы считаться функциональной. Достаточно, чтобы эти изменения не были видны стороннему наблюдателю. Для этого даже придумали специальный механизм называющийся ST, который на уровне типов помогает вам не дать утечь случайно мутабельному состоянию наружу. Типичный пример — пишем инплейс быструю сортировку и забыли скопировать входной массив: ST помогает превратить это в ошибку компиляции. Неизменяемость является важным удобным свойством, но вас никто не заставляет пользоваться только им, при необходимости можно мутировать в хвост и гриву, главное — не нарушить ссылочную прозрачность.",
            });

            //Options
            var optionsSingleList2 = new List<TestOptionModel>();
            optionsSingleList2.Add(new TestOptionModel
            {
                Id = 0,
                OptionType = ETestType.Single,
                Title = "int Factorial(int n){Log.Info($\"Computing factorial of {n}\");return Enumerable.Range(1, n).Aggregate((x, y) => x * y);}",
            });
            optionsSingleList2.Add(new TestOptionModel
            {
                Id = 1,
                OptionType = ETestType.Single,
                Title = "int Factorial(int n){int result = 1;for (int i = 2; i <= n; i++){result *= i;}return result;}",
                IsCorrect = true,
            });
            optionsSingleList2.Add(new TestOptionModel
            {
                Id = 2,
                OptionType = ETestType.Single,
                Title = "public class ProductPile {public string ProductName { get; set; }public int Amount { get; set; }public decimal Price { get; set; }}",
            });
            //Tests
            var testsList2 = new List<TestModel>();
            testsList2.Add(new TestModel
            {
                Question = "Какой из приведённых участков кода является функциональным",
                Options = optionsSingleList2,
            });
            //SubTheme
            list.Add(new SubThemeModel
            {
                Tests = testsList2,
                Title = "Зачем это нужно",
                TestTitle = "Тест",
                Content = "Наверное — самый главный вопрос.Зачем так мучиться ? Копировать данные вместо того чтобы изменить напрямую,"+
                "оборачивать объекты в эти ваши ST чтобы изменения(если они есть) не утекали наружу,"+
                "и вот это всё… Ответ — для лучшей композиции.В своё время goto очень невзлюбили именно потому, что с ним очень трудно понять как на самом деле программа себя ведет и какой на самом деле поток данных и управления, и переиспользовать функцию написанную с goto было сложно, ведь тогда он умел даже в середину тела функции прыгнуть без каких-либо проблем.С Equational reasoning всегда просто понять, что происходит: вы можете заменить результат на функцию и всё. Вам не нужно думать, в каком порядке функции вычисляются, не надо переживать насчёт того как оно поведет если поменять пару строчек местами, программа просто передает результаты одних функций в другие.В общем и целом, ФП направлено на то, чтобы можно было судить о поведении функции наблюдая только её одну.",
            });          
            //Theme
            collection.Add(new ThemeModel
            {
                Title = "Философия функционального программирования",
                SubThemes = list,
            });



            //Options
            var optionsSingleList3 = new List<TestOptionModel>();
            optionsSingleList3.Add(new TestOptionModel
            {
                Id = 0,
                OptionType = ETestType.Single,
                Title = "Сложность кода",
                IsCorrect = true,
            });
            optionsSingleList3.Add(new TestOptionModel
            {
                Id = 1,
                OptionType = ETestType.Single,
                Title = "Низкую скорость работы",
            });
            optionsSingleList3.Add(new TestOptionModel
            {
                Id = 2,
                OptionType = ETestType.Single,
                Title = "Потребность в поддержке и сопровождении",
            });
            //Tests
            var testsList3 = new List<TestModel>();
            testsList3.Add(new TestModel
            {
                Question = "Какую главную проблему корпоративного программирования помогает решить функциональная парадигма",
                Options = optionsSingleList3,
            });
            //SubTheme
            var list1 = new List<SubThemeModel>();
            list1.Add(new SubThemeModel
            {
                Tests = testsList3,
                Title = "Неизменяемые объекты",
                TestTitle = "Тест",
                Content = "Самой большой проблемой корпоративного программного обеспечения является сложность кода. Читабельность — это, пожалуй, один из самых важных аспектов программирования. И вы должны стремиться к тому, чтобы ваш код был лаконичен. Код, написанный без учета этого фактора, очень сложно анализировать и проверять на корректность." +
                "Давайте рассмотрим такой пример:" +
                " Создадим критерии поиска" +
                " var queryObject = new QueryObject<Customer>(name, page: 0, pageSize: 10);" +
                " Ищем клиентов" +
                " IReadOnlyCollection<Customer> customers = Search(queryObject);" +
                " Отрегулируем критерии, если никто не найден" +
                " if (customers.Count == 0)" +
                " {" +
                "     AdjustSearchCriteria(queryObject, name);" +
                "     Изменится ли здесь queryObject?" +
                "     Search(queryObject);" +
                " }" +
                "Будет ли изменен объект запроса к тому моменту, когда мы выполняем второй поиск? Может быть, да. А, может быть, нет. Это зависит от того, найдем ли мы что-нибудь, осуществив первый поиск. А еще и от того, изменятся ли критерии поиска после выполнения метода AdjustSearchCriteria. Проще говоря, мы не можем знать заранее, изменится ли объект запроса во втором поиске." +
                "А теперь рассмотрим следующий код:" +
                "" +
                " Создадим критерии поиска" +
                " var queryObject = new QueryObject<Customer>(name, page: 0, pageSize: 10);" +
                " Ищем клиентов" +
                " IReadOnlyCollection<Customer> customers = Search(queryObject);" +
                " if (customers.Count == 0)" +
                " {" +
                "     Отрегулируем критерии, если никто не найден" +
                "     QueryObject<Customer> newQueryObject = AdjustSearchCriteria(queryObject, name);" +
                "     Search(newQueryObject);" +
                " }" +
                "Вот здесь сразу все ясно: после того, как мы ничего не нашли во время первого поиска, метод AdjustSearchCriteria создаст новые критерии, которые в свою очередь будут использоваться во втором поиске." +
                "Итак, какие существуют проблемы в работе с подвергающимися изменениям структурами данных?" +
                "Трудно оценивать написанный код, если мы не можем быть уверенными в том, изменятся ли определенные данные или нет." +
                "Довольно сложно следовать за многочисленными отсылками, если вам потребовалось взглянуть не только на сам метод, но и на функции, которые вызываются в этом методе." +
                "Если же вы пишете многопоточное приложение, то отслеживание и отладка кода становятся еще сложнее.",
            });

            //Options
            var optionsSingleList4 = new List<TestOptionModel>();
            optionsSingleList4.Add(new TestOptionModel
            {
                Id = 0,
                OptionType = ETestType.Single,
                Title = "ImmutableList",
                IsCorrect = true,
            });
            optionsSingleList4.Add(new TestOptionModel
            {
                Id = 1,
                OptionType = ETestType.Single,
                Title = "ImmutableChart",
            });
            optionsSingleList4.Add(new TestOptionModel
            {
                Id = 2,
                OptionType = ETestType.Single,
                Title = "FieldList",
            });
            //Tests
            var testsList4 = new List<TestModel>();
            testsList4.Add(new TestModel
            {
                Question = "Какое ключевое слово пропущенно в участке кода с реализацией неизменяемых коллекцийvar builder = ____.CreateBuilder<string>();builder.Add(\"1\");____<string> list = builder.ToImmutable(); ____<string> list2 = list.Add(\"2\");",
                Options = optionsSingleList4,
            });
            //SubTheme
            list1.Add(new SubThemeModel
            {
                Tests = testsList4,
                Title = "Как описать неизменяемые объекты?",
                TestTitle = "Тест",
                Content = "Если у вас есть относительно простой класс, то вы всегда должны рассматривать вопрос о том, чтобы сделать его неизменяемым. Это правило коррелирует с понятием Value Objects — они просты и их легко сделать неизменяемыми." +
                "Так как же нам описать неизменяемые объекты? Давайте рассмотрим пример: у нас есть класс ProductPile, представляющий некоторые продукты, которые мы выставили на продажу:" +
                " public class ProductPile" +
                " {" +
                "     public string ProductName { get; set; }" +
                "     public int Amount { get; set; }" +
                "     public decimal Price { get; set; }" +
                " }" +
                "Чтобы сделать поля класса ProductPile неизменяемыми, мы отметим их доступными только для чтения и создадим конструктор:" +
                " public class ProductPile" +
                " {" +
                "     public string ProductName { get; private set; }" +
                "     public int Amount { get; private set; }" +
                "     public decimal Price { get; private set; }" +
                "     public ProductPile(string productName, int amount, decimal price)" +
                "     {" +
                "         Contracts.Require(!string.IsNullOrWhiteSpace(productName));" +
                "         Contracts.Require(amount >= 0);" +
                "         Contracts.Require(price > 0);" +
                "         ProductName = productName;" +
                "         Amount = amount;" +
                "         Price = price;" +
                "     }" +
                "     public ProductPile SubtractOne()" +
                "     {" +
                "         return new ProductPile(ProductName, Amount – 1, Price);" +
                "     }" +
                " }" +
                "Чего нам удалось добиться такой организацией класса:" +
                "1.  Мы можем не волноваться о корректности данных, т. к. проверять значение будем лишь один раз в конструкторе." +
                "2.  Теперь мы полностью уверены, что значения объектов всегда корректны." +
                "3.  Объекты автоматически становятся потокобезопасными." +
                "4.  Повысилась читаемость кода, ведь не нужно проверять, не поменялись ли значения объектов.",
            });

            //Options
            var optionsSingleList5 = new List<TestOptionModel>();
            optionsSingleList5.Add(new TestOptionModel
            {
                Id = 0,
                OptionType = ETestType.Single,
                Title = "Позволяет мутировать коллекцию",
                IsCorrect = true,
            });
            optionsSingleList5.Add(new TestOptionModel
            {
                Id = 1,
                OptionType = ETestType.Single,
                Title = "Заменяет конструктор по умолчанию",
            });
            optionsSingleList5.Add(new TestOptionModel
            {
                Id = 2,
                OptionType = ETestType.Single,
                Title = "Создаёт неизменяемую коллекцию",
            });
            //Tests
            var testsList5 = new List<TestModel>();
            testsList5.Add(new TestModel
            {
                Question = "Какой функционал предоставляет класс Builder?",
                Options = optionsSingleList5,
            });
            //SubTheme
            list1.Add(new SubThemeModel
            {
                Tests = testsList5,
                Title = "Ограничения в использовании",
                TestTitle = "Тест",
                Content = "Конечно, все имеет свою цену. Мы можем применить нашу идею в маленьких и простых классах, однако она совсем не применима к большим." +
                "Прежде всего стоит отметить производительность. Если ваш объект получается достаточно большим, то создание его копий каждый раз при изменении какого-то параметра не лучшим образом скажется на быстродействии приложения." +
                "Хорошим примером здесь являются неизменяемые коллекции (immutable collections). Их авторы учли проблемы с производительностью и добавили класс Builder, который позволяет «мутировать», изменять коллекцию:" +
                " var builder = ImmutableList.CreateBuilder<string>();" +
                " builder.Add(\"1\");    Добавление строки в существующий объект" +
                " ImmutableList<string> list = builder.ToImmutable();" +
                " ImmutableList<string> list2 = list.Add(\"2\");  Создание объекта с 2 строками" +
                "Также вы встретите множество проблем, если попытаетесь сделать изменчивый по своей природе класс неизменяемым. Но пусть вас это не останавливает.",
            });
            //Theme
            collection.Add(new ThemeModel
            {
                Title = "Неизменяемые объекты",
                SubThemes = list1,
            });



            //Options
            var optionsSingleList6 = new List<TestOptionModel>();
            optionsSingleList6.Add(new TestOptionModel
            {
                Id = 0,
                OptionType = ETestType.Single,
                Title = "Сложную работу с валидацией",
                IsCorrect = true,
            });
            optionsSingleList6.Add(new TestOptionModel
            {
                Id = 1,
                OptionType = ETestType.Single,
                Title = "Невозможность хранить значения разных типов",
            });
            optionsSingleList6.Add(new TestOptionModel
            {
                Id = 2,
                OptionType = ETestType.Single,
                Title = "Маленький объём допустимых данных",
            });
            //Tests
            var testsList6 = new List<TestModel>();
            testsList6.Add(new TestModel
            {
                Question = "Какую проблему примитивов решает функциональная парадигма",
                Options = optionsSingleList6,
            });
            //SubTheme
            var list2 = new List<SubThemeModel>();
            list2.Add(new SubThemeModel
            {
                Tests = testsList6,
                Title = "Формирование проблемы одержимости примитивами",
                TestTitle = "Тест",
                Content = "Представьте себе ситуацию, что вам потребовалось описать некий класс Customer, содержащий определенные данные — скажем, имя и электронную почту. К сожалению, многие программисты подумают, что использовать для имени и почты поля элементарных типов данных куда проще, чем написать базовый класс." +
                "Если вы тоже так думаете, то вашим результатом будет подобный код:" +
                " public class Customer" +
                " {" +
                "     public string Name { get; private set; }" +
                "     public string Email { get; private set; }" +
                "     public Customer(string name, string email)" +
                "     {" +
                "         Name = name;" +
                "         Email = email;" +
                "     }" +
                " }" +
                "Данный метод является правильным ровно до того момента, пока вам не понадобится проверять значения полей на корректность. Но вас так просто не убедить и вы пишете уйму проверок. В итоге класс увеличивается и обрастает различными условиями:" +
                " public class Customer" +
                " {" +
                "     public string Name { get; private set; }" +
                "     public string Email { get; private set; }" +
                "     public Customer(string name, string email)" +
                "     {" +
                "         Проверка корректности имени" +
                "         if (string.IsNullOrWhiteSpace(name) || name.Length > 50)" +
                "             throw new ArgumentException(\"Name is invalid\");" +
                "         Проверка корректности эл.почты" +
                "         if (string.IsNullOrWhiteSpace(email) || email.Length > 100)" +
                "             throw new ArgumentException(\"E-mail is invalid\");" +
                "         if (!Regex.IsMatch(email, @\"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$\"))" +
                "             throw new ArgumentException(\"E-mail is invalid\");" +
                "         Name = name;" +
                "         Email = email;" +
                "     }" +
                "     public void ChangeName(string name)" +
                "     {" +
                "         Проверка корректности имени" +
                "         if (string.IsNullOrWhiteSpace(name) || name.Length > 50)" +
                "             throw new ArgumentException(\"Name is invalid\");" +
                "         Name = name;" +
                "     }" +
                "     public void ChangeEmail(string email)" +
                "     {" +
                "         Проверка корректности эл.почты" +
                "         if (string.IsNullOrWhiteSpace(email) || email.Length > 100)" +
                "             throw new ArgumentException(\"E-mail is invalid\");" +
                "         if (!Regex.IsMatch(email, @\"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$\"))" +
                "             throw new ArgumentException(\"E-mail is invalid\");" +
                "         Email = email;" +
                "     }" +
                " }" +
                "Да и ладно, если бы эти проверки оставались внутри класса. Но ведь они выходят на уровень выше — в основной класс приложения:" +
                " [HttpPost]" +
                " public ActionResult CreateCustomer(CustomerInfo customerInfo)" +
                " {" +
                "     if (!ModelState.IsValid)" +
                "         return View(customerInfo);" +
                " " +
                "     Customer customer = new Customer(customerInfo.Name, customerInfo.Email);" +
                "     Остальная часть метода" +
                " }" +
                " public class CustomerInfo" +
                " {" +
                "     [Required(ErrorMessage = \"Name is required\")]" +
                "     [StringLength(50, ErrorMessage = \"Name is too long\")]" +
                "     public string Name { get; set; }" +
                "     [Required(ErrorMessage = \"E-mail is required\")]" +
                "     [RegularExpression(@\"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$\"," +
                "         ErrorMessage = \"Invalid e-mail address\")]" +
                "     [StringLength(100, ErrorMessage = \"E-mail is too long\")]" +
                "     public string Email { get; set; }" +
                " }" +
                "Согласитесь, такой подход, мягко говоря, не совсем корректный. А как же принцип DRY и единый источник истины? В приведенном выше примере по меньшей мере 3 таких источника, что совсем не оправдано." +
                "Именно эта ситуация и называется состоянием одержимости примитивами. В следующей главе мы покажем вам, как обойти эту «болезнь».",
            });

            //Options
            var optionsSingleList7 = new List<TestOptionModel>();
            optionsSingleList7.Add(new TestOptionModel
            {
                Id = 0,
                OptionType = ETestType.Single,
                Title = "Создать отдельные классы для проверки валидности Email",
                IsCorrect = true,
            });
            optionsSingleList7.Add(new TestOptionModel
            {
                Id = 1,
                OptionType = ETestType.Single,
                Title = "Заменить класс Email на String переменную везде, где можно",
            });
            optionsSingleList7.Add(new TestOptionModel
            {
                Id = 2,
                OptionType = ETestType.Single,
                Title = "Дополнить класс String в соответствии с потребностями валидации",
            });
            //Tests
            var testsList7 = new List<TestModel>();
            testsList7.Add(new TestModel
            {
                Question = "Как стоит отредактировать данный участок кода на функциональный стильpublic class Email{private readonly string _value;private Email(string value){_value = value;}",
                Options = optionsSingleList7,
            });
            //SubTheme
            list2.Add(new SubThemeModel
            {
                Tests = testsList7,
                Title = "Пути к решению",
                TestTitle = "Тест",
                Content = "Очень просто! Мы всего-навсего должны ввести два новых класса, в которых мы и будем проверять значения на валидность. Это и будет единым источником истины, о котором говорилось выше." +
                " public class Email" +
                " {" +
                "     private readonly string _value;" +
                "     private Email(string value)" +
                "     {" +
                "         _value = value;" +
                "     }" +
                "     public static Result<Email> Create(string email)" +
                "     {" +
                "         if (string.IsNullOrWhiteSpace(email))" +
                "             return Result.Fail<Email>(\"E-mail can’t be empty\");" +
                "         if (email.Length > 100)" +
                "             return Result.Fail<Email>(\"E-mail is too long\");" +
                "         if (!Regex.IsMatch(email, @\"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$\"))" +
                "             return Result.Fail<Email>(\"E-mail is invalid\");" +
                "         return Result.Ok(new Email(email));" +
                "     }" +
                "     public static implicit operator string(Email email)" +
                "     {" +
                "         return email._value;" +
                "     }" +
                "     public override bool Equals(object obj)" +
                "     {" +
                "         Email email = obj as Email;" +
                "         if (ReferenceEquals(email, null))" +
                "             return false;" +
                "         return _value == email._value;" +
                "     }" +
                "     public override int GetHashCode()" +
                "     {" +
                "         return _value.GetHashCode();" +
                "     }" +
                " }" +
                " public class CustomerName" +
                " {" +
                "     public static Result<CustomerName> Create(string name)" +
                "     {" +
                "         if (string.IsNullOrWhiteSpace(name))" +
                "             return Result.Fail<CustomerName>(\"Name can’t be empty\");" +
                "         if (name.Length > 50)" +
                "             return Result.Fail<CustomerName>(\"Name is too long\");" +
                "         return Result.Ok(new CustomerName(name));" +
                "     }" +
                "     Дальше будет то же самое, что и в классе Email" +
                " }" +
                "Красота такого подхода заключается в том, что если вы захотите изменить логику проверки значений, вам нужно будет подкорректировать код ровно в одном месте. Чем меньше дублирования кода в вашей программе, тем меньше ошибок вы допустите и тем счастливее ваши клиенты!" +
                "Обратите внимание на то, что конструктор класса Email приватный. А новый экземпляр мы можем создать при помощи метода Create, который прогоняет входное значение через множество фильтров, проверяя его на валидность. Это сделано для того, чтобы значение объекта было корректным с самого начала его существования." +
                "А вот и пример применения таких классов:" +
                " [HttpPost]" +
                " public ActionResult CreateCustomer(CustomerInfo customerInfo)" +
                " {" +
                "     Result<Email> emailResult = Email.Create(customerInfo.Email);" +
                "     Result<CustomerName> nameResult = CustomerName.Create(customerInfo.Name);" +
                "     if (emailResult.Failure)" +
                "         ModelState.AddModelError(\"Email\", emailResult.Error);" +
                "     if (nameResult.Failure)" +
                "         ModelState.AddModelError(\"Name\", nameResult.Error);" +
                "     if (!ModelState.IsValid)" +
                "         return View(customerInfo);" +
                "     Customer customer = new Customer(nameResult.Value, emailResult.Value);" +
                "     Остальная часть метода" +
                " }" +
                "Обратите внимание, что экземпляры Result<Email> и Result<CustomerName> явно говорят нам, что метод Create может вызвать ошибку. И если это произойдет, то информацию об ошибке можно узнать из свойства Error." +
                "А теперь давайте взглянем на класс Customer после того, как мы ввели два маленьких побочных класса:" +
                "" +
                " public class Customer" +
                " {" +
                "     public CustomerName Name { get; private set; }" +
                "     public Email Email { get; private set; }" +
                "     public Customer(CustomerName name, Email email)" +
                "     {" +
                "         if (name == null)" +
                "             throw new ArgumentNullException(\"name\");" +
                "         if (email == null)" +
                "             throw new ArgumentNullException(\"email\");" +
                "         Name = name;" +
                "         Email = email;" +
                "     }" +
                "     public void ChangeName(CustomerName name)" +
                "     {" +
                "         if (name == null)" +
                "             throw new ArgumentNullException(\"name\");" +
                "         Name = name;" +
                "     }" +
                "     public void ChangeEmail(Email email)" +
                "     {" +
                "         if (email == null)" +
                "             throw new ArgumentNullException(\"email\");" +
                "         Email = email;" +
                "     }" +
                " }" +
                "Практически все проверки были перемещены в классы Email и CustomerName. Остались только условия с проверками на null, но их мы рассмотрим в следующей статье." +
                "Так какие преимущества мы получили, избавившись от одержимости примитивами?" +
                "•\tМы создали единый авторитетный источник знаний для каждого объекта и избавились от дублирования кода." +
                "•\tТеперь невозможно по ошибке присвоить объекту Email или CustomerName такое значение, которое привело бы к ошибке компилятора." +
                "•\tНет необходимости в дополнительной проверке корректности электронной почты или имени покупателя. Если объекты класса Email или CustomerName существуют, то мы точно знаем, что данные в них хранятся абсолютно верные."+
                "Есть одна деталь, на которой бы хотелось остановиться поподробней. Дело в том, что некоторые программисты избавляются от одержимости элементарных типов не полностью. Например:" +
                " public void Process(string oldEmail, string newEmail)" +
                " {" +
                "     Result<Email> oldEmailResult = Email.Create(oldEmail);" +
                "     Result<Email> newEmailResult = Email.Create(newEmail);" +
                "     if (oldEmailResult.Failure || newEmailResult.Failure)" +
                "         return;" +
                "     string oldEmailValue = oldEmailResult.Value;" +
                "     Customer customer = GetCustomerByEmail(oldEmailValue);" +
                "     customer.Email = newEmailResult.Value;" +
                " }" +
                "Нужно помнить, что использовать элементарные типы стоит только тогда, когда объект покидает пределы программы. То есть в тех случаях, когда значения заносятся в базу данных или экспортируются во внешний файл. Но в своем приложении старайтесь использовать написанные вами классы-обертки настолько часто, насколько это возможно. Это сделает ваш код более чистым. Убедитесь в этом сами:" +
                " public void Process(Email oldEmail, Email newEmail)" +
                " {" +
                "     Customer customer = GetCustomerByEmail(oldEmail);" +
                "     customer.Email = newEmail;" +
                " }",
            });

            //Options
            var optionsSingleList8 = new List<TestOptionModel>();
            optionsSingleList8.Add(new TestOptionModel
            {
                Id = 0,
                OptionType = ETestType.Single,
                Title = "Result",
                IsCorrect = true,
            });
            optionsSingleList8.Add(new TestOptionModel
            {
                Id = 1,
                OptionType = ETestType.Single,
                Title = "Item",
            });
            optionsSingleList8.Add(new TestOptionModel
            {
                Id = 2,
                OptionType = ETestType.Single,
                Title = "Binary",
            });
            //Tests
            var testsList8 = new List<TestModel>();
            testsList8.Add(new TestModel
            {
                Question = "Что следует добавить в пропущенном участке кода чтобы иметь возможность работать с возникшими ошибками ____ < Email > emailResult = Email.Create(customerInfo.Email);",
                Options = optionsSingleList8,
            });
            //SubTheme
            list2.Add(new SubThemeModel
            {
                Tests = testsList8,
                Title = "Ограничения",
                TestTitle = "Тест",
                Content = "К сожалению, создание пользовательских типов данных в C# реализовано не так безупречно, как в функциональных языках: F#, например. Возможно, ситуацию исправит новая версия языка: C# 7.0."+
                "Именно поэтому я считаю, что в некоторых ситуациях использование примитивов лучше, чем создание простого класса-обертки. Например, для представления денег. Они могут быть выражены при помощи элементарного типа данных с одной лишь проверкой знака числа. Да, вам придется продублировать это условие, но это решение проще, даже в долгосрочной перспективе." +
                "Как и всегда, скажу вам, чтобы вы перед тем, как что-то написать, взвесили все «за» и «против» и только потом принимали решение. И не бойтесь менять свое мнение несколько раз.",
            });
            //Theme
            collection.Add(new ThemeModel
            {
                Title = "Решение проблем примитивов",
                SubThemes = list2,
            });

            return collection;
        }
    }
}
