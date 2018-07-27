using System;

namespace CacheRedis.Controllers.Dto
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Category(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

    }
    
}
