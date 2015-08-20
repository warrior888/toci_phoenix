using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.TeamLeasing;
using Phoenix.Bll.Interfaces.Logic.UsersList;
using Phoenix.Bll.Logic.DevelopersList;
using Phoenix.Bll.Logic.TeamLeasing;
using Phoenix.Bll.Logic.UsersList;
using Phoenix.Bll.User;
using Toci.Db.Clients;
using Toci.Db.ClusterAccess;
using Toci.Db.DbVirtualization.PostgreSqlQuery;
using Toci.Db.Interfaces;
using Toci.Utilities.Document.DocumentParsers;
using Toci.Utilities.Document.DocumentParsers.ThirdParty.Puma;
using Toci.Utilities.Interfaces;
using Toci.Utilities.Interfaces.Document.DocumentParse;
using _3mb.Bll.Interfaces.User;

namespace Phoenix.Bll.Essential
{
    public class AutofacContainer
    {
        private static AutofacContainer _instance;
        private IContainer _container;

        private AutofacContainer()
        {
            
        }

        public static AutofacContainer GetContainer()
        {
            return _instance ?? (_instance = new AutofacContainer());
        }

        private IContainer CreateConfiguration()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DbHandle>().As<IDbHandle>();
            builder.RegisterType<PostgreSqlClient>().As<IDbClient>();

            builder.RegisterType<PostgreSqlSelect>().As<ISelect>();
            builder.RegisterType<PostgreSqlInsert>().As<IInsert>();
            builder.RegisterType<PostgreSqlUpdate>().As<IUpdate>();
            builder.RegisterType<PostgreSqlDelete>().As<IDelete>();

            builder.RegisterType<DocumentResource>().As<IDocumentResource>();
            builder.RegisterType<PumaOcrParser>().As<IDocumentInterpreter>();

            builder.RegisterType<UserLogic>().As<IUserLogic>();

            builder.RegisterType<DeveloperListLogic>().As<IDeveloperListLogic>();
            builder.RegisterType<DeveloperAvailableLogic>().As<IDeveloperAvailableLogic>();
            builder.RegisterType<SkillLogic>().As<ISkillLogic>();
            builder.RegisterType<UsersLogic>().As<IUsersLogic>();
            builder.Register(c => new PortfolioLogic(Resolve<IDeveloperListLogic>())).As<IPortfolioLogic>();
            builder.Register(c => new TeamLeasingLogic(Resolve<IDeveloperListLogic>(), Resolve<IPortfolioLogic>())).As<ITeamLeasingLogic>();
            builder.Register(c => new AutoMapperConfiguration(Resolve<IUsersLogic>(), Resolve<IDeveloperListLogic>(),
                                                              Resolve<IPortfolioLogic>(), Resolve<ISkillLogic>(), Resolve<IDeveloperAvailableLogic>()));
          
            return builder.Build();
        }

        public TService Resolve<TService>(params object[] parameters)
        {
            if (_container == null)
            {
                _container = CreateConfiguration();
            }

            using (var scope = _container.BeginLifetimeScope())
            {
                List<Parameter> afParams = new List<Parameter>();
                int i = 0;

                if (parameters.Length > 0)
                {
                    foreach (var parameter in parameters)
                    {
                        afParams.Add(new PositionalParameter(i, parameter));
                        i++;
                    }
                }

                return scope.Resolve<TService>(afParams);
            }
        }
    }
}