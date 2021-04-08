using System;
using System.Collections.Generic;
using System.Text;

namespace TimerModel
{
    public class Team : IEquatable<Team>
    {
        public string Pilot { get; set; }
        public string Mechanic { get; set; }
        public string ModelName { get; set; }

        public bool Used = false;
        public bool Chosen = false;
        public override string ToString()
        {
            return "П: " + Pilot + " М: " + Mechanic + " FM: "+ModelName;
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
            return 0;
        }
        public bool Equals(Team other)
        {
            if (other == null) return false;
            return (this.Pilot.Equals(other.Pilot));
        }

    }
}
