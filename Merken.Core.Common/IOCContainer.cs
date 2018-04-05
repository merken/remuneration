using Merken.Common.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Merken.Common
{
    /// <summary>
    /// This is the OC Container, this will provide the solution with DI and DIP.
    /// </summary>
    public static class IOCContainer
    {
        private static Dictionary<Type, Type> registrations = new Dictionary<Type, Type>();
        private static ServiceCollection services = null;
        private static IServiceProvider provider = null;

        /// <summary>
        /// The main container entry point.
        /// </summary>
        public static ServiceCollection Services
        {
            get
            {
                if (services == null)
                    services = new ServiceCollection();
                return services;
            }
        }
        
        private static IServiceProvider GetServiceProvider()
        {
            if (provider == null)
                provider = services.BuildServiceProvider();

            return provider;
        }

        /// <summary>
        /// Registers a dependency against the IOC Container.
        /// </summary>
        /// <typeparam name="I">The dependency interface.</typeparam>
        /// <typeparam name="C">The dependency implementation.</typeparam>
        public static void Register<I, C>() where C : I where I : class, ICanBeResolved
        {
            if(registrations.ContainsKey(typeof(I)))
                throw new ArgumentException($"Registration for {typeof(I).Name} already registered!");

            Services.AddSingleton(typeof(I), typeof(C));
            registrations.Add(typeof(I), typeof(C));
        }

        /// <summary>
        /// Resolves an instance of a registration based on the interface.
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <returns></returns>
        public static I Resolve<I>() where I : class, ICanBeResolved
        {
            return GetServiceProvider().GetService<I>();
        }

        public static void Clear()
        {
            Services.Clear();
            provider = null;
            registrations = new Dictionary<Type, Type>();
    }

        /// <summary>
        /// Resolves a registration or returns null in case no registration was provided.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Type GetRegistrationOrNull<T>() where T : class
        {
            if (registrations.ContainsKey(typeof(T)))
                return registrations[typeof(T)];

            return null;
        }
    }
}
