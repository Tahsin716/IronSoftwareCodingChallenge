using Ninject;
using PhoneParser.Contracts;
using PhoneParser.Services;

namespace PhoneParser.DI
{
    public static class ServiceRegistration
    {
        private static readonly StandardKernel _kernel = new StandardKernel();

        static ServiceRegistration()
        {
            RegisterServices();
        }

        private static void RegisterServices()
        {
            _kernel.Bind<IOldPhoneParser>().To<OldPhoneParser>().InSingletonScope();
        }

        public static T GetService<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
