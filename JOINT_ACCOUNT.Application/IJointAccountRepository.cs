using JOINT_ACCOUNT.Domain;

namespace JOINT_ACCOUNT.Application
{
    public interface IJointAccountRepository
    {
        Task<IEnumerable<dynamic>> GetAllJointAccountsAsync();
        Task<dynamic> GetJointAccountByIdAsync(int jointAccountId);
        Task<int> AddJointAccountAsync(JointAccount jointAccount);
        Task<int> UpdateJointAccountAsync(JointAccount jointAccount);
        Task<int> DeleteJointAccountAsync(int jointAccountId);
    }
}
