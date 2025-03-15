using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain.Entities;

namespace MyCompany.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServiceCategoriesEdit(int id)
        {
            // Depending on the ID, either the record is added or the record is changed
            ServiceCategory? entity = id == default 
                ? new ServiceCategory() 
                : await _dataManager.ServiceCategories.GetServiceCategoryByIdAsync(id);

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesEdit(ServiceCategory entity)
        {
            // There are errors in the model, we return it for revision
            if (!ModelState.IsValid)
                return View(entity);

            await _dataManager.ServiceCategories.SaveServiceCategoryAsync(entity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesDelete(int id)
        {
            await _dataManager.ServiceCategories.DeleteServiceCategoryAsync(id);

            return RedirectToAction("Index");
        }
    }
}
