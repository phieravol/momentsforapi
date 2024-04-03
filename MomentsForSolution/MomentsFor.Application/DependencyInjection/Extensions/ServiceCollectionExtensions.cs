using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MomentsFor.Application.Behaviors;
using MomentsFor.Application.Mapper;

namespace MomentsFor.Application.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigMediatR(this IServiceCollection services)
            => services.AddMediatR(config => config.RegisterServicesFromAssembly(AssemblyReference.Assembly))
            //.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
            //.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipelineBehavior<,>))
            .AddValidatorsFromAssembly(Contract.AssemblyReference.Assembly);

        public static IServiceCollection AddConfigureAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(typeof(ServiceProfile));
    }
}
