using RestAspNet8VStudio.VObject;

namespace RestAspNet8VStudio.Logic
{
    public interface IHotelLogic
    {
        HotelVO Create(HotelVO hotel);
        HotelVO FindByID(long id);
        List<HotelVO> FindAll();
        HotelVO Update(HotelVO hotel);
        HotelVO Delete(long id);
    }
}
