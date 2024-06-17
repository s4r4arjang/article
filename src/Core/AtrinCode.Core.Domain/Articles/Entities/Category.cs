using AtrinCode.Core.Domain.DomainServices.Articles;
using AtrinCode.Core.Domain.Exceptions;
using AtrinCode.Framework.Core.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace AtrinCode.Core.Domain.Articles.Entities;

public class Category// : AggregateRoot<int>
{
      public int Id { get; private set; }
    public string Title { get; private set; }
    public bool IsActive { get; private set; }
    public List<Article> Articles { get; private set; }

    private Category()
    {
    }
    public Category(string title, IValidationCategory validationCategory)
    {
        if (validationCategory.ExistTitle(title))
            throw new DuplicateException("عنوان تکراری میباشد");
        Title = title;
        IsActive = true;
    }
    public void Edit(string title, IValidationCategory validationCategory)
    {
        if (validationCategory.ExistTitle(Id, title))
            throw new DuplicateException("عنوان تکراری میباشد");
        Title = title;

    }
    public void Delete(IValidationCategory validationCategory)
    {
        if (validationCategory.NotAllowDelete(Id))
            throw new AccessViolationException("امکان حذف وجود ندارد");
    }

    public void Active()
    {
        IsActive = true;
    }
    public void DeActive()
    {
        IsActive = false;
    }

}

