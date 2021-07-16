using ShopBridge.Common;
using ShopBridge.CustomModels;
using ShopBridge.Interfaces;
using ShopBridge.Models;
using ShopBridge.ProductDBContext;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
namespace ShopBridge.Repositories
{
    public class ProductItemRepository : IProductItem
    {
        private readonly ProductContext _context;
        public ProductItemRepository(ProductContext context)
        {
            _context = context;
        }

        #region ProductItemList
        /// <summary>
        /// Used For : To Get the ProductItem List
        /// </summary>
        /// <param name="ProductItem">start,length and search</param>
        /// <returns></returns>
        public async Task<ViewProductItemResponse> ProductItemList(ProductItemModel Model)
        {
            ViewProductItemResponse viewProductItemResponse = new ViewProductItemResponse();
            try
            {
                await Task.Delay(1);
                var Search = Model.search != null ? Model.search.value : "";
                string sortBy = "";
                string sortDir = "";
                if (Model.order != null)
                {
                    sortBy = Model.columns[Model.order[0].column].data;
                    sortDir = Model.order[0].dir.ToLower();
                }
                viewProductItemResponse.ViewProductItemList = _context.ProductItem.Where(x => x.Status == true
                                  && ((!string.IsNullOrEmpty(Search)
                                  && x.Name.Trim().ToLower().Contains(Search.Trim().ToLower()))
                                  || string.IsNullOrEmpty(Search)))
                                  .Select(x => new ViewProductItem
                                  {
                                      ItemId = x.ItemId,
                                      Name = x.Name,
                                      Description = x.Description,
                                      Price = x.Price,
                                      Quantity = x.Quantity,
                                      TotalPrice = x.TotalPrice
                                  }).OrderBy(x => x.Name)
                                  .Skip(Model.start).Take(Model.length).ToList();
                if (Model.order != null)
                {
                    sortBy = Model.columns[Model.order[0].column].data;
                    sortDir = Model.order[0].dir.ToLower();

                    viewProductItemResponse.ViewProductItemList = viewProductItemResponse.ViewProductItemList.AsQueryable().OrderBy(sortBy + " " + sortDir).ToList();
                }
                viewProductItemResponse.recordsTotal = _context.ProductItem.Where(x => x.Status == true).Count();
                viewProductItemResponse.recordsFiltered = _context.ProductItem.Where(x => x.Status == true
                                        && ((!string.IsNullOrEmpty(Search)
                                        && (x.Name.Trim().ToLower().Contains(Search.Trim().ToLower())))
                                        || string.IsNullOrEmpty(Search))).Count();
                viewProductItemResponse.Success = true;
            }
            catch (Exception ex)
            {
                viewProductItemResponse.Success = false;
                viewProductItemResponse.Message = "No Record is Found";
            }
            // Return the ProductItemList
            return viewProductItemResponse;
        }
        #endregion

        #region ProductItemSave
        /// <summary>
        /// Used For : Save and Update ProductItem Details
        /// </summary>
        /// <param name="Model">ItemId,Name,Description,Price,Quantity</param>
        /// <returns></returns>
        public async Task<ProductItemModel> ProductItemSave(ProductItemModel Model, CommonClass.UserInfo userInfo)
        {
            try
            {
                await Task.Delay(1);
                if (CheckDuplicate(Model, userInfo))
                {
                    var productItem = _context.ProductItem.Where(x => x.Status == true
                                  && x.ItemId == Model.ItemId).FirstOrDefault();
                    if (productItem == null)
                    {
                        ProductItem product = new ProductItem();
                        product.Name = Model.Name;
                        product.Price = Model.Price;
                        product.Quantity = Model.Quantity;
                        product.Description = Model.Description;
                        product.Status = true;
                        product.TotalPrice = Model.Price * Model.Quantity;
                        product.CreatedBy = Convert.ToInt32(userInfo.UserId);
                        product.CreatedDate = DateTime.UtcNow;
                        await _context.AddAsync(product);
                        await _context.SaveChangesAsync();
                        Model.Success = true;
                        Model.Message = "Product Item saved successfully!!";
                    }
                    else
                    {
                        productItem.Name = Model.Name;
                        productItem.Price = Model.Price;
                        productItem.Quantity = Model.Quantity;
                        productItem.Description = Model.Description;
                        productItem.Status = true;
                        productItem.TotalPrice = Model.Price * Model.Quantity;
                        productItem.UpdatedBy = Convert.ToInt32(userInfo.UserId);
                        productItem.UpdatedDate = DateTime.Now;
                        _context.ProductItem.Update(productItem);
                        await _context.SaveChangesAsync();
                        Model.Success = true;
                        Model.Message = "Product Item updated successfully!!";
                    }
                }
            }
            catch (Exception ex)
            {
                Model.Success = false;
                Model.Message = "Invalid Record";
            }
            return Model;
        }
        #endregion

