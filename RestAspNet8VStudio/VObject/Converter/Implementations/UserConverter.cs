using RestAspNet8VStudio.Model;

namespace RestAspNet8VStudio.VObject.Converter.Implementations
{
    public class UserConverter : IConverter<UserVO, User>, IConverter<User, UserVO>
    {
        public User Convert(UserVO source)
        {
            if (source == null) return null;
            return new User()
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Adress = source.Adress,
                Gender = source.Gender
            };
        }

        public List<User> Convert(List<UserVO> source)
        {
            if (source == null) return null;
            return source.Select(item => Convert(item)).ToList();
        }

        public UserVO Convert(User source)
        {
            if (source == null) return null;
            return new UserVO()
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Adress = source.Adress,
                Gender = source.Gender
            };
        }

        public List<UserVO> Convert(List<User> source)
        {
            if (source == null) return null;
            return source.Select(item => Convert(item)).ToList();
        }
    }
}
