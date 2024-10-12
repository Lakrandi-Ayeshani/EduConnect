using EduConnect.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EduConnect.Services
{
    public class TeachersService
    {
        private readonly IMongoCollection<Teacher> _teachersCollection;

        public TeachersService(
            IOptions<TeachersDatabaseSettings> teachersDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                teachersDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                teachersDatabaseSettings.Value.DatabaseName);

            _teachersCollection = mongoDatabase.GetCollection<Teacher>(
                teachersDatabaseSettings.Value.TeachersCollectionName);
        }

        public async Task<List<Teacher>> GetAsync() =>
            await _teachersCollection.Find(_ => true).ToListAsync();

        public async Task<Teacher?> GetAsync(string id) =>
            await _teachersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Teacher newTeacher) =>
            await _teachersCollection.InsertOneAsync(newTeacher);

        public async Task UpdateAsync(string id, Teacher updatedTeacher) =>
            await _teachersCollection.ReplaceOneAsync(x => x.Id == id, updatedTeacher);

        public async Task RemoveAsync(string id) =>
            await _teachersCollection.DeleteOneAsync(x => x.Id == id);

    }
}



/*using EduConnect.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EduConnect.Services
{
    public class TeachersService
    {
        private readonly IMongoCollection<Teacher> _teachersCollection;

        public TeachersService(
            IOptions<TeachersDatabaseSettings> teachersDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                teachersDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                teachersDatabaseSettings.Value.DatabaseName);

            _teachersCollection = mongoDatabase.GetCollection<Teacher>(
                teachersDatabaseSettings.Value.TeachersCollectionName);
        }

        public async Task<List<Teacher>> GetAsync() =>
            await _teachersCollection.Find(_ => true).ToListAsync();

        public async Task<Teacher?> GetAsync(string id) =>
            await _teachersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Teacher newTeacher) =>
            await _teachersCollection.InsertOneAsync(newTeacher);

        public async Task UpdateAsync(string id, Teacher updatedTeacher) =>
            await _teachersCollection.ReplaceOneAsync(x => x.Id == id, updatedTeacher);

        public async Task RemoveAsync(string id) =>
            await _teachersCollection.DeleteOneAsync(x => x.Id == id);

    }
}
*/
