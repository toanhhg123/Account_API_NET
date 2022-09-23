using System.ComponentModel.DataAnnotations;

namespace AccountApi.Models{
    public class DetailUser {
        [Key]
        public string Id {set;get;} = string.Empty;
    }
}