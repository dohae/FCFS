using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{


   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();  
        }
        public ArrayList a = new ArrayList(); 
        class process
        {
            public string name;
            public int burst;
            public int arrival;
            public int start;
            public int wait;
            public int finish;
            public int turnaround;

            public process()
            {
            }
            public process(string name, int burst, int arrival)
            {
                this.name = name;
                this.burst = burst;
                this.arrival = arrival;
            }
        }
     
        public void sort(ArrayList array)         //sorting
        {
            process temp = new process();

            for (int i = 0; i <array.Count; i++)
            {
                for (int sort = 0; sort < array.Count - 1; sort++)
                {
                    if (((process)array[sort]).arrival > ((process)array[sort + 1]).arrival)
                    {
                        temp = (process)array[sort + 1];
                        array[sort + 1] = (process)array[sort];
                        array[sort] = temp;
                    }
                }

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }
        private void button1_Click(object sender, EventArgs e)
                                                                 //adding operation
        {    process p = new process();
            p.name = textBox1.Text;
            p.burst =int.Parse( textBox2.Text);
            p.arrival =int.Parse( textBox4.Text);
            a.Add(p);
            string[] row = { textBox1.Text, textBox2.Text, textBox4.Text };
            var listviewItem = new ListViewItem(row);
            listView3.Items.Add(listviewItem);

            foreach (Control X in this.Controls)
            {
                if (X is TextBox)
                    X.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)  //the operation 
        {
            sort(a);
            for (int i = 0; i < a.Count; i++)
            {
                if (i == 0)
                {
                    ((process)a[0]).start = ((process)a[0]).arrival;
                    ((process)a[0]).finish = ((process)a[0]).burst + ((process)a[0]).start;
                    ((process)a[0]).wait = 0;
                    ((process)a[0]).turnaround = ((process)a[0]).finish - ((process)a[0]).arrival;
                }
                else
                {
                    ((process)a[i]).start = ((process)a[i - 1]).finish;
                    ((process)a[i]).wait = ((process)a[i]).start - ((process)a[i]).arrival;
                    if (((process)a[i]).wait < 0)                        //this process notcome when the before process finish
                    {
                        ((process)a[i]).start = ((process)a[i]).arrival;
                        ((process)a[i]).wait = 0;
                    }
                    ((process)a[i]).finish = ((process)a[i]).start + ((process)a[i]).burst;
                    ((process)a[i]).turnaround = ((process)a[i]).finish - ((process)a[i]).arrival;
                }
            }
            for (int k = 0; k < a.Count; k++)                                  //list view printing
            {
                ListViewItem myitem = new ListViewItem(((process)a[k]).name);
                myitem.SubItems.Add(((process)a[k]).burst.ToString());
                myitem.SubItems.Add(((process)a[k]).arrival.ToString());
                myitem.SubItems.Add(((process)a[k]).start.ToString());
                myitem.SubItems.Add(((process)a[k]).wait.ToString());
                myitem.SubItems.Add(((process)a[k]).finish.ToString());
                myitem.SubItems.Add(((process)a[k]).turnaround.ToString());
                listView1.Items.Add(myitem);
            }  
                                                                                //ganttchart
            label6.Text = ((process)a[0]).start.ToString();
            for (int s = 0; s < a.Count; s++)
            {
                ListViewItem myitem = new ListViewItem(((process)a[s]).name);
                listView2.Items.Add(myitem);
            }
           
            for (int w = 0; w < a.Count; w++)
            {  
                ListViewItem myitems = new ListViewItem(((process)a[w]).finish.ToString());
                listView4.Items.Add(myitems);
            }

          
           int ss = 1;
              for (int i = 0; i < a.Count; i++)
           {
                Label point = new Label();
                point.Location = new Point(ss * 10, 35);
                point.Text = ((process)a[i]).name;
                point.BorderStyle = BorderStyle.Fixed3D;
                point.Size = new Size(((process)a[i]).burst* 10, 35);
                point.BackColor = Color.Gray;
                groupBox1.Controls.Add(point);
                ss +=((process)a[i]).burst;
           }

    

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double AverageTA;
            int sum = 0;
            for (int n = 0; n < a.Count; n++)
            {
                sum = sum + ((process)a[n]).turnaround;
            }
            AverageTA = (sum/a.Count);
            label4.Text = AverageTA.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double AverageWait;
            int sum = 0;
            for (int m = 0; m < a.Count; m++)
            {
                sum = sum + ((process)a[m]).wait;
            }
            AverageWait = (sum / a.Count);
            label5.Text = AverageWait.ToString();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        


    }
}
