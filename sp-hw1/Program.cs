using System;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("gdi32.dll")]
    static extern int GetDeviceCaps(IntPtr hdc, int Index);

    [DllImport("user32.dll")]
    static extern IntPtr GetDC(IntPtr hWnd);

    private static double GetScreenDiagonalUsingAPI()
    {
        //Дескриптор всего экрана
        IntPtr hdc = GetDC(IntPtr.Zero);

        double widthInInches = GetDeviceCaps(hdc, 4) / 25.4; //4 - HORZSIZE
        double heightInInches = GetDeviceCaps(hdc, 6) / 25.4; //6 - VERTSIZE

        double diagonalInInches = Math.Sqrt(Math.Pow(widthInInches, 2) + Math.Pow(heightInInches, 2));
        return diagonalInInches;
    }

    static void Main(string[] args)
    {
        double diagonal = GetScreenDiagonalUsingAPI();
        Console.WriteLine($"Screen diagonal: {diagonal:F1} inches");
        Console.ReadKey();
    }
}

