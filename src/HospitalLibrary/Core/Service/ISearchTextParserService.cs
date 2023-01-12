namespace HospitalLibrary.Core.Service;

public interface ISearchTextParserService
{
    public List<string> ParseSearchText(string searchText);
}