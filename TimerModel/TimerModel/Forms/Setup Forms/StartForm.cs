using CompetitionOrganizer.Forms.Setup_Forms;
using System;
using System.Windows.Forms;
using TimerModel.Forms;

namespace TimerModel
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            TopMost = true;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Таблицы Excel (*.xls *.xlsx)|*.xls; *xlsx|Текстовый файл (*.txt)|*.txt";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Hide();
                FileReadPlaceholder ChooseModeForm = new FileReadPlaceholder(openFileDialog.FileName);
                ChooseModeForm.Closed += (s, args) => { TimerSettings.ResetCompetition();/* Может убрать в др место? */ Show(); };
                ChooseModeForm.Show();
            }
        }

        private void CreateList_Click(object sender, EventArgs e)
        {
            //DEPRICATED?
            //Hide();
            //CreateListForm ListGen = new CreateListForm();
            //ListGen.Closed += (s, args) => Show();
            //ListGen.Show();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Settings ST = new Settings();
            ST.FormClosing += (s, a) => { Show(); };
            Hide();
            ST.Show();
        }

        private void ContinueCompetition_Click(object sender, EventArgs e)
        {
            Hide();
            OpenCompetition OCM = new OpenCompetition();
            OCM.Closed += (s, args) => Show();
            OCM.Show();
        }
    }
}
