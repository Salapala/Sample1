using HospitalManagementApi.Models;

namespace HospitalManagementApi.Infrastructure

{

    public class LabInfoRepository : ICRUDRepository<LabInfo, string>

    {

        HospitalManagementDbContext _db;

        public LabInfoRepository(HospitalManagementDbContext db)

        {

            _db = db;

        }

        public IEnumerable<LabInfo> GetAll()

        {

            return _db.LabInfos.ToList();

        }

        public LabInfo GetDetails(string id)

        {

            return _db.LabInfos.FirstOrDefault(c=>c.LabInfoId==id);

        }

        public void Create(LabInfo item)

        {

           _db.LabInfos.Add(item);
           _db.SaveChanges();

        }

        public void Delete(string id)

        {
            var obj = _db.LabInfos.FirstOrDefault(c=>c.LabInfoId==id);
             if(obj==null)
                 return;
        _db.LabInfos.Remove(obj);
        _db.SaveChanges();
            
        }

        public void Update(LabInfo item)

        {

            var obj = _db.LabInfos.FirstOrDefault(c=>c.LabInfoId==item.LabInfoId);

            if(obj==null)

                return;
            obj.LabId = item.LabId;
            obj.LabName = item.LabName;
            obj.LabLocation = item.LabLocation;
           
                 _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                 _db.SaveChanges();
        }

    }
} 