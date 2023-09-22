using UnityEngine;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using TMPro;

public class SetServerIp : MonoBehaviour
{
    void Start()
    {
        var firstIp = GetLocalIPv4(NetworkInterfaceType.Ethernet);
        var secondIp = GetLocalIPv4(NetworkInterfaceType.Wireless80211);
        GetComponent<TextMeshProUGUI>().text =  "Server ip: " + (firstIp + "\n" + secondIp).Trim();
    }
    
    public string GetLocalIPv4(NetworkInterfaceType _type)
    {
        string output = "";
        foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
            {
                foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        output = ip.Address.ToString();
                    }
                }
            }
        }
        return output;
    }
}
