
// ReSharper disable All
namespace OnlineCinemaProject.Models
{
    public class TariffInfo
    {
        public int id;
        public string name;
        public string description;
        public decimal price;
    }

    public partial class tariff
    {
        public TariffInfo GetTariffInfo()
        {
            return new TariffInfo
            {
                id = id,
                name = name,
                description = description,
                price = (decimal) price
            };
        }

        public bool Includes(file file)
        {
            if ((bool) !new_films_enabled) //если тариф не вкл. просмотр фильмов которые вышли на прокат недавно
            {
                //todo check if film is a prmier
                return true;
            }
            return true;
        }
        public bool Includes(season file)
        {
            if ((bool) !new_films_enabled) //если тариф не вкл. просмотр фильмов которые вышли на прокат недавно
            {
                //todo check if film is a prmier
                return true;
            }
            return true;
        }
        
        /*public bool Includes(season season)
        {
            if ((bool) !new_films_enabled) //если тариф не вкл. просмотр фильмов которые вышли на прокат недавно
            {
                //todo check if season is a prmier
                return true;
            }
            return true;
        }*/
    }
}