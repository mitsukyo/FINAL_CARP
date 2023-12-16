using _2CARPENELLI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RSCSS
{
    public class CPU
    {
        public System.Windows.Forms.Label Status_txt { get; set; }
        public System.Windows.Forms.Label Rtl_txt { get; set; }
        public System.Windows.Forms.Label Datamove_txt { get; set; }
        public System.Windows.Forms.Label Ar_txt { get; set; }
        public System.Windows.Forms.Label Pc_txt { get; set; }
        public System.Windows.Forms.Label Dr_txt { get; set; }
        public System.Windows.Forms.Label Tr_txt { get; set; }
        public System.Windows.Forms.Label Ir_txt { get; set; }
        public System.Windows.Forms.Label R_txt { get; set; }
        public System.Windows.Forms.Label Ac_txt { get; set; }
        public System.Windows.Forms.Label Z_txt { get; set; }

        public ViewSystem viewSystem;

        public long IOint = 0;
        public string IO = "00000000";
        private int ar = 0x00000000;
        private int pc = 0x00000000;
        private int dr = 0x00000000;
        private int tr = 0x00000000;
        private int ir = 0x00000000;
        private int r = 0x00000000;
        private int ac = 0x00000000;
        private int z = 0;

        public int Z
        {
            get { return z; }
            set { z = value; }
        }

        public void SetViewSystem(ViewSystem vs)
        {
            this.viewSystem = vs;
        }
        TraceResults results;
        public CPU(TraceResults results,System.Windows.Forms.Label status_txt, System.Windows.Forms.Label rtl_txt, System.Windows.Forms.Label datamove_txt)
        {
            this.results = results;
            Status_txt = status_txt;
            Rtl_txt = rtl_txt;
            Datamove_txt = datamove_txt;
        }
        public void SetRegisters(System.Windows.Forms.Label ar_txt, System.Windows.Forms.Label pc_txt, System.Windows.Forms.Label dr_txt, System.Windows.Forms.Label tr_txt, System.Windows.Forms.Label ir_txt, System.Windows.Forms.Label r_txt, System.Windows.Forms.Label ac_txt, System.Windows.Forms.Label z_txt)
        {
            Ar_txt = ar_txt;
            Pc_txt = pc_txt;
            Dr_txt = dr_txt;
            Tr_txt = tr_txt;
            Ir_txt = ir_txt;
            R_txt = r_txt;
            Ac_txt = ac_txt;
            Z_txt = z_txt;
        }
        public void SetRegistersValue(string name, int num)
        {
     /*/ Console.WriteLine(name);/*/
            switch (name)
            {
                case "ar":
                    ar = num;
                    break;
                case "pc":
                    pc = num;
                    break;
                case "dr":
                    dr = num;
                    break;
                case "tr":
                    tr = num;
                    break;
                case "ir":
                    ir = num;
                    break;
                case "r":
                    r = num;
                    break;
                case "ac":
                    ac = num;
                    break;
                case "z":
                    z = num;
                    break;
            }
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
  
        public void Fetches(short memorycode, int fetchCounter)
        {
            Console.WriteLine("Fetcher: "+ fetchCounter);
            switch (fetchCounter)
            {
                case 0:
                    viewSystem.FETCH1 = true;
                    viewSystem.ARRed(1);
                    viewSystem.PCRed(1);
                    viewSystem.DRRed(0);
                    viewSystem.TRRed(0);
                    viewSystem.IRRed(0);
                    viewSystem.RRed(0);
                    viewSystem.ACRed(0);
                    viewSystem.ZRed(0);
                    viewSystem.readRed(0);
                    viewSystem.writeRed(0);
                    Ar_txt.ForeColor = Color.Red;
                    Pc_txt.ForeColor = Color.Red;
                    Dr_txt.ForeColor = Color.White;
                    Tr_txt.ForeColor = Color.White;
                    Ir_txt.ForeColor = Color.White;
                    R_txt.ForeColor = Color.White;
                    Ac_txt.ForeColor = Color.White;
                    Z_txt.ForeColor = Color.White;

                    ar = pc;
                    Status_txt.Text = "Running";
                    Rtl_txt.Text = "Fetch 1";
                    Datamove_txt.Text = "AR <- PC";
                    Ar_txt.Text = SpaceInserter(ar, "ar");
                    Pc_txt.Text = SpaceInserter(pc, "pc");
                    Dr_txt.Text = SpaceInserter(dr, "dr");
                    Tr_txt.Text = SpaceInserter(tr, "tr");
                    Ir_txt.Text = SpaceInserter(ir, "ir");
                    R_txt.Text = SpaceInserter(r, "r");
                    Ac_txt.Text = SpaceInserter(ac, "ac");
                    Z_txt.Text = SpaceInserter(z, "z");

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                    break;
                case 1:
                    viewSystem.FETCH2 = true;
                    viewSystem.ARRed(0);
                    viewSystem.PCRed(1);
                    viewSystem.DRRed(1);
                    viewSystem.readRed(1);
                    Ar_txt.ForeColor = Color.White;
                    Pc_txt.ForeColor = Color.Red;
                    Dr_txt.ForeColor = Color.Red;
                    //Addition
                    pc = pc + 1;
                    dr = memorycode;

                    Rtl_txt.Text = "Fetch 2";
                    Datamove_txt.Text = "DR <- M, PC <- PC+1";
                    Pc_txt.Text = SpaceInserter(pc, "pc");
                    Dr_txt.Text = SpaceInserter(dr, "dr");

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);viewSystem.ARRed(1);
                    break;
                case 2:
                    viewSystem.FETCH3 = true;
                    viewSystem.PCRed(1);
                    viewSystem.DRRed(1);
                    viewSystem.IRRed(1);
                    viewSystem.ARRed(1);
                    viewSystem.readRed(0);
                    Ir_txt.ForeColor = Color.Red;
                    Ar_txt.ForeColor = Color.Red;
                    Pc_txt.ForeColor = Color.Red;
                    Dr_txt.ForeColor = Color.Red;
                    ar = pc;
                    ir = dr;
                    Rtl_txt.Text = "Fetch 3";
                    Datamove_txt.Text = "IR <- DR, AR <- PC";
                    Ar_txt.Text = SpaceInserter(ar, "ar");
                    Ir_txt.Text = SpaceInserter(ir, "ir");

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                    break;
                default: 
                    break;
            }
            return;
        }

        //NO Operand Instructions
        public void NOP() {
            viewSystem.ARRed(0);
            viewSystem.PCRed(0);
            viewSystem.DRRed(0);
            viewSystem.TRRed(0);
            viewSystem.IRRed(0);
            viewSystem.RRed(0);
            viewSystem.ACRed(0);
            viewSystem.ZRed(0);

            Ar_txt.ForeColor = Color.White;
            Pc_txt.ForeColor = Color.White;
            Dr_txt.ForeColor = Color.White;
            Tr_txt.ForeColor = Color.White;
            Ir_txt.ForeColor = Color.White;
            R_txt.ForeColor = Color.White;
            Ac_txt.ForeColor = Color.White;
            Z_txt.ForeColor = Color.White;
            Rtl_txt.Text = "NOP";
            Datamove_txt.Text = "No Operation";

            results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
        }
        public void MVAC() {
            viewSystem.ARRed(1);
            viewSystem.PCRed(0);
            viewSystem.DRRed(0);
            viewSystem.TRRed(0);
            viewSystem.IRRed(0);
            viewSystem.RRed(1);
            viewSystem.ACRed(0);
            viewSystem.ZRed(0);

            Ar_txt.ForeColor = Color.Red;
            Pc_txt.ForeColor = Color.White;
            Dr_txt.ForeColor = Color.White;
            Tr_txt.ForeColor = Color.White;
            Ir_txt.ForeColor = Color.White;
            R_txt.ForeColor = Color.Red;
            Ac_txt.ForeColor = Color.White;
            Z_txt.ForeColor = Color.White;

            r = ac;
            Rtl_txt.Text = "MVAC";
            Datamove_txt.Text = "R <- AC";
            R_txt.Text = SpaceInserter(r, "r");

            results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
        }
        public void MOVR() {
            viewSystem.ARRed(0);
            viewSystem.PCRed(0);
            viewSystem.DRRed(0);
            viewSystem.TRRed(0);
            viewSystem.IRRed(0);
            viewSystem.RRed(1);
            viewSystem.ACRed(1);
            viewSystem.ZRed(0);

            Ar_txt.ForeColor = Color.White;
            Pc_txt.ForeColor = Color.White;
            Dr_txt.ForeColor = Color.White;
            Tr_txt.ForeColor = Color.White;
            Ir_txt.ForeColor = Color.White;
            R_txt.ForeColor = Color.Red;
            Ac_txt.ForeColor = Color.Red;
            Z_txt.ForeColor = Color.White;

            ac = r;
            Rtl_txt.Text = "MOVR";
            Datamove_txt.Text = "AC <- R";
            Ac_txt.Text = SpaceInserter(ac, "ac");

            results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
        }

        //ALU
        public void ADD() {
            viewSystem.ARRed(0);
            viewSystem.PCRed(0);
            viewSystem.DRRed(0);
            viewSystem.TRRed(0);
            viewSystem.IRRed(0);
            viewSystem.RRed(1);
            viewSystem.ACRed(1);
            viewSystem.ZRed(1);

            Ar_txt.ForeColor = Color.White;
            Pc_txt.ForeColor = Color.White;
            Dr_txt.ForeColor = Color.White;
            Tr_txt.ForeColor = Color.White;
            Ir_txt.ForeColor = Color.White;
            R_txt.ForeColor = Color.Red;
            Ac_txt.ForeColor = Color.Red;
            Z_txt.ForeColor = Color.Red;

            ac = ac + r;

            // Set z based on the result
            z = (ac == 0) ? 1 : 0;

            Rtl_txt.Text = "ADD";
            Datamove_txt.Text = "AC <- AC + R";
            Ac_txt.Text = SpaceInserter(ac, "ac");
            Z_txt.Text = SpaceInserter(z, "z");

            results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
        }
        public void SUB() {
            viewSystem.ARRed(0);
            viewSystem.PCRed(0);
            viewSystem.DRRed(0);
            viewSystem.TRRed(0);
            viewSystem.IRRed(0);
            viewSystem.RRed(1);
            viewSystem.ACRed(1);
            viewSystem.ZRed(1);

            Ar_txt.ForeColor = Color.White;
            Pc_txt.ForeColor = Color.White;
            Dr_txt.ForeColor = Color.White;
            Tr_txt.ForeColor = Color.White;
            Ir_txt.ForeColor = Color.White;
            R_txt.ForeColor = Color.Red;
            Ac_txt.ForeColor = Color.Red;
            Z_txt.ForeColor = Color.Red;

            ac = ac - r;

            // Set z based on the result
            z = (ac == 0) ? 1 : 0;

            Rtl_txt.Text = "SUB";
            Datamove_txt.Text = "AC <- AC - R";
            Ac_txt.Text = SpaceInserter(ac, "ac");
            Z_txt.Text = SpaceInserter(z, "z");

            results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
        }
        public void INAC() {
            viewSystem.ARRed(0);
            viewSystem.PCRed(0);
            viewSystem.DRRed(0);
            viewSystem.TRRed(0);
            viewSystem.IRRed(0);
            viewSystem.RRed(1);
            viewSystem.ACRed(1);
            viewSystem.ZRed(1);

            Ar_txt.ForeColor = Color.White;
            Pc_txt.ForeColor = Color.White;
            Dr_txt.ForeColor = Color.White;
            Tr_txt.ForeColor = Color.White;
            Ir_txt.ForeColor = Color.White;
            R_txt.ForeColor = Color.Red;
            Ac_txt.ForeColor = Color.Red;
            Z_txt.ForeColor = Color.Red;

            ac = ac + 1;

            // Set z based on the result
            z = (ac == 0) ? 1 : 0;

            Rtl_txt.Text = "INAC";
            Datamove_txt.Text = "AC <- AC + 1";
            Ac_txt.Text = SpaceInserter(ac, "ac");
            Z_txt.Text = SpaceInserter(z, "z");

            results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
        }
        public void CLAC() {
            viewSystem.ARRed(0);
            viewSystem.PCRed(0);
            viewSystem.DRRed(0);
            viewSystem.TRRed(0);
            viewSystem.IRRed(0);
            viewSystem.RRed(0);
            viewSystem.ACRed(1);
            viewSystem.ZRed(1);

            Ar_txt.ForeColor = Color.White;
            Pc_txt.ForeColor = Color.White;
            Dr_txt.ForeColor = Color.White;
            Tr_txt.ForeColor = Color.White;
            Ir_txt.ForeColor = Color.White;
            R_txt.ForeColor = Color.White;
            Ac_txt.ForeColor = Color.Red;
            Z_txt.ForeColor = Color.Red;

            ac = 0;
            z = 1;

            Rtl_txt.Text = "CLAC";
            Datamove_txt.Text = "AC <- 0, Z <- 1";
            Ac_txt.Text = SpaceInserter(ac, "ac");
            Z_txt.Text = SpaceInserter(z, "z");

            results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
        }
        public void AND() {
            viewSystem.ARRed(0);
            viewSystem.PCRed(0);
            viewSystem.DRRed(0);
            viewSystem.TRRed(0);
            viewSystem.IRRed(0);
            viewSystem.RRed(1);
            viewSystem.ACRed(1);
            viewSystem.ZRed(1);

            Ar_txt.ForeColor = Color.White;
            Pc_txt.ForeColor = Color.White;
            Dr_txt.ForeColor = Color.White;
            Tr_txt.ForeColor = Color.White;
            Ir_txt.ForeColor = Color.White;
            R_txt.ForeColor = Color.Red;
            Ac_txt.ForeColor = Color.Red;
            Z_txt.ForeColor = Color.Red;

            // Perform bitwise AND on ac and r
            ac = ac & r;

            // Set z based on the result
            z = (ac == 0) ? 1 : 0;

            // Update UI and status
            Rtl_txt.Text = "AND";
            Datamove_txt.Text = "AC <- AC & r";
            Ac_txt.Text = SpaceInserter(ac, "ac");
            Z_txt.Text = SpaceInserter(z, "z");

            results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
        }
        public void OR() {
            viewSystem.ARRed(0);
            viewSystem.PCRed(0);
            viewSystem.DRRed(0);
            viewSystem.TRRed(0);
            viewSystem.IRRed(0);
            viewSystem.RRed(0);
            viewSystem.ACRed(1);
            viewSystem.ZRed(1);

            Ar_txt.ForeColor = Color.White;
            Pc_txt.ForeColor = Color.White;
            Dr_txt.ForeColor = Color.White;
            Tr_txt.ForeColor = Color.White;
            Ir_txt.ForeColor = Color.White;
            R_txt.ForeColor = Color.White;
            Ac_txt.ForeColor = Color.Red;
            Z_txt.ForeColor = Color.Red;

            ac = ac | 1;
            z = (ac == 0) ? 1 : 0;

            Rtl_txt.Text = "OR";
            Datamove_txt.Text = "AC <- AC | r";
            Ac_txt.Text = SpaceInserter(ac, "ac");
            Z_txt.Text = SpaceInserter(z, "z");

            results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
        }   
        public void XOR() {
            viewSystem.ARRed(0);
            viewSystem.PCRed(0);
            viewSystem.DRRed(0);
            viewSystem.TRRed(0);
            viewSystem.IRRed(0);
            viewSystem.RRed(0);
            viewSystem.ACRed(1);
            viewSystem.ZRed(1);

            Ar_txt.ForeColor = Color.White;
            Pc_txt.ForeColor = Color.White;
            Dr_txt.ForeColor = Color.White;
            Tr_txt.ForeColor = Color.White;
            Ir_txt.ForeColor = Color.White;
            R_txt.ForeColor = Color.White;
            Ac_txt.ForeColor = Color.Red;
            Z_txt.ForeColor = Color.Red;
            // Perform bitwise XOR on ac and 1
            ac = ac ^ 1;

            // Set z based on the result
            z = (ac == 0) ? 1 : 0;

            // Update UI and status
            Rtl_txt.Text = "XOR";
            Datamove_txt.Text = "AC <- AC ^ r";
            Ac_txt.Text = SpaceInserter(ac, "ac");
            Z_txt.Text = SpaceInserter(z, "z");

            results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
        }
        public void NOT() {
            viewSystem.ARRed(0);
            viewSystem.PCRed(0);
            viewSystem.DRRed(0);
            viewSystem.TRRed(0);
            viewSystem.IRRed(0);
            viewSystem.RRed(0);
            viewSystem.ACRed(1);
            viewSystem.ZRed(1);

            Ar_txt.ForeColor = Color.White;
            Pc_txt.ForeColor = Color.White;
            Dr_txt.ForeColor = Color.White;
            Tr_txt.ForeColor = Color.White;
            Ir_txt.ForeColor = Color.White;
            R_txt.ForeColor = Color.White;
            Ac_txt.ForeColor = Color.Red;
            Z_txt.ForeColor = Color.Red;

            // Perform bitwise NOT on ac
            ac = ~ac;

            // Set z based on the result
            z = (ac == 0) ? 1 : 0;

            // Update UI and status
            Rtl_txt.Text = "NOT";
            Datamove_txt.Text = "AC <- ~AC";
            Ac_txt.Text = SpaceInserter(ac, "ac");
            Z_txt.Text = SpaceInserter(z, "z");

            results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
        }
        
        public void END() {
            viewSystem.ARRed(0);
            viewSystem.PCRed(0);
            viewSystem.DRRed(0);
            viewSystem.TRRed(0);
            viewSystem.IRRed(0);
            viewSystem.RRed(0);
            viewSystem.ACRed(0);
            viewSystem.ZRed(0);

            Ar_txt.ForeColor = Color.White;
            Pc_txt.ForeColor = Color.White;
            Dr_txt.ForeColor = Color.White;
            Tr_txt.ForeColor = Color.White;
            Ir_txt.ForeColor = Color.White;
            R_txt.ForeColor = Color.White;
            Ac_txt.ForeColor = Color.White;
            Z_txt.ForeColor = Color.White;

            Status_txt.Text = "Stopped";
            Rtl_txt.Text = "END";
            Datamove_txt.Text = "NONE";
            Ar_txt.Text = SpaceInserter(ar, "ar");
            Pc_txt.Text = SpaceInserter(pc, "pc");
            Dr_txt.Text = SpaceInserter(dr, "dr");
            Tr_txt.Text = SpaceInserter(tr, "tr");
            Ir_txt.Text = SpaceInserter(ir, "ir");
            R_txt.Text = SpaceInserter(r, "r");
            Ac_txt.Text = SpaceInserter(ac, "ac");
            Z_txt.Text = SpaceInserter(z, "z");

            results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
        }

        //One Operand Instructions
        public void LDAC(short memorycode, int choice) {
            switch (choice)
            {
                case 0:
                    viewSystem.LDAC1 = true;
                    viewSystem.ARRed(1);
                    viewSystem.PCRed(1);
                    viewSystem.DRRed(1);
                    viewSystem.TRRed(0);
                    viewSystem.IRRed(0);
                    viewSystem.RRed(0);
                    viewSystem.ACRed(0);
                    viewSystem.ZRed(0);

                    Ar_txt.ForeColor = Color.Red;
                    Pc_txt.ForeColor = Color.Red;
                    Dr_txt.ForeColor = Color.Red;
                    Tr_txt.ForeColor = Color.White;
                    Ir_txt.ForeColor = Color.White;
                    R_txt.ForeColor = Color.White;
                    Ac_txt.ForeColor = Color.White;
                    Z_txt.ForeColor = Color.White;

                    dr = memorycode;
                    ar = ar + 1;
                    pc = pc + 1;
                    Rtl_txt.Text = "LDAC 1";
                    Datamove_txt.Text = "DR <- M, PC <- PC + 1, AR <- AR + 1";
                    Ar_txt.Text = SpaceInserter(ar, "ar");
                    Pc_txt.Text = SpaceInserter(pc, "pc");
                    Dr_txt.Text = SpaceInserter(dr, "dr");

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                    break;
                case 1:
                    viewSystem.LDAC2 = true;
                    viewSystem.ARRed(0);
                    viewSystem.PCRed(1);
                    viewSystem.DRRed(1);
                    viewSystem.TRRed(1);

                    Ar_txt.ForeColor = Color.White;
                    Pc_txt.ForeColor = Color.Red;
                    Dr_txt.ForeColor = Color.Red;
                    Tr_txt.ForeColor = Color.Red;

                    tr = dr;
                    dr = memorycode;
                    pc = pc + 1;
                    Rtl_txt.Text = "LDAC 2";
                    Datamove_txt.Text = "TR <- DR, DR <- M, PC = PC + 1";
                    Pc_txt.Text = SpaceInserter(pc, "pc");
                    Dr_txt.Text = SpaceInserter(dr, "dr");
                    Tr_txt.Text = SpaceInserter(tr, "tr");

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                    break;
                case 2:
                    viewSystem.LDAC3 = true;
                    viewSystem.ARRed(1);
                    viewSystem.PCRed(0);
                    viewSystem.DRRed(1);
                    viewSystem.TRRed(1);

                    Ar_txt.ForeColor = Color.Red;
                    Pc_txt.ForeColor = Color.White;
                    Dr_txt.ForeColor = Color.Red;
                    Tr_txt.ForeColor = Color.Red;

                    ar = dr | tr;
                    Rtl_txt.Text = "LDAC 3";
                    Datamove_txt.Text = "AR <- DR | TR";
                    Ar_txt.Text = SpaceInserter(ar, "ar");

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                    break;
                case 3:
                    viewSystem.LDAC4 = true;
                    viewSystem.readRed(0);
                    viewSystem.ARRed(0);
                    viewSystem.PCRed(0);
                    viewSystem.DRRed(1);
                    viewSystem.TRRed(0);

                    Ar_txt.ForeColor = Color.White;
                    Pc_txt.ForeColor = Color.White;
                    Dr_txt.ForeColor = Color.Red;
                    Tr_txt.ForeColor = Color.White;

                    dr = memorycode;
                    Rtl_txt.Text = "LDAC 4";
                    Datamove_txt.Text = "DR <- M";
                    Dr_txt.Text = SpaceInserter(dr, "dr");

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                    break;
                case 4:
                    viewSystem.ARRed(0);
                    viewSystem.PCRed(0);
                    viewSystem.DRRed(1);
                    viewSystem.RRed(0);
                    viewSystem.ACRed(1);
                    viewSystem.ZRed(0);

                    Ar_txt.ForeColor = Color.White;
                    Pc_txt.ForeColor = Color.White;
                    Dr_txt.ForeColor = Color.Red;
                    R_txt.ForeColor = Color.White;
                    Ac_txt.ForeColor = Color.Red;
                    Z_txt.ForeColor = Color.White;

                    ac = dr;
                    Rtl_txt.Text = "LDAC 5";
                    Datamove_txt.Text = "AC <- DR";
                    Ac_txt.Text = SpaceInserter(ac, "ac");

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                    break;
                default:
                    return;
            }
        }
        public short STAC(short memorycode, int choice) {
            switch (choice)
            {
                case 0:
                    viewSystem.STAC1 = true;
                    viewSystem.ARRed(1);
                    viewSystem.PCRed(1);
                    viewSystem.DRRed(1);
                    viewSystem.TRRed(0);
                    viewSystem.IRRed(0);
                    viewSystem.RRed(0);
                    viewSystem.ACRed(0);
                    viewSystem.ZRed(0);

                    Ar_txt.ForeColor = Color.Red;
                    Pc_txt.ForeColor = Color.Red;
                    Dr_txt.ForeColor = Color.Red;

                    dr = memorycode;
                    ar = ar + 1;
                    pc = pc + 1;
                    Rtl_txt.Text = "STAC 1";
                    Datamove_txt.Text = "DR <- M, PC <- PC + 1, AR <- AR + 1";
                    Ar_txt.Text = SpaceInserter(ar, "ar");
                    Pc_txt.Text = SpaceInserter(pc, "pc");
                    Dr_txt.Text = SpaceInserter(dr, "dr");

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                    break;
                case 1:
                    viewSystem.STAC2 = true;
                    viewSystem.ARRed(0);
                    viewSystem.PCRed(1);
                    viewSystem.DRRed(1);
                    viewSystem.TRRed(1);

                    Ar_txt.ForeColor = Color.White;
                    Pc_txt.ForeColor = Color.Red;
                    Dr_txt.ForeColor = Color.Red;
                    Tr_txt.ForeColor = Color.Red;

                    tr = dr;
                    dr = memorycode;
                    pc = pc + 1;
                    Rtl_txt.Text = "STAC 2";
                    Datamove_txt.Text = "TR <- DR, DR <- M, PC <- PC + 1";
                    Pc_txt.Text = SpaceInserter(pc, "pc");
                    Dr_txt.Text = SpaceInserter(dr, "dr");
                    Tr_txt.Text = SpaceInserter(tr, "tr");

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                    break;
                case 2:
                    viewSystem.readRed(0);
                    viewSystem.ARRed(1);
                    viewSystem.PCRed(0);
                    viewSystem.DRRed(1);
                    viewSystem.TRRed(1);

                    Ar_txt.ForeColor = Color.Red;
                    Pc_txt.ForeColor = Color.White;
                    Dr_txt.ForeColor = Color.Red;
                    Tr_txt.ForeColor = Color.Red;

                    ar = dr | tr;
                    Rtl_txt.Text = "STAC 3";
                    Datamove_txt.Text = "AR <- DR | TR";
                    Ar_txt.Text = SpaceInserter(ar, "ar");

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                    break;
                case 3:
                    viewSystem.STAC4 = true;
                    viewSystem.ARRed(0);
                    viewSystem.PCRed(0);
                    viewSystem.DRRed(1);
                    viewSystem.ACRed(1);

                    Ar_txt.ForeColor = Color.White;
                    Pc_txt.ForeColor = Color.White;
                    Dr_txt.ForeColor = Color.Red;
                    Ac_txt.ForeColor = Color.Red;

                    dr = ac;
                    Rtl_txt.Text = "STAC 4";
                    Datamove_txt.Text = "DR <- AC";
                    Dr_txt.Text = SpaceInserter(dr, "dr");

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                    break;
                case 4:
                    viewSystem.STAC5 = true;
                    viewSystem.writeRed(1);
                    viewSystem.DRRed(1);
                    viewSystem.ACRed(1);

                    Ar_txt.ForeColor = Color.White;
                    Pc_txt.ForeColor = Color.White;
                    Dr_txt.ForeColor = Color.Red;
                    Ac_txt.ForeColor = Color.White;

                    memorycode = (short)dr;
                    Rtl_txt.Text = "STAC 5";
                    Datamove_txt.Text = "M <- DR";

                    results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                    break;
                default:
                    return memorycode;
            }
            return memorycode;
        }
        public int JUMP(short memorycode, short[] instructions) {
            int position = memorycode;
            Rtl_txt.Text = "JUMP";
            if (position >= 0 && position < instructions.Length)
            {
                Datamove_txt.Text = "Go To "+ position;
                results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                return position;
            }
            else
            {
                // Handle invalid jump, e.g., by throwing an exception or setting position to a default value
                Datamove_txt.Text = "Invalid Jump";
                Console.WriteLine("Invalid memory line JUMP");
                return -1;
            }
        }
        public int JMPZ(short memorycode, short[] instructions) {
            Rtl_txt.Text = "JMPZ";
            if (z==1)
            {
                int position = JUMP(memorycode, instructions);
                Rtl_txt.Text = "JMPZ";
                Datamove_txt.Text = "Go To " + position;
                results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                return position;
            }
            else
            {
                Rtl_txt.Text = "JMPZ";
                Datamove_txt.Text = "Continue";
                results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                // If the zero flag is not set, return the next instruction position
                return -1;
            }
        }
        public int JPNZ(short memorycode, short[] instructions) {
            if (z==0)
            {
                int position = JUMP(memorycode, instructions);
                Rtl_txt.Text = "JPNZ";
                Datamove_txt.Text = "Go To " + position;
                results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                return position;
            }
            else
            {
                Rtl_txt.Text = "JPNZ";
                Datamove_txt.Text = "Continue";
                results.AddResult(Rtl_txt.Text, Datamove_txt.Text, ar, pc, dr, tr, ir, r, ac, z);
                // If the zero flag is not set, return the next instruction position
                return -1;
            }
        }
    }

}
