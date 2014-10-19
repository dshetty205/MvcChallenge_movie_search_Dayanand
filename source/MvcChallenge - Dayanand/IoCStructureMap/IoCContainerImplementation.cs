using Core;
using StructureMap;

namespace IoCStructureMap
{
    public class IoCContainerImplementation : IoCContainer
    {
        public readonly IContainer _container;

        public IoCContainerImplementation(IContainer container)
        {
            _container = container;
        }

        public T GetInstance<T>()
        {
            return _container.GetInstance<T>();
        }
    }
}
