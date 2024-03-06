using RestAspNet8VStudio.Model.Base;

namespace RestAspNet8VStudio.Data
{
    public interface IGenericData<T> where T : BaseEntity
    {
        List<T> FindAll();
        T FindByID(long id);
        T Create(T item);
        T Update(T item);
        T Delete(long id);
    }
}
