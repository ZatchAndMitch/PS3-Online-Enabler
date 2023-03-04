using System;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;

using MetroFramework;
using MetroFramework.Forms;


namespace PS3_Online_Enabler
{
    public partial class MainForm : MetroForm
    {
        private static ProxyServer proxyServer = null;

        private static readonly List<Region> regions = new List<Region>
        {
            new Region("jp", "83", "Japan"),
            new Region("kr", "86", "South Korea"),
            new Region("us", "84", "United States (North America)"), 
            new Region("eu", "85", "Europe"),
            new Region("mx", "88", "Mexico"),
            new Region("uk", "87", "United Kingdom"),
            new Region("sa", "8A", "Southeast Asia"),
            new Region("au", "89", "Australia"),
            new Region("ru", "8C", "Russia"),
            new Region("cn", "8D", "China"),
            new Region("tw", "8B", "Taiwan"),
            new Region("br", "8F", "Brazil (South America)"),
        };

        public MainForm()
        {
            InitializeComponent();

            BorderStyle = MetroFormBorderStyle.FixedSingle;
            ShadowType = MetroFormShadowType.AeroShadow;
            Resizable = false;
            MaximizeBox = false;
        }

        #region UTILS
        private static Region getPSNRegionFromURL(string url)
        {
            foreach (Region rg in regions)
            {
                if (url.Contains(String.Format("list/{0}/", rg.Code)))
                    return rg;
            }

            return new Region(null, null, "not-found");
        }

        private static string getAssemblyFileVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersion.FileVersion;
        }

        private static string getLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return String.Empty;
        }
        #endregion

        #region BACKEND
        public async Task OnRequest(object sender, SessionEventArgs e)
        {
            if (e.HttpClient.Request.RequestUri.AbsoluteUri.Contains("ps3-updatelist.txt"))
            {
                Console.WriteLine("[INFO]: Request for ps3-updatelist.txt detected.");
            }
            Console.WriteLine(e.HttpClient.Request.RequestUriString);
        }

        // Modify response
        public async Task OnResponse(object sender, SessionEventArgs e)
        {
            // Spoofing PSN updatelist
            if (e.HttpClient.Request.RequestUri.AbsoluteUri.Contains("ps3-updatelist.txt"))
            {
                if (e.HttpClient.Response.StatusCode == 200)
                {
                    Region rg = getPSNRegionFromURL(e.HttpClient.Request.RequestUriString);
                    Console.WriteLine("[INFO]: Detected region: {0}", rg.Name);
                    e.SetResponseBodyString(rg.UpdateList);
                }
            }
        }
        #endregion

        #region UI CALLBACKS
        private void MainForm_Load(object sender, EventArgs e)
        {
            lbInfo.Text = String.Format("v {0} by Zatch and Mitch", getAssemblyFileVersion());
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Handling stop.
            if (proxyServer != null)
            {
                Console.WriteLine("Stopping proxy server...");
                proxyServer.Stop();
                tbxPort.Enabled = true;
                btnStart.Text = "Start";
                lbIP.Visible = false;

                if (!proxyServer.ProxyRunning)
                {
                    proxyServer.Dispose();
                    proxyServer = null;
                    Console.WriteLine("[INFO] Proxy stopped successfully");
                }

                return;
            }

            proxyServer = new ProxyServer();

            // Registering events.
            proxyServer.BeforeResponse += OnResponse;
            proxyServer.BeforeRequest += OnRequest;

            // Input validations.
            int port = int.Parse(tbxPort.Text);
            if (port > 65353 || port < 1025)
            {
                MetroMessageBox.Show(this, "Select a port between 1025 and 65353", "Invalid port",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MetroMessageBox.Show(this, "Connect to your network", "No network",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Parse(getLocalIPAddress()), port, true)
            {
                // Use self-issued generic certificate on all https requests
                // Optimizes performance by not creating a certificate for each https-enabled domain
                // Useful when certificate trust is not required by proxy clients
                //GenericCertificate = new X509Certificate2(Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "genericcert.pfx"), "password")
            };

            // Update UI.
            btnStart.Text = "Stop";
            tbxPort.Enabled = false;
            lbIP.Text = String.Format("Listening on {0}", explicitEndPoint.IpAddress);
            lbIP.Visible = true;

            // An explicit endpoint is where the client knows about the existence of a proxy
            // So client sends request in a proxy friendly manner
            proxyServer.AddEndPoint(explicitEndPoint);
            proxyServer.Start();

            foreach (var endPoint in proxyServer.ProxyEndPoints)
                Console.WriteLine("Listening on '{0}' endpoint at Ip {1} and port: {2} ",
                    endPoint.GetType().Name, endPoint.IpAddress, endPoint.Port);

            // Only explicit proxies can be set as system proxy!
            proxyServer.SetAsSystemHttpProxy(explicitEndPoint);
            proxyServer.SetAsSystemHttpsProxy(explicitEndPoint);
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCJPkTMrFNUvdOV8fdyXWtxQ");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ZatchAndMitch/PS3-Online-Enabler/releases");
        }

        private void tbxPort_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Only backspace and digits are allowed.
            char backspace = (char)8;
            e.Handled = !char.IsDigit(e.KeyChar) && !(e.KeyChar == backspace);
        }
        #endregion
    }
}

