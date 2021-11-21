using System.Collections.Generic;
using System.Threading.Tasks;
using WinTests.Models.Theme;

namespace WinTests.Services.ThemeRepository
{
    public interface IThemeRepositoryService
    {
        public Task<IList<ThemeViewModel>> GetThemesCollectionAsync();
    }
}
