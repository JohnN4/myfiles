using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace RemoteTypist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, string lParam);
        const int WM_SETTEXT = 0x000c;

        int number = 0;
        public MainWindow()
        {
            InitializeComponent();
            Bottom.Content = $"# Message Sent: {0}";
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Process[] process = Process.GetProcessesByName("notepad");
            if (process.Length == 0)
            {
                Label.Content = "Notepad Located. Start Typing!";
                Process.Start("notepad.exe");
                Thread.Sleep(150);
                IntPtr window = Process.GetCurrentProcess().MainWindowHandle;
                SetForegroundWindow(window);
                Text.Focus();
            }
        }

        private void Text_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Process[] myprocess = Process.GetProcessesByName("notepad");

            if (myprocess.Length != 0)
            {
                number++;
                Bottom.Content = $"# Message Sent: {number}";
                IntPtr notepad = FindWindowEx(myprocess[0].MainWindowHandle, IntPtr.Zero, "edit", null);
                SendMessage(notepad, WM_SETTEXT, 0, Text.Text);
            }
        }
    }
}
