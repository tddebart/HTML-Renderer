using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class MainWindow
{
	private readonly RenderWindow window;

	public MainWindow()
	{
		// Create a window
		window = new RenderWindow(new VideoMode(1280, 720), "SFML Box with Text Example");
		window.SetVerticalSyncEnabled(true);

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
			Position = new Vector2f(360, 260),
			CharacterSize = 24,
			FillColor = Color.White
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
			window.Clear(Color.Black);

			// Draw the box
			window.Draw(box);

			var elapsedTime = clock.ElapsedTime.AsSeconds();
			var pulsateValue = (float)(Math.Sin(elapsedTime * pulsateSpeed) * pulsateScale + 1);
			text.CharacterSize = (uint)(baseSize * pulsateValue);

			// Draw the text
			window.Draw(text);

			// Display the window
			window.Display();
		}
	}
}
