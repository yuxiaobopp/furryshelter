﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Linq;

namespace EFCore.Sharding
{
    internal class GenericModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
        {
            if (context is GenericDbContext genericDbContext)
            {
                var option = genericDbContext.Paramter;

                var entityTypeNames = (option?.EntityTypes ?? new Type[] { }).Select(x => x.AssemblyQualifiedName).ToList();

                return $"{option.GetType()}_{option.DbType}_{option.EntityNamespace}_{string.Join(",", entityTypeNames)}_{option.Suffix}";
            }
            else
            {
                return context.GetType();
            }
        }
    }
}
