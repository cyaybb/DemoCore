using System.Collections.Generic;

namespace StudyApi.Controllers
{
    public class DtoTeacher
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IList<DtoStudent> Students { get; set; }
    }
}