namespace RockPaperScissors;

enum SelectionType
{
    Next,
    Previous
}

class TerminalSelect<T>
{
    private Option<T>[] _options;
    private int? _selectedIndex = null;

    public TerminalSelect(Option<T>[] options, int? selectedIndex = null)
    {
        Console.WriteLine("options added");
        Array.ForEach(options, Console.WriteLine);

        _options = options;
        _selectedIndex = selectedIndex;
    }

    public void ListOptions()
    {
        for (int i = 0; i < _options.Length; i++)
        {
            if (_selectedIndex.HasValue)
            {
                _options[_selectedIndex.Value].IsSelected = true;
            }

            if (_options[i].IsSelected == true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            Console.WriteLine(_options[i].Text);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void SelectNext()
    {
        this.SelectOption(SelectionType.Next);
    }

    public void SelectPrevious()
    {
        this.SelectOption(SelectionType.Previous);
    }

    public Option<T> GetSelectedOption ()
    {
        return _options.First(i => i.IsSelected == true);
    }

    private void SelectOption(SelectionType type)
    {
        int? currentlySelectedIndex = null;

        for (int i = 0; i < _options.Length; i++)
        {
            if (_options[i].IsSelected == true)
            {
                currentlySelectedIndex = i;
            }

            _options[i].IsSelected = false;
        }

        int nextIndex = 0;

        if (currentlySelectedIndex.HasValue)
        {
            if (type == SelectionType.Next)
            {
                nextIndex = currentlySelectedIndex == _options.Length - 1 ? 0 : currentlySelectedIndex.Value + 1;
            }

            if (type == SelectionType.Previous)
            {
                nextIndex = currentlySelectedIndex == 0 ? _options.Length - 1 : currentlySelectedIndex.Value - 1;
            }
        }

        _options[nextIndex].IsSelected = true;
        _selectedIndex = nextIndex;
    }
}
