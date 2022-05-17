using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinistryMines.Models;
using MinistryMines.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace MinistryMines.Controllers
{
    public class UserController : Controller
    {

        private readonly ApplicationContext _context;
        private readonly IHostingEnvironment environment;

        public UserController(ApplicationContext context, IHostingEnvironment environment)
        {
            _context = context;
            this.environment = environment;
        }

        public JsonResult TilteAction()
        {
            var cnt = _context.tbl_Title.ToList();
            return new JsonResult(cnt);
        }

        public JsonResult StateAction()
        {
            var cnt = _context.tbl_State.ToList();
            return new JsonResult(cnt);
        }

        public JsonResult DistrictAction(int id)
        {
            var dt = _context.tbl_District.Where(e => e.State.State_Id == id).ToList();
            return new JsonResult(dt);
        }


        public JsonResult StateAction2()
        {
            var cnt = _context.tbl_State2.ToList();
            return new JsonResult(cnt);
        }

        public JsonResult DistrictAction2(int id)
        {
            var dt = _context.tbl_District2.Where(e => e.State2.S_Id == id).ToList();
            return new JsonResult(dt);
        }


        [HttpGet]
        public IActionResult UserAction(int? id)

        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                var data = _context.tbl_User_Details.Where(x => x.Id == id).FirstOrDefault();
                return View(data);
            }
        }


        [HttpPost]
        public IActionResult UserAction(User_Detail model)
        {
            try
            {
                var datediff = DateTime.UtcNow - model.dob;
                if (18 >= (datediff.Days / 365))
                {
                    TempData["dateinvalid"] = "Age should be above 18";
                    return View(model);
                }
                else
                {
                    var path = environment.WebRootPath;
                    var filePath = "Content/Image/" + model.image.FileName;
                    var fullPath = Path.Combine(path, filePath);
                    UploadFile(model.image, fullPath);
                    var data = new User_Detail()
                    {
                        title = model.title,
                        name = model.name,
                        ImagePath = filePath,
                        email = model.email,
                        gender = model.gender,
                        dob = model.dob,
                        address_1 = model.address_1,
                        district_2 = model.district_2,
                        address_2 = model.address_2,
                        district_1 = model.district_1,
                        state_1 = model.state_1,
                        state_2 = model.state_2,

                    };
                    _context.tbl_User_Details.Add(data);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return View(model);
        }

        public void UploadFile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }

        public IActionResult GetData()
        {
            var data = _context.tbl_User_Details.ToList();
            //return View(data);
            List<State> state = _context.tbl_State.ToList();
            List<Title> titles = _context.tbl_Title.ToList();
            List<State2> state2 = _context.tbl_State2.ToList();
            List<District> district = _context.tbl_District.ToList();
            List<District2> district2s = _context.tbl_District2.ToList();
            List<User_Detail> user_Details = _context.tbl_User_Details.ToList();
            var usedata = (from user in _context.tbl_User_Details
                           join state1 in _context.tbl_State on user.state_1 equals state1.State_Id
                           join state_2 in _context.tbl_State2 on user.state_2 equals state_2.S_Id
                           join dis1 in _context.tbl_District on user.district_1 equals dis1.District_Id
                           join dist2 in _context.tbl_District2 on user.district_2 equals dist2.Dis_Id
                           join tit in _context.tbl_Title on user.district_2 equals tit.Id
                           select new 
                           {
                               tit = tit.TitleName,
                               usereName = user.name,
                               Gender = user.gender,
                               DateOfBirth = user.dob,
                               Address1 = user.address_1,
                               Address2 = user.address_2,
                               state1 = state1.St_Name,
                               state_2 = state_2.State_Name,
                               dis1 = dis1.District_Name,
                               dis2 = dist2.Dis_Name,
                               ImagePath = user.ImagePath,
                               Image = user.image

                           }).ToList();
            return View(usedata.ToList());

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _context.tbl_User_Details.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(User_Detail model)
        {
            try
            {
                var datediff = DateTime.UtcNow - model.dob;
                if (18 >= (datediff.Days / 365))
                {
                    TempData["dateinvalid"] = "Age should be above 18";
                    return View(model);
                }
                else
                {
                    var path = environment.WebRootPath;
                    var filePath = "Content/Image/" + model.image.FileName;
                    var fullPath = Path.Combine(path, filePath);
                    UploadFile(model.image, fullPath);
                    var data = new User_Detail()
                    {
                        title = model.title,
                        name = model.name,
                        ImagePath = filePath,
                        email = model.email,
                        gender = model.gender,
                        dob = model.dob,
                        address_1 = model.address_1,
                        district_2 = model.district_2,
                        address_2 = model.address_2,
                        district_1 = model.district_1,
                        state_1 = model.state_1,
                        state_2 = model.state_2,
                    };
                    _context.tbl_User_Details.Add(data);
                    _context.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return View(model);
        }


        public IActionResult Delete(int id)
        {
            var data = _context.tbl_User_Details.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            List<State> state = _context.tbl_State.ToList();
            List<Title> titles = _context.tbl_Title.ToList();
            List<State2> state2 = _context.tbl_State2.ToList();
            List<District> district = _context.tbl_District.ToList();
            List<District2> district2s = _context.tbl_District2.ToList();
            List<User_Detail> user_Details = _context.tbl_User_Details.ToList();

            //var data = _context.tbl_User_Details.ToList();
            var employeeRecord = from e in state
                                 join d in state2 on e.State_Id equals d.S_Id into table1
                                 from d in table1.ToList()
                                 join i in district on e.State_Id equals i.District_Id into table2
                                 from i in table2.ToList()
                                 join j in district2s on e.State_Id equals j.Dis_Id into table3
                                 from j in table3.ToList()
                                 join k in user_Details on e.State_Id equals k.Id into table4
                                 from k in table4.ToList()
                                 join l in titles on e.State_Id equals l.Id into table5
                                 from l in table5.ToList()
                                 select new ViewDetail
                                 {
                                     district2s = j,
                                     state = e,
                                     state2 = d,
                                     district = i,
                                     titles = l,
                                     user_Detail = k
                                 };
            return View(employeeRecord);
            // return View(data);
        }
    }
}
