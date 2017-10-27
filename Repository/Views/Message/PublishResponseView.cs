using System.Collections.Generic;
using FarfetchToggleService.Repository.Views.Message;

namespace FarfetchToggleService.Repository.Views.Message
{
    public class PublishResponseView
    {
        public IList<PublishResultView> PublishResult { get; set; }
        public IList<ResponseMetadataView> ResponseMetadata { get; set; }
    }
}