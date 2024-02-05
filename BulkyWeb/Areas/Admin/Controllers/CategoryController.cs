//using Bulky.DataAccess.Data;
//using Bulky.DataAccess.Repository.IRepository;
//using BulkyWeb.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace BulkyWeb.Controllers
//{
//    public class CategoryController : Controller
//    {
//        private readonly ICategoryRepository _categoryRepo;

//        public CategoryController(ICategoryRepository db)
//        {
//            _categoryRepo = db;
//        }

//        public IActionResult Index()
//        {
//            //var objCategoryList = _db.Categories.ToList();
//            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
//            return View(objCategoryList);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(Category obj)
//        {
//            if (ModelState.IsValid)
//            {
//                _categoryRepo.Add(obj);
//                _categoryRepo.Save();
//                TempData["success"] = "Category Added Successfully";
//                return RedirectToAction("Index");
//            }
//            return View();
//        }

//        public IActionResult Edit(int? id)
//        {
//            if (id == null || id == 0)
//            {
//                return NotFound();
//            }
//            var category = _categoryRepo.Get(u => u.Id == id);
//            if (category == null)
//            {
//                return NotFound();
//            }
//            return View(category);
//        }

//        [HttpPost]
//        public IActionResult Edit(Category obj)
//        {
//            if (ModelState.IsValid)
//            {
//                _categoryRepo.Update(obj);
//                _categoryRepo.Save();
//                TempData["success"] = "Category Updated Successfully";

//                return RedirectToAction("Index");
//            }
//            return View();
//        }

//        public IActionResult Delete(int? id)
//        {
//            if (id == null || id == 0)
//            {
//                return NotFound();
//            }
//            var category = _categoryRepo.Get(u => u.Id == id); ;
//            if (category == null)
//            {
//                return NotFound();
//            }
//            return View(category);
//        }

//        [HttpPost, ActionName("Delete")]
//        public IActionResult DeletePOST(int? id)
//        {
//            var category = _categoryRepo.Get(u => u.Id == id); ;
//            if (category == null)
//            {
//                return NotFound();
//            }
//            _categoryRepo.Remove(category);
//            _categoryRepo.Save();
//            TempData["success"] = "Category Deleted Successfully";

//            return RedirectToAction("Index");
//        }
//    }
//}

using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //var objCategoryList = _db.Categories.ToList();
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Added Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Successfully";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.Get(u => u.Id == id); ;
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var category = _unitOfWork.Category.Get(u => u.Id == id); ;
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully";

            return RedirectToAction("Index");
        }
    }
}