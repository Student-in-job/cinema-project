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


        public int Id;//при редактировании объекта надо было где то хранить его Id.)
    
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        
        [Display(Name = "Описание"), DataType(DataType.MultilineText)]
        [Required]
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

        [Required]
        [Display(Name = "Вкл. премьеры")]
        public bool NewFilmsEnabled { get; set; }

        public bool? Active;

        public int SubscriptionAmount;
    
        public ICollection<subscription> Subscriptions { get; set; }
    }
}