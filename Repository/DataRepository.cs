using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Models;

public class DataRepository : IDataRepository
{
    private readonly MyDbContext _dbContext;

    public DataRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Mission> GetAllMissions()
    {
        List<Mission> missions = _dbContext.Missions
                                        .Include(x => x.Company)
                                        .Include(x => x.Database)
                                        .Include("MissionLanguages.Language")
                                        .OrderByDescending(x => x.Date)
                                        .ToList();
        return missions;
    }

    public List<Company> GetAllCompanies()
    {
        List<Company> companies = _dbContext.Companies.ToList();
        return companies;
    }

    public List<Language> GetAllLanguages()
    {
        List<Language> languages = _dbContext.Languages.ToList();
        return languages;
    }

    public List<PersonalBlog.Models.Database> GetAllDatabases()
    {
        List<Database> databases = _dbContext.Databases.ToList();
        return databases;
    }

    public Mission GetMissionById(int id)
    {
        return _dbContext.Missions
                    .Where(x => x.Id == id)
                    .Include(x => x.Company)
                    .Include(x => x.Database)
                    .Include("MissionLanguages.Language")
                    .FirstOrDefault();
    }

    public void UpdateMission(Mission mission)
    {
        Mission m = _dbContext.Missions.Where(x => x.Id == mission.Id).FirstOrDefault();

        if (m != null)
        {
            _dbContext.Update(m);
            _dbContext.SaveChanges();
        }
    }

    public void AddMission(Mission mission)
    {
        _dbContext.Missions.Add(mission);
        _dbContext.SaveChanges();
    }

    public void UpdateMissionLanguages(int missionId, int[] languageIds)
    {
        List<MissionLanguage> missionLanguages = _dbContext.MissionLanguages.Where(x => x.MissionId == missionId).ToList();

        _dbContext.RemoveRange(missionLanguages);

        foreach(int languageId in languageIds)
        {
            MissionLanguage missionLanguage = new MissionLanguage {
                MissionId = missionId,
                LanguageId = languageId
            };            
            _dbContext.MissionLanguages.Add(missionLanguage);
        }

        _dbContext.SaveChanges();
    }

    public void DeleteMission(Mission mission)
    {
        _dbContext.Remove(mission);
        _dbContext.SaveChanges();
    }
}