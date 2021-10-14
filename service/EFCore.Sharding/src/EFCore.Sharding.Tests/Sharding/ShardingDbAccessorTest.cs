﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EFCore.Sharding.Tests
{
    [TestClass]
    public class ShardingDbAccessorTest : BaseTest
    {
        private readonly IShardingDbAccessor _db;
        public ShardingDbAccessorTest()
        {
            _db = ServiceProvider.GetService<IShardingDbAccessor>();
        }

        protected override void Clear()
        {
            _db.DeleteAll<Base_UnitTest>();
        }

        [TestMethod]
        public void Insert_single()
        {
            _db.Insert(_newData);
            var theData = _db.GetIShardingQueryable<Base_UnitTest>().FirstOrDefault();
            Assert.AreEqual(_newData.ToJson(), theData.ToJson());
        }

        [TestMethod]
        public async Task InsertAsync_single()
        {
            await _db.InsertAsync(_newData);
            var theData = await _db.GetIShardingQueryable<Base_UnitTest>().FirstOrDefaultAsync();
            Assert.AreEqual(_newData.ToJson(), theData.ToJson());
        }

        [TestMethod]
        public void DeleteAll_generic()
        {
            _db.Insert(_insertList);
            _db.DeleteAll<Base_UnitTest>();
            int count = _db.GetIShardingQueryable<Base_UnitTest>().Count();
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public async Task DeleteAllAsync_generic()
        {
            _db.Insert(_insertList);
            await _db.DeleteAllAsync<Base_UnitTest>();
            int count = _db.GetIShardingQueryable<Base_UnitTest>().Count();
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Delete_single()
        {
            _db.Insert(_newData);
            _db.Delete(_newData);
            var count = _db.GetIShardingQueryable<Base_UnitTest>().Count();
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public async Task DeleteAsync_single()
        {
            _db.Insert(_newData);
            await _db.DeleteAsync(_newData);
            var count = _db.GetIShardingQueryable<Base_UnitTest>().Count();
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Delete_multiple()
        {
            _db.Insert(_insertList);
            _db.Delete(_insertList);
            var count = _db.GetIShardingQueryable<Base_UnitTest>().Count();
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public async Task DeleteAsync_multiple()
        {
            _db.Insert(_insertList);
            await _db.DeleteAsync(_insertList);
            var count = _db.GetIShardingQueryable<Base_UnitTest>().Count();
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Delete_where()
        {
            _db.Insert(_insertList);
            _db.Delete<Base_UnitTest>(x => x.UserId == "Admin2");
            var count = _db.GetIShardingQueryable<Base_UnitTest>().Count();
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public async Task DeleteAsync_where()
        {
            _db.Insert(_insertList);
            await _db.DeleteAsync<Base_UnitTest>(x => x.UserId == "Admin2");
            var count = _db.GetIShardingQueryable<Base_UnitTest>().Count();
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public async Task Delete_Sql()
        {
            _db.Insert(_insertList);
            await _db.DeleteSqlAsync<Base_UnitTest>(x => x.UserId == "Admin2");
            var count = _db.GetIShardingQueryable<Base_UnitTest>().Count();
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Update_single()
        {
            _db.Insert(_newData);
            var updateData = _newData.DeepClone();
            updateData.UserId = "Admin_Update";
            _db.Update(updateData);
            var dbUpdateData = _db.GetIShardingQueryable<Base_UnitTest>().FirstOrDefault();
            Assert.AreEqual(updateData.ToJson(), dbUpdateData.ToJson());
        }

        [TestMethod]
        public async Task UpdateAsync_single()
        {
            _db.Insert(_newData);
            var updateData = _newData.DeepClone();
            updateData.UserId = "Admin_Update";
            await _db.UpdateAsync(updateData);
            var dbUpdateData = _db.GetIShardingQueryable<Base_UnitTest>().FirstOrDefault();
            Assert.AreEqual(updateData.ToJson(), dbUpdateData.ToJson());
        }

        [TestMethod]
        public void Update_multiple()
        {
            _db.Insert(_insertList);
            var updateList = _insertList.DeepClone();
            updateList[0].UserId = "Admin3";
            updateList[1].UserId = "Admin4";
            _db.Update(updateList);
            int count = _db.GetIShardingQueryable<Base_UnitTest>().Where(x => x.UserId == "Admin3" || x.UserId == "Admin4").Count();
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public async Task UpdateAsync_multiple()
        {
            _db.Insert(_insertList);
            var updateList = _insertList.DeepClone();
            updateList[0].UserId = "Admin3";
            updateList[1].UserId = "Admin4";
            await _db.UpdateAsync(updateList);
            int count = _db.GetIShardingQueryable<Base_UnitTest>().Where(x => x.UserId == "Admin3" || x.UserId == "Admin4").Count();
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void UpdateAny_single()
        {
            _db.Insert(_newData);
            var newUpdateData = _newData.DeepClone();
            newUpdateData.UserName = "普通管理员";
            newUpdateData.UserId = "xiaoming";
            newUpdateData.Age = 100;
            _db.Update(newUpdateData, new List<string> { "UserName", "Age" });
            var dbSingleData = _db.GetIShardingQueryable<Base_UnitTest>().FirstOrDefault();
            newUpdateData.UserId = "Admin";
            Assert.AreEqual(newUpdateData.ToJson(), dbSingleData.ToJson());
        }

        [TestMethod]
        public async Task UpdateAnyAsync_single()
        {
            _db.Insert(_newData);
            var newUpdateData = _newData.DeepClone();
            newUpdateData.UserName = "普通管理员";
            newUpdateData.UserId = "xiaoming";
            newUpdateData.Age = 100;
            await _db.UpdateAsync(newUpdateData, new List<string> { "UserName", "Age" });
            var dbSingleData = _db.GetIShardingQueryable<Base_UnitTest>().FirstOrDefault();
            newUpdateData.UserId = "Admin";
            Assert.AreEqual(newUpdateData.ToJson(), dbSingleData.ToJson());
        }

        [TestMethod]
        public void UpdateAny_multiple()
        {
            _db.Insert(_insertList);
            var newList1 = _insertList.DeepClone();
            var newList2 = _insertList.DeepClone();
            newList1.ForEach(aData =>
            {
                aData.Age = 100;
                aData.UserId = "Test";
                aData.UserName = "测试";
            });
            newList2.ForEach(aData =>
            {
                aData.Age = 100;
                aData.UserName = "测试";
            });

            _db.Update(newList1, new List<string> { "UserName", "Age" });
            var dbData = _db.GetIShardingQueryable<Base_UnitTest>().ToList();
            Assert.AreEqual(newList2.OrderBy(x => x.Id).ToJson(), dbData.OrderBy(x => x.Id).ToJson());
        }

        [TestMethod]
        public async Task UpdateAnyAsync_multiple()
        {
            _db.Insert(_insertList);
            var newList1 = _insertList.DeepClone();
            var newList2 = _insertList.DeepClone();
            newList1.ForEach(aData =>
            {
                aData.Age = 100;
                aData.UserId = "Test";
                aData.UserName = "测试";
            });
            newList2.ForEach(aData =>
            {
                aData.Age = 100;
                aData.UserName = "测试";
            });

            await _db.UpdateAsync(newList1, new List<string> { "UserName", "Age" });
            var dbData = _db.GetIShardingQueryable<Base_UnitTest>().ToList();
            Assert.AreEqual(newList2.OrderBy(x => x.Id).ToJson(), dbData.OrderBy(x => x.Id).ToJson());
        }

        [TestMethod]
        public void UpdateWhere()
        {
            _db.Insert(_newData);
            _db.Update<Base_UnitTest>(x => x.UserId == "Admin", x =>
            {
                x.UserId = "Admin2";
            });

            Assert.IsTrue(_db.GetIShardingQueryable<Base_UnitTest>().Any(x => x.UserId == "Admin2"));
        }

        [TestMethod]
        public async Task UpdateWhereAsync()
        {
            _db.Insert(_newData);
            await _db.UpdateAsync<Base_UnitTest>(x => x.UserId == "Admin", x =>
            {
                x.UserId = "Admin2";
            });

            Assert.IsTrue(_db.GetIShardingQueryable<Base_UnitTest>().Any(x => x.UserId == "Admin2"));
        }

        [TestMethod]
        public void RunTransaction_fail()
        {
            bool succcess = _db.RunTransaction(() =>
            {
                _db.Insert(_newData);
                var newData2 = _newData.DeepClone();
                _db.Insert(newData2);
            }).Success;
            Assert.IsFalse(succcess);
        }

        [TestMethod]
        public async Task RunTransactionAsync_fail()
        {
            bool succcess = (await _db.RunTransactionAsync(async () =>
            {
                await _db.InsertAsync(_newData);
                var newData2 = _newData.DeepClone();
                await _db.InsertAsync(newData2);
            })).Success;
            Assert.IsFalse(succcess);
        }

        [TestMethod]
        public void RunTransaction_success()
        {
            bool succcess = _db.RunTransaction(() =>
            {
                var newData = _newData.DeepClone();
                newData.Id = Guid.NewGuid().ToString();
                newData.UserId = Guid.NewGuid().ToString();
                newData.UserName = Guid.NewGuid().ToString();
                _db.Insert(_newData);
                _db.Insert(newData);
            }).Success;
            int count = _db.GetIShardingQueryable<Base_UnitTest>().Count();
            Assert.IsTrue(succcess);
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public async Task RunTransactionAsync_success()
        {
            bool succcess = (await _db.RunTransactionAsync(async () =>
            {
                var newData = _newData.DeepClone();
                newData.Id = Guid.NewGuid().ToString();
                newData.UserId = Guid.NewGuid().ToString();
                newData.UserName = Guid.NewGuid().ToString();
                await _db.InsertAsync(_newData);
                await _db.InsertAsync(newData);
            })).Success;
            int count = _db.GetIShardingQueryable<Base_UnitTest>().Count();
            Assert.IsTrue(succcess);
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void RunTransaction_isolationLevel()
        {
            var db1 = ServiceProvider.GetService<IShardingDbAccessor>();
            var db2 = ServiceProvider.CreateScope().ServiceProvider.GetService<IShardingDbAccessor>();
            db1.Insert(_newData);

            var updateData = _newData.DeepClone();
            Task db2Task = new Task(() =>
            {
                updateData.UserName = Guid.NewGuid().ToString();
                db2.Update(updateData);
            });

            var res = db1.RunTransaction(() =>
            {
                //db1读=>db2写(阻塞)=>db1读=>db1提交
                var db1Data_1 = db1.GetIShardingQueryable<Base_UnitTest>().Where(x => x.Id == _newData.Id).FirstOrDefault();

                db2Task.Start();

                var db1Data_2 = db1.GetIShardingQueryable<Base_UnitTest>().Where(x => x.Id == _newData.Id).FirstOrDefault();
                Assert.AreEqual(db1Data_1.ToJson(), db1Data_2.ToJson());
            });
            db2Task.Wait();
            var db1Data_3 = db1.GetIShardingQueryable<Base_UnitTest>().Where(x => x.Id == _newData.Id).FirstOrDefault();
            Assert.AreEqual(updateData.ToJson(), db1Data_3.ToJson());
        }
    }
}
