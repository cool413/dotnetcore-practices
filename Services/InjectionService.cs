using MyWebsite.Controllers;

namespace MyWebsite.Services
{
    public class InjectionService
    {
        public ISample Transient { get; }
        public ISample Scoped { get; }
        public ISample Singleton { get; }

        public InjectionService(ISampleTransient transient,
            ISampleScoped scoped,
            ISampleSingleton singleton)
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
        }
    }
}
