﻿namespace Core.DTOs
{
    public class HealthRecordRequest : EntityRequest
    {
        public string BirthDay { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BloodPressure { get; set; }
        public int Temperature { get; set; }
        public int HeartBeat { get; set; }
        public string Anamnesis { get; set; }
        public string Diagnosis { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }

    }
}
