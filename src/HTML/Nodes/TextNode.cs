
public class TextNode : Node
{
	public const int DEFAULT_FONT_SIZE = 16;
	
	public string text;
	
	private int internalFontSize;
	public int fontSize => (int)MathF.Round(internalFontSize * DpiManager.GetNormalizedDpiForWindow(MainWindow.window));
	
	public TextNode(string text) : base([])
	{
		this.text = text;
		
		SetFontSize(DEFAULT_FONT_SIZE);
	}

	public void SetFontSize(int fontSize)
	{
		internalFontSize = fontSize;

		//TODO: move margin calc to only p tag
		margin.top = this.fontSize;
		margin.bottom = this.fontSize;
	}
	
}

