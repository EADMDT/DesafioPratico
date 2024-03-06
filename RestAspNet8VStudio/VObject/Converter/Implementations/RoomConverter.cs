using RestAspNet8VStudio.Model;

namespace RestAspNet8VStudio.VObject.Converter.Implementations
{
    public class RoomConverter : IConverter<RoomVO, Room>, IConverter<Room, RoomVO>
    {
        public Room Convert(RoomVO source)
        {
            if (source == null) return null;
            return new Room()
            {
                Id = source.Id,
                HotelId = source.HotelId,
                RoomNumber = source.RoomNumber,
                Capacity = source.Capacity,
                Description = source.Description,
                Photos = source.Photos
            };
        }

        public List<Room> Convert(List<RoomVO> source)
        {
            if (source == null) return null;
            return source.Select(item => Convert(item)).ToList();
        }

        public RoomVO Convert(Room source)
        {
            if (source == null) return null;
            return new RoomVO()
            {
                Id = source.Id,
                HotelId = source.HotelId,
                RoomNumber = source.RoomNumber,
                Capacity = source.Capacity,
                Description = source.Description,
                Photos = source.Photos
            };
        }

        public List<RoomVO> Convert(List<Room> source)
        {
            if (source == null) return null;
            return source.Select(item => Convert(item)).ToList();
        }
    }
}
