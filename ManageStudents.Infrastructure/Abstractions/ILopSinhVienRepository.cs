﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Abstractions
{
    public interface ILopSinhVienRepository
    {
        IUnitOfWork UnitOfWork { get; }

    }
}
