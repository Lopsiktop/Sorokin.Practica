using System.Windows.Controls;

namespace Sorokin.Practica.Windows.Utils;

public class PageSwitcher
{
    private readonly Frame _frame;
    private List<Page> _pages = new List<Page>();

    public PageSwitcher(Frame frame)
    {
        _frame = frame;
    }

    public void ShowPage<T>()
        where T : Page, new()
    {
        var page = _pages.SingleOrDefault(x => x is T);
        if (page == null)
        {
            page = new T();
            _pages.Add(page);
        }

        _frame.Navigate(page);
    }
}
