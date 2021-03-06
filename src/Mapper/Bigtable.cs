﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using BigtableNet.Common;
using BigtableNet.Mapper.Implementation;
using BigtableNet.Mapper.Interfaces;
using BigtableNet.Models.Clients;
using BigtableNet.Models.Types;
using Google.Bigtable.V1;

namespace BigtableNet.Mapper
{
    /// <summary>
    /// This class is under development
    /// </summary>
    public class Bigtable : BigtableReader
    {
        public Bigtable(BigtableCredentials credentials, string project, string zone, string cluster) : this(credentials, new BigtableConfig(project, zone, cluster))
        {

        }
        public Bigtable(BigtableCredentials credentials, BigtableConfig config) : base(credentials, config)
        {
            AdminClient = new Lazy<BigAdminClient>(() => new BigAdminClient(credentials, config));
            DataClient = new Lazy<BigDataClient>(() => new BigDataClient(credentials, config));
        }


        public async Task UpdateAsync<T>(T instance, CancellationToken cancellationToken = default(CancellationToken))
        {
            var cache = ReflectionCache.For<T>();
            var table = LocateTable<T>(cache);
            var key = ExtractKey(cache, instance);
            var changes = ExtractChanges(cache, instance);
            await DataClient.Value.WriteRowAsync(table, key, changes, cancellationToken);
        }

        public async Task<bool> UpdateWhenTrueAsync<T>(T instance, Expression<Func<T, bool>> predicate, Expression<Func<T, object>> whenTrue, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await UpdateWhenAsync(instance, predicate, whenTrue, null, cancellationToken);
        }

        public async Task<bool> UpdateWhenFalseAsync<T>(T instance, Expression<Func<T, bool>> predicate, Expression<Func<T, object>> whenFalse, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await UpdateWhenAsync(instance, predicate, null, whenFalse, cancellationToken);
        }

        public async Task<bool> UpdateWhenAsync<T>(T instance, Expression<Func<T, bool>> predicate, Expression<Func<T, object>> whenTrue = null, Expression<Func<T, object>> whenFalse = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (whenTrue == null && whenFalse == null)
                throw new ArgumentNullException("whenTrue", "Must set whenTrue or whenFalse to perform and UpdateWhen");
            var cache = ReflectionCache.For<T>();
            var table = LocateTable<T>(cache);
            var key = ExtractKey(cache, instance);
            var filter = ExtractFilter(predicate);
            var trueCase = ExtractMutateWhen(whenTrue);
            var falseCase = ExtractMutateWhen(whenFalse);
            return await DataClient.Value.WriteWhenAsync(table, key, filter, trueCase, falseCase, cancellationToken);
        }



        public async Task<IEnumerable<BigRow>>  IncrementFieldAsync<T, TParameter>(T instance, Expression<Func<T, TParameter>> field, long value = 1, CancellationToken cancellationToken = default(CancellationToken))
            where TParameter : IBigTableField
        {
            var cache = ReflectionCache.For<T>();
            var table = LocateTable<T>(cache);
            var key = ExtractKey(cache, instance);
            var rule = CreateIncrementRule(cache, table, field, value);
            return await DataClient.Value.WriteRowAsync(table, key, cancellationToken, new[] { rule  });
        }

        public async Task<IEnumerable<BigRow>> AppendFieldAsync<T, TParameter>(T instance, Expression<Func<T, TParameter>> field, string value, CancellationToken cancellationToken = default(CancellationToken))
            where TParameter : IBigTableField
        {
            var cache = ReflectionCache.For<T>();
            var table = LocateTable<T>(cache);
            var key = ExtractKey(cache, instance);
            var rule = CreateAppendRule(cache, table, field, value);
            return await DataClient.Value.WriteRowAsync(table, key, cancellationToken, new[] { rule });
        }


