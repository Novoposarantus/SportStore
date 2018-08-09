﻿using System.Collections.Generic;

namespace Domain.Entities {
    public class Permission {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
