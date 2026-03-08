using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Entities.Abstract;
using MultiShop.Catalog.Exceptions;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BaseMongoService
{
    public class GenericMongoService<TEntity, TCreateDto, TUpdateDto, TResultDto, TGetByIdDto>
        : IGenericMongoService<TEntity, TCreateDto, TUpdateDto, TResultDto, TGetByIdDto>
        where TEntity : Base
    {
        protected readonly IMongoCollection<TEntity> _collection;
        protected readonly IMapper _mapper;
        private static readonly string ResourceName = typeof(TEntity).Name;

        public GenericMongoService(IMapper mapper, IDatabaseSettings databaseSettings, string collectionName)
        {
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<TEntity>(collectionName);
        }

        public async Task CreateAsync(TCreateDto createDto)
        {
            var value = _mapper.Map<TEntity>(createDto);
            await _collection.InsertOneAsync(value);
        }

        public async Task DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            if (result.DeletedCount == 0)
                throw new NotFoundException(ResourceName, id);
        }

        public async Task<TGetByIdDto> GetByIdAsync(string id)
        {
            var value = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (value == null)
                throw new NotFoundException(ResourceName, id);
            return _mapper.Map<TGetByIdDto>(value);
        }

        public async Task<List<TResultDto>> GetAllAsync()
        {
            var values = await _collection.Find(x => true).ToListAsync();
            return _mapper.Map<List<TResultDto>>(values);
        }

        public async Task UpdateAsync(TUpdateDto updateDto)
        {
            var value = _mapper.Map<TEntity>(updateDto);
            var old = await _collection.FindOneAndReplaceAsync(x => x.Id == value.Id, value);
            if (old == null)
                throw new NotFoundException(ResourceName, value.Id);
        }




    }
}