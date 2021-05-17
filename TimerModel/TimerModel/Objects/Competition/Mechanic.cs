using System;
using System.Collections.Generic;
using System.Text;

namespace TimerModel.Objects
{
    public class Mechanic : IEquatable<Mechanic>
    {
        public string MechanicName { get; set; }
        public override string ToString()
        {
            return MechanicName;
        }
        public Mechanic(Team Team)
        {
            MechanicName = Team.Mechanic;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Mechanic objAsPart = obj as Mechanic;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public bool Equals(Mechanic other)
        {
            if (other == null) return false;
            return (MechanicName.Equals(other.MechanicName));
        }
    }
}
