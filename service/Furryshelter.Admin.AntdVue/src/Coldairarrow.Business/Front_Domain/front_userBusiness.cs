using AutoMapper;
using Coldairarrow.Entity.Front_Domain;
using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Front_Domain
{
    public class front_userBusiness : BaseBusiness<front_user>, Ifront_userBusiness, ITransientDependency
    {
        readonly IOperator _operator;
        readonly IMapper _mapper;
        public front_userBusiness(IDbAccessor db, IOperator @operator, IMapper mapper)
            : base(db)
        {
            _operator = @operator;
            _mapper = mapper;
        }

        #region 外部接口

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> SubmitLoginAsync(front_user_loginDTO input)
        {
            input.Password = input.Password.ToMD5String();
            var theUser = await GetIQueryable()
                .Where(x => x.UserName == input.UserName && x.Password == input.Password)
                .FirstOrDefaultAsync();

            if (theUser.IsNullOrEmpty())
                throw new BusException("账号或密码不正确！");

            return theUser.Id;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task ChangePwdAsync(front_user_changepwdDTO input)
        {
            var theUser = _operator.Property;
            if (theUser.Password != input.OldPwd?.ToMD5String())
                throw new BusException("原密码错误!");

            theUser.Password = input.ConfirmPwd.ToMD5String();
            await UpdateAsync(_mapper.Map<front_user>(theUser));

            //更新缓存
            //await _base_UserCache.UpdateCacheAsync(theUser.Id);
        }

        public async Task<PageResult<front_user>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<front_user>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<front_user, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<front_user> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<int> AddDataAsync(front_user data)
        {
            return await InsertAsync(data);
        }
        public async Task<int> AddDataAsync(front_userDTO data)
        {
            return await InsertAsync(_mapper.Map<front_user>(data));
        }
        public async Task UpdateDataAsync(front_user data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        /// <summary>
        /// 判断邮箱注册过
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<front_user> FindDataByEmailAsync(string email)
        {
            var res = await GetIQueryable().Where(t => t.Email == email && t.IfVeryfyEmail).ToListAsync();
            if (res.Any())
            {
                return res.FirstOrDefault();
            }

            return null;
        }



        #endregion

        #region 私有成员

        #endregion
    }
}