namespace PayItForward.Common
{
    public interface IConfigurationResolver
    {
        string GetConfigurationSection(string section);
    }
}