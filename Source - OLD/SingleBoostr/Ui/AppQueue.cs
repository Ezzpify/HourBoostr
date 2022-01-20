using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SingleBoostr.Core.Misc;

namespace SingleBoostr.Ui
{
    public partial class AppQueue : Form
    {
        public List<App> AppList;
        private App _currentApp;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
            Pen pen = new Pen(Misc.Utils.LABEL_HOVER);
            e.Graphics.DrawRectangle(pen, rect);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public AppQueue(List<App> queue, App current)
        {
            InitializeComponent();
            _currentApp = current;
            AppList = queue.Where(o => current.Appid != o.Appid).ToList();
            lblCurrentGame.Text = $"Current: {_currentApp.Name}";
        }

        private void QueueForm_Load(object sender, EventArgs e)
        {
            foreach (var app in AppList)
            {
                if (app == _currentApp)
                    continue;

                ListViewItem item = new ListViewItem();
                item.Text = $"{app.Card.Price.ToString("F")}$";
                item.SubItems.Add(Utils.Truncate(app.Name, 35));
                lvApps.Items.Add(item);
            }

            if (lvApps.Items.Count > 0)
            {
                lvApps.Columns[lvApps.Columns.Count - 1].Width = -2;
            }
            else
            {
                lblNoItems.Visible = true;
            }
        }

        private void picGoBack_MouseEnter(object sender, EventArgs e)
        {
            picGoBack.BackgroundImage = Properties.Resources.Back_Selected;
        }

        private void picGoBack_MouseLeave(object sender, EventArgs e)
        {
            picGoBack.BackgroundImage = Properties.Resources.Back;
        }

        private void QueueForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        private void picGoBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            AppList.Insert(0, _currentApp);
            Close();
        }

        private void lvApps_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Link);
        }

        private void lvApps_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void lvApps_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItem itemToDrag = lvApps.SelectedItems[0];
            if (itemToDrag == null)
                return;

            Point cp = lvApps.PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = lvApps.GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
                return;

            App app = AppList.FirstOrDefault(o => itemToDrag.SubItems[3].Text == o.Name);
            if (app != null)
            {
                int dropIndex = dragToItem.Index;
                lvApps.Items.Remove(itemToDrag);
                lvApps.Items.Insert(dropIndex, itemToDrag);

                AppList.Remove(app);
                AppList.Insert(dropIndex, app);
            }
        }
    }
}
