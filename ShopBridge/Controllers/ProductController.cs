using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ShopBridge.Common;
using ShopBridge.CustomModels;
using ShopBridge.Interfaces;
using ShopBridge.Models.Logins;

namespace ShopBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductItem _productitem;

        public ProductController(IProductItem productitem)
        {
            _productitem = productitem;
        }

        #region when user login it find out the information from token
        public CommonClass.UserInfo UserDetail()
        {
            CommonClass.UserInfo userInfo = new CommonClass.UserInfo();
            if (User.Claims != null && User.Claims.ToList().Count > 0)
            {
                userInfo.UserId = User.Claims.FirstOrDefault(x => x.Type.Equals("UserId")).Value;
                userInfo.UserName = User.Claims.FirstOrDefault(x => x.Type.Equals("UserName")).Value;
            }
            else
            {
                userInfo.UserId = "1";
                userInfo.UserName = "Admin";
            }
            return userInfo;
        }
        #endregion

        #region ProductItem
        /// <summary>
        /// Used For : Get ProductItem List
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost, Route("ProductItemList")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> ProductItemList(ProductItemModel Model)
        {
            try
            {
                var Result = await _productitem.ProductItemList(Model);
                return Ok(new { Result, Success = true });
            }
            catch (Exception ex)
            {
                return BadRequest("An error has occured!");
            }
        }

        /// <summary>
        /// Used For : Save ProductItem Details
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost, Route("ProductItemSave")]
        public async Task<ActionResult> ProductItemSave(ProductItemModel Model)
        {
            try
            {
                var Result = await _productitem.ProductItemSave(Model, UserDetail());
                return Ok(new { Result, Success = Result.Success });
            }
            catch (Exception ex)
            {
                return BadRequest("An error has occured!");
            }
        }

        /// <summary>
        /// Used For : Delete ProductItem Details
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost, Route("ProductItemDelete")]
        public async Task<ActionResult> ProductItemDelete(ProductItemModel Model)
        {
            try
            {
                var Result = await _productitem.ProductItemDelete(Model, UserDetail());
                return Ok(new { Result, Success = Result.Success });
            }
            catch (Exception ex)
            {
                return BadRequest("An error has occured!");
            }
        }

        /// <summary>
        /// Used For : Edit ProductItem Details
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost, Route("ProductItemGetById")]
        public async Task<ActionResult> ProductItemGetById(ProductItemModel Model)
        {
            try
            {
                var Result = await _productitem.ProductItemGetById(Model);
                return Ok(new { Result, Success = Result.Success });
            }
            catch (Exception ex)
            {
                return BadRequest("An error has occured!");
            }
        }
        #endregion
    }
}