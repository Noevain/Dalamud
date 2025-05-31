using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BitFaster.Caching.Counters;

using Dalamud.Plugin.Internal.Types;

namespace Dalamud.Plugin.Internal
{
    /// <summary>
    /// Service responsible for handling metrics recording for plugins 
    /// </summary>
    [ServiceManager.ScopedService]
    internal class PluginMetricsHandler : IServiceType
    {
        private readonly LocalPlugin plugin;
        private Counter<long> startupTime;
        /// <summary>
        /// Initializes a new instance of the <see cref="PluginMetricsHandler"/> class.
        /// </summary>
        /// <param name="plugin">The plugin we are tracking metrics for</param>
        [ServiceManager.ServiceConstructor]
        public PluginMetricsHandler(LocalPlugin plugin,IMeterFactory meterFactory)
        {
            this.plugin = plugin;
            var meter = meterFactory.Create(this.plugin.InternalName);
            this.startupTime = meter.CreateCounter<long>(this.plugin.InternalName + "startup_time");
        }

        public void RecordStartupTime(long obstartupTime) 
        {
            this.startupTime.Add(obstartupTime);
        }
    }
}
