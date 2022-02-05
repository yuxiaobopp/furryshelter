using Coldairarrow.Business.Front_Domain;
using Coldairarrow.Entity.Front_Domain;
using FrontGrpcService.Protos;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace FrontGrpcService.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        Ifront_userBusiness _front_userBus { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public UserService(ILogger<UserService> logger, Ifront_userBusiness front_userBus)
        {
            _logger = logger;
            _front_userBus = front_userBus;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<RegisterReply> UserRegister(RegisterRequest request, ServerCallContext context)
        {
            //var httpContext = context.GetHttpContext();
            //var clientCertificate = httpContext.Connection.ClientCertificate;

            //return Task.FromResult(new HelloReply
            //{
            //    Message = "Hello " + request.Name + " from " + clientCertificate.Issuer
            //});
            if (request == null)
            {
                return Task.FromResult(new RegisterReply
                {
                    Code = -1,
                    Message = "非法参数"
                });
            }

            if (!request.Password.Equals(request.Confirmpassword))
            {
                return Task.FromResult(new RegisterReply
                {
                    Code = -1,
                    Message = "两次密码不一致"
                });
            }

            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.Province) ||
                string.IsNullOrWhiteSpace(request.City)
                    )
            {
                return Task.FromResult(new RegisterReply
                {
                    Code = -1,
                    Message = "参数不完整"
                });
            }

            _logger.LogInformation("注册", JsonConvert.SerializeObject(request));
            //判断

            _front_userBus.AddDataAsync(new front_user
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
                RealName = request.Realname,
                UserName = request.Username,
            });
            return Task.FromResult(new RegisterReply
            {
                Code = 1,
                Message = "注册成功"
            });
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<LoginReply> UserLogin(LoginRequest request, ServerCallContext context)
        {
            return Task.FromResult(new LoginReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
