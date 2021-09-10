using System;

namespace CompetitionOrganizer.Objects
{
    public class Participant : IEquatable<Participant>
    {
        public string Name { get; set; }
        //public byte UniqueCode { get; set; }
        //public ParticipantType Type { get; set; }

        public Participant()
        {
        }
        public Participant(string Name = "")
        {
            //UniqueCode = (byte)new Random().Next(0, 255);
            this.Name = Name;
            //Type = IsPilot ? ParticipantType.Pilot : ParticipantType.Mechanic;
        }
        public override string ToString()
        {
            return Name;
        }
        public string ShortenName()
        {
            string ShortenName = "";
            if (Name == null)
            {
                return null;
            }
            var ExplodedName = Name.Split(" ");
            if (ExplodedName.Length > 1)
            {
                ShortenName = ExplodedName[0] + " ";
                for (int i = 1; i < ExplodedName.Length; i++)
                {
                    if (ExplodedName[i] == "")
                    {
                        continue;
                    }
                    ShortenName += ExplodedName[i][0] + ".";
                }
            }
            return ShortenName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Participant objAsPart = obj as Participant;
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
        public bool Equals(Participant other)
        {
            if (other == null | other.Name == null | Name == null)
            {
                return false;
            }

            return (Name.Equals(other.Name));
        }
    }
}
