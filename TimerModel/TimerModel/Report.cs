using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimerModel
{
    class Report
    {

    }

    /*class Lap: IEquatable<Lap>
    {
        public string Pilot { get; set; }
        public string Mechanic { get; set; }
        public string ModelName { get; set; }
        public override string ToString()
        {
            return "П: " + Pilot + " М: " + Mechanic + " FM: " + ModelName;
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
        public bool Equals(Lap other)
        {
            if (other == null) return false;
            return (this.Pilot.Equals(other.Pilot));
        }
    }*/

    class TourReport
    {
        public string MainReferee  { get; set; }
        public string HeadOfAStart { get; set; }
        public string Secretary { get; set; }

        public byte[] Generate()
        {
            //List<FlyModel> List
            var Package = new ExcelPackage();
            var Sheet = Package.Workbook.Worksheets
        .Add("Отчёт");
            //int i = 1;
            Sheet.Column(1).Width = 2.7;
            Sheet.Column(2).Width = 5;
            Sheet.Column(3).Width = 22;
            Sheet.Column(4).Width = 16;

            Sheet.Row(1).Height = 27.75;
            Sheet.Row(2).Height = 42;
            Sheet.Row(3).Height = 26.25;
            Sheet.Row(4).Height = 18.75;
            Sheet.Row(5).Height = 18.75;
            Sheet.Row(6).Height = 18.75;
            Sheet.Row(7).Height = 18.75;
            Sheet.Row(8).Height = 18.75;
            Sheet.Row(9).Height = 15.75;
            
            //Sheet.Row(8).Height = 18.75;
            //Sheet.Column(5).Width = 16;
            int s = 5;
            int teamsCount = 6;
            int i = 0;
            int b = 0;
            for (; i < 6; i++)
            {
                Sheet.Column(s+i).Width = 8;
                Sheet.Column(s+1+i).Width = 4;
                Sheet.Cells[9, s + i, 9, s + 1 + i].Merge = true;
                for(int c = 0; c < teamsCount; c++)
                {
                    Sheet.Cells[9 + c + c + 2, s + i, 9 + c + c + 2, s + 1 + i].Merge = true;
                }
                Sheet.Cells[9, s + i].Value = i + 1;

                Sheet.Cells[9, s + i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells[9, s + i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                s++;
            }
            int t = 10;
            for (; b < teamsCount; b++)
            {
                //1 - 10 cell
                //Sheet.Column(s + i).Width = 8;
                //Sheet.Column(s + 1 + i).Width = 4;
               // Sheet.Cells[9, s + i, 9, s + 1 + i].Merge = true;
                //Sheet.Cells[9, s + i].Value = i + 1;
                //s++;

                Sheet.Cells[t+b, 2, t+b+1, 2].Merge = true;

                Sheet.Cells[t + b, 4, t + b + 1, 4].Merge = true;

                Sheet.Cells[t + b, 4, t + b + 1, 4].Merge = true;

                Sheet.Cells[t + b, 2, t + b + 1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                Sheet.Cells[t + b, 2, t + b + 1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                Sheet.Cells[t + b, 2].Value = b + 1;

                Sheet.Cells[t + b, s+i, t + b + 1, s+i].Merge = true;
                Sheet.Cells[t + b, s + i+1, t + b + 1, s + i+1].Merge = true;

                t++;
            }
            var Table = Sheet.Cells[8,2, t+b-1 , s+i+1];
            Table.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            Table.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            Table.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            Table.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            Sheet.Cells[8, 4, t + b - 1, s + i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            Sheet.Cells[8, 4, t + b - 1, s + i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //Sheet.Cells[8, 2, t+b-1, s+i+1].Style.Border.BorderAround(ExcelBorderStyle.Thin);

            Sheet.Column(s+i).Width = 15.57;
            Sheet.Column(s+i+1).Width = 24.14;
            Sheet.Cells[1, 2, 1, 8].Merge = true;

            Sheet.Cells[1, 2].Value = "Главный судья: ";

            Sheet.Cells[3, 2, 3, s + i + 1].Merge = true;//ПРОТОКОЛ...
            Sheet.Cells[3, 2, 6, s + i + 1].Style.Font.Size = 20;
            Sheet.Cells[3, 2].Value = "ПРОТОКОЛ";
            Sheet.Cells[4, 2].Value = "соревнований по авиамодельному спорту";

            Sheet.Cells[8, 5].Value = "Туры";
            Sheet.Cells[8, 2].Value = "№";
            Sheet.Cells[8, 3].Value = "Экипаж";
            Sheet.Cells[8, 4].Value = "Команда";

            Sheet.Cells[8, s + i].Value = "Сумма";
            Sheet.Cells[8, s + i + 1].Value = "Место";

            Sheet.Cells[4, 2, 4, s + i + 1].Merge = true;
            Sheet.Cells[5, 2, 5, s + i + 1].Merge = true;
            Sheet.Cells[6, 2, 6, s + i + 1].Merge = true;

            Sheet.Cells[4, 2, 6, s + i + 1].Style.Font.Size = 14;

            Sheet.Cells[3, 2, 9, s + i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            Sheet.Cells[3, 2, 9, s + i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            Sheet.Cells[8, 5, 8, s + i - 1].Merge = true;

            Sheet.Cells[8, s + i, 9, s + i].Merge = true;
            Sheet.Cells[8, s + i + 1, 9, s + i + 1].Merge = true;


            Sheet.Cells[8, 2, 9, 2].Merge = true;
            Sheet.Cells[8, 3, 9, 3].Merge = true;
            Sheet.Cells[8, 4, 9, 4].Merge = true;
            //foreach (FlyModel Model in List)
            //{
            //Sheet.Cells[i, 1].Value = Model.Pilot;
            //Sheet.Cells[i, 2].Value = Model.Mechanic;
            //Sheet.Cells[i, 3].Value = Model.ModelName;
            //i++;
            //}
            return Package.GetAsByteArray();
        }
    }

    //public class ListOfTeams {
    //
    //}

    public class ListOfTeams
    {
        public byte[] Generate(List<Team> List)
        {
            var Package = new ExcelPackage();
            var Sheet = Package.Workbook.Worksheets
        .Add("Команды");
            int i = 1;
            foreach(Team team in List)
            {
                Sheet.Cells[i, 1].Value = team.Pilot;
                Sheet.Cells[i, 2].Value = team.Mechanic;
                Sheet.Cells[i, 3].Value = team.ModelName;
                i++;
            }
            return Package.GetAsByteArray();
        }
        //public void SaveFile()
        //{

        //}
    }
}
