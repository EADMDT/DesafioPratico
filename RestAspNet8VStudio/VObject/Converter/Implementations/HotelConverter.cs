using RestAspNet8VStudio.Model;

namespace RestAspNet8VStudio.VObject.Converter.Implementations
{
    public class HotelConverter : IConverter<HotelVO, Hotel>, IConverter<Hotel, HotelVO>
    {
        public Hotel Convert(HotelVO source)
        {
            if (source == null) return null;
            return new Hotel()
            {
                Id = source.Id,
                Name = source.Name,
                Adress = source.Adress,
                Phone = source.Phone,
                Description = source.Description,
                Rating = source.Rating
            };
        }

        public List<Hotel> Convert(List<HotelVO> source)
        {
            if (source == null) return null;
            return source.Select(item => Convert(item)).ToList();
        }

        public HotelVO Convert(Hotel source)
        {
            if (source == null) return null;
            return new HotelVO()
            {
                Id = source.Id,
                Name = source.Name,
                Adress = source.Adress,
                Phone = source.Phone,
                Description = source.Description,
                Rating = source.Rating
            };
        }

        public List<HotelVO> Convert(List<Hotel> source)
        {
            if (source == null) return null;
            return source.Select(item => Convert(item)).ToList();
        }
    }
}
