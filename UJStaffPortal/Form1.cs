using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BusinessLayer;

namespace UJStaffPortal
{
    public partial class Form1 : Form
    {
        BusinessLogic businessInst = new BusinessLogic();

        public Form1()
        {
            InitializeComponent();
        }


        private void createBtn_Click(object sender, EventArgs e)
        {
            string idNumber = idTxbx.Text;
            string name = nameTxbx.Text;
            string surname = surnameTxbx.Text;           
            emailLbl.Text = businessInst.GenerateEmail(name, surname);
            ageLbl.Text = businessInst.CalculateAge(idNumber);
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {
            string idNum = idTxbx.Text;
            string name = nameTxbx.Text;
            string surname = surnameTxbx.Text;
            businessInst.SaveDataToFile(name, surname, idNum);         
            MessageBox.Show("Written to file");
        }



        private void readBtn_Click(object sender, EventArgs e)
        {
            var reader = businessInst.GetAllData();
            listBox.Items.Clear();
            foreach (var line in reader)
            {
                listBox.Items.Add(line);
            }
        }



        private void clearBtn_Click(object sender, EventArgs e)
        {
            idTxbx.Clear();
            nameTxbx.Clear();
            surnameTxbx.Clear();
            emailLbl.Text = " ";
            ageLbl.Text = " ";
            listBox.Items.Clear();
        }


        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
