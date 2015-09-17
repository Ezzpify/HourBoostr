using System;
using System.Windows.Forms;

namespace HourBoostr
{
    public partial class Prompt : Form
    {
        private int startLocX;
        private int startLocY;

        public string info { get { return code.Text; } }

        public Prompt(string labelText, string boxText, int cx, int cy, bool password = false)
        {
            startLocX = cx;
            startLocY = cy;

            InitializeComponent();

            if (password)
                code.PasswordChar = '*';

            text.Text = labelText;
            code.Text = boxText;
        }

        private void Prompt_Load(object sender, EventArgs e)
        {
            SetDesktopLocation(startLocX, startLocY + 10);
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
