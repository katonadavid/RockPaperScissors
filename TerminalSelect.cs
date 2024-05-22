namespace RockPaperScissors;

enum SelectionType
{
    Next,
    Previous
}

class TerminalSelect<T>
{
    private List<Option<T>> _options;
    private int? _selectedIndex = null;
    private string? _label;
    public delegate void OptionSelectedHandler(T selectedOption); 
    public event OptionSelectedHandler? OnOptionSelected;

    public TerminalSelect(List<Option<T>> options, string? label = null, int? selectedIndex = null)
    {
        _options = options;
        _selectedIndex = selectedIndex;
        _label = label;
    }

    public void PromptSelection()
    {
        var optionSelected = false;
        while (!optionSelected)
        {
            Console.Clear();
            Console.WriteLine($"{_label} \n");
            ListOptions();
            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.DownArrow:
                    SelectNext();
                    break;
                case ConsoleKey.UpArrow:
                    SelectPrevious();
                    break;
                case ConsoleKey.Enter:
                    optionSelected = true;
                    OnOptionSelected?.Invoke(this._options.Find(o => o.IsSelected == true).Value);
                    break;
            }
        }
    }

    private void ListOptions()
    {
        for (int i = 0; i < _options.Count; i++)
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

    private void SelectOption(SelectionType type)
    {
        int? currentlySelectedIndex = null;

        for (int i = 0; i < _options.Count; i++)
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
                nextIndex = currentlySelectedIndex == _options.Count - 1 ? 0 : currentlySelectedIndex.Value + 1;
            }

            if (type == SelectionType.Previous)
            {
                nextIndex = currentlySelectedIndex == 0 ? _options.Count - 1 : currentlySelectedIndex.Value - 1;
            }
        }

        _options[nextIndex].IsSelected = true;
        _selectedIndex = nextIndex;
    }
}
