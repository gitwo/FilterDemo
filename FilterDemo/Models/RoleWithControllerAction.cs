namespace FilterDemo.Models
{
	/// <summary>
	/// 
	/// </summary>
	public class RoleWithControllerAction
	{
		/// <summary>
		/// 主键
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// 角色Id
		/// </summary>
		public string RoleIds { get; set; }

		/// <summary>
		/// 控制器名称
		/// </summary>
		public string ControllerName { get; set; }

		/// <summary>
		/// Action名称
		/// </summary>
		public string ActionName { get; set; }
	}
}