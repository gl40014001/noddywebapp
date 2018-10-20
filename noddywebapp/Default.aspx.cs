using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace noddywebapp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            string myIP = IPNetworking.GetIP4Address();
            lblServerIP.Text = myIP;
        }
    }




    public class IPNetworking
    {
        public static string GetIP4Address()
        {
           // IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); // `Dns.Resolve()` method is deprecated.
            //IPAddress ipAddress = ipHostInfo.AddressList[2];


            string myHost = System.Net.Dns.GetHostName();
            string myIP = null;

            for (int i = 0; i <= System.Net.Dns.GetHostEntry(myHost).AddressList.Length - 1; i++)
            {
                if (System.Net.Dns.GetHostEntry(myHost).AddressList[i].IsIPv6Teredo == false)
                {
                   // myIP = System.Net.Dns.GetHostEntry(myHost).AddressList[i].ToString();
                    IPAddress thing = System.Net.Dns.GetHostEntry(myHost).AddressList[i].MapToIPv4();
                    myIP = thing.ToString();

                }
            }

            return myIP;
        }
    }

}