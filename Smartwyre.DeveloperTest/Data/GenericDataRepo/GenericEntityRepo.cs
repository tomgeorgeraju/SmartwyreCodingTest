namespace Smartwyre.DeveloperTest.Data.GenericDataRepo
{
    public class GenericEntityRepo<T> : IGenericEntityRepo<T> where T : new()
    {
        public T GetEntityData(string identifier)
        {
            // Access database to retrieve details of identity type T
            return new T();
        }
    }
}
