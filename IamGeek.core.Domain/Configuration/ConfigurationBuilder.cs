using IamGeek.core.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IamGeek.core.Domain.Configuration
{
    // Use this class to build root instances of
    // objects
    public static class BlogConfigurationBuilder
    {
        static IDictionary<string, string> _connections = new Dictionary<string, string>();
        static IDictionary<string, Func<BlogConfiguration, IBlogManager>> _buildManager = new Dictionary<string, Func<BlogConfiguration,IBlogManager>>();

        static BlogConfiguration _blogConfiguration = null;

        public static void AddConnection(string name, string conn)
        {
            _connections.Add(name, conn);
        }

        public static void AddBuilder(string name, Func<BlogConfiguration, IBlogManager> instance)
        {
            _buildManager.Add(name, instance);
        }

        public static BlogConfiguration Config
        {
            get
            {
                if (_blogConfiguration == null)
                {
                    throw new ArgumentNullException("not initalised");
                }
                else
                {
                    return _blogConfiguration;
                }
            }
        }

        public static void Build()
        {
            _blogConfiguration = new BlogConfiguration(_connections, _buildManager);
        }
    }
}
