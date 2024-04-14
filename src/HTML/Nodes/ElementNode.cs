
public class ElementNode(ElementData elementData, Node[] children) : Node(children)
{
	public ElementData elementData = elementData;
}

public struct ElementData(string tagName, Dictionary<string, string> attributes)
{
	public string tagName = tagName;
	public Dictionary<string, string> attributes = attributes;

	public string id => attributes["id"];
	public string[] classes => attributes["class"].Split(" ");
}
