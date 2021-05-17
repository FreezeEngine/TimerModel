using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using TimerModel.Objects;
using TimerModel.Forms;
using System.Threading;

namespace TimerModel
{
    static class IListExtention
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            if(n <= 1)
            {
                return;
            }
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public class Competition
    {
        //public static int Round { get; set; }
        public static List<Mechanic> Mechanics
        {
            get
            {
                var Mechanics = new List<Mechanic>();
                foreach (var T in Teams.GetTeams())
                {
                    if (T.Mechanic == "Без механика")
                        continue;
                    Mechanics.Add(new Mechanic(T));
                }
                //if(Mechanics.Count == 0)
                //{
                //MessageBox.Show("Не обнаружено ни одного механика. Выход из программы");
                //Environment.Exit(0);
                //}
                return Mechanics;
            }
            set
            {
            }
        }
        public static TeamContainer Teams = new TeamContainer(new List<Team>());
        public Competition(List<Team> LTeams = null)
        {
            if (LTeams == null)
            {
                Teams = new TeamContainer(new List<Team>());
            }
            else
            {
                Teams = new TeamContainer(LTeams);
            }

            /*Teams.onTeamNewCycle += () =>
            {
                //Round = Round++;
            };*/

            /*Mechanics = new List<Mechanic>();
            foreach (var M in LTeams)
            {
                if (M.Mechanic == "Без механика")
                    continue;
                Mechanics.Add(new Mechanic(M));
            }
            if (Mechanics.Count == 0)
            {
                MessageBox.Show("Не обнаружено ни одного механика. Выход из программы");
                Environment.Exit(0);
            }*/
            //Delete
            //CompetitionManager CM = new CompetitionManager();
            //CM.Show();
        }
        public static void Lap(int ModelNum)
        {
            switch (ModelNum)
            {
                case 0:
                    if (Teams.First.Enabled)
                    {
                        Teams.First.CurrentRound.MakeLap(Teams.First.CM);
                    }
                    break;
                case 1:
                    if (Teams.Second.Enabled)
                    {
                        Teams.Second.CurrentRound.MakeLap(Teams.Second.CM);
                    }
                    break;
                case 2:
                    if (Teams.Third.Enabled)
                    {
                        Teams.Third.CurrentRound.MakeLap(Teams.Third.CM);
                    }
                    break;
            }
        }

        public override string ToString()
        {
            return "Соревнование";
        }
    }

}
