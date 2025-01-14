﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Blog.DBUtility;//Please add references
namespace Blog.DAL
{
	/// <summary>
	/// 数据访问类:BlogPhotoAlblumDAL
	/// </summary>
	public partial class BlogPhotoAlblumDAL
	{
		public BlogPhotoAlblumDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PaId", "BlogPhotoAlblum"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PaId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BlogPhotoAlblum");
			strSql.Append(" where PaId=@PaId");
			SqlParameter[] parameters = {
					new SqlParameter("@PaId", SqlDbType.Int,4)
			};
			parameters[0].Value = PaId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Blog.Model.BlogPhotoAlblum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BlogPhotoAlblum(");
			strSql.Append("PaAuthor,PaTitle,PaRemark,PaCoverSrc,PaPhotoNum,PaPLNum,PaStatu,PaAddtime,PaIsDel)");
			strSql.Append(" values (");
			strSql.Append("@PaAuthor,@PaTitle,@PaRemark,@PaCoverSrc,@PaPhotoNum,@PaPLNum,@PaStatu,@PaAddtime,@PaIsDel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PaAuthor", SqlDbType.Int,4),
					new SqlParameter("@PaTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@PaRemark", SqlDbType.NVarChar,50),
					new SqlParameter("@PaCoverSrc", SqlDbType.NVarChar,100),
					new SqlParameter("@PaPhotoNum", SqlDbType.Int,4),
					new SqlParameter("@PaPLNum", SqlDbType.Int,4),
					new SqlParameter("@PaStatu", SqlDbType.Int,4),
					new SqlParameter("@PaAddtime", SqlDbType.DateTime),
					new SqlParameter("@PaIsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.PaAuthor;
			parameters[1].Value = model.PaTitle;
			parameters[2].Value = model.PaRemark;
			parameters[3].Value = model.PaCoverSrc;
			parameters[4].Value = model.PaPhotoNum;
			parameters[5].Value = model.PaPLNum;
			parameters[6].Value = model.PaStatu;
			parameters[7].Value = model.PaAddtime;
			parameters[8].Value = model.PaIsDel;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Blog.Model.BlogPhotoAlblum model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BlogPhotoAlblum set ");
			strSql.Append("PaAuthor=@PaAuthor,");
			strSql.Append("PaTitle=@PaTitle,");
			strSql.Append("PaRemark=@PaRemark,");
			strSql.Append("PaCoverSrc=@PaCoverSrc,");
			strSql.Append("PaPhotoNum=@PaPhotoNum,");
			strSql.Append("PaPLNum=@PaPLNum,");
			strSql.Append("PaStatu=@PaStatu,");
			strSql.Append("PaAddtime=@PaAddtime,");
			strSql.Append("PaIsDel=@PaIsDel");
			strSql.Append(" where PaId=@PaId");
			SqlParameter[] parameters = {
					new SqlParameter("@PaAuthor", SqlDbType.Int,4),
					new SqlParameter("@PaTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@PaRemark", SqlDbType.NVarChar,50),
					new SqlParameter("@PaCoverSrc", SqlDbType.NVarChar,100),
					new SqlParameter("@PaPhotoNum", SqlDbType.Int,4),
					new SqlParameter("@PaPLNum", SqlDbType.Int,4),
					new SqlParameter("@PaStatu", SqlDbType.Int,4),
					new SqlParameter("@PaAddtime", SqlDbType.DateTime),
					new SqlParameter("@PaIsDel", SqlDbType.Bit,1),
					new SqlParameter("@PaId", SqlDbType.Int,4)};
			parameters[0].Value = model.PaAuthor;
			parameters[1].Value = model.PaTitle;
			parameters[2].Value = model.PaRemark;
			parameters[3].Value = model.PaCoverSrc;
			parameters[4].Value = model.PaPhotoNum;
			parameters[5].Value = model.PaPLNum;
			parameters[6].Value = model.PaStatu;
			parameters[7].Value = model.PaAddtime;
			parameters[8].Value = model.PaIsDel;
			parameters[9].Value = model.PaId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PaId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BlogPhotoAlblum ");
			strSql.Append(" where PaId=@PaId");
			SqlParameter[] parameters = {
					new SqlParameter("@PaId", SqlDbType.Int,4)
			};
			parameters[0].Value = PaId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string PaIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BlogPhotoAlblum ");
			strSql.Append(" where PaId in ("+PaIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Blog.Model.BlogPhotoAlblum GetModel(int PaId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PaId,PaAuthor,PaTitle,PaRemark,PaCoverSrc,PaPhotoNum,PaPLNum,PaStatu,PaAddtime,PaIsDel from BlogPhotoAlblum ");
			strSql.Append(" where PaId=@PaId");
			SqlParameter[] parameters = {
					new SqlParameter("@PaId", SqlDbType.Int,4)
			};
			parameters[0].Value = PaId;

			Blog.Model.BlogPhotoAlblum model=new Blog.Model.BlogPhotoAlblum();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Blog.Model.BlogPhotoAlblum DataRowToModel(DataRow row)
		{
			Blog.Model.BlogPhotoAlblum model=new Blog.Model.BlogPhotoAlblum();
			if (row != null)
			{
				if(row["PaId"]!=null && row["PaId"].ToString()!="")
				{
					model.PaId=int.Parse(row["PaId"].ToString());
				}
				if(row["PaAuthor"]!=null && row["PaAuthor"].ToString()!="")
				{
					model.PaAuthor=int.Parse(row["PaAuthor"].ToString());
				}
				if(row["PaTitle"]!=null)
				{
					model.PaTitle=row["PaTitle"].ToString();
				}
				if(row["PaRemark"]!=null)
				{
					model.PaRemark=row["PaRemark"].ToString();
				}
				if(row["PaCoverSrc"]!=null)
				{
					model.PaCoverSrc=row["PaCoverSrc"].ToString();
				}
				if(row["PaPhotoNum"]!=null && row["PaPhotoNum"].ToString()!="")
				{
					model.PaPhotoNum=int.Parse(row["PaPhotoNum"].ToString());
				}
				if(row["PaPLNum"]!=null && row["PaPLNum"].ToString()!="")
				{
					model.PaPLNum=int.Parse(row["PaPLNum"].ToString());
				}
				if(row["PaStatu"]!=null && row["PaStatu"].ToString()!="")
				{
					model.PaStatu=int.Parse(row["PaStatu"].ToString());
				}
				if(row["PaAddtime"]!=null && row["PaAddtime"].ToString()!="")
				{
					model.PaAddtime=DateTime.Parse(row["PaAddtime"].ToString());
				}
				if(row["PaIsDel"]!=null && row["PaIsDel"].ToString()!="")
				{
					if((row["PaIsDel"].ToString()=="1")||(row["PaIsDel"].ToString().ToLower()=="true"))
					{
						model.PaIsDel=true;
					}
					else
					{
						model.PaIsDel=false;
					}
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PaId,PaAuthor,PaTitle,PaRemark,PaCoverSrc,PaPhotoNum,PaPLNum,PaStatu,PaAddtime,PaIsDel ");
			strSql.Append(" FROM BlogPhotoAlblum ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" PaId,PaAuthor,PaTitle,PaRemark,PaCoverSrc,PaPhotoNum,PaPLNum,PaStatu,PaAddtime,PaIsDel ");
			strSql.Append(" FROM BlogPhotoAlblum ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BlogPhotoAlblum ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.PaId desc");
			}
			strSql.Append(")AS Row, T.*  from BlogPhotoAlblum T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "BlogPhotoAlblum";
			parameters[1].Value = "PaId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

