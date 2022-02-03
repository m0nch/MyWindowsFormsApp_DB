using IMyWindowsFormsApp.Data.DAL;
//using IMyWindowsFormsApp.Data.Models;
using IMyWindowsFormsApp.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IMyWindowsFormsApp.Forms
{
    public partial class AddressForm : Form
    {
        private readonly IAddressService _addressService;
        private readonly _IAppCache _appCache;
        public AddressForm(
            IAddressService addressService,
            _IAppCache appCache)
        {
            InitializeComponent();
            _addressService = addressService;
            _appCache = appCache;
        }
        private void AddressForm_Load(object sender, EventArgs e)
        {
            lblSGuid.Visible = true;
            lblSGuid.Text = _appCache._ViewBag["StudentId"].ToString();
            lblStFullName.Visible = true;
            lblStFullName.Text = _appCache._ViewBag["StudentName"].ToString();
            lblAddressId.Visible = true;
            Address address = _addressService.Get((Guid)_appCache._ViewBag["StudentId"]);
            if (address != null)
            {
                txtAddress1.Text = address.Address1;
                txtAddress2.Text = address.Address2;
                txtCity.Text = address.City;
                txtState.Text = address.State;
                txtCountry.Text = address.Country;
                txtZip.Text = address.ZipCode;
                txtPhone.Text = address.PhoneNumber;
                lblAddressId.Text = address.Id.ToString();
            }
            else
            {
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtCity.Text = "";
                txtState.Text = "";
                txtCountry.Text = "";
                txtZip.Text = "";
                txtPhone.Text = "";
                lblAddressId.Text = "";
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Address address = new Address
            {
                StudentId = (Guid)_appCache._ViewBag["StudentId"],
                Address1 = txtAddress1.Text,
                Address2 = txtAddress2.Text,
                City = txtCity.Text,
                State = txtState.Text,
                Country = txtCountry.Text,
                ZipCode = txtZip.Text,
                PhoneNumber = txtPhone.Text,
                Id = Convert.ToInt32(lblAddressId.Text)
            };
            _addressService.Add(address);
            _addressService.Save();
            MessageBox.Show($"This address\n{txtAddress1.Text} {txtAddress2.Text}\n{txtCity.Text} {txtState.Text} {txtCountry.Text}\n{txtZip.Text} {txtPhone.Text}\nwas added to AddressList", "Addres Info");
            this.Close();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Address address = _addressService.Get((Guid)_appCache._ViewBag["StudentId"]);
            _addressService.Remove(address);
            _addressService.Save();
            MessageBox.Show($"Address was deleted from AddressList", "Addres Info");

            this.Close();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Address address = new Address
            {
                Address1 = txtAddress1.Text,
                Address2 = txtAddress2.Text,
                City = txtCity.Text,
                State = txtState.Text,
                Country = txtCountry.Text,
                ZipCode = txtZip.Text,
                PhoneNumber = txtPhone.Text,
                StudentId = Guid.Parse(lblSGuid.Text),
                Id = Convert.ToInt32(lblAddressId.Text)
            };
            _addressService.Update(address);
            _addressService.Save();
            MessageBox.Show($"The address was edited to this one - \n{txtAddress1.Text} {txtAddress2.Text}\n{txtCity.Text} {txtState.Text} {txtCountry.Text}\n{txtZip.Text} {txtPhone.Text}", "Addres Info");

            this.Close();
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string pattern = "^[+]?[(]?[0-9]{1,3}[)]?[-s.]?[\\s.]?[0-9]{2,3}[-s.]?[\\s.]?[0-9]{6,7}$";
            if (!Regex.IsMatch(txtPhone.Text, pattern))
            {
                txtPhone.Clear();
            }
        }
        private void txtZip_Validating(object sender, CancelEventArgs e)
        {
            string pattern = "^[0-2]{1}[0-9]{3}$";
            if (!Regex.IsMatch(txtZip.Text, pattern))
            {
                txtZip.Clear();
            }
        }

        private void AddressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _appCache._ViewBag.Remove("StudentId");
            _appCache._ViewBag.Remove("StudentName");
        }
    }
}
