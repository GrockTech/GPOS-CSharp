﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPOS
{
    public partial class MBox1 : Form
    {
        public MBox1()
        {
            InitializeComponent();
            Messagelbl.Text = Message;


        }

        private void MBox1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        static string Message;
        public static void Show (string msg)
        {
            Message = msg;
            MBox1 Obj = new MBox1();
            Obj.Show();
            Obj.TopMost = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
