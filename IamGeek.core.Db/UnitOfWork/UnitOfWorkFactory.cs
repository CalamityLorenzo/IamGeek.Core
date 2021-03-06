﻿using IamGeek.core.Domain.Factories;
using IamGeek.core.Db.Interfacts;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
//using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IamGeek.core.Db.UnitOfWork;
using IamGeek.core.Db;

namespace IamGeek.core.Db
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private UnitOfWorkFactory() { }
        static UnitOfWorkFactory() { }

        private static UnitOfWorkFactory _factory;
        public static UnitOfWorkFactory Instance => _factory ?? (_factory = new UnitOfWorkFactory());

        public IBlogUnitOfWork Readonly()
        {
            return Instance.GetUnitOfWork<SqlBlogUnitOfWork, BlogContext>("Readonly")();
        }

        public IBlogUnitOfWork ReadWrite()
        {
            return Instance.GetUnitOfWork<SqlBlogUnitOfWork, BlogContext>("ReadWrite")();
        }

        public IBlogUnitOfWork Get(string connection)
        {
            return Instance.GetUnitOfWork<SqlBlogUnitOfWork, BlogContext>(connection)();
        }

        public T Get<T>(string connection) where T : class, IBlogUnitOfWork
        {
            return Instance.GetUnitOfWork<T, BlogContext>(connection)();
        }



        public void RecreateDb()
        {
            var s = "ReadWrite";
            var dbOpts = new DbContextOptionsBuilder();
            dbOpts.UseSqlServer(s);
            using (var db = new BlogContext(dbOpts.Options))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        internal Func<TUnitOfWork> GetUnitOfWork<TUnitOfWork, C>(string connectionName) where TUnitOfWork : class, IBlogUnitOfWork where C : BlogContext
        {
            var connectionString = connectionName;// ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            DbContextOptionsBuilder opts = new DbContextOptionsBuilder();
            opts.UseSqlServer(connectionString);
            var ctx = GetContext<C>();
            if (typeof(TUnitOfWork) == typeof(SqlBlogUnitOfWork))
            {
                return ()=>  new SqlBlogUnitOfWork(ctx(opts.Options)) as TUnitOfWork;
            }

            if(typeof(TUnitOfWork) == typeof(ISqlBlogUnitOfWork)){
                return () => new SqlBlogUnitOfWork(ctx(opts.Options)) as TUnitOfWork;
            }

            throw new ArgumentOutOfRangeException("Cannot construct Uow");
        }

        private static Func<DbContextOptions, C> GetContext<C>() where C : BlogContext
        {
            if (typeof(C) == typeof(BlogContext))
            {
                return (opts) => new BlogContext(opts) as C;
            }


            throw new ArgumentOutOfRangeException("Cannot construct dbContext");
        }
    }
}
