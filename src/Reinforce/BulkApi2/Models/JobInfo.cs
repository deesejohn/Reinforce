using System;

namespace Reinforce.BulkApi2.Models
{
    public class JobInfo
    {
        public string ApiVersion { get; set; }
        public ColumnDelimiterEnum? ColumnDelimiter { get; set; }
        public ConcurrencyModeEnum? ConcurrencyMode { get; set; }
        public ContentTypeEnum? ContentType { get; set; }
        public Uri ContentUrl { get; set; }
        public string CreatedById { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string ExternalIdFieldName { get; set; }
        public string Id { get; set; }
        public JobTypeEnum? JobType { get; set; }
        public LineEndingEnum? LineEnding { get; set; }
        public string Object { get; set; }
        public OperationEnum? Operation { get; set; }
        public JobStateEnum? State { get; set; }
        public DateTimeOffset SystemModstamp { get; set; }
    }
}