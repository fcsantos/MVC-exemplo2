using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Configuration;

namespace CrudMVC_FluentNhibernate.Models
{
    public class NHibernateHelper
    {
        private static string con = ConfigurationManager.ConnectionStrings["DBCadastro"].ConnectionString;

        private static ISessionFactory _factory;

        public static ISessionFactory Factory
        {
            get
            {
                try
                {
                    if ((_factory == null))
                    {
                        _factory = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2012
                            .ConnectionString(con))
                            .Mappings(m => m
                            .FluentMappings.AddFromAssemblyOf<AlunoMap>())
                            .BuildSessionFactory();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(("Falha ao gerar SessionFactory: " + ex.Message));
                }

                return _factory;
            }
        }
    }
}
