﻿using System;

namespace IdentityServer4.RavenDB.Storage.Entities
{
    internal class DeviceFlowCode
    {
        public string Id { get; set; }

        public string DeviceCode { get; set; }

        public string UserCode { get; set; }

        public string SubjectId { get; set; }

        public string SessionId { get; set; }

        public string ClientId { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? Expiration { get; set; }

        public string Data { get; set; }
    }
}
