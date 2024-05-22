public class Option<T>
{
	public string Text { get; set; } = String.Empty;
    public T Value { get; set; }
    public bool? IsSelected { get; set; }

    public Option(string text, T value)
    {
        Text = text;
        Value = value;
    }
}
