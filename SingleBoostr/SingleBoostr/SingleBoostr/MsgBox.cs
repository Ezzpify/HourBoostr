using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SingleBoostr
{
    public partial class MsgBox : Form
    {
        private static MsgBox _msgBox;
        private static DialogResult _dialogResult = DialogResult.Cancel;

        private List<Button> _buttons = new List<Button>();

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

        private MsgBox()
        {
            InitializeComponent();
        }

        private void PanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        private void PanelIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, Const.WM_NCLBUTTONDOWN, Const.HT_CAPTION, 0);
            }
        }

        public static void Show(string message)
        {
            _msgBox = new MsgBox();
            _msgBox.PanelHeaderLblMessage.Text = message;
            _msgBox.PanelHeaderLblTitle.Text = "";
            InitButtons(Buttons.OK);
            _msgBox.ShowDialog();
        }

        public static void Show(string message, string title)
        {
            _msgBox = new MsgBox();
            _msgBox.PanelHeaderLblMessage.Text = message;
            _msgBox.PanelHeaderLblTitle.Text = title;
            _msgBox.Text = title;
            InitButtons(Buttons.OK);
            _msgBox.Size = MessageSize(message);
            _msgBox.ShowDialog();
        }

        public static DialogResult Show(string message, string title, Buttons buttons)
        {
            _msgBox = new MsgBox();
            _msgBox.PanelHeaderLblMessage.Text = message;
            _msgBox.PanelHeaderLblTitle.Text = title;
            _msgBox.Text = title;

            InitButtons(buttons);

            _msgBox.Size = MessageSize(message);
            _msgBox.ShowDialog();

            return _dialogResult;
        }

        public static DialogResult Show(string message, string title, Buttons buttons, MsgIcon icon)
        {
            _msgBox = new MsgBox();
            _msgBox.PanelHeaderLblMessage.Text = message;
            _msgBox.PanelHeaderLblTitle.Text = title;
            _msgBox.Text = title;

            InitButtons(buttons);
            InitIcon(icon);

            _msgBox.Size = MessageSize(message);
            _msgBox.ShowDialog();

            return _dialogResult;
        }

        public static DialogResult Show(string message, string title, Buttons buttons, MsgIcon icon, Animate style)
        {
            _msgBox = new MsgBox();
            _msgBox.PanelHeaderLblMessage.Text = message;
            _msgBox.PanelHeaderLblTitle.Text = title;
            _msgBox.Text = title;
            _msgBox.Height = 0;

            InitButtons(buttons);
            InitIcon(icon);
            
            Size formSize = MessageSize(message);

            switch (style)
            {
                case Animate.SlideDown:
                    _msgBox.Size = new Size(formSize.Width, 0);
                    _msgBox.TmrAnim.Interval = 1;
                    _msgBox.TmrAnim.Tag = new AnimateMsgBox(formSize, style);
                    break;

                case Animate.FadeIn:
                    _msgBox.Size = formSize;
                    _msgBox.Opacity = 0;
                    _msgBox.TmrAnim.Interval = 20;
                    _msgBox.TmrAnim.Tag = new AnimateMsgBox(formSize, style);
                    break;

                case Animate.ZoomIn:
                    _msgBox.Size = new Size(formSize.Width + 100, formSize.Height + 100);
                    _msgBox.TmrAnim.Tag = new AnimateMsgBox(formSize, style);
                    _msgBox.TmrAnim.Interval = 1;
                    break;
            }

            _msgBox.Size = MessageSize(message);
            _msgBox.TmrAnim.Start();
            _msgBox.ShowDialog();

            return _dialogResult;
        }

        private void TmrAnim_Tick(object sender, EventArgs e)
        {
            AnimateMsgBox animate = (AnimateMsgBox)TmrAnim.Tag;
            switch (animate.Style)
            {
                case Animate.SlideDown:
                    if (_msgBox.Height < animate.FormSize.Height)
                    {
                        _msgBox.Height += 17;
                        _msgBox.Invalidate();
                    }
                    else
                    {
                        _msgBox.TmrAnim.Stop();
                        _msgBox.TmrAnim.Dispose();
                    }
                    break;

                case Animate.FadeIn:
                    if (_msgBox.Opacity < 1)
                    {
                        _msgBox.Opacity += 0.1;
                        _msgBox.Invalidate();
                    }
                    else
                    {
                        _msgBox.TmrAnim.Stop();
                        _msgBox.TmrAnim.Dispose();
                    }
                    break;

                case Animate.ZoomIn:
                    if (_msgBox.Width > animate.FormSize.Width)
                    {
                        _msgBox.Width -= 17;
                        _msgBox.Invalidate();
                    }
                    if (_msgBox.Height > animate.FormSize.Height)
                    {
                        _msgBox.Height -= 17;
                        _msgBox.Invalidate();
                    }
                    break;
            }
        }

        public enum Buttons
        {
            AbortRetryIgnore,
            OK,
            OKCancel,
            RetryCancel,
            YesNo,
            YesNoCancel,
            Fuck,
            Gotit
        }

        public enum MsgIcon
        {
            Application,
            Exclamation,
            Error,
            Warning,
            Info,
            Question,
            Shield,
            Search
        }

        public enum Animate
        {
            SlideDown,
            FadeIn,
            ZoomIn
        }

        private static void InitButtons(Buttons buttons)
        {
            switch (buttons)
            {
                case Buttons.AbortRetryIgnore:
                    _msgBox.InitAbortRetryIgnoreButtons();
                    break;

                case Buttons.OK:
                    _msgBox.InitOKButton();
                    break;

                case Buttons.OKCancel:
                    _msgBox.InitOKCancelButtons();
                    break;

                case Buttons.RetryCancel:
                    _msgBox.InitRetryCancelButtons();
                    break;

                case Buttons.YesNo:
                    _msgBox.InitYesNoButtons();
                    break;

                case Buttons.YesNoCancel:
                    _msgBox.InitYesNoCancelButtons();
                    break;

                case Buttons.Fuck:
                    _msgBox.InitFuckButton();
                    break;

                case Buttons.Gotit:
                    _msgBox.InitGotitButton();
                    break;
            }

            foreach (var btn in _msgBox._buttons)
            {
                btn.ForeColor = Const.LABEL_NORMAL;
                btn.Font = new Font("Segoe UI", 8);
                btn.Padding = new Padding(3);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Height = 30;
                btn.FlatAppearance.BorderColor = Const.LABEL_NORMAL;
                btn.Cursor = Cursors.Hand;
                btn.MouseEnter += Btn_MouseEnter;
                btn.MouseLeave += Btn_MouseLeave;
                
                _msgBox.PanelFooterFlow.Controls.Add(btn);
            }
        }

        private static void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Const.LABEL_NORMAL;
        }

        private static void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Const.LABEL_HOVER;
        }

        private static void InitIcon(MsgIcon icon)
        {
            switch (icon)
            {
                case MsgIcon.Application:
                    _msgBox.PanelIconPic.Image = SystemIcons.Application.ToBitmap();
                    break;

                case MsgIcon.Exclamation:
                    _msgBox.PanelIconPic.Image = SystemIcons.Exclamation.ToBitmap();
                    break;

                case MsgIcon.Error:
                    _msgBox.PanelIconPic.Image = SystemIcons.Error.ToBitmap();
                    break;

                case MsgIcon.Info:
                    _msgBox.PanelIconPic.Image = SystemIcons.Information.ToBitmap();
                    break;

                case MsgIcon.Question:
                    _msgBox.PanelIconPic.Image = SystemIcons.Question.ToBitmap();
                    break;

                case MsgIcon.Shield:
                    _msgBox.PanelIconPic.Image = SystemIcons.Shield.ToBitmap();
                    break;

                case MsgIcon.Warning:
                    _msgBox.PanelIconPic.Image = SystemIcons.Warning.ToBitmap();
                    break;
            }
        }

        private void InitAbortRetryIgnoreButtons()
        {
            Button btnAbort = new Button();
            btnAbort.Text = "Abort";
            btnAbort.Click += ButtonClick;

            Button btnRetry = new Button();
            btnRetry.Text = "Retry";
            btnRetry.Click += ButtonClick;

            Button btnIgnore = new Button();
            btnIgnore.Text = "Ignore";
            btnIgnore.Click += ButtonClick;

            _buttons.Add(btnAbort);
            _buttons.Add(btnRetry);
            _buttons.Add(btnIgnore);
        }

        private void InitOKButton()
        {
            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Click += ButtonClick;

            _buttons.Add(btnOK);
        }

        private void InitOKCancelButtons()
        {
            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Click += ButtonClick;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Click += ButtonClick;


            _buttons.Add(btnOK);
            _buttons.Add(btnCancel);
        }

        private void InitRetryCancelButtons()
        {
            Button btnRetry = new Button();
            btnRetry.Text = "OK";
            btnRetry.Click += ButtonClick;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Click += ButtonClick;


            _buttons.Add(btnRetry);
            _buttons.Add(btnCancel);
        }

        private void InitYesNoButtons()
        {
            Button btnYes = new Button();
            btnYes.Text = "Yes";
            btnYes.Click += ButtonClick;

            Button btnNo = new Button();
            btnNo.Text = "No";
            btnNo.Click += ButtonClick;


            _buttons.Add(btnYes);
            _buttons.Add(btnNo);
        }

        private void InitYesNoCancelButtons()
        {
            Button btnYes = new Button();
            btnYes.Text = "Abort";
            btnYes.Click += ButtonClick;

            Button btnNo = new Button();
            btnNo.Text = "Retry";
            btnNo.Click += ButtonClick;

            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Click += ButtonClick;

            _buttons.Add(btnYes);
            _buttons.Add(btnNo);
            _buttons.Add(btnCancel);
        }

        private void InitFuckButton()
        {
            Button btnFuck = new Button();
            btnFuck.Text = "Fuck";
            btnFuck.Click += ButtonClick;

            _buttons.Add(btnFuck);
        }

        private void InitGotitButton()
        {
            Button btnFuck = new Button();
            btnFuck.Text = "Got it!";
            btnFuck.Click += ButtonClick;

            _buttons.Add(btnFuck);
        }

        private static Size MessageSize(string message)
        {
            Graphics g = _msgBox.CreateGraphics();
            int width = 350;
            int height = 260;

            SizeF size = g.MeasureString(message, _msgBox.PanelHeaderLblMessage.Font);

            if (message.Length < 150)
            {
                if ((int)size.Width > 350)
                {
                    width = (int)size.Width;
                }
            }
            else
            {
                string[] groups = (from Match m in Regex.Matches(message, ".{1,180}") select m.Value).ToArray();
                int lines = groups.Length + 1;
                width = 700;
                height += (int)(size.Height + 10) * lines;
            }

            return new Size(width, height);
        }

        private static void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "Abort":
                    _dialogResult = DialogResult.Abort;
                    break;

                case "Retry":
                    _dialogResult = DialogResult.Retry;
                    break;

                case "Ignore":
                    _dialogResult = DialogResult.Ignore;
                    break;

                case "OK":
                case "Fuck":
                case "Got it!":
                    _dialogResult = DialogResult.OK;
                    break;

                case "Cancel":
                    _dialogResult = DialogResult.Cancel;
                    break;

                case "Yes":
                    _dialogResult = DialogResult.Yes;
                    break;

                case "No":
                    _dialogResult = DialogResult.No;
                    break;
            }

            _msgBox.Dispose();
        }

        class AnimateMsgBox
        {
            public Size FormSize;
            public Animate Style;

            public AnimateMsgBox(Size formSize, Animate style)
            {
                FormSize = formSize;
                Style = style;
            }
        }
    }
}
