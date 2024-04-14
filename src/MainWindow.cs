using System.Runtime.InteropServices;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class MainWindow
{
	public static RenderWindow window;
	private readonly Document document;

	public MainWindow()
	{
		DpiManager.SetProcessDpiAwareness(DpiManager.PROCESS_DPI_AWARENESS.Process_Per_Monitor_DPI_Aware);
		
		// Create a window
		window = new RenderWindow(new VideoMode(1280, 720, 32), "SFML Box with Text Example");
		window.SetVerticalSyncEnabled(true);
		
		document = DomReader.CreateDocument("./tests/HTML-files/test1.html");

		// Load a font
		var font = new Font("Ubuntu-Regular.ttf");

		// Create a rectangle shape (box)
		var box = new RectangleShape(new Vector2f(200, 100))
		{
			Position = new Vector2f(350, 250),
			FillColor = Color.Red
		};

		// Create a text object
		var text = new Text(
			"Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime mollitia,\nmolestiae quas vel sint commodi repudiandae consequuntur voluptatum laborum\nnumquam blanditiis harum quisquam eius sed odit fugiat iusto fuga praesentium\noptio, eaque rerum! Provident similique accusantium nemo autem. Veritatis\nobcaecati tenetur iure eius earum ut molestias architecto voluptate aliquam\nnihil, eveniet aliquid culpa officia aut! Impedit sit sunt quaerat, odit,\ntenetur error, harum nesciunt ipsum debitis quas aliquid. Reprehenderit,\nquia. Quo neque error repudiandae fuga? Ipsa laudantium molestias eos \nsapiente officiis modi at sunt excepturi expedita sint? Sed quibusdam\nrecusandae alias error harum maxime adipisci amet laborum. Perspiciatis \nminima nesciunt dolorem! Officiis iure rerum voluptates a cumque velit \nquibusdam sed amet tempora. Sit laborum ab, eius fugit doloribus tenetur \nfugiat, temporibus enim commodi iusto libero magni deleniti quod quam \nconsequuntur! Commodi minima excepturi repudiandae velit hic maxime\ndoloremque. Quaerat provident commodi consectetur veniam similique ad \nearum omnis ipsum saepe, voluptas, hic voluptates pariatur est explicabo \nfugiat, dolorum eligendi quam cupiditate excepturi mollitia maiores labore \nsuscipit quas? Nulla, placeat. Voluptatem quaerat non architecto ab laudantium\nmodi minima sunt esse temporibus sint culpa, recusandae aliquam numquam \ntotam ratione voluptas quod exercitationem fuga. Possimus quis earum veniam \nquasi aliquam eligendi, placeat qui corporis!",
			font)
		{
			FillColor = Color.Black
		};

		window.Closed += (_, _) => { window.Close(); };

		window.Resized += (sender, e) =>
		{
			// Adjust the view to the new size of the window
			window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
		};

		float baseSize = 24; // Base size of the text
		var pulsateSpeed = 4f; // Speed of the pulsating effect
		var pulsateScale = 1f; // Scale of the pulsating effect

		var clock = new Clock();
		// Main loop
		while (window.IsOpen)
		{
			// Process events
			window.DispatchEvents();

			// Clear the window
			window.Clear(Color.White);

			Vector2i pos = new Vector2i(document.body.margin.left, document.body.margin.top);

			foreach (var node in document.body.children)
			{
				if (node is ElementNode element)
				{
					if (element.elementData.tagName == "p")
					{
						var textNode = element.children.First() as TextNode; 
						
						text.Position = new Vector2f(pos.X, pos.Y);
						text.CharacterSize = (uint)textNode.fontSize;
						text.DisplayedString = textNode.text;
						
						window.Draw(text);

						pos = new Vector2i(pos.X, pos.Y + (int)text.GetLocalBounds().Height + textNode.margin.bottom);
					}
				}
			}

			// Display the window
			window.Display();
		}
	}
}
