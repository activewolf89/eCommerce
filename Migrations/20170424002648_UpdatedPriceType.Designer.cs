using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using eCommerce.Models;

namespace eCommerce.Migrations
{
    [DbContext(typeof(eCommerceContext))]
    [Migration("20170424002648_UpdatedPriceType")]
    partial class UpdatedPriceType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ChangeDetector.SkipDetectChanges", "true")
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");
        }
    }
}
