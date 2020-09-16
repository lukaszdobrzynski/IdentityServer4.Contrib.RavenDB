﻿using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.RavenDB.Storage.Indexes;
using IdentityServer4.RavenDB.Storage.Mappers;
using IdentityServer4.Stores;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace IdentityServer4.RavenDB.Storage.Stores
{
    /// <summary>
    /// Implementation of IClientStore that uses RavenDB.
    /// </summary>
    /// <seealso cref="IdentityServer4.Stores.IClientStore" />
    public class ClientStore : IClientStore
    {
        public ClientStore(IAsyncDocumentSession session, ILogger<ClientStore> logger)
        {
            Session = session ?? throw new ArgumentNullException(nameof(session));
            Logger = logger;
        }

        protected IAsyncDocumentSession Session { get; }
        protected ILogger<ClientStore> Logger { get; }

        /// <inheritdoc />
        public virtual async Task<Client> FindClientByIdAsync(string clientId)
        {
            var client = await Session.Query<Entities.Client, ClientIndex>()
                .Where(x => x.ClientId == clientId)
                .SingleOrDefaultAsync();

            if (client == null) return null;

            var model = client.ToModel();

            Logger.LogDebug("{clientId} found in database: {clientIdFound}", clientId, model != null);

            return model;
        }
    }
}
