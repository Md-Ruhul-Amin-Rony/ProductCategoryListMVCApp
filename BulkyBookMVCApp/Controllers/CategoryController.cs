using BulkyBookMVCApp.Data;
using BulkyBookMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace BulkyBookMVCApp.Controllers
{
    public class CategoryController : Controller
    {

        //this is dependency injection through which we create an instance of ApplicationDbContext to access database.
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            //var objCategoryList = _db.Categories.ToList();  
            //Instead of the line above we can write the line below- list and IEnumerable almost same and strongly typebut advanced
            //IEnumerable use korle last e ToList use korte hoi na
            
            IEnumerable<Category> objCategoryList= _db.Categories;
            return View(objCategoryList);
        }

        //GET

        public IActionResult Create()
        {
           
            return View();
        }
        //We will create a view for create action method and so rightclick on Create
        //so now after creating "create " button now we have to make another action method to 'post' this 
        // action to create a category.so when user will press create button it will create a category-see bleow

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //this one help and prevent the cross site request forgery attack

        public IActionResult Create(Category obj) // inside the parameters we will be receiving a category object and this will be post action method.
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {

            _db.Categories.Add(obj);    
            _db.SaveChanges();
                TempData["success"] = "Category created successfully";// this Tempdata we have to declare on Index.cshtml
            return RedirectToAction("Index");    
            }
            return View(obj);
            // return View();    
            // if the return is View then it will take us back to the same category view but we want to go to index so that we can see the new category that was created so rather that return view,
            //we want to redirect to an action which is Index action

            // now for validation we can use ModelState.Isvalid and this serverside validation and 
            // on view (create.cshtml) also we did a span for validation which is 
            // <span asp-validation-for="DisplayOrder" class="text-danger"></span>

            //now we will do clientside validation and for this we will use "PartialView"
        }


        //GET

        public IActionResult Edit(int? id)
        {
            if (id==null||id==0)
            {
                return NotFound();

            }
            var categoryFromDb = _db.Categories.Find(id);
            // var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=> u.Id == id);   // we can use these method also 
            // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb== null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //We will create a view for create action method and so rightclick on Create
        //so now after creating "create " button now we have to make another action method to 'post' this 
        // action to create a category.so when user will press create button it will create a category-see bleow

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //this one help and prevent the cross site request forgery attack

        public IActionResult Edit(Category obj) // inside the parameters we will be receiving a category object and this will be post action method.
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {

                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
            // return View();    
            // if the return is View then it will take us back to the same category view but we want to go to index so that we can see the new category that was created so rather that return view,
            //we want to redirect to an action which is Index action

            // now for validation we can use ModelState.Isvalid and this serverside validation and 
            // on view (create.cshtml) also we did a span for validation which is 
            // <span asp-validation-for="DisplayOrder" class="text-danger"></span>

            //now we will do clientside validation and for this we will use "PartialView"
        }
        //GET

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var categoryFromDb = _db.Categories.Find(id);
            // var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=> u.Id == id);   // we can use these method also 
            // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //We will create a view for create action method and so rightclick on Create
        //so now after creating "create " button now we have to make another action method to 'post' this 
        // action to create a category.so when user will press create button it will create a category-see bleow

        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken] //this one help and prevent the cross site request forgery attack

        public IActionResult DeletePost(int? id) // inside the parameters we will be receiving a category object and this will be post action method.
        {
            var obj =_db.Categories.Find(id);
            if (obj == null) 
            {
                return NotFound();
            }
            
           
            

                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
           
            
        }
    }
}
