using Lab04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Services
{
    public interface IRecordService
    {
        List<Record> GetRecordsByUser(long userId);
    }
}
