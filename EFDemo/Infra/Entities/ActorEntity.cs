﻿using EFDemo.Infra.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Infra.Entities
{
    public class ActorEntity:PersonBaseEntity
    {
        public virtual ICollection<MovieEntity> Movies { get; set; }
    }
}
