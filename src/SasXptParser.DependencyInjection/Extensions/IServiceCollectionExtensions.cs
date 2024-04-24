using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SasXptParser.Abstract;
using SasXptParser.Internal;

namespace SasXptParser.DependencyInjection
{
    /// <summary>
    /// Provides methods for adding all required dependencies to a container
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds all required dependencies to a container
        /// </summary>
        public static IServiceCollection AddSasXptParsing(this IServiceCollection services)
        {
            AddScopedInternal(services);
            AddSasXptByteProcessor<SasXptByteProcessor>(services);

            AddSasXptParsers<SasXptDataRecordParser>(services);
            AddSasXptParsers<SasXptLibraryHeaderRecordParser>(services);
            AddSasXptParsers<SasXptMemberDescriptorHeaderRecordParser>(services);

            AddSasXptParsingProcessor<SasXptParsingProcessor>(services);

            return services;
        }

        /// <summary>
        /// Adds parsing processor to a container
        /// </summary>
        private static void AddSasXptParsingProcessor<TProcessor>(IServiceCollection services)
            where TProcessor : class, ISasXptParsingProcessor
        {
            services.TryAddScoped<ISasXptParsingProcessor, TProcessor>();
        }

        /// <summary>
        /// Adds byte processor to a container
        /// </summary>
        private static void AddSasXptByteProcessor<TProcessor>(IServiceCollection services)
            where TProcessor : class, ISasXptByteProcessor
        {
            services.TryAddScoped<ISasXptByteProcessor, TProcessor>();
        }


        /// <summary>
        /// Adds all required parsers to a container
        /// </summary>
        private static void AddSasXptParsers<TParser>(IServiceCollection services)
            where TParser : class, ISasXptParser<ISasXptElement>
        {
            services.AddScoped<ISasXptParser<ISasXptElement>, TParser>();
        }

        /// <summary>
        /// Adds internal components to a container
        /// </summary>
        private static void AddScopedInternal(IServiceCollection services)
        {
            services.TryAddSingleton<ISasXptPropertyProcessorProvider, SasXptVariablePropertyProcessorProvider>();
            services.TryAddScoped<ISasXptVariableParser, SasXptVariableParser>();
            services.TryAddScoped<ISasXptObservationParser, SasXptObservationsParser>();
        }
    }
}