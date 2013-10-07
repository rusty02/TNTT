using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using TNTT.Data.Contracts;
using TNTT.Model;
using TNTT.Web.Models;

namespace TNTT.Web.Controllers
{
    public class DoanController : ApiControllerBase
    {
        // GET: all TNTT member
        public HttpResponseMessage Get()
        {
            try
            {
                var doanList = new List<DoanModel>();
                var list = uow.Doans.GetAll().OrderBy(c => c.Mien.Name);
                foreach (var doan in list)
                {
                    doanList.Add(new DoanModel()
                    {
                        Id = doan.Id,
                        LienDoanId = doan.LienDoanId,
                        MienId = doan.MienId,
                        mienName = GetEnumDescription(uow.Miens.GetById(doan.MienId).Name),
                        Name = doan.Name,
                        StartDate = doan.StartDate,
                        EndDate = doan.EndDate,
                        ChaTuyenUy = doan.ChaTuyenUy,
                        DoanTruong = doan.DoanTruong,
                        PhoNghienHuan = doan.PhoNghienHuan,
                        PhoQuanTri = doan.PhoQuanTri,
                        ThuKy = doan.ThuKy,
                        ThuQuy = doan.ThuQuy,
                        Website = doan.Website,
                        Address = doan.Address,
                        City = doan.City,
                        State = doan.State,
                        Zip = doan.Zip,
                        Status = doan.Status,
                        ParishName = doan.ParishName
                    });
                }
               
                return Request.CreateResponse(HttpStatusCode.OK, doanList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error loading Doan list");
            }
          
        }

        // GET Doan by DoanId
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var doan = uow.Doans.GetById(id);
                if (doan != null)
                {
                    var myDoan = new DoanModel()
                    {
                        Id = doan.Id,
                        LienDoanId = doan.LienDoanId,
                        MienId = doan.MienId,
                        Name = doan.Name,
                        StartDate = doan.StartDate,
                        EndDate = doan.EndDate,
                        ChaTuyenUy = doan.ChaTuyenUy,
                        DoanTruong = doan.DoanTruong,
                        PhoNghienHuan = doan.PhoNghienHuan,
                        PhoQuanTri = doan.PhoQuanTri,
                        ThuKy = doan.ThuKy,
                        ThuQuy = doan.ThuQuy,
                        Website = doan.Website,
                        Address = doan.Address,
                        City = doan.City,
                        State = doan.State,
                        Zip = doan.Zip,
                        Status = doan.Status,
                        ParishName = doan.ParishName
                    };

                    return Request.CreateResponse(HttpStatusCode.OK, myDoan);
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                    
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error loading Doan information");
            }
           
        }


        // GET Doan by MienId
        public HttpResponseMessage GetByMienId(int id, bool flag)
        {
            try
            {
                var doanList = new List<DoanModel>();
                var list = uow.Doans.GetByMienId(id).OrderBy(c => c.Name);
                foreach (var doan in list)
                {
                    doanList.Add(new DoanModel()
                    {
                        Id = doan.Id,
                        LienDoanId = doan.LienDoanId,
                        MienId = doan.MienId,
                        Name = doan.Name,
                        StartDate = doan.StartDate,
                        EndDate = doan.EndDate,
                        ChaTuyenUy = doan.ChaTuyenUy,
                        DoanTruong = doan.DoanTruong,
                        PhoNghienHuan = doan.PhoNghienHuan,
                        PhoQuanTri = doan.PhoQuanTri,
                        ThuKy = doan.ThuKy,
                        ThuQuy = doan.ThuQuy,
                        Website = doan.Website,
                        Address = doan.Address,
                        City = doan.City,
                        State = doan.State,
                        Zip = doan.Zip,
                        Status = doan.Status,
                        ParishName = doan.ParishName
                    });
                }
               
                return Request.CreateResponse(HttpStatusCode.OK, doanList);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error loading Doan information");
            }

        }

        // POST creating a new Doan
        public HttpResponseMessage Post(DoanModel doan)
        {
            try
            {
                var myDoan = new Doan()
                {
                    Id = doan.Id,
                    LienDoanId = doan.LienDoanId,
                    MienId = doan.MienId,
                    Name = doan.Name,
                    StartDate = doan.StartDate,
                    EndDate = doan.EndDate,
                    ChaTuyenUy = doan.ChaTuyenUy,
                    DoanTruong = doan.DoanTruong,
                    PhoNghienHuan = doan.PhoNghienHuan,
                    PhoQuanTri = doan.PhoQuanTri,
                    ThuKy = doan.ThuKy,
                    ThuQuy = doan.ThuQuy,
                    Website = doan.Website,
                    Address = doan.Address,
                    City = doan.City,
                    State = doan.State,
                    Zip = doan.Zip,
                    Status = doan.Status,
                    ParishName = doan.ParishName
                };

                uow.Doans.Add(myDoan);
                uow.Commit();
                var addedDoan = uow.Doans.GetById(doan.Id);
                doan.Id = addedDoan.Id;
                return Request.CreateResponse(HttpStatusCode.Created, doan);

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error adding a new Doan");
            }
       
        }

        // PUT update a Doan
        public HttpResponseMessage Put(DoanModel doan)
        {
            try
            {
                var updateDoan = uow.Doans.GetById(doan.Id);
                updateDoan.Id = doan.Id;
                updateDoan.LienDoanId = doan.LienDoanId;
                updateDoan.MienId = doan.MienId;
                updateDoan.Name = doan.Name;
                updateDoan.StartDate = doan.StartDate;
                updateDoan.EndDate = doan.EndDate;
                updateDoan.ChaTuyenUy = doan.ChaTuyenUy;
                updateDoan.DoanTruong = doan.DoanTruong;
                updateDoan.PhoNghienHuan = doan.PhoNghienHuan;
                updateDoan.PhoQuanTri = doan.PhoQuanTri;
                updateDoan.ThuKy = doan.ThuKy;
                updateDoan.ThuQuy = doan.ThuQuy;
                updateDoan.Website = doan.Website;
                updateDoan.Address = doan.Address;
                updateDoan.City = doan.City;
                updateDoan.State = doan.State;
                updateDoan.Zip = doan.Zip;
                updateDoan.Status = doan.Status;
                updateDoan.ParishName = doan.ParishName;

                uow.Doans.Update(updateDoan);
                uow.Commit();
                return Request.CreateResponse(HttpStatusCode.OK, doan);

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error updating the doan");
            }
        }

        // DELETE api/values/5 
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                uow.Doans.Delete(uow.Doans.GetById(id));
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "Error deleting the Doan");
            }
        }

        //Private methods

        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        private static int GetEnumFromDescription(string description, Type enumType)
        {
            foreach (var field in enumType.GetFields())
            {
                DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute == null)
                    continue;
                if (attribute.Description == description)
                {
                    return (int)field.GetValue(null);
                }
            }
            return 0;
        }
    }
}