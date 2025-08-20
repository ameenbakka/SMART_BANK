using BRANCHES.Domain;

namespace BRANCHES.Application
{
    public interface IBranchesRepository
    {
        Task<IEnumerable<dynamic>> GetAllBranchesAsync();
        Task<dynamic> GetByBranchIdAsync(int BranchId);
        Task<int> AddBranchAsync(Branch branch);
        Task<int> UpdateBranchAsync(Branch branch);
        Task<int> DeleteBranchesAsync(int BranchId);
    }
}
