﻿using Aura_OS.System.Network.IPV4;
using System;
using Aura_OS.HAL.Drivers.Network;

/*
* PROJECT:          Aura Operating System Development
* CONTENT:          DHCP - DHCP Core
* PROGRAMMER(S):    Alexy DA CRUZ <dacruzalexy@gmail.com>
*/

namespace Aura_OS.System.Network.DHCP
{
    class Core
    {
        /// <summary>
        /// Get the IP address of the DHCP server
        /// </summary>
        /// <returns></returns>
        public static Address DHCPServerAddress(NetworkDevice networkDevice)
        {
            Utils.Settings settings = new Utils.Settings(@"0:\System\" + networkDevice.Name + ".conf");
            return Address.Parse(settings.GetValue("dhcp_server"));
        }

        /// <summary>
        /// Send a packet to the DHCP server to make the address available again
        /// </summary>
        public static void SendReleasePacket()
        {
            foreach (NetworkDevice networkDevice in NetworkDevice.Devices)
            {
                Address source = Config.FindNetwork(DHCPServerAddress(networkDevice));
                DHCPRelease dhcp_release = new DHCPRelease(source, DHCPServerAddress(networkDevice));
                OutgoingBuffer.AddPacket(dhcp_release);
                NetworkStack.Update();
            }            
        }

        /// <summary>
        /// Send a packet to find the DHCP server and tell that we want a new IP address
        /// </summary>
        public static void SendDiscoverPacket()
        {
            foreach (NetworkDevice networkDevice in NetworkDevice.Devices)
            {
                DHCPDiscover dhcp_discover = new DHCPDiscover(networkDevice.MACAddress);
                OutgoingBuffer.AddPacket(dhcp_discover);
                NetworkStack.Update();
            }            
        }

        /// <summary>
        /// Send a request to apply the new IP configuration
        /// </summary>
        public static void SendRequestPacket(Address RequestedAddress, Address DHCPServerAddress)
        {
            foreach (NetworkDevice networkDevice in NetworkDevice.Devices)
            {
                DHCPRequest dhcp_request = new DHCPRequest(networkDevice.MACAddress, RequestedAddress, DHCPServerAddress);
                OutgoingBuffer.AddPacket(dhcp_request);
                NetworkStack.Update();
            }
        }

        public static void Apply(DHCPOption Options)
        {
            NetworkStack.RemoveAllConfigIP();

            Console.WriteLine();
            CustomConsole.WriteLineInfo("[DHCP ACK] Packet received, applying IP configuration...");
            CustomConsole.WriteLineInfo("   IP Address  : " + Options.Address().ToString());
            CustomConsole.WriteLineInfo("   Subnet mask : " + Options.Subnet().ToString());
            CustomConsole.WriteLineInfo("   Gateway     : " + Options.Gateway().ToString());
            CustomConsole.WriteLineInfo("   DNS server  : " + Options.DNS01().ToString());

            Utils.Settings.LoadValues();
            Utils.Settings.EditValue("ipaddress", Options.Address().ToString());
            Utils.Settings.EditValue("subnet", Options.Subnet().ToString());
            Utils.Settings.EditValue("gateway", Options.Gateway().ToString());
            Utils.Settings.EditValue("dns01", Options.DNS01().ToString());
            Utils.Settings.EditValue("dhcp_server", Options.Server().ToString());
            Utils.Settings.PushValues();

            NetworkInit.Enable();

            CustomConsole.WriteLineOK("[DHCP CONFIG] IP configuration applied.");
            Console.WriteLine();

            Kernel.BeforeCommand();
        }
    }
}
