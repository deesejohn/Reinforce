namespace Reinforce.BulkApi2.Models
{
    public class JobInfoResponse : JobInfo
    {
        public long? ApexProcessingTime { get; set; }
        public long? ApiActiveProcessingTime { get; set; }
        public int? NumberRecordsFailed { get; set; }
        public int? NumberRecordsProcessed { get; set; }
        public int? Retries { get; set; }
        public long? TotalProcessingTime { get; set; }
    }
}