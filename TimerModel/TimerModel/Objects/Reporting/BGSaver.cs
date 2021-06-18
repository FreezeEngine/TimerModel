
//using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using System.Threading;
using TimerModel;

namespace CompetitionOrganizer.Objects.Reporting
{
    public class BGSaver
    {
        public static void SaveData()
        {
            //return;
            var Saver = new Thread(new ThreadStart(() =>
            {
                TimerSettings.MakeEnvironment();
                Directory.CreateDirectory(Path.Combine(TimerSettings.CurrentProjectFolder));

                var ProjectFile = File.CreateText(Path.Combine(TimerSettings.CurrentProjectFolder, TimerSettings.Container.Name + ".json"));

                //string data = TimerSettings.jsonEngine ? : JsonSerializer.Serialize(TimerSettings.Container);
                //JsonSerializer.Serialize(TimerSettings.Container)
                ProjectFile.Write(JsonSerializer.Serialize(TimerSettings.Container));
                //ProjectFile.Write(JsonConvert.SerializeObject(TimerSettings.Container));

                ProjectFile.Close();
            }));
            Saver.IsBackground = true;
            Saver.Start();
        }

        public void MergeActiveProject()
        {
            //var RR = TimerSettings.Container.GetCombined();
        }
    }
}
