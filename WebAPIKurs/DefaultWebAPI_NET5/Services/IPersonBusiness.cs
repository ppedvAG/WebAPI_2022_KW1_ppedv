using System.Collections.Generic;

namespace DefaultWebAPI_NET5.Services
{
    public interface IPersonBusiness
    {
        public List<string> GetPersonList();
    }
}
