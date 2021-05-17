using System;
using System.Windows.Forms;

namespace TimerModel
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
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
                ExcelDataReadMode ChooseModeForm = new ExcelDataReadMode(openFileDialog.FileName);
                ChooseModeForm.Closed += (s, args) => Show();
                ChooseModeForm.Show();
            }
        }

        private void CreateList_Click(object sender, EventArgs e)
        {
            Hide();
            CreateListForm ListGen = new CreateListForm();
            ListGen.Closed += (s, args) => Show();
            ListGen.Show();
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }
    }
}
