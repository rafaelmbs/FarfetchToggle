using System.Collections.Generic;

namespace FarfetchToggleService.Repository.Views.Message
{
    public class SubscribeResponseView
    {
         public IList<SubscribeResultView> SubscribeResult { get; set; }
         public IList<ResponseMetadataView> ResponseMetadata { get; set; }
    }
}