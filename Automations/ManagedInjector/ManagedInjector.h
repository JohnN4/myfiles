#pragma once

__declspec(dllexport)
LRESULT __stdcall MessageHookProc(int nCode, WPARAM wparam, LPARAM lparam);

using namespace System;

namespace ManagedInjector {
	public ref class Injector
	{
	public:

		static void Launch(System::IntPtr windowHandle, System::String^ assemblyName, System::String^ className, System::String^ methodName);

		static void LogMessage(System::String^ message, bool append);
	};
}
