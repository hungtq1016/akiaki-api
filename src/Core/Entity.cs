using Core.Enums;

namespace Core
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public abstract class AbstractEntity : IEntity
    {
        public Guid Id { get; set; }

        public StatusEnum Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class Response<TEntity>
    {
        public TEntity Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool IsError { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
    public abstract class EntityRequest
    {
        public Guid Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public StatusEnum Status { get; set; }

    }

    public class AbstractFile : AbstractEntity
    {
        public string Title { get; set; }

        public string? Alt { get; set; }

        public long Size { get; set; }

        public string Path { get; set; }

        public string Extension { get; set; }
    }

    public class FileResponse
    {
        public Byte[] FilesBytes { get; set; }
        public string Extension { get; set; }
    }

    public class ExcelResponse : FileResponse
    {
        public string? Name { get; set; }
    }
}
