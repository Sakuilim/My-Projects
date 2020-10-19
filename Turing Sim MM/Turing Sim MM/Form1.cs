using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turing_UI
{
    public partial class Form1 : Form
    {
        FileReader Txt = new FileReader();
        Logic W = new Logic();
        Logic W1 = new Logic();
        Logic W2 = new Logic();
        Logic W3 = new Logic();
        public int[] chk = new int[5] { 0, 0, 0, 0, 0 };
        public bool[] btn = new bool[4] { false, false, false, false };
        Variables Duom = new Variables();
        CancellationTokenSource cts = null;
        public Form1()
        {
            InitializeComponent();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            if (tBox1.Text != "")
            {
                btn[0] = true;
                UI(btn);
                cts = new CancellationTokenSource();
                var token = cts.Token;
                Logic.Info info = W.Machine(Duom.name[0]);
                foreach (var ats1 in FileReader.Veiksmas(info.log, info.x, Duom.ats, info.arr, info.instr, Duom.h, Duom.Stop, Duom.ATS, token))
                {
                    await Task.Delay(1);
                    tBox1.Text = ats1;
                }
                
            }
            btn[0] = false;
        }
        private async void strtBtn2_Click(object sender, EventArgs e)
        {
            if (tBox2.Text != "")
            {
                btn[1] = true;
                UI(btn);
                cts = new CancellationTokenSource();
                var token = cts.Token;
                Logic.Info info1 = W.Machine(Duom.name[1]);
                foreach (var ats2 in FileReader.Veiksmas(info1.log, info1.x, Duom.ats, info1.arr, info1.instr, Duom.h, Duom.Stop, Duom.ATS, token))
                {
                    await Task.Delay(1);
                    tBox2.Text = ats2;
                }
                btn[1] = false;
            }
        }
        private async void strtBtn3_Click(object sender, EventArgs e)
        {
            if (tBox3.Text != "")
            {
                btn[2] = true;
                UI(btn);
                cts = new CancellationTokenSource();
                var token = cts.Token;
                Logic.Info info2 = W.Machine(Duom.name[2]);
                foreach (var ats3 in FileReader.Veiksmas(info2.log, info2.x, Duom.ats, info2.arr, info2.instr, Duom.h, Duom.Stop, Duom.ATS, token))
                {
                    await Task.Delay(1);
                    tBox3.Text = ats3;
                }
                btn[2] = false;
            }
        }
        private async void strtBtn4_Click(object sender, EventArgs e)
        {
            if (tBox4.Text != "")
            {
                btn[3] = true;
                UI(btn);
                cts = new CancellationTokenSource();
                var token = cts.Token;
                Logic.Info info3 = W.Machine(Duom.name[3]);
                foreach (var ats4 in FileReader.Veiksmas(info3.log, info3.x, Duom.ats, info3.arr, info3.instr, Duom.h, Duom.Stop, Duom.ATS, token))
                {
                    await Task.Delay(1);
                    tBox4.Text = ats4;
                }
                btn[3] = false;
            }
        }
        public void fileBtn1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Pasirinkite Faila";
            ofd.Filter = "TXT|*.txt";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Duom.name[0] = ofd.FileName;
                chk[0] = 1;
                go(chk);

            }
            else
            {
                return;
            }
            Duom.first = File.ReadAllLines(Duom.name[0]);//.Where(arg => !string.IsNullOrWhiteSpace(arg));
            tBox1.Text = Duom.first[0];
        }
        private void Filebtn2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Pasirinkite Faila";
            ofd.Filter = "TXT|*.txt";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Duom.name[1] = ofd.FileName;
                chk[1] = 1;
                go(chk);

            }
            else
            {
                return;
            }
            go(chk);
            Duom.first = File.ReadAllLines(Duom.name[1]);//.Where(arg => !string.IsNullOrWhiteSpace(arg));
            tBox2.Text = Duom.first[0];
        }
        public void FileBtn3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Pasirinkite Faila";
            ofd.Filter = "TXT|*.txt";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Duom.name[2] = ofd.FileName;
                chk[2] = 1;
                go(chk);

            }
            else
            {
                return;
            }
            Duom.first = File.ReadAllLines(Duom.name[2]);//.Where(arg => !string.IsNullOrWhiteSpace(arg));
            tBox3.Text = Duom.first[0];
        }
        private void FileBtn4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Pasirinkite Faila";
            ofd.Filter = "TXT|*.txt";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Duom.name[3] = ofd.FileName;
                chk[3] = 1;
                go(chk);
            }
            else
            {
                return;
            }
            Duom.first = File.ReadAllLines(Duom.name[3]);//.Where(arg => !string.IsNullOrWhiteSpace(arg));
            tBox4.Text = Duom.first[0];
        }
        private void strtAllBtn1_Click(object sender, EventArgs e)
        {
            Duom.Stop = false;
            stopBtn1.Enabled = true;
            strtAllBtn1.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            cts = new CancellationTokenSource();
            var token = cts.Token;
            Parallel.Invoke(() =>
            {
                this.BeginInvoke((Action)async delegate ()
               {
                   Logic.Info info = W.Machine(Duom.name[0]);
                   {
                       foreach (var ats1 in FileReader.Veiksmas(info.log, info.x, Duom.ats, info.arr, info.instr, Duom.h, Duom.Stop, Duom.ATS, token))
                       {
                           await Task.Delay(1);
                           tBox1.Text = ats1;
                       }
                   }
               });
            },
            () =>
            {
                this.BeginInvoke((Action)async delegate ()
                {
                    Logic.Info info1 = W1.Machine(Duom.name[1]);
                    foreach (var ats2 in FileReader.Veiksmas(info1.log, info1.x, Duom.ats, info1.arr, info1.instr, Duom.h, Duom.Stop, Duom.ATS, token))
                    {
                        await Task.Delay(1);
                        tBox2.Text = ats2;
                    }
                });
            },
            () =>
            {
                this.BeginInvoke((Action)async delegate ()
                {
                    Logic.Info info2 = W2.Machine(Duom.name[2]);
                    foreach (var ats3 in FileReader.Veiksmas(info2.log, info2.x, Duom.ats, info2.arr, info2.instr, Duom.h, Duom.Stop, Duom.ATS, token))
                    {
                        await Task.Delay(1);
                        tBox3.Text = ats3;
                    }
                });
            },
            () =>
            {
                this.BeginInvoke((Action)async delegate ()
                {
                    Logic.Info info3 = W3.Machine(Duom.name[3]);
                    foreach (var ats4 in FileReader.Veiksmas(info3.log, info3.x, Duom.ats, info3.arr, info3.instr, Duom.h, Duom.Stop, Duom.ATS, token))
                    {
                        await Task.Delay(1);
                        tBox4.Text = ats4;
                    }
                });
            }
            );
        }
        private void extBtn1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void stopBtn1_Click(object sender, EventArgs e)
        {

            this.Enable(true);
            strtAllBtn1.Enable(false);
            go(chk);
            cts.Cancel();
        }
        public void go(int[] chk)
        {
            if (chk[0] == 1 && chk[1] == 1 && chk[2] == 1 && chk[3] == 1 && strtAllBtn1.Enabled == false)
            {
                strtAllBtn1.Enabled = true;
            }
        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };
            func(Controls);
        }
        public void UI(bool[] btn)
        {
            if (btn[0] == true)
            {
                startBtn1.Enable(false);
                groupBox2.Enable(false);
                groupBox3.Enable(false);
                groupBox4.Enable(false);
                fileBtn1.Enable(false);
                strtAllBtn1.Enable(false);
            }
            else if (btn[1] == true)
            {
                strtAllBtn1.Enable(false);
                groupBox1.Enable(false);
                groupBox3.Enable(false);
                groupBox4.Enable(false);
                strtBtn2.Enable(false);
                Filebtn2.Enable(false);
            }
            else if (btn[2] == true)
            {
                strtAllBtn1.Enable(false);
                groupBox1.Enable(false);
                groupBox2.Enable(false);
                groupBox4.Enable(false);
                strtBtn3.Enable(false);
                FileBtn3.Enable(false);
            }
            else if (btn[3] == true)
            {
                strtAllBtn1.Enable(false);
                groupBox1.Enable(false);
                groupBox2.Enable(false);
                groupBox3.Enable(false);
                strtBtn4.Enable(false);
                FileBtn4.Enable(false);
            }

        }


    }
    public static class GuiExtensionMethods
    {
        public static void Enable(this Control con, bool enable)
        {
            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    c.Enable(enable);
                }

                try
                {
                    con.Invoke((MethodInvoker)(() => con.Enabled = enable));
                }
                catch
                {
                }
            }
        }
    }
}
