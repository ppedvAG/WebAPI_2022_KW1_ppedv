using AutoFacImplementationWeb.Interface;

using System.Collections.Generic;

namespace AutoFacImplementationWeb.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {
        public List<string> GetPersonList()
        {
            List<string> personList = new List<string>();
            personList.Add("ppedv AG");
            personList.Add("Kevin Winter");
            return personList;
        }
    }
}
