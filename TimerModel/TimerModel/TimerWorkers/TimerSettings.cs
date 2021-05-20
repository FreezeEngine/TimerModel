using TimerModel.Objects.PrintModes;

namespace TimerModel
{
    class TimerSettings
    {
        //public 
        //public static byte Laps;
        //public static byte AmountOfModels;
        public static byte RoundCount = 10;
        public static byte LapCount = 10;
        public static bool NoPrePrintAsking = false;
        public static bool VerticalPrint = false;
        public static PrintModes PrintMode = PrintModes.Horizontal;
    }
}
