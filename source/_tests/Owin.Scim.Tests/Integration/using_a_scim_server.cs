﻿namespace Owin.Scim.Tests.Integration
{
    using Configuration;

    using Machine.Specifications;

    using Microsoft.Owin.Testing;

    using Scim.Extensions;

    public class using_a_scim_server : IAssemblyContext
    {
        public void OnAssemblyStart()
        {
            //ncrunch: no coverage start
            if (_Server != null) return;

            _Server = TestServer.Create(app =>
            {
                app.UseScimServer(
                    new ScimServerConfiguration
                    {
                        RequireSsl = false
                    });
            });
            //ncrunch: no coverage end
        }

        public void OnAssemblyComplete()
        {
            if (_Server == null) return;
            
            _Server.Dispose();
        }

        protected static TestServer Server
        {
            get { return _Server; }
        }
        
        private static TestServer _Server;
    }
}