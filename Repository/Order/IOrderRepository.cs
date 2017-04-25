using Model.Base;

namespace Repository.Order
{
    public interface IOrderRepository: IBaseRepository<Model.Model.Order>
    {
        int Insert(Model.Model.Order entity);
    }
}
