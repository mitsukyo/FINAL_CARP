using RSCSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2CARPENELLI
{
    public partial class ViewBreakPoints : Form
    {
        //Breakpoints
        private List<int> breakpointList;
        ViewSystem vsystem;
        public ViewBreakPoints(ViewSystem viewSystem)
        {
            InitializeComponent();
            breakpointList = new List<int>();
            vsystem = viewSystem;

            this.FormClosing += YourForm_FormClosing;
        }

        private void YourForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the close button (red "X") is clicked
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Prevent the form from being disposed
                e.Cancel = true;

                // Instead, hide the form
                this.Hide();
            }
            else
            {
                // Form is closing due to other reasons (e.g., application exit)
            }
        }

        //Breakpoints Button
        private void Delete_Breakpoint(object sender, EventArgs e)
        {
            if (breakBox.SelectedItem != null)
            {
                breakpointList.Remove(breakBox.SelectedIndex);
                vsystem.breakpoints.Remove(breakBox.SelectedIndex);
                breakBox.Items.Remove(breakBox.SelectedItem.ToString());
            }
        }

        private void Add_Breakpoint(object sender, EventArgs e)
        {
            int.TryParse(breakLine.Text, out int result);
            if (!string.IsNullOrEmpty(breakLine.Text) && IsDigitsRegex(breakLine.Text) && result < 65536 && result > 0)
            {
                breakpointList.Add(result);
                vsystem.breakpoints.Add(result);
                breakBox.Items.Add("Address: " + breakLine.Text);
                breakLine.Clear();

            }
            else
            {
                breakLine.Clear();
                MessageBox.Show("Please enter a valid breakpoint.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<int> GetBreakPoints()
        {
            return breakpointList;
        }
        public bool IsDigitsRegex(string input)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(input);
        }
    }
}
