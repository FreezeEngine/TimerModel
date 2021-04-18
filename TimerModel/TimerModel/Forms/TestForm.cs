using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimerModel.Forms
{
    public partial class TestForm : Form
    {
        Competition Competition;
        public TestForm()
        {
            InitializeComponent();
            List<Team> Teams = new List<Team>();
            for(int i = 0; i < 5; i++)
            {
                Teams.Add(new Team() { Pilot = new Random().Next().ToString(), Mechanic = new Random().Next().ToString(), ModelName = new Random().Next().ToString() });
            }
            Competition = new Competition(Teams);
            LapCounter.Text = Competition.Round.ToString();
        }
        void UpdateData()
        {
            LapCounter.Text = Competition.Round.ToString();
        }
    }
}
