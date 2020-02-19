using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy.Standard;


namespace R5T.Gepidia.Local.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ILocalFileSystemOperator"/> service.
        /// </summary>
        public static IServiceCollection AddLocalFileSystemOperator(this IServiceCollection services)
        {
            services.AddLocalFileSystemOperator(
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ILocalFileSystemOperator"/> service.
        /// </summary>
        public static ServiceAction<ILocalFileSystemOperator> AddLocalFileSystemOperatorAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<ILocalFileSystemOperator>(() => services.AddLocalFileSystemOperator());
            return serviceAction;
        }

        /// <summary>
        /// Adds the local-based <see cref="IFileSystemOperator"/> service.
        /// </summary>
        public static IServiceCollection AddFileSystemOperator(this IServiceCollection services)
        {
            services.AddLocalBasedFileSystemOperator(
                services.AddLocalFileSystemOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the local-based <see cref="IFileSystemOperator"/> service.
        /// </summary>
        public static ServiceAction<IFileSystemOperator> AddFileSystemOperatorAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IFileSystemOperator>(() => services.AddFileSystemOperator());
            return serviceAction;
        }
    }
}
