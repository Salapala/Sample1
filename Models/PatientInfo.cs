 namespace HospitalManagementApi.Mosels;
{
    public class PatientInfo
    {
        public string PatientName{get;set;}
        public int PatientId{get;set;}
        public string PatientAddress{get;set;}
        public string PatientGender{get;set;}
        public int PatientAge{get;set;}
        public string PatientDisease{get;set;}
        public datetime PatientRegistrationDate{get;set;}
        public datetime PatientDischargeDate{get;set;}


    }
}  