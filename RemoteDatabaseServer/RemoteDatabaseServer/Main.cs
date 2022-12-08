using System;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RemoteDatabaseServer
{
    public partial class Main : Form
    {
        PL.Machine machine = new PL.Machine();
        public TcpChannel channel;


        public Main()
        {
            InitializeComponent();
            channel = new TcpChannel(9090);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("RemotingClass.RemoteClass,RemotingClass"), "RemoteClass", WellKnownObjectMode.Singleton);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                machine.Add_Machine(txtName.Text, txtManufacturer.Text, txtProtocol.Text, cmbStatus.Text);
                dgvServer.DataSource = machine.Get_Machines();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dgvServer.DataSource = machine.Get_Machines();
        }

        private void dgvServer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                machine.Delete_Machine(int.Parse(dgvServer.SelectedRows[0].Cells[0].Value.ToString()));
                dgvServer.DataSource = machine.Get_Machines();
            }
            catch { }
        }

        private void dgvServer_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvServer.SelectedRows.Count>0)
                {
                    txtNameUpdate.Text = dgvServer.SelectedRows[0].Cells[1].Value.ToString();
                    txtManufacturerUpdate.Text = dgvServer.SelectedRows[0].Cells[2].Value.ToString();
                    txtProtocolUpdate.Text = dgvServer.SelectedRows[0].Cells[3].Value.ToString();
                    cmbStatusUpdate.Text = dgvServer.SelectedRows[0].Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtNameUpdate.Text = "";
                txtManufacturerUpdate.Text = "";
                txtProtocolUpdate.Text = "";
                cmbStatusUpdate.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNameUpdate.Text != "")
            {
                machine.Update_Machine(int.Parse(dgvServer.SelectedRows[0].Cells[0].Value.ToString()),
                txtNameUpdate.Text, txtManufacturerUpdate.Text, txtProtocolUpdate.Text, cmbStatusUpdate.Text);
                dgvServer.DataSource = machine.Get_Machines();
            }
        }
    }
}
