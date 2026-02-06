using System;
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
            this.button1.Tag = ReviewClass.Gray;
            this.button2.Tag = ReviewClass.Orange;
            this.button3.Tag = ReviewClass.Red;
            this.button4.Tag = ReviewClass.Pink;
            this.button5.Tag = ReviewClass.Green;
            this.button6.Tag = ReviewClass.Yellow;
            this.button7.Tag = ReviewClass.Orange;
            this.button8.Tag = ReviewClass.Red;
            this.button9.Tag = ReviewClass.Pink;
            this.button10.Tag = ReviewClass.Blue;
            this.button11.Tag = ReviewClass.Yellow;
        }
        private void ModelReviewForm_Load(object sender, System.EventArgs e)
        {
            var currentScreen = Screen.FromPoint(Cursor.Position);
            var workingArea = currentScreen.WorkingArea;
            this.Location = new Point(workingArea.Right - this.Width - 50, workingArea.Top + 150);
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        private void ReviewClassButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag == null)
                return;

            var reviewClass = (ReviewClass)button.Tag;
            try
            {
                this.LockedUserInterface(true);
                ChangeClass(reviewClass);
            }
            finally
            {
                this.LockedUserInterface(false);
            }
        }
        private static void ChangeClass(ReviewClass reviewClass)
        {
            var model = new Model();
            if (!model.GetConnectionStatus())
                return;

            var selector = new TSMUI.ModelObjectSelector();
            var selectedObjects = selector.GetSelectedObjects();

            if (!selectedObjects.MoveNext())
                return;

            do
            {
                if (selectedObjects.Current is Part part)
                {
                    part.Class = ((int)reviewClass).ToString();
                    part.Modify();
                }
            }
            while (selectedObjects.MoveNext());

            model.CommitChanges();
        }
        private void LockedUserInterface(bool locked)
        {
            this.Enabled = !locked;
            Cursor.Current = locked ? Cursors.WaitCursor : Cursors.Default;
        }
    }
}
