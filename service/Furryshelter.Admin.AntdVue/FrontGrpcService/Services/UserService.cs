using FrontGrpcService.Protos;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontGrpcService.Services
{
    public class UserService: User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<RegisterReply> UserRegister(RegisterRequest request, ServerCallContext context)
        {
            return Task.FromResult(new RegisterReply
            {
                Message = ""
            });
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<LoginReply> UserLgin(LoginRequest request, ServerCallContext context)
        {
            return Task.FromResult(new LoginReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
