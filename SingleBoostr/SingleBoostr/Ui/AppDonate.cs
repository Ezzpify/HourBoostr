using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using SingleBoostr.Core;

namespace SingleBoostr.Ui
{
    public partial class AppDonate : Form
    {
        public class DonationHolder
        {
            public string Paypal { get; set; }

            public string Bitcoin { get; set; }
        }

        private DonationHolder _donationHolder;

        public AppDonate()
        {
            InitializeComponent();
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1));
            Pen pen = new Pen(Const.LABEL_HOVER);
            e.Graphics.DrawRectangle(pen, rect);
        }

        private void DonateForm_Load(object sender, EventArgs e)
        {
            BgwGetInfo.RunWorkerAsync();
        }

        private void picGoBack_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void picGoBack_MouseEnter(object sender, EventArgs e)
        {
            picGoBack.BackgroundImage = Properties.Resources.Back_Selected;
        }

        private void picGoBack_MouseLeave(object sender, EventArgs e)
        {
            picGoBack.BackgroundImage = Properties.Resources.Back;
        }

        private void LblPaypalLink_MouseEnter(object sender, EventArgs e)
        {
            LblPaypalLink.ForeColor = Const.LABEL_HOVER;
        }

        private void LblPaypalLink_MouseLeave(object sender, EventArgs e)
        {
            LblPaypalLink.ForeColor = Const.LABEL_NORMAL;
        }

        private void LblPaypalLink_Click(object sender, EventArgs e)
        {
            Process.Start(_donationHolder.Paypal);
        }

        private void BgwGetInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            var req = new RestRequest();
            var resp = new RestClient(Const.DONATION_URL).Execute(req);

            if (resp.StatusCode != HttpStatusCode.OK)
                return;

            _donationHolder = JsonConvert.DeserializeObject<DonationHolder>(resp.Content);
        }

        private void BgwGetInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TxtBtcAdress.Text = _donationHolder.Bitcoin;
            LblPaypalLink.Text = _donationHolder.Paypal;

            LblLoadingNotice.Visible = false;
            PanelBitcoin.Visible = true;
            PanelPaypal.Visible = true;

            TxtBtcAdress.SelectAll();
            TxtBtcAdress.SelectionAlignment = HorizontalAlignment.Center;

            picGif.Image = Properties.Resources.animation;
        }
    }
}
