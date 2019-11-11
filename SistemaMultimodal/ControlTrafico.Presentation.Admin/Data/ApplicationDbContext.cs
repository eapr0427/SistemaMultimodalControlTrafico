using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ControlTrafico.Application.DTO;

namespace ControlTrafico.Presentation.Admin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ControlTrafico.Application.DTO.EstacionesRootResponseDto> EstacionesRootResponseDto { get; set; }
        public DbSet<ControlTrafico.Application.DTO.EstacionesResponseDTO> EstacionesResponseDTO { get; set; }
    }
}
