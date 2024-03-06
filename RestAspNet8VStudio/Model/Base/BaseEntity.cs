using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNet8VStudio.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
