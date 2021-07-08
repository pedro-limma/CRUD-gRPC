using System.Threading.Tasks;
using Grpc.Core;
using GRPCCRUD.GrpcService1;
using System.Linq;

namespace GrpcCRUD.Services
{
    public class EquipamentCRUDService : EquipamentCRUD.EquipamentCRUDBase
    {
        private DataAccess.AppDbContext _db = null;
        public EquipamentCRUDService(DataAccess.AppDbContext db) {
            this._db = db;
        }


        public override Task<Equipaments> SelectAll(Empty requestData, ServerCallContext context) {
            Equipaments responseData = new Equipaments();
            var query = from emp in _db.Equipaments 
                        select new Equipament(){
                            EquipamentID = emp.EquipamentID,
                            Name = emp.Name,
                            Type = emp.Type
                        };
            responseData.Items.AddRange(query.ToArray());
            return Task.FromResult(responseData);
        }

        public override Task<Equipament> SelectByID(EquipamentFilter requestData, ServerCallContext context) {
            var data = _db.Equipaments.Find(requestData.EquipamentID);

            Equipament emp = new Equipament(){
                EquipamentID = data.EquipamentID,
                Name = data.Name,
                Type = data.Type
            };

            return Task.FromResult(emp);
        }

        public override Task<Empty> Insert (Equipament requestData, ServerCallContext context) {
            _db.Equipaments.Add(new DataAccess.Equipament(){
                EquipamentID = requestData.EquipamentID,
                Name = requestData.Name,
                Type = requestData.Type
            });
            _db.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> Update (Equipament requestData, ServerCallContext context) {
            _db.Equipaments.Update(new DataAccess.Equipament(){
                EquipamentID =  requestData.EquipamentID,
                Name = requestData.Name,
                Type = requestData.Type
            });
            _db.SaveChanges();

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> Delete(EquipamentFilter requestData, ServerCallContext context){
            var data = _db.Equipaments.Find(requestData.EquipamentID);

            _db.Equipaments.Remove(new DataAccess.Equipament(){
                EquipamentID = data.EquipamentID,
                Name = data.Name,
                Type = data.Type
            });

            _db.SaveChanges();
            return Task.FromResult(new Empty());
        }
    }
}