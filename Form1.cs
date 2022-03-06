using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TaskForm
{    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Stopwatch stopWatch = new Stopwatch();
           string result=""; 

            var task =new Task(()=>{
                stopWatch.Start();
                result= Fibo(textBox1.Text).ToString();           
            });

            task.ContinueWith((previousTask)=>{
                textBox2.Text=result;
                stopWatch.Stop();
                label1.Text=(stopWatch.ElapsedMilliseconds/1000).ToString();
                stopWatch.Reset();
            },TaskScheduler.FromCurrentSynchronizationContext());
 
            task.Start();
        }

        private ulong Fibo(string nthValue){
            try{
                
                ulong x = 0,y=1,z=0,nth,i;
                nth=Convert.ToUInt64(nthValue);

                for(i=1;i<=nth;i++){
                    z=x+y;
                    x=y;
                    y=z;
                    label1.Text=i.ToString();
                }
                return z;

            }
            catch{}
            return 0;
        }
    }  

}
