using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace KST.ABP.Organizations.Dto
{
    public class PagedAndFilteredResultRequest : PagedResultRequestDto, IPagedResultRequest
    {

        public string Filter { get; set; }

        public PagedAndFilteredResultRequest()
        {

        }
    }
}
