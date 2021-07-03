using CompetitionOrganizer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using TimerModel.Objects;

namespace TimerModel
{
    static class IListExtention
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            if (n <= 1)
            {
                return;
            }
            while (n > 1)
            {
                byte[] box = new byte[1];
                do
                {
                    provider.GetBytes(box);
                }
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static void ShuffleTeamSet<T>(this IList<T> list)
        {
            T v = list[0];
            list[0] = list[1];
            list[1] = list[2];
            list[2] = v;
        }
    }

    public class Competition : IEquatable<Competition>
    {
        //public static int Round { get; set; }


        //[JsonIgnore]
        public byte Key1 { get; set; }

        //[JsonIgnore]
        public byte Key2 { get; set; }

        public string DateOfCreation { get; set; }

        [JsonIgnore]
        public List<Participant> Mechanics
        {
            get
            {
                var Mechanics = new List<Participant>();
                foreach (var T in Teams.GetTeams())
                {
                    if (T.Mechanic == null | T.Mechanic?.Name == null)
                    {
                        continue;
                    }

                    Mechanics.Add(T.Mechanic);
                }
                //if(Mechanics.Count == 0)
                //{
                //MessageBox.Show("Не обнаружено ни одного механика. Выход из программы");
                //Environment.Exit(0);
                //}
                return Mechanics;
            }
        }
        public TeamContainer Teams { get; set; }//= new TeamContainer(new List<Team>());

        public delegate void CompetitionHandler();
        public event CompetitionHandler onCompetitionFinished;

        public Competition()
        {
            //AutoClosingMessageBox.Show("Test","Test", 4000);
            Key1 = (byte)new Random().Next(0, 255);
            Key2 = (byte)new Random().Next(0, 255);
            DateOfCreation = DateTime.Now.ToString("D") + " " + DateTime.Now.ToString("H-mm-ss");
            Teams = new TeamContainer(new List<Team>());
        }
        public Competition(List<Team> LTeams)
        {
            Key1 = (byte)new Random().Next(0, 255);
            Key2 = (byte)new Random().Next(0, 255);
            DateOfCreation = DateTime.Now.ToString("D") + " " + DateTime.Now.ToString("H-mm-ss");
            Teams = new TeamContainer(LTeams);
        }
        public void Lap(int ModelNum)
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

        public void Finish(bool Recover = false)
        {
            //onCompetitionFinished();
            //return; //FIX
            //List<byte> MinRounds = new List<byte>();
            foreach (var T in TimerSettings.Competition.Teams.AllTeams)
            {
                //var Rc = 
                var BR = T.Rounds.FindAll(delegate (Round R) { return !R.Finished; });
                foreach (var R in BR)
                {
                    T.Rounds.Remove(R);
                }
                //MinRounds.Add((byte)T.Rounds.Count);
            }
            //byte minr = MinRounds.ToArray().Min();
            if (!Recover)
            {
                foreach (var TC in TimerSettings.Competition.Teams.TeamClumps)
                {
                    List<byte> MinRounds = new List<byte>();
                    foreach (var T in TC.Teams())
                    {
                        MinRounds.Add((byte)T.Rounds.Count);
                    }
                    byte minr = MinRounds.ToArray().Min();

                    foreach (var T in TC.Teams())
                    {
                        T.SetRoundsCount(minr);
                    }
                }
            }
            else
            {
                foreach (var TC in TimerSettings.Competition.Teams.TeamClumps)
                {
                    List<byte> MaxRounds = new List<byte>();
                    foreach (var T in TC.Teams())
                    {
                        MaxRounds.Add((byte)T.Rounds.Count);
                    }
                    byte maxr = MaxRounds.ToArray().Max();

                    foreach (var T in TC.Teams())
                    {
                        T.SetRoundsCount(maxr);
                    }
                }
            }
            if(onCompetitionFinished != null)
            onCompetitionFinished();
        }

        public override string ToString()
        {
            return "Соревнование " + DateOfCreation;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Competition objAsPart = obj as Competition;
            if (objAsPart == null)
            {
                return false;
            }
            else
            {
                return Equals(objAsPart);
            }
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public bool Equals(Competition other)
        {
            if (other == null)
            {
                return false;
            }

            return (Mechanics.Equals(other.Mechanics) && Teams.Count.Equals(other.Teams.Count) && Teams.TeamClumps.Equals(other.Teams.TeamClumps) && Key1 == other.Key1 && Key2 == other.Key2);
        }
    }

}
