using System.Collections.Generic;
using PersonalBlog.Models;

public interface IResumeRepository 
{
    // CRUD operations

    public List<Experience> GetAllExperiences();

    public List<Company> GetAllCompanies();

    public List<Database> GetAllDatabases();

    public List<Tag> GetAllTags();

    public Experience GetExperienceById(int id);

    public void AddExperience(Experience experience);

    public void UpdateExperience(Experience experience);

    public void UpdateExperienceTags(int experienceId, int[] tagIds);

    public void DeleteExperience(Experience experience);

    public int AddCompany(string name);

    public int AddDatabase(string name);

    public int AddTag(string name);
}
