namespace Pandape.CandidatesManager.Infrastructure.Data.Interceptors
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Pandape.CandidatesManager.Infrastructure.DTOs;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Linq;

    public class CandidateSaveChangesInterceptor : SaveChangesInterceptor
    {
        public CandidateSaveChangesInterceptor()
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

            foreach (var entry in context.ChangeTracker.Entries<CandidateDTO>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.InsertDate = DateTime.Now;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                {
                    entry.Entity.ModifyDate = DateTime.Now;
                }
            }
        }
    }
    public static class Extensions
    {
        public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
            entry.References.Any(r =>
                r.TargetEntry != null &&
                r.TargetEntry.Metadata.IsOwned() &&
                (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    }
}
