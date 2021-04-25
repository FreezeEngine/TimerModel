using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace TimerModel
{
    public class Team : IEquatable<Team>
    {
        private string _TeamName;
        public string TeamName { get { if (_Pilot == null) { return "Без имени"; } else { return _TeamName; } } set { _TeamName = value; } }

        private string _Pilot;
        public string Pilot { get { if (_Pilot == null) { return "Без пилота"; } else { return _Pilot; } } set { _Pilot = value; } }

        private string _Mechanic;
        public string Mechanic { get { if (_Mechanic == null) { return "Без механика"; } else { return _Mechanic; } } set { _Mechanic = value; } }
        public string ModelName { get; set; }

        public List<Round> _Rounds;
        public List<Round> Rounds
        {
            get
            {
                if (_Rounds == null)
                {
                    _Rounds = new List<Round>();
                }
                return _Rounds;
            }
            private set
            {
                _Rounds = value;
            }
        }

        public bool Finished { get; set; }
        public bool Enabled { get; set; }


        public Team()
        {
            Rounds.Add(new Round());
            Enabled = true;
        }
        public void NextRound()
        {
            Rounds.Add(new Round());
        }
        public void Reset()
        {
            Rounds = new List<Round>();
            Rounds.Add(new Round());
            Finished = false;
        }
        public override string ToString()
        {
            return "П: " + Pilot + " М: " + Mechanic + " FM: " + ModelName + " T: " + TeamName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Team objAsPart = obj as Team;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public bool Equals(Team other)
        {
            if (other == null) return false;
            return (Pilot.Equals(other.Pilot));
        }
    }
}
