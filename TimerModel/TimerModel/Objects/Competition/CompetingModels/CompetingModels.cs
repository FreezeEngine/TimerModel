using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TimerModel.Objects
{
    public class CompetingModels : IEquatable<CompetingModels>
    {
        //public int Round { get; set; }
        private int _RoundsForThisClass = Rules.MinRounds;
        public int RoundsForThisClass { get { return _RoundsForThisClass; } set { if (Rules.MinRounds <= value && value <= Rules.MaxRounds) { _RoundsForThisClass = value; }; } }

        private int _LapsCount = Rules.MinLaps;
        public int LapsCount { get { return _LapsCount; } set { if (value <= Rules.MaxLaps && Rules.MinLaps <= value) { _LapsCount = value; } } }
        public string CompetingModel { get; set; }

        public List<Team> Teams = new List<Team>();
        /*public List<Team> Teams
        {
            get
            {
                List<Team> TeamsByModel = new List<Team>();
                TeamsByModel = Competition.Teams.Teams.FindAll(
            delegate (Team T)
            {
                return T.ModelName == CompetingModel;
            }
            );
                //if (TeamsByModel.Count != 0)
                return TeamsByModel;
            }
            set {
                Competition.Teams.Teams = value;
            }
        }*/
        public CompetingModels(List<Team> Teams)
        {
            foreach(var T in Teams)
            {
                Add(T);
            }
            UpdateRoundsCount();
        }
        public void SetLapsCount(int LapsCount)
        {
            if (LapsCount < this.LapsCount)
            {
                DialogResult dialogResult = MessageBox.Show("Изменение количества кругов в меньшую сторону приведёт к удалению сохранённых данных в удалённом круге, что так же приведёт к пересчету очков", "Предупреждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.LapsCount = LapsCount;
                    foreach (var T in Teams)
                    {
                        T.SetLapsCount(LapsCount);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }
        public void Add(Team Team)
        {
            Teams.Add(Team);
            Teams[^1].CM = this;
            Teams[^1].SetRoundsCount(RoundsForThisClass);
        }
        public void SetRoundsCount(int RoundsCount)
        {
            RoundsForThisClass = RoundsCount;
            UpdateRoundsCount();
        }
        private void UpdateRoundsCount()
        {
            foreach (var T in Teams)
            {
                T.SetRoundsCount(RoundsForThisClass);
            }
        }
        public override string ToString()
        {
            return CompetingModel;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            CompetingModels objAsPart = obj as CompetingModels;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public bool Equals(CompetingModels other)
        {
            if (other == null) return false;
            return (CompetingModel.Equals(other.CompetingModel));
        }
    }
}
