using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TimerModel.Forms.Team_Managers
{
    public partial class Refly : Form
    {
        public bool CloseForm = false;

        //public event FormEvents onRealClose;
        //public delegate void FormEvents();
        public Refly()
        {
            InitializeComponent();
            ListOfTeams.Items.AddRange(Competition.Teams.GetTeams().ToArray());
            ListOfTeams.SelectedIndex = 0;
        }
        private void UpdateReflyStatus()
        {
            List<Team> Ts = Competition.Teams.GetTeams();
            foreach (var T in Ts)
            {
                foreach (var R in T.Rounds)
                {
                    if (!R.Finished)
                    {
                        SubmitRefly.Enabled = true;
                        return;
                    }
                }
            }
        }
        private void ListOfTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListOfTeams.SelectedItem != null)
            {
                //Submit.Enabled = true;
                Team T = (Team)ListOfTeams.SelectedItem;
                PilotL.Text = "Пилот: " + T.GetShortPilotName();
                MechanicL.Text = "Механик: " + T.GetShortMechanicName();
                TeamL.Text = "Команда: " + T.TeamName;
                //SubmitRefly.Enabled = true;
                List<byte> RTR = new List<byte>();

                for (byte i = 0; i < T.Rounds.Count; i++)
                {
                    if (!T.Rounds[i].Finished)
                    {
                        RTR.Add((byte)(i + 1));
                    }
                }
                RoundsToRefly.Text = string.Join(',', RTR);
                Submit.Enabled = true;
            }
            else
            {
                PilotL.Text = "Пилот: Не выбрано";
                MechanicL.Text = "Механик: Не выбрано";
                TeamL.Text = "Команда: Не выбрано";
                Submit.Enabled = false;
                RoundsToRefly.Text = "";
            }
        }

        private void SubmitRefly_Click(object sender, EventArgs e)
        {
            CloseForm = true;
            Close();
        }

        private void Submit_Click(object sender, EventArgs e)
        {

            Submit.Enabled = false;
            if (RoundsToRefly.Text != "")
            {
                var RTRI = RoundsToRefly.Text.Split(",");
                if (RTRI.Length == 0)
                {
                    Submit.Enabled = true;
                    return;
                }
                Team T = (Team)ListOfTeams.SelectedItem;
                foreach (var i in RTRI)
                {
                    try
                    {
                        byte index = Convert.ToByte(i);
                        if(index > T.Rounds.Count)
                        {
                            MessageBox.Show("Номер тура превысил количество туров для команды");
                            return;
                        }
                        //T.CurrentRoundNum = --index;
                        T.SelectRound(index);
                        T.Reset();
                    }
                    catch
                    {
                        Submit.Enabled = true;
                        MessageBox.Show("Проверьте правильность перечисления туров: целые числа через запятую без пробелов");
                        return;
                    }
                }
                
                T.CurrentRoundNum = (byte)(Convert.ToByte(RTRI[0]) - 1);
            }
            UpdateReflyStatus();
            //Submit.Enabled = true;
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            CloseForm = false;
            Close();
        }
    }
}