        #region ProductItemDelete
        /// <summary>
        /// Used For : Delete ProductItem Details.
        /// </summary>
        /// <param name="Model">ItemId</param>
        /// <returns></returns>
        public async Task<ProductItemModel> ProductItemDelete(ProductItemModel Model, CommonClass.UserInfo userInfo)
        {
            try
            {
                await Task.Delay(1);
                var ProductItem = _context.ProductItem.Where(x => x.Status == true
                              && x.ItemId == Model.ItemId).FirstOrDefault();
                if (ProductItem != null)
                {
                    ProductItem.Status = false;
                    ProductItem.UpdatedBy = Convert.ToInt32(userInfo.UserId);
                    ProductItem.UpdatedDate = DateTime.UtcNow;
                    _context.ProductItem.Update(ProductItem);
                    await _context.SaveChangesAsync();
                    Model.Success = true;
                    Model.Message = "Product Item deleted successfully!!";
                }
                else
                {
                    Model.Success = false;
                    Model.Message = "Invalid Record!!";
                }
            }
            catch (Exception ex)
            {
                Model.Success = false;
                Model.Message = "Invalid Record!!";
            }
            return Model;
        }
        #endregion

        #region  ProductItemGetById
        /// <summary>
        /// Used For : To get the details for specific ProductItem against the the ProductItem ID
        /// </summary>
        /// <param name="Model">ItemId</param>
        /// <returns></returns>
        public async Task<ProductItemModel> ProductItemGetById(ProductItemModel Model)
        {
            ProductItemModel ProductItem = new ProductItemModel();
            try
            {
                await Task.Delay(1);
                if (!string.IsNullOrEmpty(Model.ItemId.ToString()))
                {
                    ProductItem = _context.ProductItem.Where(x => x.Status == true
                                  && x.ItemId == Model.ItemId)
                                  .Select(x => new ProductItemModel
                                  {
                                      ItemId = x.ItemId,
                                      Name = x.Name,
                                      Description = x.Description,
                                      Price = x.Price,
                                      Quantity = x.Quantity,
                                      TotalPrice = x.TotalPrice
                                  }).FirstOrDefault();
                    ProductItem.Success = true;
                }
                else
                {
                    ProductItem.Success = false;
                    ProductItem.Message = "Invalid Record!!";
                }
            }
            catch (Exception ex)
            {
                ProductItem.Success = false;
                ProductItem.Message = "Invalid Record!!";
            }
            return ProductItem;
        }
        #endregion

        #region CheckDuplicate
        /// <summary>
        /// Used For : Check ProductItem Name Already Exist or Not
        /// </summary>
        /// <param name="Model">Name</param>
        /// <returns></returns>
        private bool CheckDuplicate(ProductItemModel Model, CommonClass.UserInfo userInfo)
        {
            var ProductItem = _context.ProductItem.Where(x => x.Name.ToLower() == Model.Name.Trim().ToLower()
                              && x.ItemId != Model.ItemId).FirstOrDefault();
            if (ProductItem != null)
            {
                var UpdateDeleteItem = _context.ProductItem.Where(x => x.Name.ToLower()
                                       == Model.Name.Trim().ToLower() && x.Status == false).FirstOrDefault();
                if (UpdateDeleteItem != null)
                {
                    ProductItem.Status = true;
                    ProductItem.UpdatedBy = Convert.ToInt32(userInfo.UserId);
                    _context.Update(ProductItem);
                    _context.SaveChanges();
                    Model.Success = true;
                    Model.Message = "Product Item saved successfully!!";
                    return false;
                }
                else
                {
                    Model.Success = false;
                    Model.Message = "Product Item Name already exist!!";
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}