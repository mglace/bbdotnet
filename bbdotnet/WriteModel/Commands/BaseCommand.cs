using System;
using CQRSlite.Commands;

namespace bbdotnet
{
    public class BaseCommand : ICommand
    {
        public BaseCommand(Guid aggregateId, int expectedVersion = 0)
        {
            AggregateId = aggregateId;
            ExpectedVersion = expectedVersion;
        }

        /// <summary>
        /// The Aggregate ID of the Aggregate Root being changed
        /// </summary>
        public Guid AggregateId { get; set; }

        /// <summary>
        /// The Expected Version which the Aggregate will become.
        /// </summary>
        public int ExpectedVersion { get; set; }
    }
}