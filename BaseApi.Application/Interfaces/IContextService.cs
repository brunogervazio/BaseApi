namespace BaseApi.Application.Interfaces
{
    public interface IContextService
    {
        public Guid? GetCurrentUserUuid();

        public string GetCurrentUserName();

        public string GetCurrentUserEmail();

        public string GetHeaderValue(string headerName);
    }
}
