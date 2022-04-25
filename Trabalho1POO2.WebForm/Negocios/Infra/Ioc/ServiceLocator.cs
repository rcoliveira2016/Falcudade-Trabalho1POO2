using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho1POO2.WebForm.Negocios.Infra.Ioc
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, object> services = new Dictionary<Type, object>();

        public static void Register<TInterface, TService>() where TService : TInterface, new()
        {
            Register<TInterface, TService>(new TService());
        }
        public static void Register<TInterface, TService>(TService service) where TService : TInterface
        {
            if(!services.ContainsKey(typeof(TInterface)))
                services.Add(typeof(TInterface), service);
        }

        public static TService Get<TService>()
        {
            return (TService)services[typeof(TService)];
        }

    }
}