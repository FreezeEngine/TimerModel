using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TimerModel;
using TimerModel.Objects;

namespace CompetitionOrganizer.Objects
{
    public class TreeDrawer
    {
        public static void DrawCompetitionStructure(TreeView view, List<CompetingModels> competingModels = null, Competition competition = null)
        {
            view.Nodes.Clear();
            view.Nodes.Add("Соревнование");
            int c = 0;
            var TCLs = competingModels == null ? TimerSettings.Competition.Teams.TeamClumps : competingModels;
            foreach (var TC in TCLs)
            {
                view.CheckBoxes = false;
                view.Nodes[0].Nodes.Add("Между моделями: " + TC.CompetingModel + " | Количество команд: " + TC.Teams(competition).Count);
                //view.Nodes[0].Nodes[c].Nodes.Add("Туров в соревновании: " + TC.RoundsForThisClass.ToString());
                int d = 0;
                view.Nodes[0].Nodes[c].Nodes.Add("Команды:");
                var Ts = TC.Teams(competition);
                foreach (var T in Ts)
                {
                    view.Nodes[0].Nodes[c].Nodes[0].Nodes.Add(T.ToString());
                    view.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes.Add("Текущий тур: " + (T.CurrentRoundNum + 1).ToString());
                    view.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes.Add("Туры: ");
                    int b = 0;
                    //MessageBox.Show(T.Rounds.Count.ToString());
                    foreach (var TD in T.Rounds)
                    {
                        view.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes.Add("Тур - " + (b + 1).ToString());
                        if (TD.Laps.Count == 0)
                        {
                            view.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("В очереди");
                            b++;
                            continue;
                        }
                        view.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("Круги:");
                        int e = 0;
                        foreach (var TL in TD.Laps)
                        {
                            view.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes[0].Nodes.Add(TL.ToString());
                            e++;
                        }
                        view.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("Время: " + TD.RoundTTime());
                        view.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[b].Nodes.Add("Всего очков: " + TD.RoundPoints());

                        if (T.CurrentRound == TD)
                        {
                            if (!T.CurrentRound.Finished)
                            {
                                view.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[T.CurrentRoundNum].Nodes.Clear();
                                view.Nodes[0].Nodes[c].Nodes[0].Nodes[d].Nodes[1].Nodes[T.CurrentRoundNum].Nodes.Add("В ожидании");
                            }
                        }
                        b++;
                    }
                    d++;
                }
                c++;
            }
            view.Nodes[0].Expand();
        }
    }
}
