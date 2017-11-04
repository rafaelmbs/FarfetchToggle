using System.Collections.Generic;

namespace FarfetchToggle.Repository.Views.Message
{
    public class PublishResponseView
    {
        public IList<PublishResultView> PublishResult { get; set; }
        public IList<ResponseMetadataView> ResponseMetadata { get; set; }
    }
}
