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
            var stringlyTypedPathOperatorAction = services.AddStringlyTypedPathOperatorAction();

            services.AddLocalFileSystemOperatorOnly(
                stringlyTypedPathOperatorAction);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ILocalFileSystemOperator"/> service.
        /// </summary>
        public static (
            IServiceAction<ILocalFileSystemOperator> localFileSystemOperatorAction,
            IServiceAction<IFileSystemOperator> fileSystemOperatorAction
            ) AddLocalFileSystemOperatorAction(this IServiceCollection services)
        {
            var stringlyTypedPathOperatorAction = services.AddStringlyTypedPathOperatorAction();

            var serviceAction = services.AddLocalFileSystemOperatorAction(stringlyTypedPathOperatorAction);
            return serviceAction;
        }
    }
}
