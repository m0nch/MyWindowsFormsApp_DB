using IMyWindowsFormsApp.Data.DAL;
//using IMyWindowsFormsApp.Data.Models;
using IMyWindowsFormsApp.Forms;
using IMyWindowsFormsApp.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IMyWindowsFormsApp
{
    public partial class SecondForm : Form
    {
        private readonly IStudentService _studentService;
        private readonly IAddressService _addressService;
        private AddressForm _addressForm;
        private readonly _IAppCache _appCache;

        public SecondForm(
            IStudentService studentService,
            IAddressService addressService,
            AddressForm addressForm,
            _IAppCache appCache)
        {
            InitializeComponent();
            _studentService = studentService;
            _addressService = addressService;
            _addressForm = addressForm;
            _appCache = appCache;
        }
        private void SecondForm_Load(object sender, EventArgs e)
        {
            grdStudents.AutoGenerateColumns = false;
            RefreshStudents();
            //if (grdStudents.SelectedRows.Count > 0)
            //{
            //    ShowRow();
            //}
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                TeacherId = (Guid)_appCache._ViewBag["TeacherId"],
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Age = Convert.ToInt32(txtAge.Text)
            };
            _studentService.Add(student);
            _studentService.Save();
            RefreshStudents();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Student student = _studentService.Get(Guid.Parse(grdStudents.SelectedRows[0].Cells["Id"].Value.ToString()));
            _studentService.Remove(student);
            _studentService.Save();
            RefreshStudents();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                Id = Guid.Parse(lblGuid.Text),
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Age = Convert.ToInt32(txtAge.Text),
                TeacherId = Guid.Parse(lblTGuid.Text)
            };
            _studentService.Update(student);
            _studentService.Save();
            RefreshStudents();
        }
        private void grdStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowRow();
        }
        private void grdStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var objId = ((DataGridView)sender).SelectedRows[0].Cells["Id"].Value;
                var objName = (object)string.Concat(((DataGridView)sender).SelectedRows[0].Cells["stLastName"].Value, " ", ((DataGridView)sender).SelectedRows[0].Cells["stFirstName"].Value);
                if (!_appCache._ViewBag.ContainsValue(objId))
                {
                    _appCache._ViewBag.Add("StudentId", objId);
                    _appCache._ViewBag.Add("StudentName", objName);
                }
                _addressForm.ShowDialog();
                _addressForm.Activate();
            }
        }
        private void RefreshStudents()
        {
            grdStudents.DataSource = null;
            grdStudents.DataSource = _studentService.GetAllByTeacher((Guid)_appCache._ViewBag["TeacherId"]);
            if (grdStudents.Rows.Count > 0)
            {
                grdStudents.Rows[0].Selected = true;
            }
            ShowRow();
        }
        private void SecondForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _appCache._ViewBag.Remove("TeacherId");
        }
        private void ShowRow()
        {
            if (grdStudents.SelectedRows.Count > 0)
            {
                lblGuid.Visible = true; lblTGuid.Visible = true;
                lblGuid.Text = grdStudents.SelectedRows[0].Cells["id"].Value.ToString();
                lblTGuid.Text = grdStudents.SelectedRows[0].Cells["TeacherId"].Value.ToString();
                txtLastName.Text = grdStudents.SelectedRows[0].Cells["stLastName"].Value.ToString();
                txtFirstName.Text = grdStudents.SelectedRows[0].Cells["stFirstName"].Value.ToString();
                txtAge.Text = grdStudents.SelectedRows[0].Cells["stAge"].Value.ToString();
            }
            else
            {
                lblGuid.Visible = false; lblTGuid.Visible = false;
                lblGuid.Text = "";
                lblTGuid.Text = "";
                txtLastName.Text = "";
                txtFirstName.Text = "";
                txtAge.Text = "";
            }
        }
    }
}