        public async Task<IEnumerable<BigRow>> AppendFieldAsync<T, TParameter>(T instance, Expression<Func<T, TParameter>> field, byte[] value, CancellationToken cancellationToken = default(CancellationToken))
            where TParameter : IBigTableField
        {
            var cache = ReflectionCache.For<T>();
            var table = LocateTable<T>(cache);
            var key = ExtractKey(cache, instance);
            var rule = CreateAppendRule(cache, table, field, value);
            return await DataClient.Value.WriteRowAsync(table, key, cancellationToken, new[] { rule });
        }



        private BigChange.FromRead CreateIncrementRule<T, TParameter>(ReflectionCache reflection, BigTable table, Expression<Func<T, TParameter>> field, long value)
            where TParameter : IBigTableField
        {
            var columnName = ExtractColumnName(reflection, field);
            var familyName = ExtractFamilyName<T, TParameter>(reflection, field);
            return BigChange.FromRead.CreateCellIncrement(familyName, columnName, value, table.Encoding);
        }

        private BigChange.FromRead CreateAppendRule<T, TParameter>(ReflectionCache reflection, BigTable table, Expression<Func<T, TParameter>> field, string value)
            where TParameter : IBigTableField
        {
            var columnName = ExtractColumnName(reflection, field);
            var familyName = ExtractFamilyName<T, TParameter>(reflection, field);
            return BigChange.FromRead.CreateCellAppend(familyName, columnName, value, table.Encoding);
        }

        private BigChange.FromRead CreateAppendRule<T, TParameter>(ReflectionCache reflection, BigTable table, Expression<Func<T, TParameter>> field, byte[] value)
            where TParameter : IBigTableField
        {
            var columnName = ExtractColumnName(reflection, field);
            var familyName = ExtractFamilyName<T, TParameter>(reflection, field);
            return BigChange.FromRead.CreateCellAppend(familyName, columnName, value, table.Encoding);
        }



        private string ExtractFamilyName<T, TParameter>(ReflectionCache reflection, Expression<Func<T, TParameter>> field)
            where TParameter : IBigTableField
        {
            throw new NotImplementedException();
        }

        private string ExtractColumnName<T, TParameter>(ReflectionCache reflection, Expression<Func<T, TParameter>> field)
        {
            MemberInfo member = GetMemberInfo(field);

            if (!reflection.MemberNameLookup.ContainsKey(member.Name))
                throw new MissingFieldException(typeof (T).Name, member.Name);

            return reflection.MemberNameLookup[member.Name];
        }

        private RowFilter ExtractFilter<T>(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Mutation> ExtractMutateWhen<T>(Expression<Func<T, object>> whenTrue)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private IEnumerable<BigChange> ExtractChanges<T>(ReflectionCache reflection, T instance)
        {
            var result = new List<BigChange>();
            reflection.ExtractChanges(instance, (familyName, fieldName, value) => result.Add(BigChange.CreateCellUpdate(familyName, fieldName, value)));
            return result;
        }

        private static MemberInfo GetMemberInfo<T, TParameter>(Expression<Func<T, TParameter>> lambda)
        {
            MemberExpression expression = lambda.Body as MemberExpression;
            if (expression == null)
            {
                throw new ArgumentException(String.Format("Expression '{0}' refers to a method, not a property or field.", lambda));
            }

            PropertyInfo propInfo = expression.Member as PropertyInfo;
            FieldInfo fieldInfo = expression.Member as FieldInfo;
            bool isProperty = propInfo == null;
            bool isField = fieldInfo == null;
            if (!isProperty && isField)
            {
                throw new ArgumentException(String.Format("Expression '{0}' refers to a field, not a property or field.", lambda));
            }



            //Type type = typeof(TTable);
            //if (type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType) && !propInfo.ReflectedType.IsAssignableFrom(type))
            //{
            //    throw new ArgumentException(string.Format("Expression '{0}' refers to a property that is not from type {1}.", lambda, type));
            //}

            return expression.Member;
        }

    }
}
