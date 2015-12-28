namespace G4.WCF
{
    public interface IWcfLogService
    {
        long LogRequest(string operationName, string callingAddress, string requestMessage);
        void LogResponse(long idMessage, string responseMessage);
    }
}
