using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GetNgrokUrlTunnel
{

    public class NgrokTunnel
    {
        public List<TunnelDetail>? Tunnels { get; set; }
    }

    public class TunnelDetail
    {
        public string? name { get; set; }
        public string? ID { get; set; }
        public string? uri { get; set; }
        public string? public_url { get; set; }
        public string? proto { get; set; }
        public ConfigDetail? config { get; set; }
    }

    public class ConfigDetail
    {
        public string? addr { get; set; }
    }

}
