using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.IRepository;
using Auth.IRepository.IIds4;
using Auth.Utility;
using AutoMapper;
using Dapper.Contrib.Plus;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Auth.Repository.Ids4
{
    public class MySqlPersistedGrantStore : RepositoryBase, IMySqlPersistedGrantStore
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public MySqlPersistedGrantStore(IDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Task<IEnumerable<PersistedGrant>></returns>
        public async Task<IEnumerable<PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
        {
            IEnumerable<Entity.Ids4Entity.PersistedGrant> grants = new List<Entity.Ids4Entity.PersistedGrant>();

            using (_dbContext.InitConnection(RW.R))
            {
                List<Condition> conditions = new List<Condition>();

                // ClientId
                if (!string.IsNullOrWhiteSpace(filter.ClientId))
                {
                    conditions.Add(new Condition
                    {
                        Name = nameof(PersistedGrantFilter.ClientId),
                        Value = filter.ClientId,
                        Type = ConditionalType.Equal
                    });
                }

                // SessionId
                if (!string.IsNullOrWhiteSpace(filter.SessionId))
                {
                    conditions.Add(new Condition
                    {
                        Name = nameof(PersistedGrantFilter.SessionId),
                        Value = filter.SessionId,
                        Type = ConditionalType.Equal
                    });
                }

                // SubjectId
                if (!string.IsNullOrWhiteSpace(filter.SubjectId))
                {
                    conditions.Add(new Condition
                    {
                        Name = nameof(PersistedGrantFilter.SubjectId),
                        Value = filter.SubjectId,
                        Type = ConditionalType.Equal
                    });
                }

                grants = await _dbContext.Connection.GetListAsync<Entity.Ids4Entity.PersistedGrant>(conditions);
            }

            return _mapper.Map<IEnumerable<PersistedGrant>>(grants);
        }

        public async Task<PersistedGrant> GetAsync(string key)
        {
            Entity.Ids4Entity.PersistedGrant grant = new Entity.Ids4Entity.PersistedGrant();

            using (_dbContext.InitConnection(RW.R))
            {
                grant = await _dbContext.Connection.GetAsync<Entity.Ids4Entity.PersistedGrant>(key);
            }

            return _mapper.Map<PersistedGrant>(grant);
        }

        public async Task RemoveAllAsync(PersistedGrantFilter filter)
        {
            using (_dbContext.InitConnection(RW.W))
            {
                List<Condition> conditions = new List<Condition>();

                // ClientId
                if (!string.IsNullOrWhiteSpace(filter.ClientId))
                {
                    conditions.Add(new Condition
                    {
                        Name = nameof(PersistedGrantFilter.ClientId),
                        Value = filter.ClientId,
                        Type = ConditionalType.Equal
                    });
                }

                // SessionId
                if (!string.IsNullOrWhiteSpace(filter.SessionId))
                {
                    conditions.Add(new Condition
                    {
                        Name = nameof(PersistedGrantFilter.SessionId),
                        Value = filter.SessionId,
                        Type = ConditionalType.Equal
                    });
                }

                // SubjectId
                if (!string.IsNullOrWhiteSpace(filter.SubjectId))
                {
                    conditions.Add(new Condition
                    {
                        Name = nameof(PersistedGrantFilter.SubjectId),
                        Value = filter.SubjectId,
                        Type = ConditionalType.Equal
                    });
                }

                await _dbContext.Connection.DeleteAnyAsync<Entity.Ids4Entity.PersistedGrant>(conditions);
            }
        }

        public async Task RemoveAsync(string key)
        {
            using (_dbContext.InitConnection(RW.W))
            {
                await _dbContext.Connection.DeleteAsync(new Entity.Ids4Entity.PersistedGrant
                {
                    Key = key
                });
            }
        }

        /// <summary>
        /// 新增PersistedGrant
        /// </summary>
        /// <param name="grant"></param>
        /// <returns></returns>
        public async Task StoreAsync(PersistedGrant grant)
        {
            Entity.Ids4Entity.PersistedGrant grantEntity = _mapper.Map<Entity.Ids4Entity.PersistedGrant>(grant);

            using (_dbContext.InitConnection(RW.W))
            {
                await _dbContext.Connection.InsertAsync(grantEntity);
            }
        }
    }
}
