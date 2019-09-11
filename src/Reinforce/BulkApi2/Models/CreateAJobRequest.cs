using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Reinforce.BulkApi2.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class CreateAJobRequest
    {
        public CreateAJobRequest(string @object, OperationEnum? operation)
        {
            Object = @object ?? throw new ArgumentNullException(nameof(@object));
            Operation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public CreateAJobRequest(string @object, OperationEnum? operation, string externalIdFieldName)
        {
            Object = @object ?? throw new ArgumentNullException(nameof(@object));
            Operation = operation ?? throw new ArgumentNullException(nameof(operation));
            ExternalIdFieldName = externalIdFieldName ?? throw new ArgumentNullException(nameof(externalIdFieldName));
        }

        /// <summary>
        /// Optional
        /// The column delimiter used for CSV job data. The default value is COMMA.
        /// </summary>
        public ColumnDelimiterEnum? ColumnDelimiter { get; set; }

        /// <summary>
        /// Optional
        /// The content type for the job. The only valid value (and the default) is CSV.
        /// </summary>
        public ContentTypeEnum? ContentType { get; set; }
        
        /// <summary>
        /// Optional
        /// The external ID field in the object being updated. Only needed for upsert operations.
        /// Field values must also exist in CSV job data. Required for upsert operations.
        /// </summary>
        public string ExternalIdFieldName { get; set; }

        /// <summary>
        /// Optional
        /// The line ending used for CSV job data, marking the end of a data row. The default is LF.
        /// </summary>
        public LineEndingEnum? LineEnding { get; set; }

        /// <summary>
        /// Required
        /// The object type for the data being processed. Use only a single object type per job.
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        /// Required
        /// The processing operation for the job.
        /// </summary>
        public OperationEnum? Operation { get; set; }
    }
}