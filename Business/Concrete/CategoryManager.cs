using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.BusinessRules;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [SecuredOperation("admin,moderator")]
        public IResult Add(Category category)
        {
            var result = BusinessRules.Run(CheckIfCategoryNameExists(category.CategoryName));
            if(result !=null)
            {
                return result;
            }
            _categoryDal.Add(category);
            return new SuccessResult();
        }
        [SecuredOperation("admin,moderator")]
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new Core.Utilities.Results.SuccessDataResult<List<Category>>(_categoryDal.GetAll().ToList());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new Core.Utilities.Results.SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryID == categoryId));
        }
        [SecuredOperation("admin,moderator")]
        public IResult Update(Category category)
        {
            var result = BusinessRules.Run(CheckIfCategoryNameExists(category.CategoryName));
            if (result != null)
            {
                return result;
            }
            _categoryDal.Update(category);
            return new SuccessResult();
        }
        private IResult CheckIfCategoryNameExists(string categoryName) 
        {
            var result = _categoryDal.GetAll(c => c.CategoryName == categoryName).Any();
            if (result)
                return new ErrorResult();
            return new SuccessResult();
        }
    }
}
