using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Med_Match.Forms
{
    public partial class _ِaboutUs : UserControl
    {
        public _ِaboutUs()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            label3.Text = "We are delighted to present our innovative Prescription Detection System App,\r\ndeveloped as our graduation project at the esteemed Faculty of Computer Science in Kafr El Sheikh, Egypt.\r\nOur team of dedicated students aimed to tackle the challenges in prescription management by leveraging advanced technology.\r\nThis article provides an overview of our project, highlighting its inception, development timeline, and the expertise of our team members.\r\n";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            label4.Text = "Our existence is driven by a clear purpose: to revolutionize prescription management in healthcare. Through our Prescription Detection System App,\r\nwe aim to improve patient safety, enhance efficiency, empower patients, bridge the gap in technology, and drive innovation in the healthcare industry.\r\nOur mission is to make a meaningful impact by leveraging advanced technology to address the challenges and inefficiencies in prescription handling";
        }
    }
}
