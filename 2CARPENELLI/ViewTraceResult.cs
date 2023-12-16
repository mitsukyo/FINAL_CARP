using RSCSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2CARPENELLI
{
    public partial class ViewTraceResult : Form
    {
        private TraceResults traceResults;
        public ViewTraceResult(TraceResults traceResults)
        {
            InitializeComponent();
            this.traceResults = traceResults;
            textBox2.ScrollBars = ScrollBars.Vertical;

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

        private void btnTraceResults_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Trace Results: " + Environment.NewLine;
            traceResults.UpdateTraceResults(textBox2);
            textBox2.Text += Environment.NewLine;
        }

        private void ClearTrace_Btn(object sender, EventArgs e)
        {
            textBox2.Clear();
            traceResults.RemoveAllStatements();
        }
    }
}
