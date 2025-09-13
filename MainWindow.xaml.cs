using System.Collections;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hP, IntPtr hC, string sC, string sW);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(EnumedWindow lpEnumFunc, ArrayList lParam);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public MainWindow()
        {
            InitializeComponent();
            SetAsDesktopChild();
            ToBackground();
            this.LocationChanged += MainWindow_LocationChanged;
            this.Activated += MainWindow_Activated;
        }

        private void MainWindow_Activated(object? sender, EventArgs e)
        {
            ToBackground();
        }

        private void ToBackground()
        {
            Screen activeMonitor = Screen.FromHandle(new WindowInteropHelper(this).Handle);

            SetWindowPos(new WindowInteropHelper(this).Handle,
                1,
                activeMonitor.WorkingArea.X,
                activeMonitor.WorkingArea.Y,
                activeMonitor.WorkingArea.Width,
                activeMonitor.WorkingArea.Height,
                0);
        }

        private void MainWindow_LocationChanged(object? sender, EventArgs e)
        {
            ToBackground();
        }

        public delegate bool EnumedWindow(IntPtr handleWindow, ArrayList handles);

        public static bool GetWindowHandle(IntPtr windowHandle, ArrayList
        windowHandles)
        {
            windowHandles.Add(windowHandle);
            return true;
        }

        private void SetAsDesktopChild()
        {
            ArrayList windowHandles = new ArrayList();
            EnumedWindow callBackPtr = GetWindowHandle;
            EnumWindows(callBackPtr, windowHandles);

            foreach (IntPtr windowHandle in windowHandles)
            {
                IntPtr hNextWin = FindWindowEx(windowHandle, IntPtr.Zero,
                "SHELLDLL_DefView", null);
                if (hNextWin != IntPtr.Zero)
                {
                    var interop = new WindowInteropHelper(this);
                    interop.EnsureHandle();
                    interop.Owner = hNextWin;
                }
            }
        }

    }
}