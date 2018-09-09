using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TeknasyonA.Models;

namespace TeknasyonA.Controllers
{
    public class BaseController : ApiController
    {
        SqlConnection myConnection = new SqlConnection("Data Source=YENEN;Initial Catalog=Teknasyon;Integrated Security=True");
        [System.Web.Http.Route("api/CateGoryDeatil")]
        [System.Web.Http.HttpGet]
        public List<CategoryDeatilModel> getCategoryDetail(int id)
        {
            List<CategoryDeatilModel> list = new List<CategoryDeatilModel>();
            SqlCommand sqlCmd = new SqlCommand("sp_CategoryDetail", myConnection);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@BookShelfId", SqlDbType.Int);
            sqlCmd.Parameters["@BookShelfId"].Value = id;
            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                CategoryDeatilModel model = new CategoryDeatilModel();
                model.CategoryId = Convert.ToInt32(reader.GetValue(0));
                model.CategoryDeatilTitle = (reader.GetValue(1)).ToString();
                model.CategoryExplanation = (reader.GetValue(2)).ToString();
                model.CategoryMp3Path = (reader.GetValue(3)).ToString();
                list.Add(model);
            }
            myConnection.Close();

            return list;
        }
        [System.Web.Http.Route("api/BookShelf")]
        [System.Web.Http.HttpGet]
        public List<BookShelfModel> getBookShelf()
        {
            List<BookShelfModel> list = new List<BookShelfModel>();
            SqlCommand sqlCmd = new SqlCommand("sp_GetBookShelf", myConnection);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            myConnection.Open();
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                BookShelfModel model = new BookShelfModel();
                model.BookShelfID = Convert.ToInt32(reader.GetValue(0));
                model.BookShelfTitle = (reader.GetValue(1)).ToString();
                model.BookShelfImgPath = (reader.GetValue(2)).ToString();
                list.Add(model);
            }
            myConnection.Close();
            return list;
        }
    }
}