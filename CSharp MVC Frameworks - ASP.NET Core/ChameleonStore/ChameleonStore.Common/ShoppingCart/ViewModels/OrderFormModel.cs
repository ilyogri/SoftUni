using System.ComponentModel.DataAnnotations;

namespace ChameleonStore.Web.Models.ShoppingCart
{
    public class OrderFormModel
    {
        [Required]
        public string Address { get; set; }
    }
}
