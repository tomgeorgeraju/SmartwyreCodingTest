namespace Smartwyre.DeveloperTest.Extensions
{
    internal static class GenericExtensions
    {
        public static bool IsNull<T>(this T instance)
        {
            return instance == null;
        }
    }
}
