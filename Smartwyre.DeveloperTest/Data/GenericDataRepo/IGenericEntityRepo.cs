namespace Smartwyre.DeveloperTest.Data.GenericDataRepo
{
    public interface IGenericEntityRepo<T> 
    {
        T GetEntityData(string identifier);
    }
}
