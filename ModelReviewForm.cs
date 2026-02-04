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
            var pos = this.Location;
            this.Location = new Point(pos.X + 570, pos.Y - 250);
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
            var result = string.Empty;
            if (e.Button == MouseButtons.Left && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                result = ShowCommentDialog();

            }

            ChangeClass("1");
            ChangeComment(result);
        }

        private static void ChangeComment(string result)
        {
            MessageBox.Show(result);
        }

        private static string ShowCommentDialog()
        {
            using (var form = new Form())
            using (var textBox = new TextBox())
            {
                form.Text = "Enter new value for the comment and press enter ...";
                form.StartPosition = FormStartPosition.CenterParent;

                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.ClientSize = new Size(450, 70);
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.TopMost = true;

                textBox.Multiline = false;
                textBox.SetBounds(20, 20, 400, 20);

                textBox.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        form.DialogResult = DialogResult.OK;
                        form.Close();
                    }

                    if (e.KeyCode == Keys.Escape)
                    {
                        form.DialogResult = DialogResult.Cancel;
                        form.Close();
                    }
                };

                form.Controls.Add(textBox);

                return form.ShowDialog() == DialogResult.OK ? textBox.Text : null;
            }
        }
    }
}
