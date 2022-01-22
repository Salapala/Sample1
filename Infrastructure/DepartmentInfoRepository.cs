 using HospitalManagementApi.Models;

namespace HospitalManagementApi.Infrastructure

{

    public class DepartmentInfoRepository : ICRUDRepository<DepartmentInfo, string>

    {

        HospitalManagementContext _db;

        public DepartmentInfoRepository(HospitalManagementContext db)

        {

            _db = db;

        }

        public IEnumerable<DepartmentInfo> GetAll()

        {

            return _db.DepartmentInfos.ToList();

        }

        public DepartmentInfo GetDetails(string id)

        {

            return _db.DepartmentInfos.FirstOrDefault(c=>c.DepartmentInfoId==id);

        }

        public void Create(DepartmentInfo item)

        {

           _db.DepartmentInfos.Add(item);
           _db.SaveChanges();

        }

        public void Delete(string id)

        {
            var obj = _db.DepartmentInfos.FirstOrDefault(c=>c.DepartmentInfoId==id);
             if(obj==null)
                 return;
        _db.DepartmentInfos.Remove(obj);
        _db.SaveChanges();
           
        }

        public void Update(DepartmentInfo item)

        {

            var obj = _db.DepartmentInfos.FirstOrDefault(c=>c.DepartmentInfoId==item.DepartmentInfoId);

            if(obj==null)

                return;
            obj.DepartmentId = item.DepartmentId;
            obj.DepartmentName = item.DepartmentName;
            obj.DepartmentAddress = item.DepartmentAddress;
             _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
             _db.SaveChanges();
        }
    }
}
 