using Core;
using Core.Repositories;
using StructureMap;
using DAL;
namespace IoCStructureMap
{
    public static class Initializer
    {
        public static void Initialize()
        {
            var container = new Container(x => x.For<ITitleRepository>().Use<TitlesRepositoryImplementation>());
            IoCContainerFactory.Current = new IoCContainerImplementation(container);
        }
    }
}
