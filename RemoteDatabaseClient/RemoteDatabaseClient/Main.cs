using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemotingClass;

namespace RemoteDatabaseClient
{
    public partial class Main : Form
    {
        RemoteClass remoteClass;
        string URL;

        public Main()
        {
            InitializeComponent();
            URL = "Tcp://localhost:9090/RemoteClass";
            //URL = "Tcp://192.168.29.107:9090/RemoteClass";
            remoteClass = (RemoteClass) Activator.GetObject(typeof(RemoteClass), URL);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvServer.DataSource = remoteClass.Get_Machines();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                remoteClass.Add_Machine(txtName.Text, txtManufacturer.Text, txtProtocol.Text, cmbStatus.Text);
                dgvServer.DataSource = remoteClass.Get_Machines();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                remoteClass.Delete_Machine(int.Parse(dgvServer.SelectedRows[0].Cells[0].Value.ToString()));
                dgvServer.DataSource = remoteClass.Get_Machines();
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNameUpdate.Text != "")
            {
                remoteClass.Update_Machine(int.Parse(dgvServer.SelectedRows[0].Cells[0].Value.ToString()),
                txtNameUpdate.Text, txtManufacturerUpdate.Text, txtProtocolUpdate.Text, cmbStatusUpdate.Text);
                dgvServer.DataSource = remoteClass.Get_Machines();
            }
        }
    }
}
