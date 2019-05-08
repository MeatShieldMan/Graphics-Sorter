using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp1
{
    public partial class Form1 : Form
    {
        // Global vars
        int[] xpos = new int[776]; // holds values for xposition of rectangles
        List<int> color_value = new List<int>();
        // holds color values of rectangles

        Random rand = new Random(); // ranom number generator for color values
        public Form1()
        {
            InitializeComponent();
           
            find_xpos();
            
        }
       
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            color_value.Clear();
            setlist();
            visualizer();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            quicksort();
            visualizer();
            
            
        }
        public void setlist()
        {
            for (int i = 0; i < xpos.Length; i++)
            {

                int c = rand.Next(0, 255);
                color_value.Add(c);

            }
        }
        public void quicksort()
        {
            int[] colorarray = color_value.ToArray();
            color_value.Clear();
            dothesort(colorarray, 0, colorarray.Length - 1);
            for (int i = 0; i < colorarray.Length; i++)
            {
                color_value.Add(colorarray[i]);
            }

        }
        public void dothesort(int[] carray, int start, int end)
        {
            int pivotpoint;
            if (start < end)
            {
                pivotpoint = partition(carray, start, end);

                dothesort(carray, start, pivotpoint - 1);
                dothesort(carray, pivotpoint + 1, end);
            }

        }
        public int partition(int[] carray, int start, int end)
        {
            // Graphics g = panel1.CreateGraphics();
            int pivotvalue;
            int endofleftlist = 0;
            int mid;

            mid = (start + end) / 2;
            swap(carray, start, mid);

            pivotvalue = carray[start];
            endofleftlist = start;

            for (int scan = start + 1; scan <= end; scan++)
            {
                if (carray[scan] < pivotvalue)
                {
                    endofleftlist++;

                    swap(carray, endofleftlist, scan);
                }

            }


            swap(carray, start, endofleftlist);


            return endofleftlist;
        }

        public void swap(int[] carray, int a, int b)
        {
            int temp;

            temp = carray[a];
            carray[a] = carray[b];
            carray[b] = temp;

        }
        public async void visualizer()
        {
            Graphics g = panel1.CreateGraphics();
            int index = 0;
            foreach (int co in color_value)
            {

                

                Color c = Color.FromArgb(0, 0, co);
                SolidBrush brush = new SolidBrush(c);
                g.FillRectangle(brush, xpos[index], 0, 1, 230);
                index++;
                await Task.Delay(5);

            }
            index = 0;
        }
        public void find_xpos()
        {
            xpos[0] = 0;
            for (int i = 0; i < xpos.Length; i++)
            {

                for (int j = i + 1; j < xpos.Length; j++)
                {
                    xpos[j] = xpos[i] + 1;

                }


            }
        }
    } 


}
