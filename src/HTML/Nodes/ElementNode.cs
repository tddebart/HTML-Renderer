
public class ElementNode(ElementData elementData, Node[] children) : Node(children)
{
	public ElementData elementData = elementData;
}

public struct ElementData
{
	public string tagName;
	public Dictionary<string, string> attributes;

	public string id => attributes["id"];
	public string[] classes => attributes["class"].Split(" ");
}
