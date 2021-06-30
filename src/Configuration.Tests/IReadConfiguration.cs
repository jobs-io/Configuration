namespace Configuration.Tests
{
    public interface IReadConfiguration
    {
        string GetSource();
        Jobs GetJobs();
    }
}