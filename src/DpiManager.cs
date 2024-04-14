
using System.Runtime.InteropServices;
using SFML.Graphics;

public static class DpiManager
{
	[DllImport("SHCore.dll", SetLastError = true)]
	public static extern bool SetProcessDpiAwareness(PROCESS_DPI_AWARENESS awareness);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern uint GetDpiForWindow(IntPtr hwnd);

	public enum PROCESS_DPI_AWARENESS
	{
		Process_DPI_Unaware = 0,
		Process_System_DPI_Aware = 1,
		Process_Per_Monitor_DPI_Aware = 2
	}

	public static float GetNormalizedDpiForWindow(RenderWindow window)
	{
		return GetDpiForWindow(window.SystemHandle) / 96f;
	}
}

