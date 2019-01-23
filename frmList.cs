using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proj10FileStreams
{
    
    /// <summary>
    /// Project: File Streams
    /// Task: Defines fields and methods of formList : Form 
    /// Dev: justin Mangan
    /// Date: 1 May 2018
    /// </summary>
    public partial class frmList : Form
    {

        /// <summary>
        /// Instantiates class
        /// </summary>
        string fileName;
        public frmList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Enables save as button on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmList_Load(object sender, EventArgs e)
        {
            btnSaveAs.Enabled = false;
        }

        /// <summary>
        /// Prints data from input fields to text area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, EventArgs e)
        {
            int id = 0;
            bool isValid = true;
            lblMessage.Text = "";

            if(txtBxLastName.Text == "")
            {
                lblMessage.Text += "Last name required. ";
                isValid = false;
            }
            if(txtBxFirstName.Text == "")
            {
                lblMessage.Text += "First Name required";
                isValid = false;
            }
            if(txtBxID.Text == "")
            {
                lblMessage.Text += "ID required";
                isValid = false;
            }
            else if(int.TryParse(txtBxID.Text, out id) == false)
            {
                lblMessage.Text += "ID must be numeric";
                isValid = false;
            }
            if(txtBxClass.Text == "")
            {
                lblMessage.Text += "Class required";
                isValid = false;
            }
            if(txtBxGrade.Text == "")
            {
                lblMessage.Text += "Grade required";
                isValid = false;
            }
            if (isValid)
            {
                StudentClass aStudent = new StudentClass(txtBxLastName.Text,
                                                        txtBxFirstName.Text,
                                                        Convert.ToInt32(txtBxID.Text),
                                                        txtBxClass.Text,
                                                        txtBxGrade.Text);
                lstBxGrades.Items.Add(aStudent);
                lblMessage.Text = "Student added";
                ClearBox();
                btnSaveAs.Enabled = true;
            } 
        }

        /// <summary>
        /// clears input fields
        /// </summary>
        void ClearBox()
        {
            txtBxClass.Clear();
            txtBxFirstName.Clear();
            txtBxGrade.Clear();
            txtBxID.Clear();
            txtBxLastName.Clear();
            txtBxLastName.Focus();
        }

        /// <summary>
        /// Event handler saves text area data to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            try { 
            saveFileDialog1.FileName = fileName;
            saveFileDialog1.ShowDialog();
            fileName = saveFileDialog1.FileName;
            StreamWriter outFile = new StreamWriter(fileName);

            foreach(StudentClass item in lstBxGrades.Items)
            {
                outFile.WriteLine(item.ToFileString());
            }
                outFile.Close();
                lblMessage.Text = "File saved";
            }
            catch(Exception exc)
            {
                lblMessage.Text = exc.Message;
            }
        }

        /// <summary>
        /// Event handler loads from file on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string inputRecord;
            string[] fields;
            try
            {
                openFileDialog1.FileName = fileName;
                openFileDialog1.ShowDialog();
                fileName = openFileDialog1.FileName;
                StreamReader inFile = new StreamReader(fileName);

                inputRecord = inFile.ReadLine();
                while(inputRecord != null)
                {
                    fields = inputRecord.Split(',');
                    StudentClass aStudent = new StudentClass();
                    aStudent.LastName = fields[0];
                    aStudent.FirstName = fields[1];
                    aStudent.IdNumber = Convert.ToInt32(fields[2]);
                    aStudent.ClassName = fields[3];
                    aStudent.Grade = fields[4];
                    lstBxGrades.Items.Add(aStudent);
                    inputRecord = inFile.ReadLine();
                }
                inFile.Close();
                lblMessage.Text = "File loaded";
            }
            catch(Exception exc)
            {
                lblMessage.Text = exc.Message;
            }
        }
    }
}
