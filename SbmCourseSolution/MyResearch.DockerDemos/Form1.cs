using MyResearch.DockerDemos.ReturnStructs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyResearch.DockerDemos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DataGridObjects.Containers _listContainers;
        private void button1_Click(object sender, EventArgs e)
        {

            ListAllContainers();
        }

        public void ListAllContainers()
        {
            var jsons = ExecuteDockerCommandAndGetOutputAsJson("container ls -a");
            string[] jsonsarray = SplitJsonsIntoArray(jsons);

            _listContainers = new DataGridObjects.Containers();
            foreach (var item in jsonsarray)
            {
                if (item.Trim() != "")
                {
                    _listContainers.Add(JsonConvert.DeserializeObject<ReturnStructs.Container>(item));
                }
            }
            dgContainers.DataSource = _listContainers;
        }
        public void ExecuteDockerCommand(string command)
        {
            tbJsons.Text = "";
            var fullCommand = String.Format("docker {0}", command);
            tbCommandsExecuted.Text = tbCommandsExecuted.Text + "docker " + command + Environment.NewLine;
            tbCommandsExecuted.SelectionStart = tbCommandsExecuted.TextLength;
            tbCommandsExecuted.ScrollToCaret();
            var output = RunExternalExe("powershell.exe", fullCommand);
        }
        public string ExecuteDockerCommandAndGetOutputAsJson(string command)
        {
            tbJsons.Text = "";
            var fullCommand = String.Format("docker {0} --format='{{{{json .}}}}'", command);
            tbCommandsExecuted.Text = tbCommandsExecuted.Text + "docker " + command + Environment.NewLine;
            tbCommandsExecuted.SelectionStart = tbCommandsExecuted.TextLength;
            tbCommandsExecuted.ScrollToCaret();
            var output = RunExternalExe("powershell.exe", fullCommand);
            string[] jsonsarray = SplitJsonsIntoArray(output);
            foreach (var item in jsonsarray)
            {
                tbJsons.Text = tbJsons.Text + JsonPrettify(item) + Environment.NewLine;
            }

            return output;
        }
        public async Task ExecuteDockerCommandAndCaptureOutput(string command)
        {
            await Task.Run(() =>
            {
               
                var fullCommand = String.Format("docker {0}", command);

                this.Invoke((MethodInvoker)delegate {
                    tbCommandsExecuted.Text = tbCommandsExecuted.Text + "docker " + command + Environment.NewLine;
                    tbCommandsExecuted.SelectionStart = tbCommandsExecuted.TextLength;
                    tbCommandsExecuted.ScrollToCaret();
                });
                
                RunExternalExeAndCaptureOutput("powershell.exe", fullCommand);
            });
        }
        public string[] SplitJsonsIntoArray(string jsons)
        {
            return jsons.Split(
                            new[] { Environment.NewLine },
                            StringSplitOptions.None
                        );
        }

        private static int CountLines(string str)
        {
            if (str == null)
                throw new ArgumentNullException("str");
            if (str == string.Empty)
                return 0;
            int index = -1;
            int count = 0;
            while (-1 != (index = str.IndexOf(Environment.NewLine, index + 1)))
                count++;

            return count + 1;
        }

        public string RunExternalExe(string filename, string arguments = null)
        {
            var process = new Process();

            process.StartInfo.FileName = filename;
            if (!string.IsNullOrEmpty(arguments))
            {
                process.StartInfo.Arguments = arguments;
            }

            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;

            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            var stdOutput = new StringBuilder();
            process.OutputDataReceived += (sender, args) => stdOutput.AppendLine(args.Data); // Use AppendLine rather than Append since args.Data is one line of output, not including the newline character.

            string stdError = null;
            try
            {
                process.Start();
                process.BeginOutputReadLine();
                stdError = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
            catch (Exception e)
            {
                throw new Exception("OS error while executing " + Format(filename, arguments) + ": " + e.Message, e);
            }

            if (process.ExitCode == 0)
            {
                return stdOutput.ToString();
            }
            else
            {
                var message = new StringBuilder();

                if (!string.IsNullOrEmpty(stdError))
                {
                    message.AppendLine(stdError);
                }

                if (stdOutput.Length != 0)
                {
                    message.AppendLine("Std output:");
                    message.AppendLine(stdOutput.ToString());
                }

                throw new Exception(Format(filename, arguments) + " finished with exit code = " + process.ExitCode + ": " + message);
            }
        }

        private int _pid;
        public void RunExternalExeAndCaptureOutput(string filename, string arguments = null)
        {
            var process = new Process();

            process.StartInfo.FileName = filename;
            if (!string.IsNullOrEmpty(arguments))
            {
                process.StartInfo.Arguments = arguments;
            }

            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;

            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            var stdOutput = new StringBuilder();
            process.OutputDataReceived += Process_OutputDataReceived;

            string stdError = null;
            try
            {
                process.Start();
                _pid = process.Id;
                this.Invoke((MethodInvoker)delegate {
                    label1.Text = _pid.ToString();
                });
                process.BeginOutputReadLine();
                stdError = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
            catch (Exception e)
            {
                throw new Exception("OS error while executing " + Format(filename, arguments) + ": " + e.Message, e);
            }

           
        }

        private string Format(string filename, string arguments)
        {
            return "'" + filename +
                ((string.IsNullOrEmpty(arguments)) ? string.Empty : " " + arguments) +
                "'";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var jsons = ExecuteDockerCommandAndGetOutputAsJson("version");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var jsons = ExecuteDockerCommandAndGetOutputAsJson("image ls");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var container in _listContainers)
            {
                ExecuteDockerCommand("container stop " + container.Id);
            }
            ListAllContainers();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var container in _listContainers)
            {
                ExecuteDockerCommand("container rm " + container.Id);
            }
            ListAllContainers();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:5001/api/barcode/FOOBAR12345");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var container = (ReturnStructs.Container)dgContainers.SelectedRows[0].DataBoundItem;
            ExecuteDockerCommand("container start " + container.Id);
            ListAllContainers();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var container = (ReturnStructs.Container)dgContainers.SelectedRows[0].DataBoundItem;
            ExecuteDockerCommand("container stop " + container.Id);
            ListAllContainers();
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            //docker logs --follow generatebarcodecontainer
            await ExecuteDockerCommandAndCaptureOutput("logs --follow generatebarcodecontainer");
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                tbCommandsExecuted.Text = tbCommandsExecuted.Text + "docker " + e.Data + Environment.NewLine;
                tbCommandsExecuted.SelectionStart = tbCommandsExecuted.TextLength;
                tbCommandsExecuted.ScrollToCaret();
            });
        }

        private void button10_Click(object sender, EventArgs e)
        {
            KillProcessAndChildren(_pid);
        }

        private static void KillProcessAndChildren(int pid)
        {
            // Cannot close 'system idle process'.
            if (pid == 0)
            {
                return;
            }
            ManagementObjectSearcher searcher = new ManagementObjectSearcher
                    ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc)
            {
                KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
            }
            try
            {
                Process proc = Process.GetProcessById(pid);
                proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }
        }
    }
}
