using System.Collections.Generic;

namespace Pipeliner.Business
{
    public interface IInstanceCreator
    {
        PipelineInstance CreateInstance();
    }
}