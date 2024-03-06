using RestAspNet8VStudio.Data;
using RestAspNet8VStudio.Model;
using RestAspNet8VStudio.VObject.Converter.Implementations;
using RestAspNet8VStudio.VObject;

namespace RestAspNet8VStudio.Logic.Implementations
{
    public class HotelLogicImplementation : IHotelLogic
    {
        private readonly IGenericData<Hotel> _data;
        private readonly HotelConverter _converter;

        public HotelLogicImplementation(IGenericData<Hotel> data)
        {
            _data = data;
            _converter = new HotelConverter();
        }

        public HotelVO Create(HotelVO hotel)
        {
            var HotelEntity = _converter.Convert(hotel);
            HotelEntity = _data.Create(HotelEntity);
            return _converter.Convert(HotelEntity);
        }

        public HotelVO Delete(long id)
        {
            var HotelEntity = _data.Delete(id);
            return  _converter.Convert(HotelEntity);
        }

        public List<HotelVO> FindAll()
        {
            return _converter.Convert(_data.FindAll());
        }
        public HotelVO FindByID(long id)
        {
            return _converter.Convert(_data.FindByID(id));
        }
        public HotelVO Update(HotelVO hotel)
        {
            var HotelEntity = _converter.Convert(hotel);
            HotelEntity = _data.Update(HotelEntity);
            return _converter.Convert(HotelEntity);
        }
    }
}
