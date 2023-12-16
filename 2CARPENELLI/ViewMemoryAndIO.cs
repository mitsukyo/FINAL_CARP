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

namespace _2CARPENELLI
{
    public partial class ViewMemoryAndIO : Form
    {
        //Memory
        private bool isHex = false;
        private Memory memory;
        public ViewMemoryAndIO(Memory memory)
        {
            InitializeComponent();
            this.memory = memory;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.ReadOnly = true;

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

        //Memory and IO Buttons
        private void BinaryMemory(object sender, EventArgs e)
        {
            isHex = false;
            textBox2.Text = "";
            memory.UpdateMemoryTextBox(textBox2, isHex);
        }

        private void HexMemory(object sender, EventArgs e)
        {
            isHex = true;
            textBox2.Text = "";
            memory.UpdateMemoryTextBox(textBox2, isHex);
        }
        private void ViewMemoryAndIOs(object sender, EventArgs e)
        {
            textBox2.Text = "";
            memory.UpdateMemoryTextBox(textBox2, isHex);
        }

        private void ClearMemoryAndIOs(object sender, EventArgs e)
        {
            memory.Clear();
            textBox2.Clear();
            memory.UpdateMemoryTextBox(textBox2, isHex);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            memory.UpdateMemoryTextBox(textBox2, isHex);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            memory.Clear();
            textBox2.Clear();
            memory.UpdateMemoryTextBox(textBox2, isHex);
        }

        private void btnHex_Click(object sender, EventArgs e)
        {
            isHex = true;
            textBox2.Text = "";
            memory.UpdateMemoryTextBox(textBox2, isHex);
        }

        private void btnBinary_Click(object sender, EventArgs e)
        {
            isHex = false;
            textBox2.Text = "";
            memory.UpdateMemoryTextBox(textBox2, isHex);
        }
    }
}
