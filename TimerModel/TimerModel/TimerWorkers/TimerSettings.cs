using TimerModel.Objects.PrintMode;

namespace TimerModel
{
    class TimerSettings
    {
        //public 
        //public static byte Laps;
        //public static byte AmountOfModels;
        //public static Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
        public static byte RoundCount = 10;
        public static byte LapCount = 10;
        public static bool NoPrePrintAsking = false;
        public static PrintModes PrintMode = PrintModes.Horizontal;
        public static bool PrintingEnabled = true;
        public static bool DoubleClickProtectionEnabled = true;
        public static bool PrintFileGeneration = true;
    }
}
