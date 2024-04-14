using System.Runtime.InteropServices;
using ImGuiGeneral;
using ImGuiNET;
using static SDL2.SDL;
using static SDL2.SDL_ttf;

public class MainWindow
{
	public IntPtr window; 
	public IntPtr gl_context;
	private IntPtr sdlRenderer;
	public ImGuiGLRenderer imGuiRenderer;
	private IntPtr font;
	
	[DllImport("user32.dll", SetLastError=true)]
	static extern bool SetProcessDPIAware();
	
	public bool quit = false;

	private int textSize = 24;
	private int direction = 1;

	public MainWindow()
	{
		SetProcessDPIAware();
		(window, gl_context) = ImGuiGL.CreateWindowAndGLContext("My SDL Imgui window", 1280, 720);
		imGuiRenderer = new ImGuiGLRenderer(window, gl_context);
		sdlRenderer = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

		TTF_Init();
		
		while (!quit)
		{
			Update();
		}
		//
		// SDL_DestroyRenderer(imGuiRenderer);
		SDL_GL_DeleteContext(gl_context);
		SDL_DestroyWindow(window);
		TTF_Quit();
		SDL_Quit();
	}

	public void Update()
	{
		EventHandling();
		
		
		
		SDL_SetRenderDrawColor(sdlRenderer, 255, 255, 255, 255);
		SDL_RenderClear(sdlRenderer);

		// Render SDL text using SDL_ttf
		SDL_SetRenderDrawColor(sdlRenderer, 0, 0, 0, 255); // Set text color to black
		IntPtr surface = TTF_RenderText_Solid(font, "Hello, SDL_ttf!", new SDL_Color { r = 0, g = 255, b = 0, a = 255 });
		IntPtr texture = SDL_CreateTextureFromSurface(sdlRenderer, surface);
		SDL_FreeSurface(surface);

		SDL_Rect dstrect = new SDL_Rect { x = 100, y = 100, w = 200, h = 200 }; // Adjust size as needed
		SDL_RenderCopy(sdlRenderer, texture, IntPtr.Zero, ref dstrect);

		SDL_DestroyTexture(texture);

		// Start a new frame for ImGui
		imGuiRenderer.NewFrame();

		// Render ImGui content
		ImGui.Text("Hello, ImGui!");

		// Perform your game's rendering then render the ImGui data
		imGuiRenderer.Render();

		// Swap SDL window buffers to display the rendered ImGui on top of your SDL text
		SDL_GL_SwapWindow(window);
		
		SDL_Delay(10);
	}

	private void EventHandling()
	{
		while (SDL_PollEvent(out var _event) != 0)
		{
			imGuiRenderer.ProcessEvent(_event);
			switch (_event.type)
			{
				case SDL_EventType.SDL_QUIT:
					quit = true;
					break;
        			
				case SDL_EventType.SDL_KEYDOWN:
					if (_event.key.keysym.sym == SDL_Keycode.SDLK_ESCAPE)
					{
						quit = true;
					}

					break;
			}
		}
	}
}

