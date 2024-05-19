﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XtremePharmacyManager.DataEntities;
using static XtremePharmacyManager.ImageBinConverter;
namespace XtremePharmacyManager
{
    public partial class frmEditPaymentMethod : Form
    {
        PaymentMethod target;
        public frmEditPaymentMethod(ref PaymentMethod target)
        {
            InitializeComponent();
            this.target = target;
        }


        private void frmEditPaymentMethod_Load(object sender, EventArgs e)
        {
            this.txtID.Text = (target.ID >= 0) ? target.ID.ToString() : string.Empty;
            this.txtMethodName.Text = (!String.IsNullOrEmpty(target.MethodName)) ? target.MethodName.ToString() : string.Empty;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (target != null)
                {
                    target.ID = Int32.Parse(txtID.Text);
                    target.MethodName = txtMethodName.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
