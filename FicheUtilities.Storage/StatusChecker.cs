using FicheUtilities.Storage.API;
using System;
using System.Collections.Generic;

namespace FicheUtilities.Storage
{
    public class StatusChecker : IStatusChecker
    {
        private IDiskAPI _diskApi;
        private IDirectoryWrapper _directoryWrapper;
        private List<LogMessage> _log;

        public StatusChecker(IDiskAPI diskApi, IDirectoryWrapper directoryWrapper)
        {
            _diskApi = diskApi;
            _directoryWrapper = directoryWrapper;
            _log = new List<LogMessage>();
        }
        
        public List<LogMessage> GetStatus(StatusOptions options)
        {
            IStatusData status;

            if (!_directoryWrapper.Exists(options.Path))
            {
                AddLogMessage($"ERROR - Verify that you have the correct path: {options.Path}", MessageType.Critical);

                return _log;
            }

            try
            {
                status = _diskApi.GetDiskStats(options.Path);
            }
            catch (Exception ex)
            {
                AddLogMessage("ERROR - " + ex.Message, MessageType.Critical);

                return _log;
            }

            if (options.IsVerbose)
            {
                AddLogMessage("Status: ", MessageType.Info);
            }

            if (status.AvailableGigabytes > options.WarningThreshold)
            {
                AddLogMessage("OK", MessageType.Ok);
            }
            else if (status.AvailableGigabytes <= options.WarningThreshold && status.AvailableGigabytes > options.CriticalThreshold)
            {
                AddLogMessage("Warning", MessageType.Warning);
            }
            else if (status.AvailableGigabytes <= options.CriticalThreshold)
            {
                AddLogMessage("Critical", MessageType.Critical);
            }

            if (options.IsVerbose)
            {
                AddLogMessage("Disk at path: " + options.Path, MessageType.Info);
                AddLogMessage("Total space: " + status.TotalGigabytes + " GB", MessageType.Info);
                AddLogMessage("Used space: " + status.UsedGigabytes + " GB", MessageType.Info);
                AddLogMessage("Available space: " + status.AvailableGigabytes + " GB", MessageType.Info);
            }

            return _log;
        }

        private void AddLogMessage(string message, MessageType messageType)
        {
            _log.Add(new LogMessage(message, messageType));
        }
    }
}
