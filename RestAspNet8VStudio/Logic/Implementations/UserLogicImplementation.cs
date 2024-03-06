using RestAspNet8VStudio.Data;
using RestAspNet8VStudio.Model;
using RestAspNet8VStudio.VObject.Converter.Implementations;
using RestAspNet8VStudio.VObject;

namespace RestAspNet8VStudio.Logic.Implementations
{
    public class UserLogicImplementation : IUserLogic
    {
        private readonly IGenericData<User> _data;
        private UserConverter _converter;

        public UserLogicImplementation(IGenericData<User> data)
        {
            _data = data;
            _converter = new UserConverter();
        }

        public UserVO Create(UserVO user)
        {
            var UserEntity = _converter.Convert(user);
            UserEntity = _data.Create(UserEntity);
            return _converter.Convert(UserEntity);
        }

        public UserVO Delete(long id)
        {
             var UserEntity = _data.Delete(id);
            return  _converter.Convert(UserEntity);
        }

        public List<UserVO> FindAll()
        {
            return _converter.Convert(_data.FindAll());
        }
        public UserVO FindByID(long id)
        {
            return _converter.Convert(_data.FindByID(id));
        }
        public UserVO Update(UserVO user)
        {
            var UserEntity = _converter.Convert(user);
            UserEntity = _data.Update(UserEntity);
            return _converter.Convert(UserEntity);
        }
    }
}
