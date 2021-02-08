namespace Albelli.Web.Models.Interfaces
{
    public interface IOrderMapper
    {
        Data.Order ToDomainModel(Models.Order webOrder);
        Models.Order ToWebModel(Data.Order order);
    }
}
