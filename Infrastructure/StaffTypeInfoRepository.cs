 using HospitalManagementApi.Models;

namespace HosptalManagementApi.Infrastructure

{

    public class StaffTypeInfoRepository : ICRUDRepository<StaffTypeInfo, string>

    {

        HospitalMangementDbContext _db;

        public StaffTypeInfoRepository(HospitalManagementContext db)

        {

            _db = db;

        }

        public IEnumerable<StaffTypeInfo> GetAll()

        {

            return _db.StaffTypeInfos.ToList();

        }

        public StaffTypeInfo GetDetails(string id)

        {

            return _db.StaffTypeInfos.FirstOrDefault(c=>c.StaffTypeInfoId==id);

        }

        public void Create(StaffTypeInfo item)

        {

           _db.StaffTypeInfos.Add(item);
           _db.SaveChanges();

        }

        public void Delete(string id)

        {
            var obj = _db.StaffTypeInfos.FirstOrDefault(c=>c.StaffTypeInfoId==id);
             if(obj==null)
                 return;
        _db.StaffTypeInfos.Remove(obj);
        _db.SaveChanges();
            
        }

        public void Update(Customer item)

        {

            var obj = _db.StaffTypeInfos.FirstOrDefault(c=>c.StaffTypeInfoId==item.StaffTypeInfoId);

            if(obj==null)

                return;
            obj.StaffTypeName = item.StaffTypeName;
            obj.StaffTypeId = item.StaffTypeId;
            obj.StaffTypeDescription = item.StaffTypeDescription;
                 _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                 _db.SaveChanges();
        }

    }
} 