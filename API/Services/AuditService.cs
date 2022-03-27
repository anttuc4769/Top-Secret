using API.Models;

namespace API.Services
{
    public interface IAuditor<T>
    {
        /// <summary>
        /// V2 Auditor - takes in AuditBuilder with enum format (Class/Controller|Method Type|Method Name|Status) & normal partition keys.
        /// </summary>
        /// <param name="auditBuilder">Builds most the audit record along with dynamic partitions.</param>
        /// <param name="partitionObjs">Pass in partition object like V1 function</param>
        /// <returns></returns>
        void Audit(AuditBuilder auditBuilder, params object[] partitionObjs);
    }

    public class AzureAuditor<T> : IAuditor<T> 
    {
        public void Audit(AuditBuilder auditBuilder, params object[] partitionObjs)
        {
            //Do nothing for this :) Normally would log to azure storage
        }
    }
}
