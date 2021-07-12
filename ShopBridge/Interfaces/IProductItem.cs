using ShopBridge.Common;
using ShopBridge.CustomModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Interfaces
{
    /// <summary>
    /// Used For : Interfaces for List, Save, Delete, Get By Id of ProductItem
    /// </summary>
    /// <param name="IProductItem"></param>
    /// <returns></returns>
    public interface IProductItem
    {
        Task<ViewProductItemResponse> ProductItemList(ProductItemModel Model);
        Task<ProductItemModel> ProductItemSave(ProductItemModel Model, CommonClass.UserInfo userInfo);
        Task<ProductItemModel> ProductItemDelete(ProductItemModel Model, CommonClass.UserInfo userInfo);
        Task<ProductItemModel> ProductItemGetById(ProductItemModel Model);
    }
}
