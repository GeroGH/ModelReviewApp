using System.Drawing;
using System.Windows.Forms;
using Tekla.Structures.Model;
using TSMUI = Tekla.Structures.Model.UI;

namespace ModelReviewApp
{
    public partial class ModelReviewForm : Form
    {
        public ModelReviewForm()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
        }

        private static void ChangeClass(string partClass)
        {
            var model = new Model();
            var mos = new TSMUI.ModelObjectSelector();
            var moe = mos.GetSelectedObjects();

            while (moe.MoveNext())
            {
                var part = moe.Current as Part;
                if (part == null) { continue; }

                part.Class = partClass;
                part.Modify();
            }

            model.CommitChanges();
        }

        private void UnderReviewType1_Click(object sender, System.EventArgs e)
        {
            ChangeClass("13");
        }

        private void UnderReviewType2_Click(object sender, System.EventArgs e)
        {
            ChangeClass("2");
        }

        private void UnderReviewType3_Click(object sender, System.EventArgs e)
        {
            ChangeClass("9");
        }

        private void TempWorksReady_Click(object sender, System.EventArgs e)
        {
            ChangeClass("6");
        }

        private void ReadyToBeConected_Click(object sender, System.EventArgs e)
        {
            ChangeClass("3");
        }

        private void ModelReviewForm_Load(object sender, System.EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            var currentScreen = Screen.FromPoint(Cursor.Position);
            var workingArea = currentScreen.WorkingArea;
            this.Location = new Point(workingArea.Right - this.Width - 50, workingArea.Top + 150);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ChangeClass("13");
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            ChangeClass("2");
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            ChangeClass("9");
        }

        private void TempWorksReady_Click_1(object sender, System.EventArgs e)
        {
            ChangeClass("6");
        }

        private void ReadyForEditting_Click_1(object sender, System.EventArgs e)
        {
            ChangeClass("11");
        }

        private void Stage4Import_MouseClick(object sender, MouseEventArgs e)
        {

            ChangeClass("1");
        }
    }
}
