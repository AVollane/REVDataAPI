using RXVBack.Concurrency;
using RXVBackDL.Models.Implementations;

namespace RXVBack
{
    /// <summary>
    /// Global cache class that provides concurrent (thread safe) collections to contain any tipes of information
    /// </summary>
    public static class GlobalCache
    {
        public static ConcurrentQueue<NeuronetInformation> NeuronetInformationCacheQueue { get; set; }
            = new ConcurrentQueue<NeuronetInformation>();
    }
}
