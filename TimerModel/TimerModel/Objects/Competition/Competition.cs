﻿using CompetitionOrganizer.Objects;
using CompetitionOrganizer.Objects.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using TimerModel.Objects;

namespace TimerModel
{

    public class Competition : IEquatable<Competition>
    {
        //public static int Round { get; set; }
        public bool Finished { get; set; }

        public string DateOfCreation { get; set; }

        [JsonIgnore]
        public List<Participant> Mechanics
        {
            get
            {
                var Mechanics = new List<Participant>();
                foreach (var T in Teams.GetTeams())
                {
                    if (T.Mechanic != null & (T.Mechanic?.Name) != null)
                    {
                        Mechanics.Add(T.Mechanic);
                    }
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
            DateOfCreation = DateTime.Now.ToString("D") + " " + DateTime.Now.ToString("H-mm-ss");
            Teams = new TeamContainer(new List<Team>());
        }
        public Competition(List<Team> LTeams)
        {
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
        public void FillOut()
        {
            foreach (var T in Teams.AllTeams)
            {
                foreach (var R in T.Rounds)
                {
                    R.RandomRound();
                    R.Finished = true;
                    R.BadFinish = false;
                }
            }
        }
        public void Finish(bool Recover = false, bool FinishEntirely = true)
        {
            BGSaver.SaveData();
            TimerSettings.Competition.Finished = FinishEntirely;
            //onCompetitionFinished();
            //return; //FIX
            //List<byte> MinRounds = new List<byte>();
            /*foreach (var T in TimerSettings.Competition.Teams.AllTeams)
            {
                //var Rc = 
                var BR = T.Rounds.FindAll(delegate (Round R) { return !R.Finished; });
                foreach (var R in BR)
                {
                    T.Rounds.Remove(R);
                }
                //MinRounds.Add((byte)T.Rounds.Count);
            }*/
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
            if (onCompetitionFinished != null)
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

            return (Mechanics.Equals(other.Mechanics) && Teams.Count.Equals(other.Teams.Count) && Teams.TeamClumps.Equals(other.Teams.TeamClumps));
        }
    }

}
