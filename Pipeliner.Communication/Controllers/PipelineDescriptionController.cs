using System.Collections.Generic;
using System.Web.Http;
using Pipeliner.Communication.ViewModels;

namespace Pipeliner.Communication.Controllers
{
    public class PipelineDescriptionController : ApiController
    {
        public IEnumerable<PipelineDescriptionViewModel> GetAll()
        {
            return new[]
                       {
                           new PipelineDescriptionViewModel { DisplayName = "Pipeline One", Key = "First" },
                           new PipelineDescriptionViewModel { DisplayName = "Pipeline Two", Key = "Second" }
                       };
        }
    }
}