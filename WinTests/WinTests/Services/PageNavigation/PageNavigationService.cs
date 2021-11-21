using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace WinTests.Services.PageNavigation
{
    public class PageNavigationService : IPageNavigationService
    {
        private readonly Dictionary<Frame,Stack<Page>> navigationStack;
        private int? lastFrameId = null;

        public PageNavigationService()
        {
            navigationStack = new();
        }

        public void NavigateTo(Page page, Frame frame, object parameter = null)
        {
            if (page is not null && 
                frame is not null)
            {
                var key = frame.GetHashCode();

                var existFrame = navigationStack.Keys.FirstOrDefault(x => x.GetHashCode() == key);

                if (existFrame is null)
                {
                    var pages = new Stack<Page>();
                    pages.Push(page);

                    navigationStack.Add(frame, pages);

                    frame.NavigationService.Navigate(page, parameter);

                    lastFrameId = frame.GetHashCode();
                }
                else
                {
                    Stack<Page> pages;
                    navigationStack.TryGetValue(existFrame, out pages);

                    if (pages is null)
                    {
                        pages = new Stack<Page>();
                    }

                    pages.Push(page);
                    existFrame.Navigate(page, parameter);

                    lastFrameId = existFrame.GetHashCode();
                }
            }
        }

        public void NavigateTo(Page page, int id, object parameter = null)
        {
            if (page is not null)
            {
                var frame = navigationStack.Keys.FirstOrDefault(x => x.GetHashCode() == id);
                Stack<Page> pages;

                if (frame is not null)
                {
                    navigationStack.TryGetValue(frame, out pages);

                    if (pages is null)
                    {
                        pages = new Stack<Page>();
                    }

                    pages.Push(page);
                    frame.NavigationService.Navigate(page, parameter);

                    lastFrameId = frame.GetHashCode();
                }
            }
        }

        public void Clear(int id)
        {
            Stack<Page> pages;

            var frame = navigationStack.Keys.FirstOrDefault(x => x.GetHashCode() == id);

            if (frame is not null)
            {
                navigationStack.TryGetValue(frame, out pages);

                while (frame.NavigationService.CanGoBack)
                {
                    frame.NavigationService.GoBack();
                }

                pages?.Clear();
            }
        }

        public void GoBack(int id)
        {
            Stack<Page> pages;

            var frame = navigationStack.Keys.FirstOrDefault(x => x.GetHashCode() == id);

            if (frame?.NavigationService.CanGoBack ?? false)
            {
                navigationStack.TryGetValue(frame, out pages);

                frame.NavigationService.GoBack();
                pages?.Pop();

                lastFrameId = frame.GetHashCode();
            }
        }

        public void GoBack()
        {
            if (lastFrameId is not null)
            {
                Stack<Page> pages;
                
                var frame = navigationStack.Keys.FirstOrDefault(x => x.GetHashCode() == lastFrameId);

                if (frame?.NavigationService.CanGoBack ?? false)
                {
                    navigationStack.TryGetValue(frame, out pages);

                    frame.NavigationService.GoBack();
                    pages?.Pop();
                }
            }
        }

        public void GoBackToRoot(int id)
        {
            Stack<Page> pages;

            var frame = navigationStack.Keys.FirstOrDefault(x => x.GetHashCode() == id);

            if (frame?.NavigationService.CanGoBack ?? false)
            {
                navigationStack.TryGetValue(frame, out pages);

                while (pages.Count > 1)
                {
                    frame.NavigationService.GoBack();
                    pages?.Pop();
                }

                lastFrameId = frame.GetHashCode();
            }
        }

        public void GoBackToRoot()
        {
            if (lastFrameId is not null)
            {
                Stack<Page> pages;

                var frame = navigationStack.Keys.FirstOrDefault(x => x.GetHashCode() == lastFrameId);

                if (frame?.NavigationService.CanGoBack ?? false)
                {
                    navigationStack.TryGetValue(frame, out pages);

                    while (pages.Count > 1)
                    {
                        frame.NavigationService.GoBack();
                        pages?.Pop();
                    }
                }
            }
        }
    }
}
