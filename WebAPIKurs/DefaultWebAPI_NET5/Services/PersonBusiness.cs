using System.Collections.Generic;

namespace DefaultWebAPI_NET5.Services
{
    public class PersonBusiness : IPersonBusiness
    {
        public List<string> GetPersonList()
        {
            List<string> personList = new List<string>();
            personList.Add("Code Maze");
            personList.Add("Kevin Winter");
            return personList;
        }
    }
}
