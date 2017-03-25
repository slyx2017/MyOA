using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Model;
namespace BLL
{
    /// <summary>
    /// Users
    /// </summary>
    public partial class UsersBLL
    {
        private readonly DAL.UsersDAL dal = new DAL.UsersDAL();
        public UsersBLL()
        { }

        #region  BasicMethod
        /// <summary>
        /// 是否存在此用户名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Exists(string name)
        {
           return dal.Exists(name);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddNewUser(Model.Users model,int roleId)
        {
            return dal.AddNewUser(model,roleId);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        public bool ModifyPwd(Model.Users model)
        {
            return dal.ModifyPwd(model);
        }
        public int EditUser(Model.Users model,int roleId)
        {
            return dal.EditUser(model,roleId);
        }
        /// <summary>
        /// 冻结一条数据
        /// </summary>
        public int FreezeUser(int uId,int state)
        {

            return dal.FreezeUser(uId,state);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteUserByID(int uId,int uIsDel)
        {
            return dal.DeleteUserByID(uId, uIsDel);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Users GetModel(int uId)
        {

            return dal.GetModel(uId);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetUserList(string strWhere)
        {
            return dal.GetUserList(strWhere);
        }
        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <param name="uLoginName">用户名</param>
        /// <param name="uPwd">密码</param>
        /// <returns></returns>
        public DataSet GetUserByLoginName(string uLoginName, string uPwd)
        {
            return dal.GetUserByLoginName(uLoginName, uPwd);
        }
        #endregion  BasicMethod
    }
}

