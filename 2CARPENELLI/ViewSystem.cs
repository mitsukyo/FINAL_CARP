using RSCSS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2CARPENELLI
{
    public partial class ViewSystem : Form
    {
        AnimationHandler animationHandler;

        private Label memoryLoc_txt;
        private Label status_txt;
        private Label rtl_txt;
        private Label datamove_txt;

        private CPU cpu;
        private Memory memory;
        private TraceResults traceResults;
        //Breakpoints
        public List<int> breakpoints;

        #region VisualizationOpcodes
        public const short opcodeNOP = 0x00;
        public const short opcodeLDAC = 0x01;
        public const short opcodeSTAC = 0x02;
        public const short opcodeMVAC = 0x03;
        public const short opcodeMOVR = 0x04;
        public const short opcodeJUMP = 0x05;
        public const short opcodeJMPZ = 0x06;
        public const short opcodeJPNZ = 0x07;
        public const short opcodeADD = 0x08;
        public const short opcodeSUB = 0x09;
        public const short opcodeINAC = 0x0a;
        public const short opcodeCLAC = 0x0b;
        public const short opcodeAND = 0x0c;
        public const short opcodeOR = 0x0d;
        public const short opcodeXOR = 0x0e;
        public const short opcodeNOT = 0x0f;
        public const short opcodeEND = 0xff;

        short[] memorycode;
        int fetchCounter = 0;
        int memoryCount = 0;

        int ldacCounter = 0;
        int stacCounter = 0;

        short instructadv1;
        short instructadv2;
        #endregion

        #region AnimationBooleans
        public bool FETCH1 = false;
        public bool FETCH2 = false;
        public bool FETCH3 = false;
        public bool LDAC1 = false;
        public bool LDAC2 = false;
        public bool LDAC3 = false;
        public bool LDAC4 = false;
        public bool STAC1 = false;
        public bool STAC2 = false;
        public bool STAC4 = false;
        public bool STAC5 = false;
        public bool NOP = false;
        public bool MVAC = false;
        public bool MOVR = false;
        public bool JUMP = false;
        public bool JMPZ = false;
        public bool JPNZ = false;
        public bool ADD = false;
        public bool SUB = false;
        public bool INAC = false;
        public bool CLAC = false;
        public bool AND = false;
        public bool OR = false;
        public bool XOR = false;
        public bool NOT = false;
        public bool END = false;
        #endregion

        #region MoversStartPosition
        public List<int> movePosX;
        public List<int> movePosY;
        #endregion

        public bool instructionPlay = false;
        private bool cyclePlay = false;
        public ViewSystem(Form form2, Label rtl, Label datamove, Label status, Label memoryLoc, TraceResults results, CPU cpu, Memory memory, List<int> breakpoints)
        {
            InitializeComponent();
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.WindowState = FormWindowState.Maximized;
            movePosX = new List<int>();
            movePosY = new List<int>();
            fetchCounter = 0;
            memoryCount = 0;

            SetXYPosition();

            #region Hidden Items
            //clkRed
            pictureBox44.Hide();
            pictureBox42.Hide();
            pictureBox43.Hide();
            pictureBox45.Hide();
            //-----

            //readRed
            pictureBox46.Hide();
            pictureBox47.Hide();
            pictureBox48.Hide();
            pictureBox49.Hide();
            pictureBox50.Hide();
            pictureBox51.Hide();
            pictureBox52.Hide();
            pictureBox53.Hide();
            //-----

            //writeRed           
            pictureBox55.Hide();
            pictureBox56.Hide();
            pictureBox57.Hide();
            //-----


            //-----------------------------
            //sprites/redDot
            move1.Hide();
            move2.Hide();
            move3.Hide();
            move4.Hide();
            move5.Hide();
            move5y.Hide();
            move6.Hide();
            move7.Hide();
            move8.Hide();
            move9.Hide();
            move10.Hide();
            move11.Hide();
            move12.Hide();
            //------------------------------

            arInput.Hide();
            pcInput.Hide();
            drInput.Hide();
            trInput.Hide();
            irInput.Hide();
            rInput.Hide();
            acInput.Hide();
            zInput.Hide();
            #endregion
            this.traceResults = results;
            this.rtl_txt = rtl;
            this.datamove_txt = datamove;
            this.status_txt = status;
            this.memoryLoc_txt = memoryLoc;
            this.cpu = cpu;
            this.memory = memory;
            this.breakpoints = breakpoints;

            memorycode = memory.contents;
            animationHandler = new AnimationHandler();
            SetRegisters();
            cpu.SetViewSystem(this);

            updateTimer.Start();
            clkTimer.Start();
            traceResults.RemoveAllStatements();

            this.TopMost = true;
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

        private void SetXYPosition()
        {
            //X Location
            movePosX.Add(Pause.Location.X);//0
            movePosX.Add(startPoint2.Location.X);//1
            movePosX.Add(startPoint3.Location.X);//2
            movePosX.Add(startPoint4.Location.X);//3
            movePosX.Add(point5x.Location.X);//4
            movePosX.Add(point5y.Location.X);//5 5y
            movePosX.Add(endPoint3.Location.X);//6
            movePosX.Add(endPoint1.Location.X);//7
            movePosX.Add(endPoint2.Location.X);//8
            movePosX.Add(endPoint4.Location.X);//9
            movePosX.Add(locPoint7.Location.X);//10
            movePosX.Add(locPoint5.Location.X);//11
            movePosX.Add(locPoint8.Location.X);//12

            //YLocation
            movePosY.Add(Pause.Location.Y);//0
            movePosY.Add(startPoint2.Location.Y);//1
            movePosY.Add(startPoint3.Location.Y);//2
            movePosY.Add(startPoint4.Location.Y);//3
            movePosY.Add(point5x.Location.Y);//4
            movePosY.Add(point5y.Location.Y);//5 5y
            movePosY.Add(endPoint3.Location.Y);//6
            movePosY.Add(endPoint1.Location.Y);//7
            movePosY.Add(endPoint2.Location.Y);//8
            movePosY.Add(endPoint4.Location.Y);//9
            movePosY.Add(locPoint7.Location.Y);//10
            movePosY.Add(locPoint5.Location.Y);//11
            movePosY.Add(locPoint8.Location.Y);//12
        }
        public void SetRegisters()
        {
            cpu.SetRegisters(ar_txt,pc_txt,dr_txt,tr_txt,ir_txt,r_txt,ac_txt,z_txt);
        }
       /* public void ResetRegisters()
        {
            ar_txt.Text = "0000 0000 0000 0000";
            pc_txt.Text = "0000 0000 0000 0000";
            dr_txt.Text = "0000 0000";
            tr_txt.Text = "0000 0000";
            ir_txt.Text = "0000 0000";
            r_txt.Text = "0000 0000";
            ac_txt.Text = "0000 0000";
            z_txt.Text = "0";
        }*/

        int count = 0;
        private void Update(object sender, EventArgs e)
        {
            if (FETCH1)
            {
                Fetch1();
            }
            if (FETCH2)
            {
                Fetch2();
            }
            if (FETCH3)
            {
                Fetch3();
            }

            if (LDAC1)
            {
                Ldac1();
            }
            if (LDAC2)
            {
                Ldac2();
            }
            if (LDAC3)
            {
                Ldac3();
            }
            if (LDAC4)
            {
                Ldac4();
            }

            if (STAC1)
            {
                Stac1();
            }
            if (STAC2)
            {
                Stac2();
            }
            if (STAC4)
            {
                Stac4();
            }
            if (STAC5)
            {
                Stac5();
            }
        }
        //Fetches
        public void Fetch1()
        {
            if (count == 0)
            {
                cpuToA.Start();
                count = 1;
            }
            if (count == 1 && !cpuToA.Enabled)
            {
                aToP5x.Start();
                count = 2;
            }
            if (count == 2 && !aToP5x.Enabled)
            {
                p5xToE3.Start();
                p5yToL5.Start();
                count = 3;
            }
            if (count == 3 && !p5yToL5.Enabled)
            {
                l5ToD.Start();
                count = 4;
            }
            if (count == 4 && !l5ToD.Enabled)
            {
                readRed(1);
                FETCH1 = false;
                count = 0;
                //FETCH2 = true;
                fetchCounter++;
            }
        }
        public void Fetch2()
        {
            if (count == 0)
            {
                mToL7.Start();
                count = 1;
            }
            if (count == 1 && !mToL7.Enabled)
            {
                l7ToD.Start();
                count = 2;
            }
            if (count == 2 && !l7ToD.Enabled)
            {
                dToCPU.Start();
                count = 3;
            }
            if (count == 3 && !dToCPU.Enabled)
            {
                FETCH2 = false;
                count = 0;
                fetchCounter++;
            }
        }
        public void Fetch3()
        {
            if (count == 0 && !dToCPU.Enabled)
            {
                cpuToA.Start();
                count = 1;
            }
            if (count == 1 && !cpuToA.Enabled)
            {
                aToP5x.Start();
                count = 2;
            }
            if (count == 2 && !aToP5x.Enabled)
            {
                p5xToE3.Start();
                p5yToL5.Start();
                count = 3;
            }
            if (count == 3 && !p5yToL5.Enabled)
            {
                l5ToD.Start();
                count = 4;
            }
            if (count == 4 && !l5ToD.Enabled)
            {
                readRed(1);
                FETCH3 = false;
                count = 0;
                fetchCounter++;
            }
        }

        //LDAC
        public void Ldac1()
        {
            if (count == 0)
            {
                cpuToA.Start();
                mToL7.Start();
                count = 1;
            }
            if (count == 1 && !cpuToA.Enabled && !mToL7.Enabled)
            {
                l7ToD.Start();
                aToP5x.Start();
                count = 2;
            }
            if (count == 2 && !aToP5x.Enabled)
            {
                p5xToE3.Start();
                p5yToL5.Start();
                count = 3;
            }
            if (count == 3 && !p5yToL5.Enabled && !l7ToD.Enabled)
            {
                dToCPU.Start();
                l5ToD.Start();
                count = 4;
            }
            if(count == 4 && !dToCPU.Enabled && !l5ToD.Enabled)
            {
                LDAC1 = false;
                count = 0;
            }
        }
        public void Ldac2()
        {
            if (count == 0)
            {
                mToL7.Start();
                count = 1;
            }
            if (count == 1 && !mToL7.Enabled)
            {
                l7ToD.Start();
                count = 2;
            }
            if (count == 2 && !l7ToD.Enabled)
            {
                dToCPU.Start();
                count = 3;
            }
            if(count == 3 && !dToCPU.Enabled)
            {
                LDAC2 = false;
                count = 0;
            }
        }
        public void Ldac3()
        {
            if (count == 0)
            {
                cpuToA.Start();
                count = 1;
            }
            if (count == 1 && !cpuToA.Enabled)
            {
                aToP5x.Start();
                count = 2;
            }
            if (count == 2 && !aToP5x.Enabled)
            {
                p5xToE3.Start();
                p5yToL5.Start();
                count = 3;
            }
            if (count == 3 && !p5yToL5.Enabled)
            {
                l5ToD.Start();
                count = 4;
            }
            if( count == 4 && !l5ToD.Enabled && !p5xToE3.Enabled)
            {
                LDAC3 = false;
                count = 0;
            }
        }
        public void Ldac4()
        {
            if (count == 0)
            {
                mToL7.Start();
                count = 1;
            }
            if (count == 1 && !mToL7.Enabled)
            {
                l7ToD.Start();
                count = 2;
            }
            if (count == 2 && !l7ToD.Enabled)
            {
                dToCPU.Start();
                LDAC4 = false;
                count = 0;
            }
        }

        //STAC
        public void Stac1()
        {
            if (count == 0)
            {
                cpuToA.Start();
                mToL7.Start();
                count = 1;
            }
            if (count == 1 && !cpuToA.Enabled && !mToL7.Enabled)
            {
                l7ToD.Start();
                aToP5x.Start();
                count = 2;
            }
            if (count == 2 && !aToP5x.Enabled)
            {
                p5xToE3.Start();
                p5yToL5.Start();
                count = 3;
            }
            if (count == 3 && !p5yToL5.Enabled && !l7ToD.Enabled)
            {
                dToCPU.Start();
                l5ToD.Start();
                count = 4;
            }
            if (count == 4 && !dToCPU.Enabled)
            {
                STAC1 = false;
                count = 0;
            }
        }
        public void Stac2()
        {
            if (count == 0)
            {
                mToL7.Start();
                count = 1;
            }
            if (count == 1 && !mToL7.Enabled)
            {
                l7ToD.Start();
                count = 2;
            }
            if (count == 2 && !l7ToD.Enabled)
            {
                dToCPU.Start();
                STAC2 = false;
                count = 0;
            }
        }
        public void Stac4()
        {
            if (count == 0)
            {
                cpuToA.Start();
                count = 1;
            }
            if (count == 1 && !cpuToA.Enabled)
            {
                aToP5x.Start();
                count = 2;
            }
            if (count == 2 && !aToP5x.Enabled)
            {
                p5xToE3.Start();
                p5yToL5.Start();
                count = 3;
            }
            if (count == 3 && !p5yToL5.Enabled)
            {
                l5ToD.Start();
                STAC4 = false;
                count = 0;
            }
        }
        public void Stac5()
        {
            if (count == 0)
            {
                writeRed(1);
                cpuToD.Start();
                count = 1;
            }
            if (count == 1 && !cpuToD.Enabled)
            {
                dToL7.Start();
                count = 2;
            }
            if (count == 2 && !dToL7.Enabled)
            {
                l7ToE4.Start();
                count = 3;
            }
            if(count == 3 && !l7ToE4.Enabled)
            {
                STAC5 = false;
                writeRed(0);
                count = 0;
            }
        }


        private void Instruction_Tick(object sender, EventArgs e)
        {
            ExecuteMicrocode();
        }
        #region Color Animation
        public void clkRed(int num)
        {
            if(num > 0)
            {
                pictureBox5.Hide();
                pictureBox11.Hide();
                pictureBox12.Hide();
                pictureBox44.Show();
                pictureBox42.Show();
                pictureBox43.Show();
                pictureBox45.Show();
                lblClock.ForeColor = Color.Red;
                lblClk.ForeColor = Color.Red;
            }
            else
            {
                pictureBox5.Show();
                pictureBox11.Show();
                pictureBox12.Show();
                pictureBox44.Hide();
                pictureBox42.Hide();
                pictureBox43.Hide();
                pictureBox45.Hide();
                lblClock.ForeColor = Color.White;
                lblClk.ForeColor = Color.Black;
            }
            //clockTimer.Start();
        }
        public void readRed(int num)
        {
            if(num > 0)
            {
                label29.ForeColor = Color.Red;
                lblRead.ForeColor = Color.Red;
                pictureBox27.Hide();
                pictureBox28.Hide();
                pictureBox29.Hide();
                pictureBox30.Hide();
                pictureBox31.Hide();
                pictureBox32.Hide();
                pictureBox46.Show();
                pictureBox47.Show();
                pictureBox48.Show();
                pictureBox49.Show();
                pictureBox50.Show();
                pictureBox51.Show();
                pictureBox52.Show();
                pictureBox53.Show();
            }
            else
            {
                label29.ForeColor = Color.White;
                lblRead.ForeColor = Color.White;
                pictureBox27.Show();
                pictureBox28.Show();
                pictureBox29.Show();
                pictureBox30.Show();
                pictureBox31.Show();
                pictureBox32.Show();
                pictureBox46.Hide();
                pictureBox47.Hide();
                pictureBox48.Hide();
                pictureBox49.Hide();
                pictureBox50.Hide();
                pictureBox51.Hide();
                pictureBox52.Hide();
                pictureBox53.Hide();
            }
            //clockTimer.Start();
        }

        public void writeRed(int num)
        {
            if(num > 0)
            {
                lblWrite.ForeColor = Color.Red;
                pictureBox19.Hide();
                pictureBox20.Hide();
                pictureBox33.Hide();
                pictureBox34.Hide();
                pictureBox35.Hide();
                pictureBox36.Hide();
                pictureBox55.Show();
                pictureBox56.Show();
                pictureBox57.Show();
            }
            else
            {
                lblWrite.ForeColor = Color.White;
                pictureBox19.Show();
                pictureBox20.Show();
                pictureBox33.Show();
                pictureBox34.Show();
                pictureBox35.Show();
                pictureBox36.Show();
                pictureBox55.Hide();
                pictureBox56.Hide();
                pictureBox57.Hide();
            }
        }



        //ALU and CU Red
        public void ALURed()
        {
            lblALU.ForeColor = Color.Red;
        }

        public void CURed()
        {
            lblCU.ForeColor = Color.Red;
        }

        //-------------------------------
        //All 8 register to Red
        public void ARRed(int num)
        {
            if (num > 0)
                lblAR.ForeColor = Color.Red;
            else
                lblAR.ForeColor = Color.White;
        }

        public void PCRed(int num)
        {
            if (num > 0)
                lblPC.ForeColor = Color.Red;
            else
                lblPC.ForeColor = Color.White;

        }

        public void DRRed(int num)
        {   
            if(num>0)
                lblDR.ForeColor = Color.Red;
            else
                lblDR.ForeColor = Color.White;

        }
        public void TRRed(int num)
        {
            if (num > 0)
                lblTR.ForeColor = Color.Red;
            else
                lblTR.ForeColor = Color.White;

        }
        public void IRRed(int num)
        {
            if (num > 0)
                lblIR.ForeColor = Color.Red;
            else
                lblIR.ForeColor = Color.White;

        }
        public void RRed(int num)
        {
            if (num > 0)
                lblR.ForeColor = Color.Red;
            else
                lblR.ForeColor = Color.White;

        }
        public void ACRed(int num)
        {
            if (num > 0)
                lblAC.ForeColor = Color.Red;
            else
                lblAC.ForeColor = Color.White;
        }
        public void ZRed(int num)
        {
            if (num > 0)
                lblZ.ForeColor = Color.Red;
            else
                lblZ.ForeColor = Color.White;

        }
        #endregion

        #region RSCPU Visualization
        public void ExecuteMicrocode()
        {
            if (fetchCounter < 3 &&(!FETCH1 && !FETCH2 && !FETCH3 &&
                 !LDAC1 && !LDAC2 && !LDAC3 && !LDAC4 &&
                !STAC1 && !STAC2 && !STAC4 && !STAC5))
            {
                clkRed(1);
                cpu.Fetches(memorycode[memoryCount], fetchCounter);
            }
            if(fetchCounter >= 3 &&(!FETCH1 && !FETCH2 && !FETCH3 &&
                !LDAC1 && !LDAC2 && !LDAC3 && !LDAC4 && 
                !STAC1 && !STAC2 && !STAC4 && !STAC5))
            {
                InstructionFinder();
            }
            if (cyclePlay)
            {
                instructionReaderTimer.Stop();
                cyclePlay = false;
            }
            Breakpoint(memoryCount);
        }
        private void ClkTimer(object sender, EventArgs e)
        {
            clkRed(0);
        }
        public void InstructionFinder()
        {
            clkRed(1);
            instructadv1 = memorycode[memoryCount + 1];
            instructadv2 = memorycode[memoryCount + 2];
            int m1 = memoryCount + 1;
            int m2 = memoryCount + 2;
            Console.WriteLine(memorycode[memoryCount]);
            switch (memorycode[memoryCount])
            {
                case opcodeNOP:
                    readRed(0);
                    writeRed(0);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    Breakpoint(memoryCount);
                    // Perform actions for NOP instruction
                    memoryCount++;
                    Console.WriteLine("NOP encountered!");
                    cpu.NOP();
                    //animationTimer.Stop();
                    fetchCounter = 0;

                    if (instructionPlay)
                    {
                        instructionReaderTimer.Stop();
                        instructionPlay = false;
                    }
                    break;
                case opcodeLDAC:
                    Breakpoint(memoryCount);
                    // Perform actions for LDAC instruction
                    Console.WriteLine("LDAC encountered!");

                    if (ldacCounter < 3)
                    {
                        memoryLoc_txt.Text = m1.ToString();
                        Breakpoint(m1);
                        cpu.LDAC(instructadv1, ldacCounter);
                    }
                    else if (ldacCounter < 5)
                    {
                        memoryLoc_txt.Text = m2.ToString();
                        Breakpoint(m2);
                        cpu.LDAC(instructadv2, ldacCounter);
                    }
                    else
                    {
                        fetchCounter = 0;
                        ldacCounter = 0;
                        memoryCount += 3;
                        if (instructionPlay)
                        {
                            instructionReaderTimer.Stop();
                            instructionPlay = false;
                        }
                        //animationTimer.Stop();
                        break;
                    }
                    ldacCounter++;
                    break;
                case opcodeSTAC:
                    Breakpoint(memoryCount);
                    // Perform actions for STAC instruction
                    Console.WriteLine("STAC encountered!");
                    if (stacCounter == 0)
                    {
                        memoryLoc_txt.Text = m1.ToString();
                        Breakpoint(m1);
                        cpu.STAC(instructadv1, stacCounter);
                    }
                    else if (stacCounter < 4)
                    {
                        memoryLoc_txt.Text = m2.ToString();
                        Breakpoint(m2);
                        cpu.STAC(instructadv2, stacCounter);    
                    }
                    else
                    {
                        memorycode[memoryCount] = cpu.STAC(instructadv2, stacCounter);
                        fetchCounter = 0;
                        stacCounter = 0;
                        memoryCount += 3;
                        if (instructionPlay)
                        {
                            instructionReaderTimer.Stop();
                            instructionPlay = false;
                        }
                        //animationTimer.Stop();
                        break;
                    }
                    stacCounter++;
                    break;
                case opcodeMVAC:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for MVAC instruction
                    Console.WriteLine("MVAC encountered!");
                    cpu.MVAC();
                    //animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeMOVR:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for MOVR instruction
                    Console.WriteLine("MOVR encountered!");
                    cpu.MVAC();
                    //animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeJUMP:
                    Breakpoint(memoryCount);
                    // Perform actions for JUMP instruction
                    Console.WriteLine("JUMP encountered!");
                    memoryLoc_txt.Text = memoryCount.ToString();
                    if (cpu.JUMP(instructadv1, memorycode) < 0)
                    {
                        Breakpoint(m1);
                        memoryLoc_txt.Text = m1.ToString();
                        memoryCount += 3;
                        Breakpoint(memoryCount);
                    }
                    else
                    {
                        Breakpoint(memoryCount);
                        memoryCount = cpu.JUMP(instructadv1, memorycode);
                    }
                    //animationTimer.Stop();
                    fetchCounter = 0;
                    break;
                case opcodeJMPZ:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for JMPZ instruction
                    Console.WriteLine("JMPZ encountered!");
                    if (cpu.JMPZ(instructadv1, memorycode) < 0)
                    {
                        memoryCount += 3;
                    }
                    else
                    {
                        memoryCount = cpu.JMPZ(instructadv1, memorycode);
                    }
                    //animationTimer.Stop();
                    fetchCounter = 0;
                    break;
                case opcodeJPNZ:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for JPNZ instruction
                    Console.WriteLine("JPNZ encountered!");
                    if (cpu.JPNZ(instructadv1, memorycode) < 0)
                    {
                        memoryLoc_txt.Text = m1.ToString();
                        memoryCount += 3;
                    }
                    else
                    {
                        memoryCount = cpu.JPNZ(instructadv1, memorycode);
                    }
                    //animationTimer.Stop();
                    fetchCounter = 0;
                    break;
                case opcodeADD:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for ADD instruction
                    Console.WriteLine("ADD encountered!");
                    cpu.ADD();
                    //animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeSUB:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for SUB instruction
                    Console.WriteLine("SUB encountered!");
                    cpu.SUB();
                    //animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeINAC:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for INAC instruction
                    Console.WriteLine("INAC encountered!");
                    cpu.INAC();
                    //animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeCLAC:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for CLAC instruction
                    Console.WriteLine("CLAC encountered!");
                    cpu.CLAC();
                    //animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeAND:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for AND instruction
                    Console.WriteLine("AND encountered!");
                    cpu.AND();
                    //animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeOR:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for OR instruction
                    Console.WriteLine("OR encountered!");
                    cpu.OR();
                    //animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeXOR:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for XOR instruction
                    Console.WriteLine("XOR encountered!");
                    cpu.XOR();
                    //animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeNOT:
                    Breakpoint(memoryCount);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for NOT instruction
                    Console.WriteLine("NOT encountered!");
                    cpu.NOT();
                    //animationTimer.Stop();
                    memoryCount++;
                    fetchCounter = 0;
                    break;
                case opcodeEND:
                    readRed(0);
                    writeRed(0);
                    memoryLoc_txt.Text = memoryCount.ToString();
                    // Perform actions for END instruction
                    Console.WriteLine("END encountered!");
                    cpu.END();
                    //animationTimer.Stop();
                    //fullCycleTimer.Stop();
                    Console.WriteLine("It has finished");
                    updateTimer.Stop();
                    instructionReaderTimer.Stop();
                    MessageBox.Show("Simulation has ended", "Simulation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    // Handle unknown instructions or implement additional instructions
                    Console.WriteLine("Instruction Does not Exist");
                    break;
            }
        }
        public void Breakpoint(int memcount)
        {
            foreach (int breaks in breakpoints)
            {
                if(memcount == breaks)
                {
                    cpu.Status_txt.Text = "Breaks";
                    instructionReaderTimer.Stop();

                }
            }
        }
        #endregion

        #region Controls
        private void StartToEndBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(simLocStart.Text, out int simValue))
            {
                traceResults.RemoveAllStatements();
                status_txt.Text = "Running";
                SetRegisters();
                memoryCount = simValue;
                fetchCounter = 0;
                stacCounter = 0;
                ldacCounter = 0;
                instructionReaderTimer.Start();
                
                ExecuteMicrocode();
            }
            else
            {
                MessageBox.Show(simLocStart.Text + " is not a valid memory location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Stop_Btn(object sender, EventArgs e)
        {
            status_txt.Text = "Stopped";
            instructionReaderTimer.Stop();
        }
        private void StepCycle_Tick(object sender, EventArgs e)
        {
            status_txt.Text = "Running";
            cyclePlay = true;
            instructionReaderTimer.Start();
            ExecuteMicrocode();
        }
        private void StepThroughInstruction_Click(object sender, EventArgs e)
        {
            status_txt.Text = "Running";
            instructionPlay = true;
            instructionReaderTimer.Start();
            ExecuteMicrocode();
        }
        private void NextInstruction(object sender, EventArgs e)
        {
            ExecuteMicrocode();
        }
        public string SpaceInserter(int reg, string regname)
        {
            string binaryString;
            if (regname == "ar" || regname == "pc")
            {
                // Convert the integer to a binary string with spaces every 4 digits
                binaryString = Convert.ToString(reg, 2).PadLeft(16, '0');
            }
            else if (regname == "z")
            {
                // Convert the integer to a binary string with spaces every 4 digits
                binaryString = Convert.ToString(reg);
            }
            else
            {
                // Convert the integer to a binary string with spaces every 4 digits
                binaryString = Convert.ToString(reg, 2).PadLeft(8, '0');
            }

            // Insert spaces after every 4 digits
            int groupSize = 4;
            for (int i = groupSize; i < binaryString.Length; i += (groupSize + 1))
            {
                binaryString = binaryString.Insert(i, " ");
            }
            return binaryString;
        }
        private void Reset_Btn(object sender, EventArgs e)
        {
            memoryLoc_txt.Text = "0";
            ar_txt.Text = "0000 0000 0000 0000";
            pc_txt.Text = "0000 0000 0000 0000";
            dr_txt.Text = "0000 0000";
            tr_txt.Text = "0000 0000";
            ir_txt.Text = "0000 0000";
            r_txt.Text = "0000 0000";
            ac_txt.Text = "0000 0000";
            z_txt.Text = "0";
            cpu.SetRegistersValue("ar", 0);
            cpu.SetRegistersValue("pc", 0);
            cpu.SetRegistersValue("dr", 0);
            cpu.SetRegistersValue("tr", 0);
            cpu.SetRegistersValue("ir", 0);
            cpu.SetRegistersValue("r", 0);
            cpu.SetRegistersValue("ac", 0);
            cpu.SetRegistersValue("z", 0);
        }
        #endregion
        #region Animation Timers
        private void CPUToA(object sender, EventArgs e)
        {
            animationHandler.MoveAnimation(move1, endPoint1, 0,0, movePosX[0], movePosY[0], cpuToA);
        }

        private void AToP5(object sender, EventArgs e)
        {
            animationHandler.MoveAnimation(move3, point5x, 0, 0, movePosX[2], movePosY[2], aToP5x);
        }

        private void P5xToM(object sender, EventArgs e)
        {
            animationHandler.MoveAnimation(move5, endPoint3, 0, 0, movePosX[4], movePosY[4], p5xToE3);
        }

        private void P5yToL5(object sender, EventArgs e)
        {
            animationHandler.MoveAnimation(move5y, locPoint5, 1, 0, movePosX[5], movePosY[5], p5yToL5);
        }

        private void L5ToD(object sender, EventArgs e)
        {
            animationHandler.MoveAnimation(move11, locPoint6, 0, 0, movePosX[11], movePosY[11], l5ToD);
        }

        private void MToL7(object sender, EventArgs e)
        {
            animationHandler.MoveAnimation(move9, locPoint7, 0, 1, movePosX[9], movePosY[9], mToL7);
        }

        private void L7ToD(object sender, EventArgs e)
        {
            animationHandler.MoveAnimation(move10, startPoint4, 0, 1, movePosX[10], movePosY[10], l7ToD);
        }

        private void DToCPU(object sender, EventArgs e)
        {
            animationHandler.MoveAnimation(move8, startPoint2, 0, 1, movePosX[8], movePosY[8], dToCPU);
        }

        private void DToL7(object sender, EventArgs e)
        {
            animationHandler.MoveAnimation(move4, locPoint7, 0, 0, movePosX[3], movePosY[3], dToL7);
        }

        private void L7ToE4(object sender, EventArgs e)
        {
            animationHandler.MoveAnimation(move10, endPoint4, 0, 0, movePosX[10], movePosY[10], l7ToE4);
        }

        private void CpuToD(object sender, EventArgs e)
        {
            animationHandler.MoveAnimation(move2, endPoint2, 0, 0, movePosX[1], movePosY[1], cpuToD);
        }
        #endregion

        #region RegistersDouble_Clicked
        private void AR_Tapped(object sender, MouseEventArgs e)
        {
            arInput.Show();
        }

        private void PC_Tapped(object sender, MouseEventArgs e)
        {
            pcInput.Show();
        }

        private void DR_Tapped(object sender, MouseEventArgs e)
        {
            drInput.Show();
        }

        private void TR_Tapped(object sender, MouseEventArgs e)
        {
            trInput.Show();
        }

        private void IR_Tapped(object sender, MouseEventArgs e)
        {
            irInput.Show();
        }

        private void R_Tapped(object sender, MouseEventArgs e)
        {
            rInput.Show();
        }

        private void AC_Tapped(object sender, MouseEventArgs e)
        {
            acInput.Show();
        }

        private void Z_Tapped(object sender, EventArgs e)
        {
            zInput.Show();
        }
        #endregion
        #region Inputs
        private void arInput_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (int.TryParse(arInput.Text, out int simValue))
                {
                    cpu.SetRegistersValue("ar", simValue);
                    ar_txt.Text = SpaceInserter(simValue, "ar");
                    arInput.Hide();
                    SetRegisters();
                }
                else
                {
                    arInput.Text = "";
                    MessageBox.Show(arInput.Text + " is not valid try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pcInput_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (int.TryParse(pcInput.Text, out int simValue))
                {
                    cpu.SetRegistersValue("pc", simValue);
                    pc_txt.Text = SpaceInserter(simValue, "pc");
                    pcInput.Hide();
                    SetRegisters();
                }
                else
                {
                    pcInput.Text = "";
                    MessageBox.Show(pcInput.Text + " is not valid try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void drInput_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (int.TryParse(drInput.Text, out int simValue))
                {
                    cpu.SetRegistersValue("dr", simValue);
                    dr_txt.Text = SpaceInserter(simValue, "dr");
                    drInput.Hide();
                    SetRegisters();
                }
                else
                {
                    drInput.Text = "";
                    MessageBox.Show(drInput.Text + " is not valid try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void trInput_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (int.TryParse(trInput.Text, out int simValue))
                {
                    cpu.SetRegistersValue("tr", simValue);
                    tr_txt.Text = SpaceInserter(simValue, "tr");
                    trInput.Hide();
                    SetRegisters();
                }
                else
                {
                    trInput.Text = "";
                    MessageBox.Show(trInput.Text + " is not valid try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void irInput_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (int.TryParse(irInput.Text, out int simValue))
                {
                    cpu.SetRegistersValue("ir", simValue);
                    ir_txt.Text = SpaceInserter(simValue, "ir");
                    irInput.Hide();
                    SetRegisters();
                }
                else
                {
                    irInput.Text = "";
                    MessageBox.Show(irInput.Text + " is not valid try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rInput_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (int.TryParse(rInput.Text, out int simValue))
                {
                    cpu.SetRegistersValue("r", simValue);
                    r_txt.Text = SpaceInserter(simValue, "r");
                    rInput.Hide();
                    SetRegisters();
                }
                else
                {
                    rInput.Text = "";
                    MessageBox.Show(rInput.Text + " is not valid try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void acInput_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (int.TryParse(acInput.Text, out int simValue))
                {
                    cpu.SetRegistersValue("ac", simValue);
                    ac_txt.Text = SpaceInserter(simValue, "ac");
                    acInput.Hide();
                    SetRegisters();
                }
                else
                {
                    acInput.Text = "";
                    MessageBox.Show(acInput.Text + " is not valid try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void zInput_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (int.TryParse(zInput.Text, out int simValue))
                {
                    if (simValue > 1)
                    {
                        zInput.Text = "";
                        MessageBox.Show(zInput.Text + " is not valid try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cpu.SetRegistersValue("z", simValue);
                        z_txt.Text = SpaceInserter(simValue, "z");
                        zInput.Hide();
                        SetRegisters();
                    }
                }
                else
                {
                    zInput.Text = "";
                    MessageBox.Show(zInput.Text + " is not valid try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            status_txt.Text = "Stopped";
            rtl_txt.Text = "Fetch";
            datamove_txt.Text = "Fetch";
            ar_txt.Text = "0000 0000 0000 0000";
            pc_txt.Text = "0000 0000 0000 0000";
            dr_txt.Text = "0000 0000";
            tr_txt.Text = "0000 0000";
            ir_txt.Text = "0000 0000";
            r_txt.Text = "0000 0000";
            ac_txt.Text = "0000 0000";
            z_txt.Text = "0";
            cpu.SetRegistersValue("ar", 0);
            cpu.SetRegistersValue("pc", 0);
            cpu.SetRegistersValue("dr", 0);
            cpu.SetRegistersValue("tr", 0);
            cpu.SetRegistersValue("ir", 0);
            cpu.SetRegistersValue("r", 0);
            cpu.SetRegistersValue("ac", 0);
            cpu.SetRegistersValue("z", 0);
            memoryCount = 0;
            fetchCounter = 0;
            stacCounter = 0;
            ldacCounter = 0;
            instructionReaderTimer.Stop();
            traceResults.RemoveAllStatements();
        }
    }
}
