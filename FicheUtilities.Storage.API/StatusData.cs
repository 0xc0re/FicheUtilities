﻿using System;

namespace FicheUtilities.Storage.API
{
    public class StatusData : IStatusData
    {
        private readonly ulong AvailableBytes;
        private readonly ulong Total;
        public double AvailableGigabytes => ConvertToGigabytes(AvailableBytes);
        public double UsedGigabytes => ConvertToGigabytes(CalculateUsed());
        public double TotalGigabytes => ConvertToGigabytes(Total);

        public StatusData(ulong total, ulong available)
        {
            AvailableBytes = available;
            Total = total;
        }

        private ulong CalculateUsed()
        {
            return Total - AvailableBytes;
        }

        private double ConvertToGigabytes(ulong bytes)
        {
            var gb = (double)bytes / Constants.BytesInGigabyte;

            return Math.Round(gb, 2);
        }
    }
}
