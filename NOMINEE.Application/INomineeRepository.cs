using NOMINEE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOMINEE.Application
{
    public interface INomineeRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<dynamic> GetByIdAsync(int nomineeId);
        Task<int> AddAsync(Nominee nominee);
        Task<int> UpdateAsync(Nominee nominee);
        Task<int> DeleteAsync(int nomineeId);
    }
}
