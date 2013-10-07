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
    public class MemberController : ApiControllerBase
    {
        // GET: all TNTT member
        public HttpResponseMessage Get()
        {
            try
            {
                var contactList = new List<ContactModel>();

                var list = uow.Contacts.GetAll().OrderBy(c => c.FirstName);
                foreach (var person in list)
                {
                    contactList.Add(new ContactModel()
                    {
                        Id = person.Id,
                        Role = (int)person.Role,
                        SaintName = person.SaintName,
                        LastName = person.LastName,
                        MiddleName = person.MiddleName,
                        FirstName = person.FirstName,
                        Email = person.Email,
                        Gender = person.Gender,
                        DateOfBirth = person.DateOfBirth,
                        Address = person.AddressLine,
                        City = person.City,
                        State = person.State,
                        Zip = person.Zip,
                        Phone = person.Phone1,
                        Status = person.Status,
                        MienId = uow.Doans.GetById(person.DoanId).MienId,
                        DoanId = person.DoanId,
                        DoanName = uow.Doans.GetById(person.DoanId).Name
                    });
                }

                return Request.CreateResponse(HttpStatusCode.OK, contactList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error loading TNTT Member list");
            }

        }

        // GET member by Id
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var person = uow.Contacts.GetById(id);
                if (person != null)
                {

                    var member = new ContactModel()
                    {
                        Id = person.Id,
                        Role = (int)person.Role,
                        SaintName = person.SaintName,
                        LastName = person.LastName,
                        MiddleName = person.MiddleName,
                        FirstName = person.FirstName,
                        Email = person.Email,
                        Gender = person.Gender,
                        DateOfBirth = person.DateOfBirth,
                        Address = person.AddressLine,
                        City = person.City,
                        State = person.State,
                        Zip = person.Zip,
                        Phone = person.Phone1,
                        Status = person.Status,
                        MienId= uow.Doans.GetById(person.DoanId).MienId,
                        DoanId = person.DoanId,
                        DoanName = uow.Doans.GetById(person.DoanId).Name
                    };

                    return Request.CreateResponse(HttpStatusCode.OK, member);
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error loading member information");
            }

        }


        // POST api/values 
        public HttpResponseMessage Post(ContactModel person)
        {
            try
            {
                var doan = uow.Doans.GetByName(person.DoanName, person.MienId);
                var member = new Contact()
                {
                    //DoanId = 1,
                    Role = (RoleList)person.Role,
                    DoanId = doan.Id,
                    SaintName = person.SaintName,
                    LastName = person.LastName,
                    MiddleName = person.MiddleName,
                    FirstName = person.FirstName,
                    Email = person.Email,
                    Gender = person.Gender,
                    DateOfBirth = person.DateOfBirth,
                    AddressLine = person.Address,
                    City = person.City,
                    State = person.State,
                    Zip = person.Zip,
                    Phone1 = person.Phone,
                    Status = person.Status,
                    Doan = doan,
                    SaMacDanhSaches = new List<SaMacDanhSach>(),
                    LastUpdate = DateTime.Now,
                };

                member.SaMacDanhSaches.Add(uow.SaMacDanhSachs.GetById(4));

                uow.Contacts.Add(member);
                uow.Commit();
                var addedContact = uow.Contacts.GetById(member.Id);
                person.Id = addedContact.Id;
                return Request.CreateResponse(HttpStatusCode.Created, person);

            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("Violation of UNIQUE KEY"))
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Member already exist or email address has been used");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error adding a new member");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error adding a new member");
            }

        }

        // PUT api/values/5 
        public HttpResponseMessage Put(ContactModel member)
        {
            try
            {
                var updateContact = uow.Contacts.GetById(member.Id);
                // var role = (RoleList) GetEnumFromDescription(member.Role, typeof (RoleList));
                updateContact.Role = (RoleList)member.Role;
                //  db.DoanSet.First(d => d.Id == updateContact.DoanId).MienId = GetEnumFromDescription(member.MienName, typeof(MienList));
                updateContact.DoanId = member.DoanId;
                updateContact.SaintName = member.SaintName;
                updateContact.FirstName = member.FirstName;
                updateContact.MiddleName = member.MiddleName;
                updateContact.LastName = member.LastName;
                updateContact.Email = member.Email;
                updateContact.Gender = member.Gender;
                updateContact.DateOfBirth = member.DateOfBirth;
                updateContact.AddressLine = member.Address;
                updateContact.City = member.City;
                updateContact.State = member.State;
                updateContact.Zip = member.Zip;
                updateContact.Phone1 = member.Phone;
                updateContact.Status = member.Status;
                updateContact.LastUpdate = DateTime.Now;

                uow.Contacts.Update(updateContact);
                uow.Commit();
                member.MienName = GetEnumDescription((MienList)Enum.ToObject(typeof(MienList), uow.Doans.GetById(updateContact.DoanId).MienId));

                return Request.CreateResponse(HttpStatusCode.OK, member);

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error updating the member");
            }
        }

        // DELETE api/values/5 
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                uow.Contacts.Delete(uow.Contacts.GetById(id));
                return Request.CreateResponse(HttpStatusCode.NoContent);

            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.NoContent);
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