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
using TNTT.Web.Controllers;
using TNTT.Web.Models;

namespace TNTT.Web.Models
{
    public class ModelFactory : ApiControllerBase
    {

        private ITNTTUow _uow;

        public ModelFactory(ITNTTUow uow)
        {
            _uow = uow;
        }

        public ContactModel Create(Contact person)
        {
            return new ContactModel()
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
                MienName = GetEnumDescription((MienList)Enum.ToObject(typeof(MienList), uow.Doans.GetById(person.DoanId).MienId)),
                DoanId = person.DoanId,
                DoanName = uow.Doans.GetById(person.DoanId).Name
            };
        }

        public Contact Parse(ContactModel person)
        {
            
            var doan = uow.Doans.GetByName(person.DoanName, GetEnumFromDescription(person.MienName, typeof(MienList)));

            var contact = new Contact();

            contact.Role = (RoleList) person.Role;
            contact.DoanId = doan.Id;
            contact.SaintName = person.SaintName;
            contact.LastName = person.LastName;
            contact.MiddleName = person.MiddleName;
            contact.FirstName = person.FirstName;
            contact.Email = person.Email;
            contact.Gender = person.Gender;
            contact.DateOfBirth = person.DateOfBirth;
            contact.AddressLine = person.Address;
            contact.City = person.City;
            contact.State = person.State;
            contact.Zip = person.Zip;
            contact.Phone1 = person.Phone;
            contact.Status = person.Status;
            contact.Doan = doan;
            contact.SaMacDanhSaches = new List<SaMacDanhSach>();
            contact.LastUpdate = DateTime.Now;

            contact.SaMacDanhSaches.Add(uow.SaMacDanhSachs.GetById(4));
            return contact;
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