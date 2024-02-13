//using Fish_Shop.Data;
//using Fish_Shop.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;
//using System.Net;

//namespace Fish_Shop.Controllers
//{

//    [Route("{controller}")]
//    public class MyData1 : ControllerBase
//    {
//        //ApplicationContext db;
//        //public MyData1Controller(ApplicationContext db2)        {            db = db2;        }

//        [HttpGet]
//        //[Authorize]
//        //public List<User> Get() { return db.Users.ToList(); }
//        public User[] Get()
//        {
//            Fish_ShopContext db = new Fish_ShopContext();
//			//var users = db.Users.ToArray();			
//			User[] users = new User[] 
//            { 
//                new User { Id = "1", Name = "Tom" },
//                new User { Id = "1", Name = "Bob" } 
//            };
//			return users;            
//		}
////----------------------------------------------------------------------------------
//        [HttpGet("{id}")]                   //after slash
//        public User GetById(string idd)     //request param after questionmark ?name=value
//        {
//            /*
//            Person pers = Persons.FirstOrDefault(r => r.id == idd);
//            if (pers == null) 
//            {
//                return this.Conflict();
//            }*/
//            Fish_ShopContext db = new Fish_ShopContext();
//            return db.Users.FirstOrDefault(u => u.Id == idd);
//        }
////----------------------------------------------------------------------------------      
//        [HttpPost]
//        public ActionResult Post(string name)
//        {
//            Fish_ShopContext db = new Fish_ShopContext();
//            if (db.Users.Any(r=>r.Name==name||r.Name==null))
//            {                
//                return this.StatusCode((int)HttpStatusCode.Conflict);
//            }
//            //db.Users.Add(new User(Convert.ToInt32(Guid.NewGuid()), name, 18));
//            User user = new User { Name = name};
//          /*  using ( var transaction = db.Database.BeginTransaction())
//            {
//                db.Users.Add(user);
//                db.SaveChanges();
//                transaction.Commit();
//                //db.Dispose();
//                Console.WriteLine($"Id после добавления в базу данных = {user.Id}");
//                /*try
//                {  
//                    db.Users.Add(user);
//                    db.SaveChanges();
//                    transaction.Commit();
//                    //db.Dispose();
//                    Console.WriteLine($"Id после добавления в базу данных = {user.Id}");
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Ошибка сохранения в базу данных = {ex.Message}");
//                    transaction.Rollback();
//                }
//            }*/
//            //var transaction = db.Database.BeginTransaction();
//                db.Users.Add(user);
//                db.SaveChanges();
//              //  transaction.Commit();                

//            Console.WriteLine($"Id после добавления в базу данных = {user.Id}");                
            
//            return this.Ok();
//        }

//        [HttpPatch]
//        public ActionResult Patch([FromQuery] User persPatch)
//        {
//            Fish_ShopContext db = new Fish_ShopContext();
//            User? user = db.Users.FirstOrDefault(u => u.Id == persPatch.Id);

//            if (user == null)
//            {
//                return this.StatusCode((int)HttpStatusCode.NotFound);
//            }
//            db.Update(user);
//            db.SaveChanges();

//            return this.Ok();
//        }
//        [HttpDelete]
//        public ActionResult Delete(string idd) //([FromQuery] int idd)
//        {
//            Fish_ShopContext db = new Fish_ShopContext();
//            User? user = db.Users.FirstOrDefault(r => r.Id == idd);
//            if (user == null)
//            {
//                return this.StatusCode((int)HttpStatusCode.NotFound);
//            }

//            db.Users.Remove(user);
//            db.SaveChanges();

//            return this.Ok();
//        }
//    }
//}

