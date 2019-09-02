using FilterDemo.Models;
using System.Collections.Generic;

namespace FilterDemo.DataBase
{
	public class SampleData
	{
		public static List<User> users;
		public static List<Role> roles;
		public static List<RoleWithControllerAction> roleWithControllerAndAction;
		static SampleData()
		{
			// 用户初始化
			users = new List<User> {
				 new User(){ Id = 1, UserName = "sample1", RoleId = 1},
				 new User(){ Id = 2, UserName = "senior1", RoleId = 2},
				 new User(){ Id = 3, UserName = "senior2", RoleId = 2},
				 new User(){ Id = 5, UserName = "junior1", RoleId = 3},
				 new User(){ Id = 6, UserName = "junior2", RoleId = 3},
				 new User(){ Id = 6, UserName = "junior3", RoleId = 3}
			};

			//角色初始化		
			roles = new List<Role>()
			{
				new Role() { Id=1, RoleName="管理员", Description="管理员角色"},
				new Role() { Id=2, RoleName="高级会员", Description="高级会员角色"},
				new Role() { Id=3, RoleName="初级会员", Description="初级会员角色"}
			};

			//初始化角色，控制器，action对应类
			roleWithControllerAndAction = new List<RoleWithControllerAction> {
				new RoleWithControllerAction(){ Id = 1, ControllerName = "AuthFilters", ActionName = "AdminUser", RoleIds ="1"},
			    new RoleWithControllerAction(){ Id = 2, ControllerName = "AuthFilters", ActionName = "SeniorUser",RoleIds ="1,2"},
			    new RoleWithControllerAction(){ Id = 3, ControllerName = "AuthFilters", ActionName = "JuniorUser",RoleIds ="1,2,3"},
			    new RoleWithControllerAction(){ Id = 4, ControllerName = "ActionFilters", ActionName = "Index", RoleIds = "2,3"}

			};

		}
	}
}