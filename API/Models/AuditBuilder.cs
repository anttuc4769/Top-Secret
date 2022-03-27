using API.Enums;
using Hydra.Enums;
using Hydra.Extensions;

namespace API.Models
{
    public class AuditBuilder
    {
        public AuditBuilder() { }
        /// <summary>
        /// Builds partition object on the fly from enums. Pass enums in with order of (Class/Controller|Method Type|Method Name|Status)
        /// </summary>
        /// <param name="enums">Pass enums in correct order to build keys.</param>
        /// <returns></returns>
        public AuditBuilder(params AuditEnums[] enums)
        {
            BuildPartitions(enums);
        }
        public AuditBuilder(object entity, params AuditEnums[] enums)
        {
            BuildPartitions(enums);
            Entity = entity;
        }
        public string Level { get; set; } = AuditLevels.Info.ToString();

        private string _message;
        public string Message
        {
            get
            {
                if (string.IsNullOrEmpty(_message))
                    _message = $"{EventType.Replace("_", "")} - {Status}";
                return _message;
            }
            set => _message = value;
        }
        public string Main { get; set; }
        public string EventType { get; set; }
        public string Status { get; set; }
        public object[] Partitions { get; set; }
        public object Entity { get; set; }

        private void BuildPartitions(params AuditEnums[] enums)
        {
            var c = 1;
            foreach (var e in enums)
            {
                if (c == 1)
                    Main = e.ToString();
                if (e.ToDescription().Contains("Status"))
                {
                    Status = e.ToString();
                    continue;
                }

                EventType = string.IsNullOrEmpty(EventType) ? e.ToString() : $"{EventType}_{e}";
                c++;
            }

            Partitions = !string.IsNullOrEmpty(Status) ? new object[] { Main, EventType, $"{EventType}_{Status}" } : new object[] { Main, EventType };
        }
    }

}
