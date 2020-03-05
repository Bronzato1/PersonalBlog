using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Models;

public class ResumeRepository : IResumeRepository
{
    private readonly MyDbContext _dbContext;

    public ResumeRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Experience> GetAllExperiences()
    {
        List<Experience> experiences = _dbContext.Experiences
                                        .Include(x => x.Company)
                                        .Include(x => x.Database)
                                        .Include("ExperienceKeywords.Keyword")
                                        .OrderByDescending(x => x.Date)
                                        .ToList();
        return experiences;
    }

    public List<Company> GetAllCompanies()
    {
        List<Company> companies = _dbContext.Companies.ToList();
        return companies;
    }

    public List<Keyword> GetAllKeywords()
    {
        List<Keyword> keywords = _dbContext.Keywords.ToList();
        return keywords;
    }

    public List<PersonalBlog.Models.Database> GetAllDatabases()
    {
        List<Database> databases = _dbContext.Databases.ToList();
        return databases;
    }

    public Experience GetExperienceById(int id)
    {
        return _dbContext.Experiences
                    .Where(x => x.Id == id)
                    .Include(x => x.Company)
                    .Include(x => x.Database)
                    .Include("ExperienceKeywords.Keyword")
                    .FirstOrDefault();
    }

    public void UpdateExperience(Experience experience)
    {
        Experience m = _dbContext.Experiences.Where(x => x.Id == experience.Id).FirstOrDefault();

        if (m != null)
        {
            _dbContext.Update(m);
            _dbContext.SaveChanges();
        }
    }

    public void AddExperience(Experience experience)
    {
        _dbContext.Experiences.Add(experience);
        _dbContext.SaveChanges();
    }

    public void UpdateExperienceKeywords(int experienceId, int[] keywordIds)
    {
        List<ExperienceKeyword> experienceKeywords = _dbContext.ExperienceKeywords.Where(x => x.ExperienceId == experienceId).ToList();

        _dbContext.RemoveRange(experienceKeywords);

        foreach(int keywordId in keywordIds)
        {
            ExperienceKeyword experienceKeyword = new ExperienceKeyword {
                ExperienceId = experienceId,
                KeywordId = keywordId
            };            
            _dbContext.ExperienceKeywords.Add(experienceKeyword);
        }

        _dbContext.SaveChanges();
    }

    public void DeleteExperience(Experience experience)
    {
        _dbContext.Remove(experience);
        _dbContext.SaveChanges();
    }

    public int AddCompany(string name)
    {
        Company company = new Company { Name = name };
        _dbContext.Companies.Add(company);
        _dbContext.SaveChanges();
        return company.Id;
    }

    public int AddDatabase(string name)
    {
        Database database = new Database { Name = name };
        _dbContext.Databases.Add(database);
        _dbContext.SaveChanges();
        return database.Id;
    }

    public int AddKeyword(string name)
    {
        Keyword keyword = new Keyword { Name = name };
        _dbContext.Keywords.Add(keyword);
        _dbContext.SaveChanges();
        return keyword.Id;
    }
}