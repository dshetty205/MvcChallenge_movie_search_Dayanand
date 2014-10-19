namespace Core
{
    public interface IoCContainer
    {
        T GetInstance<T>();
    }
    public static class IoCContainerFactory
    {
        public static IoCContainer Current { get; set; }
    }
}
