using Appccelerate.EventBroker;
using Ninject.Modules;

namespace SquawkBank.Core
{
    public class InjectionModules : NinjectModule
    {
        public override void Load()
        {
            Bind<IPtmManager>().To(typeof(PtmManager)).InSingletonScope();
            Bind<IEventBroker>().To(typeof(EventBroker)).InSingletonScope();
        }
    }
}
