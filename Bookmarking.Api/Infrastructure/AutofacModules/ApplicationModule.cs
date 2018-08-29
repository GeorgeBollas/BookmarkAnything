using Autofac;
using BookmarkAnything.Services.Bookmarking.Domain.AggregateModel.BookmarkListAggregate;
using Bookmarking.Api.Application.Commands;
using Bookmarking.Api.Application.Queries;
using Bookmarking.Infrastructure.Repositories;
using EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmarking.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule:Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new BookmarkingQueries(QueriesConnectionString))
                .As<IBookmarkingQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookmarkListRepository>()
                .As<IBookmarkListRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateBookmarkListCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>)); //? part of Eventing
        }
    }
}
