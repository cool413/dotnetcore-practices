using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Controllers
{
    public interface ISample
    {
        int Id { get; }
    }

    public interface ISampleTransient : ISample
    {
    }

    public interface ISampleScoped : ISample
    {
    }

    public interface ISampleSingleton : ISample
    {
    }

    public class Sample : ISampleTransient, ISampleScoped, ISampleSingleton
    {
        private static int _counter;

        public Sample()
        {
            Id = ++_counter;
        }

        public int Id { get; }
    }

}
