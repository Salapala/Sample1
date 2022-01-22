 using HospitalManagementApi.Models;

namespace HospitalManagementApi.Infrastructure

{

    public class StaffInfoRepository : ICRUDRepository<StaffInfo, string>

    {

        HospitalManagementContext _db;

        public StaffInfoRepository(HospitalManagementContext db)

        {

            _db = db;

        }

        public IEnumerable<StaffInfo> GetAll()

        {

            return _db.StaffInfos.ToList();

        }

        public StaffInfo GetDetails(string id)

        {

            return _db.StaffInfos.FirstOrDefault(c=>c.StaffInfoId==id);

        }

        public void Create(StaffInfo item)

        {

           _db.StaffInfos.Add(item);
           _db.SaveChanges();

        }

        public void Delete(string id)

        {
            var obj = _db.StaffInfos.FirstOrDefault(c=>c.StaffInfoId==id);
             if(obj==null)
                 return;
        _db.StaffInfos.Remove(obj);
        _db.SaveChanges();
            
        }

        public void Update(StaffInfo item)

        {

            var obj = _db.StaffInfos.FirstOrDefault(c=>c.StaffInfoId==item.StaffInfoId);

            if(obj==null)

                return;
            obj.StaffId = item.StaffId;
            obj.StaffName = item.StaffName;
            obj.StaffAddress = item.StaffAddress;
            obj.StaffGender = item.StaffGender;
            obj.StaffQualification = item.StaffQualification;
            obj.StaffTimings = item.StaffTimings;
            obj.StaffTypeId = item.StaffTypeId;
                 _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                 _db.SaveChanges();
        }

    }
} 