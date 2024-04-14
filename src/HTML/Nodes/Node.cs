public class Node(Node[] children)
{
	public Node[] children = children;
	public Node? parent = null;

	public Margin margin = new Margin();
}

public struct Margin(int top = 0, int right = 0, int bottom = 0, int left = 0)
{
	public int top = top;
	public int right = right;
	public int bottom = bottom;
	public int left = left;
}

