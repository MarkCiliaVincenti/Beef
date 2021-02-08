/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

using Beef;
using Beef.Data.Database.Cdc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using Beef.Demo.Cdc.Data;

namespace Beef.Demo.Cdc.Services
{
    /// <summary>
    /// Provides the CDC background service for database object 'Demo.Person'.
    /// </summary>
    public partial class PersonCdcBackgroundService : CdcBackgroundService<IPersonCdcData>
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonCdcBackgroundService"/> class.
        /// </summary>
        /// <param name="config">The <see cref="IConfiguration"/>.</param>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/>.</param>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        public PersonCdcBackgroundService(IConfiguration config, IServiceProvider serviceProvider, ILogger<PersonCdcBackgroundService> logger) :
            base(serviceProvider, logger) => _config = Check.NotNull(config, nameof(config));

        /// <summary>
        /// Gets the interval seconds between each execution.
        /// </summary>
        public override int? IntervalSeconds => _config.GetValue<int?>("PersonCdcIntervalSeconds");
    }
}

#pragma warning restore
#nullable restore