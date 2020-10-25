using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IResolver
    {
        IT Resolve<IT>();
        object Resolve(Type type);

        IEnumerable<IT> ResolveAll<IT>();

        IEnumerable<object> ResolveAll(Type type);

        void LoadLibraries(string path);
    }
}
