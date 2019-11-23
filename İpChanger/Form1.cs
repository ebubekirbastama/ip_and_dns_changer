using System;
using System.Management;
using System.Windows.Forms;

namespace İpChanger
{
    public partial class Form1 : Form
    {
        private string nic;

        public Form1()
        {
            InitializeComponent();
        }
        ManagementClass adapterConfig = new ManagementClass("Win32_NetworkAdapterConfiguration");
        private string description;

        private void buttonX1_Click(object sender, EventArgs e)
        {

            var networkCollection = adapterConfig.GetInstances();
            foreach (ManagementObject adapter in networkCollection)
            {
                description = adapter["Description"].ToString();
                if (description == comboBoxEx1.Text)
                {
                    try
                    {
                        // Set DefaultGateway
                        var newGateway = adapter.GetMethodParameters("SetGateways");
                        newGateway["DefaultIPGateway"] = new string[] { Gateway.Text };
                        newGateway["GatewayCostMetric"] = new int[] { 1 };

                        // Set IPAddress and Subnet Mask
                        var newAddress = adapter.GetMethodParameters("EnableStatic");
                        newAddress["IPAddress"] = new string[] { ipadrs.Text };
                        newAddress["SubnetMask"] = new string[] { subnet.Text };

                        adapter.InvokeMethod("EnableStatic", newAddress, null);
                        adapter.InvokeMethod("SetGateways", newGateway, null);

                        MessageBox.Show("Static İp Adresi Değiştirildi.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("İp Adresi Ayarlanmadı : " + ex.Message);
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var adapterConfig = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var networkCollection = adapterConfig.GetInstances();
            foreach (ManagementObject adapter in networkCollection)
            {
                comboBoxEx1.Items.Add(adapter["Description"] as string);
            }
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            DnsChanger(dns1.Text,dns2.Text);
            MessageBox.Show("DnsChanger Değiştirdi");
        }
        public void DnsChanger(string dns1, string dns2)
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {

                if ((bool)mo["IPEnabled"])
                {
                    nic = mo["Caption"].ToString();
                    if ((bool)mo["IPEnabled"])
                    {
                        if (mo["Caption"].Equals(nic))
                        {
                            ManagementBaseObject DnsEntry = mo.GetMethodParameters("SetDNSServerSearchOrder");
                            string dnsler = dns1 + "," + dns2;
                            DnsEntry["DNSServerSearchOrder"] = dnsler.Split(',');
                            ManagementBaseObject DnsMbo = mo.InvokeMethod("SetDNSServerSearchOrder", DnsEntry, null);
                            int returnCode = int.Parse(DnsMbo["returnvalue"].ToString());
                            break;
                        }
                    }
                }

            }
        }
    }
}
