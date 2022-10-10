namespace Pandape.CandidatesManager.Infrastructure.Data.Interceptors
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Pandape.CandidatesManager.Infrastructure.DTOs;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CandidateExperienceSaveChangesInterceptor : SaveChangesInterceptor
    {
        public CandidateExperienceSaveChangesInterceptor()
        {

        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            SetDates(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            SetDates(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void SetDates(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<CandidateExperienceDTO>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.InsertDate = DateTime.Now;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifyDate = DateTime.Now;
                }
            }
        }
    }
}
