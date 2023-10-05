using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class formConfirmation : Form
    {
        public formConfirmation()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;    
        }

        private void formConfirmation_Load(object sender, EventArgs e)
        {
            lblStudentNo.Text = StudentInformationClass.SetStudentNo.ToString();
            lblName.Text = StudentInformationClass.SetFullName;
            lblBirthday.Text = StudentInformationClass.SetBirthDay;
            lblProgram.Text = StudentInformationClass.SetProgram;
            lblGender.Text = StudentInformationClass.SetGender;
            lblContactNo.Text = StudentInformationClass.SetContactNum.ToString();
            lblAge.Text = StudentInformationClass.SetAge.ToString();
        }
    }
}


