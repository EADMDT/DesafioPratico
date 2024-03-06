using RestAspNet8VStudio.Data;
using RestAspNet8VStudio.Model;
using RestAspNet8VStudio.VObject.Converter.Implementations;
using RestAspNet8VStudio.VObject;

namespace RestAspNet8VStudio.Logic.Implementations
{
    public class RoomLogicImplementation : IRoomLogic
    {
        private readonly IGenericData<Room> _data;
        private readonly RoomConverter _converter;

        public RoomLogicImplementation(IGenericData<Room> data)
        {
            _data = data;
            _converter = new RoomConverter();
        }

        public RoomVO Create(RoomVO room)
        {
            var RoomEntity = _converter.Convert(room);
            RoomEntity = _data.Create(RoomEntity);
            return _converter.Convert(RoomEntity);
        }

        public RoomVO Delete(long id)
        {
            var RoomEntity = _data.Delete(id);
            return  _converter.Convert(RoomEntity);
        }

        public List<RoomVO> FindAll()
        {
            return _converter.Convert(_data.FindAll());
        }
        public RoomVO FindByID(long id)
        {
            return _converter.Convert(_data.FindByID(id));
        }
        public RoomVO Update(RoomVO room)
        {
            var RoomEntity = _converter.Convert(room);
            RoomEntity = _data.Update(RoomEntity);
            return _converter.Convert(RoomEntity);
        }
    }
}
