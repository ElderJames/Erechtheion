using System;
using System.Threading.Tasks;

namespace DNIC.Erechtheion.Core.Domain.Uow
{
	/// <summary>
	/// 工作单元
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// 提交,返回影响的行数
		/// </summary>
		int Commit();
		/// <summary>
		/// 提交,返回影响的行数
		/// </summary>
		Task<int> CommitAsync();
	}
}
