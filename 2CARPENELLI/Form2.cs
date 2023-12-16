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
    public partial class Form2 : Form
    {
        private Assembler assembler;
        private CPU cpu;
        private Memory memory;
        private TraceResults results;
        private List<int> breakpoints;

        private ViewBreakPoints breakpoint;
        private ViewSystem viewSystem;
        private ViewTraceResult viewTrace;
        private ViewMemoryAndIO memoryIO;

        public Form2()
        {
            InitializeComponent();
            breakpoints = new List<int>();
            assembler = new Assembler();
            memory = new Memory();
            results = new TraceResults();
            cpu = new CPU(results, status_txt, rtl_txt, datamove_txt);
            instructionCode.ScrollBars = ScrollBars.Vertical;

            viewSystem = new ViewSystem(this, rtl_txt, datamove_txt, status_txt, memoryLoc_txt, results, cpu, memory, breakpoints);
            breakpoint = new ViewBreakPoints(viewSystem);
            viewTrace = new ViewTraceResult(results);
            memoryIO = new ViewMemoryAndIO(memory);
        }

        private Form activeForm2 = null;
        private void openChildForm2(Form childForm2)
        {
            if (activeForm2 != null)
                activeForm2.Close();
            activeForm2 = childForm2;
            childForm2.TopLevel = false;
            childForm2.FormBorderStyle = FormBorderStyle.None;
            childForm2.Dock = DockStyle.Fill;
            panelShowBody.Controls.Add(childForm2);
            panelShowBody.Tag = childForm2;
            childForm2.BringToFront();
            childForm2.Show();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelShowBody.Controls.Add(childForm);
            panelShowBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        
        private void View_System(object sender, EventArgs e)
        {
            if(viewSystem == null)
            {
                viewSystem = new ViewSystem(this, rtl_txt, datamove_txt, status_txt, memoryLoc_txt, results, cpu, memory, breakpoints);
                viewSystem.Show();
            }
            else
            {
                viewSystem.Show();
                viewSystem.BringToFront();
            }
            /* if (viewSystem == null)
             {
                 viewSystem = new ViewSystem(memoryLoc_txt, cpu, memory, breakpoints);
                 openChildForm(viewSystem);
             }
             else
             {
                 if (viewSystem.Visible)
                 {
                     viewSystem.Hide();
                 }
                 else
                 {
                     viewSystem.Show();
                 }

             }*/


            //openChildForm(new ViewSystem(memoryLoc_txt, cpu, memory, breakpoints));
        }

        private void View_MemoryAndIO(object sender, EventArgs e)
        {
            /*ViewMemoryAndIO memoryIO = new ViewMemoryAndIO(memory);
            memoryIO.Show();*/
            openChildForm(memoryIO);
        }

        private void View_Breakpoints(object sender, EventArgs e)
        {
            
             /*breakpoint.Show();
             breakpoints = breakpoint.GetBreakPoints();*/
            openChildForm(breakpoint);
        }

        private void View_TraceResults(object sender, EventArgs e)
        {
            /*ViewTraceResult trace = new ViewTraceResult(results);
            trace.Show();*/
            openChildForm(viewTrace);
        }
        
        private void btnAssemble_Click(object sender, EventArgs e)
        {
            string text = instructionCode.Text;

            if (int.TryParse(memLocation.Text, out int location))
            {
                AssemblyResults results = assembler.Assemble(text, location, cpu, memory);
                AssemblyError[] errors = results.GetErrors();
                int i = 0;
                while (i < errors.Length)
                {
                    viewSystem.TopMost = false;
                    MessageBox.Show(errors[i].GetString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    i++;
                }
                if (errors.Length <= 0)
                {
                    viewSystem.TopMost = false;
                    MessageBox.Show("Assembly Successful.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                viewSystem.TopMost = false;
                MessageBox.Show(memLocation.Text + " is not a valid memory location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
        }

        private void panelShowBody_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            viewSystem.TopMost = true;
            if (viewSystem == null)
            {
                viewSystem = new ViewSystem(this, rtl_txt, datamove_txt, status_txt, memoryLoc_txt, results, cpu, memory, breakpoints);
                viewSystem.Show();
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                viewSystem.Show();
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            /* if (viewSystem == null)
             {
                 viewSystem = new ViewSystem(memoryLoc_txt, cpu, memory, breakpoints);
                 openChildForm(viewSystem);
             }
             else
             {
                 if (viewSystem.Visible)
                 {
                     viewSystem.Hide();
                 }
                 else
                 {
                     viewSystem.Show();
                 }

             }*/


            //openChildForm(new ViewSystem(memoryLoc_txt, cpu, memory, breakpoints));
        }
    }
}
