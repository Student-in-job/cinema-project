using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCinemaProject.Models.ViewModels
{
    public sealed class TariffViewModel
    {
        public TariffViewModel()
        {
            this.Subscriptions = new HashSet<subscription>();
        }
    
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание"), DataType(DataType.MultilineText)]

        public string Description { get; set; }
        [Required]
        [Display(Name = "Дата создания"), DataType(DataType.DateTime)]
        public System.DateTime CreationDate { get; set; }
        [Required]
        [Display(Name = "Цена"), DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Вкл. руклама")]
        public bool AdverticementEnabled { get; set; }
        [Display(Name = "Вкл. премьеры")]
        public bool NewFilmsEnabled { get; set; }

        public int SubscriptionAmount;
    
        public ICollection<subscription> Subscriptions { get; set; }
    }
}