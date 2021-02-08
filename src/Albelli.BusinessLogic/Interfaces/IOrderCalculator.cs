using Albelli.Data;

namespace Albelli.BusinessLogic.Interfaces
{
    public interface IOrderCalculator
    {
        decimal GetPackageWidth(Order order);
    }
}
