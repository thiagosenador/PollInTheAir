namespace PollInTheAir.Domain.Service.Impl
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Repository;

    public class NoteService : INoteService
    {
        private readonly ICatalog catalog;

        public NoteService(ICatalog catalog)
        {
            this.catalog = catalog;
        }
    }
}