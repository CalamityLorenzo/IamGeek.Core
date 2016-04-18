using System;
using System.Collections.Generic;
using IamGeek.core.Domain.Interface;
namespace IamGeek.core.Domain.Configuration
{
    public class BlogConfiguration
    {
        internal BlogConfiguration(IDictionary<string, string> connections, IDictionary<string, Func<BlogConfiguration, IBlogManager>> managers)
        {
            this.Connections = new Dictionary<string,string>(connections);
            this.Managers = new Dictionary<string, Func<BlogConfiguration, IBlogManager>>(managers);
        }

        public IDictionary<string, string> Connections { get; private set; }
        public IDictionary<string, Func<BlogConfiguration,IBlogManager>> Managers { get; private set; }
    }
}