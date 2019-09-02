using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilterDemo.Models
{
	/// <summary>
	/// 用户类
	/// </summary>
	public class User
	{
		/// <summary>
		/// 主键
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// 用户属于哪个Role
		/// </summary>
		public int RoleId { get; set; }
	}
}