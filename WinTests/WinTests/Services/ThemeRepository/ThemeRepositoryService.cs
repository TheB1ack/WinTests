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
            //Options
            var optionsSeveralList = new List<TestOptionModel>();
            optionsSeveralList.Add(new TestOptionModel
            {
                Id = 0,
                OptionType = ETestType.Several,
                Title = "yes",
                IsCorrect = true,
            });
            optionsSeveralList.Add(new TestOptionModel
            {
                Id = 1,
                OptionType = ETestType.Several,
                Title = "no",
            });
            optionsSeveralList.Add(new TestOptionModel
            {
                Id = 2,
                OptionType = ETestType.Several,
                Title = "maybe",
            });
            optionsSeveralList.Add(new TestOptionModel
            {
                Id = 3,
                OptionType = ETestType.Several,
                Title = "0",
            });
            optionsSeveralList.Add(new TestOptionModel
            {
                Id = 4,
                OptionType = ETestType.Several,
                Title = "1",
                IsCorrect = true,
            });

            var optionsSingleList = new List<TestOptionModel>();
            optionsSingleList.Add(new TestOptionModel
            {
                Id = 0,
                OptionType = ETestType.Single,
                Title = "yes",
                IsCorrect = true,
            });
            optionsSingleList.Add(new TestOptionModel
            {
                Id = 1,
                OptionType = ETestType.Single,
                Title = "no",
            });
            optionsSingleList.Add(new TestOptionModel
            {
                Id = 2,
                OptionType = ETestType.Single,
                Title = "maybe",
            });
            optionsSingleList.Add(new TestOptionModel
            {
                Id = 3,
                OptionType = ETestType.Single,
                Title = "0",
            });
            optionsSingleList.Add(new TestOptionModel
            {
                Id = 4,
                OptionType = ETestType.Single,
                Title = "1",
            });

            //Tests
            var testsList = new List<TestModel>();
            testsList.Add(new TestModel
            {
                Question = "Test question single?",
                Options = optionsSingleList,
            });
            testsList.Add(new TestModel
            {
                Question = "Test question several?",
                Options = optionsSeveralList,
            });

            //SubTheme
            var list = new List<SubThemeModel>();
            list.Add(new SubThemeModel
            {
                Tests = testsList,
                Title = "Subtheme title",
                TestTitle = "Testtitle",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. In nisl nisi scelerisque eu ultrices. Integer feugiat scelerisque varius morbi enim nunc. Enim nulla aliquet porttitor lacus. Egestas purus viverra accumsan in nisl nisi scelerisque eu ultrices. Enim diam vulputate ut pharetra sit amet aliquam. Aliquet lectus proin nibh nisl condimentum id venenatis. Non pulvinar neque laoreet suspendisse interdum consectetur libero id faucibus. At erat pellentesque adipiscing commodo. Pellentesque massa placerat duis ultricies lacus sed turpis tincidunt id. Dolor sed viverra ipsum nunc aliquet bibendum enim facilisis gravida. Mi eget mauris pharetra et. Aliquet porttitor lacus luctus accumsan tortor posuere ac. Interdum velit euismod in pellentesque massa placerat duis ultricies. Dis parturient montes nascetur ridiculus mus mauris vitae ultricies. Lobortis mattis aliquam faucibus purus in massa tempor nec feugiat. Aliquet lectus proin nibh nisl condimentum id venenatis a condimentum. Non nisi est sit amet facilisis magna etiam tempor. Elementum sagittis vitae et leo duis. Nulla facilisi etiam dignissim diam.",
            });
            list.Add(new SubThemeModel
            {
                Tests = testsList,
                Title = "Subtheme title",
                TestTitle = "Testtitle",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. In nisl nisi scelerisque eu ultrices. Integer feugiat scelerisque varius morbi enim nunc. Enim nulla aliquet porttitor lacus. Egestas purus viverra accumsan in nisl nisi scelerisque eu ultrices. Enim diam vulputate ut pharetra sit amet aliquam. Aliquet lectus proin nibh nisl condimentum id venenatis. Non pulvinar neque laoreet suspendisse interdum consectetur libero id faucibus. At erat pellentesque adipiscing commodo. Pellentesque massa placerat duis ultricies lacus sed turpis tincidunt id. Dolor sed viverra ipsum nunc aliquet bibendum enim facilisis gravida. Mi eget mauris pharetra et. Aliquet porttitor lacus luctus accumsan tortor posuere ac. Interdum velit euismod in pellentesque massa placerat duis ultricies. Dis parturient montes nascetur ridiculus mus mauris vitae ultricies. Lobortis mattis aliquam faucibus purus in massa tempor nec feugiat. Aliquet lectus proin nibh nisl condimentum id venenatis a condimentum. Non nisi est sit amet facilisis magna etiam tempor. Elementum sagittis vitae et leo duis. Nulla facilisi etiam dignissim diam.",
            });
            list.Add(new SubThemeModel
            {
                Tests = testsList,
                Title = "Subtheme title",
                TestTitle = "Testtitle",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. In nisl nisi scelerisque eu ultrices. Integer feugiat scelerisque varius morbi enim nunc. Enim nulla aliquet porttitor lacus. Egestas purus viverra accumsan in nisl nisi scelerisque eu ultrices. Enim diam vulputate ut pharetra sit amet aliquam. Aliquet lectus proin nibh nisl condimentum id venenatis. Non pulvinar neque laoreet suspendisse interdum consectetur libero id faucibus. At erat pellentesque adipiscing commodo. Pellentesque massa placerat duis ultricies lacus sed turpis tincidunt id. Dolor sed viverra ipsum nunc aliquet bibendum enim facilisis gravida. Mi eget mauris pharetra et. Aliquet porttitor lacus luctus accumsan tortor posuere ac. Interdum velit euismod in pellentesque massa placerat duis ultricies. Dis parturient montes nascetur ridiculus mus mauris vitae ultricies. Lobortis mattis aliquam faucibus purus in massa tempor nec feugiat. Aliquet lectus proin nibh nisl condimentum id venenatis a condimentum. Non nisi est sit amet facilisis magna etiam tempor. Elementum sagittis vitae et leo duis. Nulla facilisi etiam dignissim diam.",
            });
            list.Add(new SubThemeModel
            {
                Tests = testsList,
                Title = "Subtheme title",
                TestTitle = "Testtitle",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. In nisl nisi scelerisque eu ultrices. Integer feugiat scelerisque varius morbi enim nunc. Enim nulla aliquet porttitor lacus. Egestas purus viverra accumsan in nisl nisi scelerisque eu ultrices. Enim diam vulputate ut pharetra sit amet aliquam. Aliquet lectus proin nibh nisl condimentum id venenatis. Non pulvinar neque laoreet suspendisse interdum consectetur libero id faucibus. At erat pellentesque adipiscing commodo. Pellentesque massa placerat duis ultricies lacus sed turpis tincidunt id. Dolor sed viverra ipsum nunc aliquet bibendum enim facilisis gravida. Mi eget mauris pharetra et. Aliquet porttitor lacus luctus accumsan tortor posuere ac. Interdum velit euismod in pellentesque massa placerat duis ultricies. Dis parturient montes nascetur ridiculus mus mauris vitae ultricies. Lobortis mattis aliquam faucibus purus in massa tempor nec feugiat. Aliquet lectus proin nibh nisl condimentum id venenatis a condimentum. Non nisi est sit amet facilisis magna etiam tempor. Elementum sagittis vitae et leo duis. Nulla facilisi etiam dignissim diam.",
            });

            //Theme
            var collection = new List<ThemeModel>();
            collection.Add(new ThemeModel
            {
                Title = "Theme 1",
                SubThemes = list,
            });
            collection.Add(new ThemeModel
            {
                Title = "Theme 2",
                SubThemes = list,
            });
            collection.Add(new ThemeModel
            {
                Title = "Theme 3",
                SubThemes = list,
            });

            return collection;
        }
    }
}
