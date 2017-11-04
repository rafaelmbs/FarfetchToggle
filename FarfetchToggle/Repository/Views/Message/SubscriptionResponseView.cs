using System.Collections.Generic;

namespace FarfetchToggle.Repository.Views.Message
{
    public class SubscriptionResponseView
    {
        public IList<SubscriptionResultView> SubscribeResult { get; set; }
        public IList<ResponseMetadataView> ResponseMetadata { get; set; }
    }
}
