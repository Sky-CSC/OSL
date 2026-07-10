using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace OSL_Utils;

/// <summary>
/// Provides network related utility methods.
/// </summary>
public static class NetworkUtils
{
    /// <summary>
    /// Gets the preferred local IPv4 address.
    /// </summary>
    /// <returns>The preferred IPv4 address, or <see langword="null"/> if none is found.</returns>
    public static IPAddress? GetPreferredIPv4Address()
    {
        var interfaces = NetworkInterface.GetAllNetworkInterfaces()
            .Where(IsValidInterface)
            .OrderBy(GetPriority);

        foreach (var networkInterface in interfaces)
        {
            var properties = networkInterface.GetIPProperties();

            // Prefer interfaces with a default gateway.
            if (!properties.GatewayAddresses.Any(g =>
                    g.Address.AddressFamily == AddressFamily.InterNetwork &&
                    !IPAddress.IsLoopback(g.Address)))
            {
                continue;
            }

            var address = properties.UnicastAddresses
                .FirstOrDefault(a =>
                    a.Address.AddressFamily == AddressFamily.InterNetwork &&
                    !IPAddress.IsLoopback(a.Address));

            if (address is not null)
            {
                return address.Address;
            }
        }

        return null;
    }

    private static bool IsValidInterface(NetworkInterface networkInterface)
    {
        if (networkInterface.OperationalStatus != OperationalStatus.Up)
            return false;

        if (networkInterface.NetworkInterfaceType is NetworkInterfaceType.Loopback or NetworkInterfaceType.Tunnel)
            return false;

        var text = $"{networkInterface.Name} {networkInterface.Description}";

        string[] excluded =
        [
            "Hyper-V",
            "Docker",
            "Virtual",
            "VMware",
            "VirtualBox",
            "TAP",
            "VPN",
            "WSL"
        ];

        return !excluded.Any(x => text.Contains(x, StringComparison.OrdinalIgnoreCase));
    }

    private static int GetPriority(NetworkInterface networkInterface) =>
        networkInterface.NetworkInterfaceType switch
        {
            NetworkInterfaceType.Ethernet => 0,
            NetworkInterfaceType.GigabitEthernet => 0,
            NetworkInterfaceType.Wireless80211 => 1,
            _ => 10
        };
}
