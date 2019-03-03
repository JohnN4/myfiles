#include "MainWindow.h"
#include <windows.h>

// Thanks to:  http://www.winprog.org/tutorial/

const char g_szClassName[] = "MyWin32WindowClass";

// The Window Procedure
LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
		case WM_CLOSE:
			DestroyWindow(hwnd);
			break;
		case WM_DESTROY:
			PostQuitMessage(0);
			break;
		default:
			return DefWindowProc(hwnd, msg, wParam, lParam);
	}
	return 0;
}

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
									 LPSTR lpCmdLine, int nCmdShow)
{
	WNDCLASSEX wc;
	HWND hwnd;
	MSG Msg;

	//Step 1: Registering the Window Class
	wc.cbSize = sizeof(WNDCLASSEX);
	wc.style = 0;
	wc.lpfnWndProc = WndProc;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hInstance = hInstance;
	wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = g_szClassName;
	wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

	if (!RegisterClassEx(&wc))
	{
		MessageBox(NULL, "Window Registration Failed!", "Error!",
							 MB_ICONEXCLAMATION | MB_OK);
		return 0;
	}

	// Step 2: Creating the Window
	hwnd = CreateWindowEx(
		WS_EX_CLIENTEDGE,
		g_szClassName,
		"My Very Own Window",
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, CW_USEDEFAULT, 400, 300,
		NULL, NULL, hInstance, NULL);

	if (hwnd == NULL)
	{
		MessageBox(NULL, "Window Creation Failed!", "Error!",
							 MB_ICONEXCLAMATION | MB_OK);
		return 0;
	}

	static HWND hwnd_st_u, hwnd_ed_u;
	int x, w, y, h;
	y = 7; h = 20;
	x = 7; w = 80;
	hwnd_st_u = CreateWindow("static", "ST_U",
													 WS_CHILD | WS_VISIBLE | WS_TABSTOP,
													 x, y, w, h,
													 hwnd, (HMENU)(501),
													 (HINSTANCE)GetWindowLongPtr(hwnd, GWLP_HINSTANCE), NULL);
	SetWindowText(hwnd_st_u, "Type Here:");

	y += 24; h = 220; w = 370;
	hwnd_ed_u = CreateWindow("edit", "",
													 WS_CHILD | WS_VISIBLE | WS_TABSTOP | WS_HSCROLL | WS_VSCROLL
													 | ES_LEFT | WS_BORDER | ES_MULTILINE | ES_AUTOHSCROLL | ES_AUTOVSCROLL,
													 x, y, w, h,
													 hwnd, (HMENU)(502),
													 (HINSTANCE)GetWindowLongPtr(hwnd, GWLP_HINSTANCE), NULL);

	ShowWindow(hwnd, nCmdShow);
	UpdateWindow(hwnd);

	// Step 3: The Message Loop
	while (GetMessage(&Msg, NULL, 0, 0) > 0)
	{
		TranslateMessage(&Msg);
		DispatchMessage(&Msg);
	}
	return Msg.wParam;
}