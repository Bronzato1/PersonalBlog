using System.Collections.Generic;
using PersonalBlog.Models;

public interface IDataRepository 
{
    // CRUD operations

    public List<Mission> GetAllMissions();
    public List<Company> GetAllCompanies();
    public List<Database> GetAllDatabases();
    public List<Language> GetAllLanguages();

    public Mission GetMissionById(int id);

    public void AddMission(Mission mission);

    public void UpdateMission(Mission mission);

    public void UpdateMissionLanguages(int missionId, int[] languageIds);

    public void DeleteMission(Mission mission);

}
