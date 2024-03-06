using RestAspNet8VStudio.VObject;

namespace RestAspNet8VStudio.Logic
{
    public interface IRoomLogic
    {
        List<RoomVO> FindAll();
        RoomVO FindByID(long id);
        RoomVO Create(RoomVO room);
        RoomVO Update(RoomVO room);
        RoomVO Delete(long id);
    }
}
