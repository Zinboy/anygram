using System;
using System.Drawing;
using System.Windows.Forms;

using Anygram2.Properties;


namespace Anygram2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void butGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ClearListBoxes();

                Words AnygramWords = new Words(txtLetters.Text.Trim());

                foreach (string word in AnygramWords.words)
                {
                    switch (word.Length)
                    {
                        case 3:
                            lst3.Items.Add(word);
                            break;
                        case 4:
                            lst4.Items.Add(word);
                            break;
                        case 5:
                            lst5.Items.Add(word);
                            break;
                        case 6:
                            lst6.Items.Add(word);
                            break;
                        case 7:
                            lst7.Items.Add(word);
                            break;
                        case 8:
                            lst8.Items.Add(word);
                            break;
                        case 9:
                            lst9.Items.Add(word);
                            break;
                    }
                }

                DisplayCounts(AnygramWords.Count());
                HighlightAnagrams();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating Anygrams\n" + ex.ToString(), "Anygram", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void DisplayCounts(int TotalWords)
        {
            lbl3.Text = $"3: {lst3.Items.Count}";
            lbl4.Text = $"4: {lst4.Items.Count}";
            lbl5.Text = $"5: {lst5.Items.Count}";
            lbl6.Text = $"6: {lst6.Items.Count}";
            lbl7.Text = $"7: {lst7.Items.Count}";
            lbl8.Text = $"8: {lst8.Items.Count}";
            lbl9.Text = $"9: {lst9.Items.Count}";

            lblFound.Text = $"Found {TotalWords} words";
        }

        private void HighlightAnagrams()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(System.Windows.Forms.Label))
                {
                    ((Label)ctrl).Font = new Font(this.Font, FontStyle.Regular);
                }
            }

            int len = txtLetters.Text.Trim().Length;

            switch (len) {
                case 3:
                    if (lst3.Items.Count > 1)
                    {
                        lbl3.Font = new Font(this.Font, FontStyle.Bold);
                    }                    
                    break;
                case 4:
                    if (lst4.Items.Count > 1)
                    {
                        lbl4.Font = new Font(this.Font, FontStyle.Bold);
                    }
                    break;
                case 5:
                    if (lst5.Items.Count > 1)
                    {
                        lbl5.Font = new Font(this.Font, FontStyle.Bold);
                    }
                    break;
                case 6:
                    if (lst6.Items.Count > 1)
                    {
                        lbl6.Font = new Font(this.Font, FontStyle.Bold);
                    }
                    break;
                case 7:
                    if (lst7.Items.Count > 1)
                    {
                        lbl7.Font = new Font(this.Font, FontStyle.Bold);
                    }
                    break;
                case 8:
                    if (lst8.Items.Count > 1)
                    {
                        lbl8.Font = new Font(this.Font, FontStyle.Bold);
                    }
                    break;
                case 9:
                    if (lst9.Items.Count > 1)
                    {
                        lbl9.Font = new Font(this.Font, FontStyle.Bold);
                    }
                    break;
            }
        }

        private void ClearListBoxes()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(System.Windows.Forms.ListBox))
                {
                    ((ListBox)ctrl).Items.Clear();
                }
            }
        }

        private void txtLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true)
            {
                return;
            }
            if (char.IsControl(e.KeyChar) == true)
            {
                // we want to allow for things like backspace and pasting
                return;
            }

            // throws away anything else
            e.Handled = true;
            return;
        }

        private void txtLetters_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                txtLetters.SelectAll();
            }
        }

        private void txtLetters_Enter(object sender, EventArgs e)
        {
            txtLetters.SelectAll();
        }


        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                return;
            }

            if (this.Width > 808 )
            {
                this.Width = 808;
            }
            if (this.Height < 200)
            {
                this.Height = 200;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowLocation = this.Location;
                Settings.Default.WindowSize = this.Size;
                Settings.Default.Save();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Settings.Default.WindowLocation != null)
            {
                this.Location = Settings.Default.WindowLocation;
                this.Size = Settings.Default.WindowSize;
            }
        }

    }
}
