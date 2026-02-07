using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using MySHop.Data;
using MySHop.Data.Repositories;
using MySHop.Models;

namespace MySHop.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private IGroupRepository _groupRepository;
        public ProductGroupsComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View("/Views/Component/ProductGroupsComponent.cshtml", _groupRepository.GetGroupForShow() );   
        }
    }
}
