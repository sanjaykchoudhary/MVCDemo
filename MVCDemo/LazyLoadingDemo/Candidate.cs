using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoadingDemo
{
    public class EducationProfile
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public DateTime PassingYear { get; set; }
    }
    public class Candidate
    {
        public string Name { get; set; }
        public int EducationProfileId { get; set; }
        public List<EducationProfile> GetAllEducationProfile()
        {
            return profileList.Value;
        }

        private Lazy<List<EducationProfile>> profileList;

        public Candidate(int Id, string name)
        {
            //Initializing candidate object.
            Name = name;
            EducationProfileId = Id;
            profileList = new Lazy<List<EducationProfile>>(() => { return GetEducationProfileList(Id); });
            //Initialization done.
        }

        private List<EducationProfile> GetEducationProfileList(int Id)
        {
            //Loading Education Profiles.
            List<EducationProfile> educationProfileList = new List<EducationProfile>();
            Parallel.For(100, 110, (int i) =>
              {
                  EducationProfile profile = new EducationProfile();
                  profile.Id = i;
                  profile.Degree = "Degree " + i;
                  educationProfileList.Add(profile);
              });
            return educationProfileList;
        }
    }

}
