using CompetitionOrganizer.Objects;
using System;
using System.IO;
using System.Reflection;
using TimerModel.Objects.PrintMode;

namespace TimerModel
{
    public class TimerSettings
    {
        //public static bool jsonEngine = false;
        //public 
        //public static byte Laps;
        //public static byte AmountOfModels;
        //public static Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
        public static string MainFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string CompetitionProjects = Path.Combine(MainFolder, "Соревнования/");
        public static string CurrentProjectFolder { get; set; }

        public static byte RoundCount = 10;
        public static byte LapCount = 10;
        public static bool NoPrePrintAsking = false;
        public static PrintModes PrintMode = PrintModes.Horizontal;
        public static bool PrintingEnabled = true;
        public static bool DoubleClickProtectionEnabled = true;
        public static bool PrintFileGeneration = true;
        public static Single LabelsSize = 12F;

        public static byte CompetitionIndex { get; set; }
        //[JsonIgnore]
        public static Competition Competition;
        /*{
            get
            {
                return Container.PartsOfCompetitions[CompetitionIndex];
            }
            set
            {
                Container.PartsOfCompetitions[CompetitionIndex] = value;
            }
        }*/
        public static CompetitionsContainer Container { get; set; } //save this!!

        public static void ResetCompetition()
        {
            Competition = new Competition();
        }

        public static void MakeEnvironment()
        {
            if (!Directory.Exists(CompetitionProjects))
            {
                Directory.CreateDirectory(CompetitionProjects);
            }
        }

    }
}
