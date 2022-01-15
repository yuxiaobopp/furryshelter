using Coldairarrow.Business.Front_Domain;
using Coldairarrow.Entity.Front_Domain;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Front_Domain
{
    [Route("/Front_Domain/[controller]/[action]")]
    public class front_userController : BaseApiController
    {
        #region DI
        private readonly ILogger<front_userController> _logger;

        public front_userController(ILogger<front_userController> logger, Ifront_userBusiness front_userBus)
        {
            _logger = logger;
            _front_userBus = front_userBus;
        }

        Ifront_userBusiness _front_userBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<front_user>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _front_userBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<front_user> GetTheData(IdInputDTO input)
        {
            return await _front_userBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<dynamic> UserRegister(front_userDTO request)
        {
            //var httpContext = context.GetHttpContext();
            //var clientCertificate = httpContext.Connection.ClientCertificate;

            //return Task.FromResult(new HelloReply
            //{
            //    Message = "Hello " + request.Name + " from " + clientCertificate.Issuer
            //});
            if (request == null)
            {
                return Task.FromResult(new 
                {
                    Code = -1,
                    Message = "非法参数"
                });
            }

            if (request.Password!.Equals(request.ConfirmPassword))
            {
                return Task.FromResult(new 
                {
                    Code = -1,
                    Message = "两次密码不一致"
                });
            }

            if (string.IsNullOrWhiteSpace(request.UserName) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.Province) ||
                string.IsNullOrWhiteSpace(request.City)
                    )
            {
                return Task.FromResult(new 
                {
                    Code = -1,
                    Message = "参数不完整"
                });
            }

            _logger.LogInformation("注册", JsonConvert.SerializeObject(request));
            //判断

            await _front_userBus.AddDataAsync(new front_user
            {
                Sex = request.Sex,
                Birthday = request.Birthday,
                City = request.City,
                CreateTime = DateTime.Now,
                IdentityCardNo = request.IdentityCardNo,
                IfPet = request.IfPet,
                Deleted = false,
                IfVerifyCardNo = request.IfVerifyCardNo,
                Password = request.Password,
                Phone = request.Phone,
                Province = request.Province,
                RealName = request.RealName,
                UserName = request.UserName,
            });

            return Task.FromResult(new 
            {
                Code = 1,
                Message = "注册成功"
            });
        }
        [HttpPost]
        public async Task SaveData(front_user data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _front_userBus.AddDataAsync(data);
            }
            else
            {
                await _front_userBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _front_userBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}