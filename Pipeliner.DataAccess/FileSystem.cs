using System.IO;

namespace Pipeliner.DataAccess
{
    public class FileSystem : IFileSystem
    {
        public Stream GetReadonlyFileStream(string fileName)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IFileSystem
    {
        Stream GetReadonlyFileStream(string fileName);
    }
}