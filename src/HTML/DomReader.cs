
using System.Xml;

public static class DomReader
{
	public static Document CreateDocument(string filePath)
	{
		var xmlString = File.ReadAllText(filePath);
		
		var xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(xmlString);

		var body = xmlDoc.GetElementsByTagName("body").Item(0);
		if (body == null)
		{
			throw new Exception($"HTML file \"{filePath}\" does not contain a body");
		}

		//TODO: write own xmlParser
		var nodes = new List<Node>();
		foreach (XmlNode node in body)
		{
			nodes.Add(createNode(node));
		}

		return new Document(nodes.ToArray());
	}

	private static Node createNode(XmlNode element)
	{
		var nodeChildren = new List<Node>();

		foreach (XmlNode child in element.ChildNodes)
		{
			nodeChildren.Add(createNode(child));
		}

		if (element is XmlText)
		{
			return new TextNode(element.InnerText);
		}
		else
		{
			return new ElementNode(new ElementData(element.Name, new Dictionary<string, string>()), nodeChildren.ToArray());
		}

	}
}

