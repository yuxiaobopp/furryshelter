using Coldairarrow.Business.Front_Domain;
using Coldairarrow.Entity.Front_Domain;
using Coldairarrow.Util;
using Coldairarrow.Util.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Coldairarrow.Util.ImgVerifyCodeHelper;

namespace Coldairarrow.Api.Controllers.Front_Domain
{
    [Route("/Front_Domain/[controller]/[action]")]
    [OpenApiTag("C端接口")]
    public class front_userController : BaseApiController
    {
        #region DI
        private readonly ILogger<front_userController> _logger;
        readonly IConfiguration _configuration;

        public front_userController(IConfiguration configuration, ILogger<front_userController> logger, Ifront_userBusiness front_userBus)
        {
            _logger = logger;
            _configuration = configuration;
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
        /// 提交注册信息，成功后跳转到发送邮件验证码页面
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <returns></returns>
        /// <example>
        /// {
        ///     "UserName":"xxxx@qq.com",
        ///     "Password":"123456",
        ///     "ConfirmPassword":"123456",
        ///     "Province":"浙江省",
        ///     "City":"杭州市",
        ///     "Sex" : 1,
        ///     "Birthday" : "2000-01-01",
        ///     "IdentityCardNo" : "123456123456123456",
        ///     "IfVerifyCardNo" : 1,
        ///     "IfPet" : 1,
        ///     "Phone" : "13888888888",
        /// }
        /// </example>
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
                    Code = (int)FrontUserRegistResult.参数错误,
                    Message = FrontUserRegistResult.参数错误.ToString()
                });
            }


            ModelState.ClearValidationState(nameof(front_userDTO));
            if (!TryValidateModel(request, nameof(front_userDTO)))
            {
                return Task.FromResult(new
                {
                    Code = (int)FrontUserRegistResult.参数错误,
                    Message = FrontUserRegistResult.参数错误.ToString()
                });
            }

            //if (!request.Password.Equals(request.ConfirmPassword))
            //{
            //    return Task.FromResult(new
            //    {
            //        Code = (int)FrontUserRegistResult.两次密码不一致,
            //        Message = FrontUserRegistResult.两次密码不一致.ToString()
            //    });
            //}

            if (string.IsNullOrWhiteSpace(request.UserName) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.Province) ||
                string.IsNullOrWhiteSpace(request.City)
                    )
            {
                return Task.FromResult(new
                {
                    Code = (int)FrontUserRegistResult.参数错误,
                    Message = FrontUserRegistResult.参数错误.ToString()
                });
            }

            var emailEntry = await _front_userBus.FindDataByEmailAsync(request.Email);
            if (emailEntry != null)
            {
                return Task.FromResult(new
                {
                    Code = (int)FrontUserRegistResult.邮箱已经存在,
                    Message = FrontUserRegistResult.邮箱已经存在.ToString()
                });
            }

            _logger.LogInformation("注册", JsonConvert.SerializeObject(request));
            
            InitEntity(request);
            request.EmailCode = new VerifyCodeFactory().CreateValidateCode(5);//生成邮件验证码 验证过的用户才可以登录
            var ret= await _front_userBus.AddDataAsync(request);

            return Task.FromResult(new
            {
                Code = (int)FrontUserRegistResult.成功,
                Date= request.EmailCode,
                Message = FrontUserRegistResult.成功.ToString()
            });
        }

        /// <summary>
        /// 发送邮箱验证码，发送成功后，跳转到校验验证码页面
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<dynamic> SendVeryfyEmailCode(front_user_emailDTO request)
        {
            ModelState.ClearValidationState(nameof(front_userDTO));
            if (!TryValidateModel(request, nameof(front_userDTO)))
            {
                return Task.FromResult(new
                {
                    Code = (int)FrontUserRegistResult.参数错误,
                    Message = FrontUserRegistResult.参数错误.ToString()
                });
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return Task.FromResult(new
                {
                    Code = (int)FrontUserRegistResult.参数错误,
                    Message = FrontUserRegistResult.参数错误.ToString()
                });
            }

            var emailEntry = await _front_userBus.FindDataByEmailAsync(request.Email);
            if (emailEntry == null)
            {
                return Task.FromResult(new
                {
                    Code = (int)FrontUserRegistResult.邮箱不存在,
                    Message = FrontUserRegistResult.邮箱不存在.ToString()
                });
            }

            EmailHelper.SendEmail("注册邮箱验证码", _configuration["adminemail"], request.Email, DateTime.Now, request.EmailCode);

            return Task.FromResult(new
            {
                Code = (int)FrontUserRegistResult.成功,
                Message = FrontUserRegistResult.成功.ToString()
            });
        }

        /// <summary>
        /// 邮箱验证码校验，成功后跳转到登录页面
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<dynamic> VeryfyEmail(front_user_emailDTO request)
        {
            ModelState.ClearValidationState(nameof(front_userDTO));
            if (!TryValidateModel(request, nameof(front_userDTO)))
            {
                return Task.FromResult(new
                {
                    Code = (int)FrontUserRegistResult.参数错误,
                    Message = FrontUserRegistResult.参数错误.ToString()
                });
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return Task.FromResult(new
                {
                    Code = (int)FrontUserRegistResult.参数错误,
                    Message = FrontUserRegistResult.参数错误.ToString()
                });
            }

            var emailEntry = await _front_userBus.FindDataByEmailAsync(request.Email);
            if (emailEntry == null)
            {
                return Task.FromResult(new
                {
                    Code = (int)FrontUserRegistResult.邮箱不存在,
                    Message = FrontUserRegistResult.邮箱不存在.ToString()
                });
            }

            if (!emailEntry.EmailCode.Equals(request.EmailCode))
            {
                return Task.FromResult(new
                {
                    Code = (int)FrontUserRegistResult.邮箱验证码错误,
                    Message = FrontUserRegistResult.邮箱验证码错误.ToString()
                });
            }

            emailEntry.IfVeryfyEmail = true;
            await _front_userBus.UpdateDataAsync(emailEntry);

            return Task.FromResult(new
            {
                Code = (int)FrontUserRegistResult.成功,
                Message = FrontUserRegistResult.成功.ToString()
            });
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<dynamic> UserLogin(front_user_loginDTO request)
        {
            ModelState.ClearValidationState(nameof(front_userDTO));
            if (!TryValidateModel(request, nameof(front_userDTO)))
            {
                return Task.FromResult(new
                {
                    Code = (int)FrontUserRegistResult.参数错误,
                    Message = FrontUserRegistResult.参数错误.ToString()
                });
            }

            await _front_userBus.SubmitLoginAsync(request);

            return Task.FromResult(new
            {
                Code = (int)FrontUserRegistResult.成功,
                Message = FrontUserRegistResult.成功.ToString()
            });
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 注销用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _front_userBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}