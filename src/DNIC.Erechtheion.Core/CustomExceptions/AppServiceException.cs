using System;

namespace DNIC.Erechtheion.Core.CustomExceptions
{
	/// <summary>
	/// 应用程序服务层异常基类
	/// </summary>
	[Serializable]
	public class AppServiceException : ErechtheionException
	{
		/// <summary>
		/// 无参构造器
		/// </summary>
		public AppServiceException() { }

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="message">异常消息</param>
		public AppServiceException(string message) : base(message) { }
	}
}
