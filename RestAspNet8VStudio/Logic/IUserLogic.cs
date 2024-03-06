using RestAspNet8VStudio.VObject;

namespace RestAspNet8VStudio.Logic
{
    public interface IUserLogic
    {
        List<UserVO> FindAll();
        UserVO FindByID(long id);
        UserVO Create(UserVO user);
        UserVO Update(UserVO user);
        UserVO Delete(long id);
    }
}
