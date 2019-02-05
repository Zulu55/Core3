namespace Core3.Data
{
    using Core3.Models;
    using Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository
    {
        Task AddProductAsync(Product product, string userName);

        Product GetProduct(int id);

        IEnumerable<Product> GetProducts();

        void RemoveProduct(Product product);

        Task<bool> SaveAllAsync();

        void UpdateProduct(Product product);

        bool ProductExists(int id);

        Task<IEnumerable<Order>> GetOrdersAsync(string userName);

        Task<IEnumerable<OrderDetailTemp>> GetDetailTempsAsync(string userName);

        IEnumerable<SelectListItem> GetComboProducts();

        Task AddItemToOrderAsync(AddItemViewModel model, string userName);

        Task ModifyOrderDetailTempQuantityAsync(int id, double quantity);
    }
}