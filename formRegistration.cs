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
    public partial class formRegistration : Form
    {

        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        public formRegistration()
        {
            InitializeComponent();
        }

        private void btbRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // This section checks if all of the textbox have no valid input
                if (string.IsNullOrEmpty(txtStudentNo.Text))
                {
                    throw new ArgumentNullException("", "Student Number cannot be empty!");
                }
                if (cbPrograms.SelectedItem == null)
                {
                    throw new ArgumentNullException("", "Select Your Program!");
                }
                if (string.IsNullOrEmpty(txtLastName.Text))
                {
                    throw new ArgumentNullException("", "Last Name cannot be empty!");
                }
                if (string.IsNullOrEmpty(txtFirstName.Text))
                {
                    throw new ArgumentNullException("", "First Name cannot be empty!");
                }
                if (string.IsNullOrEmpty(txtMiddleInitial.Text))
                {
                    throw new ArgumentNullException("", "Middle Initial cannot be empty!");
                }
                if (string.IsNullOrEmpty(txtAge.Text))
                {
                    throw new ArgumentNullException("", "Age cannot be empty!");
                }
                if (cbGender.SelectedItem == null)
                {
                    throw new ArgumentNullException("", "Select your Gender!");
                }
                if (string.IsNullOrEmpty(txtContactNum.Text))
                {
                    throw new ArgumentNullException("", "Contact Number cannot be empty!");
                }

                // Overflow
                if (txtLastName.Text.Length > 15)
                {
                    throw new OverflowException("Last Name is too long Common length is 15 Characters max");
                }
                if (txtMiddleInitial.Text.Length > 2)
                {
                    throw new OverflowException("Middle Initial is too long Common length is 2 Characters max");
                }
                if (txtFirstName.Text.Length > 15)
                {
                    throw new OverflowException("First Name is too long Common length is 15 Characters max");
                }

                // Symbols
                if (Regex.IsMatch(txtLastName.Text, "[0-9]+$"))
                {
                    throw new FormatException("Last Name cannot contain any number or Symbol!");
                }
                if (Regex.IsMatch(txtFirstName.Text, "[0-9]+$"))
                {
                    throw new FormatException("First Name cannot contain any number or Symbol!");
                }
                if (Regex.IsMatch(txtMiddleInitial.Text, "[0-9]"))
                {
                    throw new FormatException("Middle Initial cannot contain any number!");
                }
                if (Regex.IsMatch(txtContactNum.Text, "[a-zA-Z\\W_]+$"))
                {
                    throw new FormatException("Contact Number does not contain any Letters or Symbols!");
                }

                // Out of Bounds
                if (txtContactNum.Text.Length < 10 || txtContactNum.Text.Length > 11)
                {
                    throw new IndexOutOfRangeException("This is an Invalid Contact Number!");
                }
                if (Convert.ToInt32(txtAge.Text) > 150)
                {
                    throw new IndexOutOfRangeException("This age is out of Bounds!");
                }
            }
            catch (ArgumentNullException an)
            {
                MessageBox.Show(an.Message);
                return;
            }
            catch (FormatException fx)
            {
                MessageBox.Show(fx.Message);
                return;
            }
            catch (OverflowException ox)
            {
                MessageBox.Show(ox.Message);
                return;
            }
            catch (IndexOutOfRangeException IOX)
            {
                MessageBox.Show(IOX.Message);
                return;
            }

            StudentInformationClass.SetFullName = FullName(txtLastName.Text,txtFirstName.Text,txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = (int)StudentNumber(txtStudentNo.Text);
            StudentInformationClass.SetProgram = cbPrograms.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNum = ContactNo(txtContactNum.Text.ToString());
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthDay = datePickerBirthday.Value.ToString("yyyy-MM-dd");

            formConfirmation frm = new formConfirmation();
            frm.ShowDialog();
        }

        private void formRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            string[] ListOfGender = new string[]
            {
                "Male",
                "Female"
            };

            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(ListOfGender[i].ToString());
            }
        }
        public long StudentNumber(string studNum)
        {
            _StudentNo = long.Parse(studNum);
            return _StudentNo;
        }
        public long ContactNo(string Contacter)
        {
            if (Regex.IsMatch(Contacter, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contacter);
            }
            return _ContactNo;
        }
        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            return _FullName;
        }
        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }
            return _Age;
        }
    }
}
