using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Inredning.Models
{
    public class OrderItem
    {
        [BindNever]
        public int OrderItemId { get; set; }

        [Required(ErrorMessage = "Var god skriv in namn på materialet")]
        [Display(Name = "Materialets namn")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Var god skriv in projektets tilldelade id från 'Visa projekt'-sidan")]
        [Display(Name = "Projektets id")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Var god skriv in leverantörens namn")]
        [Display(Name = "Leverantörens namn")]
        [StringLength(50)]
        public string Supplier { get; set; }

        [Required(ErrorMessage = "Var god skriv in kostnaden per enskild produkt")]
        [Display(Name = "Kostnad per produkt")]
        public double IndividualPrice { get; set; }

        [Required(ErrorMessage = "Var god skriv in det antal som ska inköpas")]
        [Display(Name = "Antal")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Var god skriv in övrig information")]
        [Display(Name = "Övrig information som länk")]
        [StringLength(80)]
        public string Info { get; set; }
    }
}