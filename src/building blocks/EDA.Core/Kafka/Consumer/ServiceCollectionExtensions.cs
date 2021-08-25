using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EDA.Core.Kafka.Consumer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddKafkaConsumer(this IServiceCollection services, params Type[] handlerAssemblyMarkerTypes)
        {
            services.AddMediatR(handlerAssemblyMarkerTypes);

            // TODO: is there a way to avoid this? Better way to discover handlers?
            services.AddTransient<IKafkaMessageConsumerManager>(serviceProvider =>
                new KafkaMessageConsumerManager(serviceProvider, services));

            services.AddTransient<IKafkaConsumerBuilder, KafkaConsumerBuilder>();

            services.AddTransient<IKafkaTopicMessageConsumer, KafkaTopicMessageConsumer>();

            return services;
        }
    }
}