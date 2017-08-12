using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_MultiThreads
{
    /// <summary>
    /// 双色球：投注号码由6个红色球号码和1个蓝色球号码组成。
    /// 红色球号码从01--33中选择
    /// 蓝色球号码从01--16中选择
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.btnStop.Enabled = false;
        }
        /// <summary>
        /// 红色球集合
        /// </summary>
        private string[] RedNums = {  "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16","17","18","19","20",
            "21","22","23","24","25","26","27","28","29","30",
            "31","32","33"};
        /// <summary>
        /// 蓝色球集合
        /// </summary>
        private string[] BlueNums = {  "01","02","03","04","05","06","07","08","09","10",
            "11","12","13","14","15","16"};

        private bool isGoon = true;
        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnStart.Text = "开始ing";
                this.btnStart.Enabled = false;
                this.isGoon = true;
                this.lblBlue.Text = "00";
                this.lblRed1.Text = "00";
                this.lblRed2.Text = "00";
                this.lblRed3.Text = "00";
                this.lblRed4.Text = "00";
                this.lblRed5.Text = "00";
                this.lblRed6.Text = "00";
                Thread.Sleep(1000);

                this.btnStop.Enabled = true;

                List<Task> taskList = new List<Task>();
                TaskFactory taskFactory = new TaskFactory();
                foreach (Control c in this.gboSSQ.Controls)
                {
                    if (c is Label)
                    {
                        Label lbl = (Label)c;
                        taskList.Add(taskFactory.StartNew(() =>
                        {
                            while (isGoon)
                            {
                                string text = this.GetNum(lbl);
                                this.UpdateLbl(lbl, text);
                            }

                        }));
                    }
                }

                taskFactory.ContinueWhenAll(taskList.ToArray(), t => {
                    MessageShow();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("双色球出现异常：{0}", ex.Message);
            }
        }
        /// <summary>
        /// 结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.btnStop.Enabled = false;
            this.btnStart.Enabled = true;
            btnStart.Text = "开始";
            isGoon = false;
           
        }
        /// <summary>
        /// 打印结果
        /// </summary>
        private void MessageShow()
        {
            MessageBox.Show(string.Format("本期双色球结果是 {0} {1} {2} {3} {4} {5}  {6}",
                 lblRed1.Text, lblRed2.Text, lblRed3.Text, lblRed4.Text, lblRed5.Text, lblRed6.Text, lblBlue.Text));
        }
        private static object GetNum_Lock = new object();
        /// <summary>
        /// 获取num
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        private string GetNum(Label label)
        {
            Thread.Sleep(1000);
            if (label.Name.Equals("lblBlue"))
            {
                return this.BlueNums[new Random().Next(0, BlueNums.Length - 1)];//0-15
            }
            else
            {
                //33个选6个
                string text = this.RedNums[new Random().Next(0, RedNums.Length - 1)];//0-15
                lock (GetNum_Lock)
                {
                    List<string> usedNumList = this.GetUsedNums();
                    while (usedNumList.Contains(text))
                    {
                        text = this.RedNums[new Random().Next(0, RedNums.Length - 1)];//0-15
                    }
                    return text;
                }
                 
            }
        }
        /// <summary>
        /// 获取当前界面上的球号码
        /// </summary>
        /// <returns></returns>
        private List<string> GetUsedNums()
        {
            List<string> usedNumList = new List<string>();
            foreach (Control c in this.gboSSQ.Controls)
            {
                if (c is Label && ((Label)c).Name.Contains("Red"))
                {
                    usedNumList.Add(((Label)c).Text);
                }
            }
            return usedNumList;
        }


        /// <summary>
        /// 更新界面
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="text"></param>
        private void UpdateLbl(Label lbl, string text)
        {
            if (lbl.InvokeRequired)
            {
                this.Invoke(new Action(() => lbl.Text = text));//交给UI线程去更新
            }
            else
            {
                lbl.Text = text;
            }
        }
    }
}
