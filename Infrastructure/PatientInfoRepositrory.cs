 using HospitalManagementApi.Models;

namespace HospitalManagementApi.Infrastructure

{

    public class PatientInfoRepository : ICRUDRepository<PatientInfo, string>

    {

        HospitalManagementContext _db;

        public PatientInfoRepository(HospitalManagementContext db)

        {

            _db = db;

        }

        public IEnumerable<PatientInfo> GetAll()

        {

            return _db.PatientInfos.ToList();

        }

        public PatientInfo GetDetails(string id)

        {

            return _db.PatientInfos.FirstOrDefault(c=>c.StaffInfoId==id);

        }

        public void Create(PatientInfo item)

        {

           _db.PatientInfos.Add(item);
           _db.SaveChanges();

        }

        public void Delete(string id)

        {
            var obj = _db.PatientInfos.FirstOrDefault(c=>c.StaffInfoId==id);
             if(obj==null)
                 return;
        _db.PatientInfos.Remove(obj);
        _db.SaveChanges();
            
        }

        public void Update(PatientInfo item)

        {

            var obj = _db.PatientInfos.FirstOrDefault(c=>c.PatientInfoId==item.PatientInfoId);

            if(obj==null)

                return;

            obj.PatientName = item.PatientName;
            obj.PatientId = item.PatientId; 
            obj.PatientAddress = item.PatientAddress;
            obj.PatientGender = item.PatientGender;
            obj.PatientAge = item.PatientAge;
            obj.PatientDisease = item.PatientDisease;
            obj.PatientRegistrationDate = item.PatientRegistrationDate;
            obj.PatientDischargeDate = item.PatientDischargeDate;

                 _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                 _db.SaveChanges();
        }

    }
} 