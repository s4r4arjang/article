using AtrinCode.Core.Contracts.Services.Articles;
using Microsoft.AspNetCore.Mvc;
using AtrinCode.Core.Domain.DTOs.Articles;
using AtrinCode.Core.Domain.PagingModel;

namespace EndPoint.Web.Admin.Controllers
{


    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: ArticleCategoryController
        public ActionResult Index(PagingData pagingData)
        {

        //    PagingData PagingData = new PagingData
        //    {
        //        CurrentPage = CurrentPage,
        //    PageSize = PageSize,
        //};

            var model = _categoryService.GetCategoryPageList(pagingData);
            //var total = _categoryService.GetAll().Count();

            //pagingResult.Paging.TotalItem = total;
            //pagingResult.Result = model;
            //d.PageCount = 5;
            return View(model);
            
        }

        // GET: ArticleCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleCategoryController/Create
        [HttpPost]
    
        public ActionResult Create(CreateCategoryDTO category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "مقادیر را به درستی وارد کنید");
                return View(category);
            }

            _categoryService.InsertCategory(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: ArticleCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _categoryService.GetCategory(id);
            return View(model);
        }

        // POST: ArticleCategoryController/Edit/5
        [HttpPost]
     
        public ActionResult Edit( EditCategoryDTO category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "مقادیر را به درستی وارد کنید");
                return View(category);
            }
            _categoryService.EditCategory(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        
        public ActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
            //return Json(new { success = true, Message = "عملیات با موفقیت انجام شد" });
        }

        [HttpPost]
        public ActionResult ActiveCategory (int id )
        {
           _categoryService.ActiveCategory(id);
            
           return  RedirectToAction(nameof(Index));    
        }
        [HttpPost]
        public ActionResult DeActiveCategory(int id)
        {
            _categoryService.DeActiveCategory(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
