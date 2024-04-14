public class Document
{
	public Node body;
	
	public Document(Node[] nodes)
	{
		body = new ElementNode(new ElementData("body", new Dictionary<string, string>()), nodes);
		body.margin = new Margin(16, 8, 8, 8);
		
		AssignParents(body);
	}

	private void AssignParents(Node node)
	{
		foreach (var child in node.children)
		{
			child.parent = node;
			AssignParents(child);
		}
	}
}
