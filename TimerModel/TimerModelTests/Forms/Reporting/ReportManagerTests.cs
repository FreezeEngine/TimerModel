using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimerModel.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimerModel.Forms.Tests
{
    [TestClass()]
    public class ReportManagerTests
    {
        [TestMethod()]
        public void ReportManagerTest()
        {
            new Competition(new List<Team>() { new Team() { Pilot = new Random().Next().ToString(), Mechanic = new Random().Next().ToString(), ModelName = new Random().Next().ToString() } });
            for (int i = 0; i <= 20; i++)
            {
                Competition.Teams.Add(new Team() { Pilot = new Random().Next().ToString(), Mechanic = new Random().Next().ToString(), ModelName = new Random().Next().ToString() });
            }
            var RM = new ReportManager();
            RM.Show();
            RM.Closing += (a, s) => { Assert.Fail(); };
        }
    }
}