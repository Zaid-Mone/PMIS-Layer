using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMIS2.DTO
{
    public class UpdateProjectDTO
    {
        public string ProjectName { get; set; }
        public int  ProjectId{ get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        //public int ProjectMangerId { get; set; }
        public int ProjectTypeId { get; set; }

        public int ClientId { get; set; }
        public int ProjectStatusId { get; set; }


        public decimal ContractAmount { get; set; }


        public IFormFile ContractFile { get; set; }
    }
}
