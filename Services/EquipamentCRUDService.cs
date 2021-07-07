using DataAccess = GrpcCRUD.DataAccess;

namespace GrpcCRUD.Services
{
    public class EquipamentCRUDService : EquipamentCRUD.EquipamentCRUDBase
    {
        private DataAccess.AppDbContext _db = null;
        public EquipamentCRUDService(DataAccess.AppDbContext db) {
            this._db = db;
        }
    }
}