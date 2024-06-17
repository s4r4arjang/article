using AtrinCode.Core.Contracts.Services.Articles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AtrinCode.Core.Domain.DTOs.Articles;
using AtrinCode.Core.Domain.PagingModel;
using AtrinCode.Core.Domain.Articles.Entities;
using EndPoint.Web.Admin.ViewModels.Articles;

namespace EndPoint.Web.Admin.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private IWebHostEnvironment Environment;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, 
            IWebHostEnvironment _environment)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            Environment = _environment;
        }

        // GET: ArticleController
        public ActionResult Index(PagingData pagingData)
        {
            var model = _articleService.GetArticlePageList(pagingData);
            return View(model);
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Title");
            return View();
        }


        [HttpPost]
      
        public ActionResult Uploadimage(List<IFormFile> upload)
        {
            var filepath = "";
            foreach (var photo in Request.Form.Files)
            {
                string serverpath =
  Path.Combine(Environment.WebRootPath, "Uploads", photo.FileName);
                using (var stream = new FileStream(serverpath, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
         var d= $"{Request.Scheme}://{Request.Host}";
                filepath = d +
                    "/Uploads/"+photo.FileName;

            }
            return Json(new {url=filepath });
        }
        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateArticleVewModel article)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "مقادیر را به درستی وارد کنید");
                ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Title", article.CategoryId);
                return View(article);
            }
           
            var res = new CreateArticleDTO()
            {
                Title = article.Title,
                CategoryId = article.CategoryId,
                ArticleImage = Guid.NewGuid().ToString() + "." + Path.GetExtension(article.ArticleImageFile.FileName),
                Content = article.Content,
                ShortDescription = article.ShortDescription

            };

            var articleid= _articleService.InsertArticle(res);

             SaveImageFile(article.ArticleImageFile, res.ArticleImage);

            SaveArticleFilesInDataBase(article.ArticleFile , articleid);

            return RedirectToAction(nameof(Index));
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _articleService.GetArticleWithFiles(id);
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Title", model.CategoryId);
            return View(model);
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditArticleDTO article)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "مقادیر را به درستی وارد کنید");
                ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Title", article.CategoryId);
                return View(article);
            }

            var res = new EditArticleDTO()
            {
                Id = article.Id,    
                Title = article.Title,
                CategoryId = article.CategoryId,
                ArticleImage = Guid.NewGuid().ToString() + "." + Path.GetExtension(article.ArticleImageFile.FileName),
                Content = article.Content,
                ShortDescription = article.ShortDescription

            };
            //SaveFiles(article.FileList, article.Title);
            _articleService.EditArticle(res);
            return RedirectToAction(nameof(Index));
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var image=_articleService.GetArticleImage(id);   
            
            DeleteImageFiles(image);
            _articleService.DeleteArticle(id);

            return RedirectToAction(nameof(Index));

            //return Json(new { Status = true, Message = "عملیات با موفقیت انجام شد" });
        }

        public ActionResult ConfirmArticle(int id)
        {
            _articleService.AcceptArticle(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult RejectArticle(int id)
        {
            _articleService.RejectArticle(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult ArticleDetails(int id)
        {
            var model = _articleService.GetArticleDetails(id);
            return View(model);  
        }
        private void SaveImageFile(IFormFile formFile, string Title)
        {
            string FilePath = Path.Combine(Environment.WebRootPath, "ArticleImages");

            if (!Directory.Exists(FilePath))

                Directory.CreateDirectory(FilePath);

            var filePath = Path.Combine(FilePath, Title);



            using (FileStream fs = System.IO.File.Create(filePath))

            {

                formFile.CopyTo(fs);

            }

        }
         public void DeleteImageFiles(string Title)
        {
            if (!string.IsNullOrEmpty(Title))
            {
                string FilePath = Path.Combine(Environment.WebRootPath, "ArticleImages");

                FilePath = Path.Combine(FilePath, Title);
                System.IO.File.Delete(FilePath);
            }
        }

        private void SaveArticleFilesInDataBase(List<IFormFile> files , int articleId)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string FilePath = Path.Combine(Environment.WebRootPath, "Uploads");

                        if (!Directory.Exists(FilePath))

                            Directory.CreateDirectory(FilePath);

                        
                        //string FilePath1 = Path.Combine(FilePath, $"{articleId}");
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);
                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);
                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
                        var filePath = Path.Combine(FilePath, newFileName);

                        //using (Stream fs = file.OpenReadStream())
                        //{
                        //    using (BinaryReader br = new BinaryReader(fs))
                        //    {
                        //        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        //    }
                        //}


                        using (FileStream fs = System.IO.File.Create(filePath))

                        {

                            file.CopyTo(fs);

                        }

                        var objfiles = new FileTable()
                        {
                            
                            Name = newFileName,
                            FileType = fileExtension,
                            CreatedOn = DateTime.Now,
                            Path= filePath,
                            ArticleId=articleId,
                            
                        };

                        using (var target = new MemoryStream())
                        {
                            file.CopyTo(target);
                            //objfiles.DataFiles = target.ToArray();
                            var fileBytes = target.ToArray();
                            //string s = Convert.ToBase64String(fileBytes);
                            objfiles.FileContent = fileBytes;
                        }

                        _articleService.SaveArticleFiles(objfiles); 
                        
                    }
                }
            }
        }



        public FileResult Download(string fileName)
        {
            string path = Path.Combine(Environment.WebRootPath, "Uploads");
            string FullPath = Path.Combine(path, fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(FullPath);
            return File(fileBytes, "application/force-download", Path.GetFileName(FullPath));
        }
    }
}
